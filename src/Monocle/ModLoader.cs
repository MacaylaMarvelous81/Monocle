using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using Find_You;

namespace Monocle
{
	internal class ModLoader
	{
		public IImmutableList<Mod> Mods { get; private set; }

		internal ModLoader()
		{
			if (!Directory.Exists($"{ Game1.dataPath }\\Monocle"))
			{
				Directory.CreateDirectory($"{ Game1.dataPath }\\Monocle");
			}
			
			if (!Directory.Exists($"{ Game1.dataPath }\\Monocle\\Mods"))
			{
				Directory.CreateDirectory($"{ Game1.dataPath }\\Monocle\\Mods");
			}
			
			LoadMods();
		}

		private void LoadMods()
		{
			ImmutableList<Mod>.Builder builder = ImmutableList.CreateBuilder<Mod>();
			
			foreach (string file in Directory.GetFiles($"{ Game1.dataPath }\\Monocle\\Mods"))
			{
				if (!file.EndsWith(".dll")) continue;
				
				Assembly assembly = Assembly.LoadFile(file);
				
				IEnumerable<Type> modTypes = from type in assembly.GetTypes()
					where type.IsSubclassOf(typeof(Mod))
					select type;

				foreach (Type modType in modTypes)
				{
					dynamic dynMod = Activator.CreateInstance(modType);

					if (dynMod is not Mod mod) continue;
					
					mod.Load();
					
					builder.Add(mod);
				}
			}
			
			Mods = builder.ToImmutable();
		}
	}
}