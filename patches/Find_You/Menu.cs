--- decompiled/Find_You/Menu.cs
+++ src/Find_You/Menu.cs
@@ -7,6 +7,7 @@
 using JuliHelper;
 using Microsoft.Xna.Framework;
 using Microsoft.Xna.Framework.Graphics;
+using Monocle;
 
 namespace Find_You;
 
@@ -21,7 +22,8 @@
 		Options,
 		Credits,
 		Stats,
-		Win
+		Win,
+		ModTab
 	}
 
 	[Serializable]
@@ -585,6 +587,18 @@
 
 	public static Tab tab;
 
+	public static IModTab modTab
+	{
+		get => tab == Tab.ModTab ? _modTab : null;
+		set
+		{
+			tab = Tab.ModTab;
+			_modTab = value;
+		}
+	}
+
+	private static IModTab _modTab;
+
 	public static List<GuiElement> guis;
 
 	public static List<GuiElement> delSaveGuis;
@@ -778,7 +792,15 @@
 					Game1.Close();
 				});
 			};
-			int buttonCount = 4;
+			GuiEvent evMods = delegate
+			{
+				Game1.Transit(delegate
+				{
+					modTab = new ModListTab();
+					Reload();
+				});
+			};
+			int buttonCount = 5;
 			int buttonWidth = 128;
 			int buttonHeight = 32;
 			int yPlus = 56;
@@ -788,6 +810,7 @@
 			guis.Add(new G_Button(new M_Rectangle(x, y += yPlus, 128f, 32f), evEditor, "Editor", Game1.font14, Color.White));
 			guis.Add(new G_Button(new M_Rectangle(x, y += yPlus, 128f, 32f), evOptions, "Options", Game1.font14, Color.White));
 			guis.Add(new G_Button(new M_Rectangle(x, y += yPlus, 128f, 32f), evStats, "Statistics", Game1.font14, Color.White));
+			guis.Add(new G_Button(new M_Rectangle(x, y += yPlus, 128f, 32f), evMods, "Mods", Game1.font14, Color.White));
 			guis.Add(new G_Button(new M_Rectangle(x, y += yPlus, 128f, 32f), evQuit, "Quit", Game1.font14, Color.White));
 			Texture2D texture2D = ContentLoader.textures["stuntboost"];
 			float width = (float)texture2D.Width / 2f + 10f;
@@ -1231,6 +1254,10 @@
 			};
 			guis.Add(new G_Button(new M_Rectangle(8f, 8f, 32f, 32f), evBack4, "<", Game1.font14, Color.White));
 		}
+		else if (tab == Tab.ModTab)
+		{
+			modTab.Reload();
+		}
 		if (controllerStart)
 		{
 			Game1.useKeysInsteadOfMouse = true;
