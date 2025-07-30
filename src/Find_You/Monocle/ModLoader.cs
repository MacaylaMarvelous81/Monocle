using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using Find_You;

namespace Monocle;

internal class ModLoader
{
	public IImmutableList<Mod> Mods { get; private set; }

	internal ModLoader()
	{
		if (!Directory.Exists(Path.Combine(Game1.dataPath, "Monocle")))
		{
			Directory.CreateDirectory(Path.Combine(Game1.dataPath, "Monocle"));
		}
		if (!Directory.Exists(Path.Combine(Game1.dataPath, "Monocle/Mods")))
		{
			Directory.CreateDirectory(Path.Combine(Game1.dataPath, "Monocle/Mods"));
		}
		LoadMods();
	}

	private void LoadMods()
	{
		ImmutableList<Mod>.Builder nextRand = ImmutableList.CreateBuilder<Mod>();
		string[] files = Directory.GetFiles(Path.Combine(Game1.dataPath, "Monocle/Mods"));
		foreach (string text in files)
		{
			if (!text.EndsWith(".dll"))
			{
				continue;
			}
			Assembly assembly = Assembly.LoadFile(text);
			IEnumerable<Type> enumerable = from type in assembly.GetTypes()
				where type.IsSubclassOf(typeof(Mod))
				select type;
			foreach (Type item in enumerable)
			{
				object obj = Activator.CreateInstance(item);
				if (obj is Mod mod)
				{
					mod.Load();
					nextRand.Add(mod);
				}
			}
		}
		Mods = nextRand.ToImmutable();
	}
}
