using Find_You;
using JuliHelper;
using Microsoft.Xna.Framework;

namespace Monocle
{
	public class ModListTab : IModTab
	{
		public void Render()
		{
		}
		
		public void Reload()
		{
			Menu.guis.Add(new G_Button(new M_Rectangle(8f, 8f, 32f, 32f), NavigateBack, "<", Game1.font14, Color.White));
		}

		private void NavigateBack(GuiElement element)
		{
			Game1.Transit(delegate
			{
				Menu.tab = Menu.Tab.Menu;
				Menu.Reload();
			});
		}
	}
}