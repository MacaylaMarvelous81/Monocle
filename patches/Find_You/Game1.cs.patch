--- decompiled/Find_You/Game1.cs
+++ src/Find_You/Game1.cs
@@ -123,10 +123,12 @@
 	public static Dictionary<string, EmitterOld> emitters;
 
 	private static bool previousIsActive;
-
+	
+#if WPF_LEGACY
 	private static Cursor cursor1;
 
 	private static Cursor cursor2;
+#endif
 
 	public static bool removeUndeservedForThisAccountAchievements;
 
@@ -159,6 +161,7 @@
 		window = base.Window;
 		base.Window.ClientSizeChanged += Window_ClientSizeChanged;
 		window.AllowUserResizing = true;
+#if WPF_LEGACY
 		if (!File.Exists(modPath + "\\Cursors\\mouse1.cur"))
 		{
 			cursor1 = Calculate.GenerateCursor(File.ReadAllBytes(Environment.CurrentDirectory + "\\Content\\Cursors\\mouse1.cur"));
@@ -175,18 +178,19 @@
 		{
 			cursor2 = Calculate.GenerateCursor(File.ReadAllBytes(modPath + "\\Cursors\\mouse2.cur"));
 		}
+#endif
 		rand = new Random();
 		ps = new ParticleSystemOld(rand);
 		isFullScreen = false;
-		dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Find_You";
-		modPath = dataPath + "\\mod";
+		dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Find_You");
+		modPath = Path.Combine(dataPath, "mod");
 		if (!Directory.Exists(dataPath))
 		{
 			Directory.CreateDirectory(dataPath);
 		}
-		if (!File.Exists(dataPath + "\\error.log"))
+		if (!File.Exists(Path.Combine(dataPath, "error.log")))
 		{
-			File.Create(dataPath + "\\error.log").Dispose();
+			File.Create(Path.Combine(dataPath, "error.log")).Dispose();
 		}
 		ContentLoader.Initialize(base.Content, base.GraphicsDevice, rand);
 		ContentLoader.fonts["lato-thin-mod_14_b"].Spacing = 1f;
@@ -224,6 +228,7 @@
 		ev_exit = (EmptyEventHandler)Delegate.Combine(ev_exit, new EmptyEventHandler(base.Exit));
 		EditorNew.Initialize();
 		Restart();
+		new Monocle.ModLoader();
 		base.Initialize();
 	}
 
@@ -233,12 +238,12 @@
 		sw.Start();
 		if (Directory.Exists(modPath))
 		{
-			if (Directory.Exists(modPath + "\\Textures\\"))
+			if (Directory.Exists(Path.Combine(modPath, "Textures")))
 			{
-				string[] files = Directory.GetFiles(modPath + "\\Textures\\", "*.png", SearchOption.AllDirectories);
+				string[] files = Directory.GetFiles(Path.Combine(modPath, "Textures"), "*.png", SearchOption.AllDirectories);
 				foreach (string file in files)
 				{
-					string name = file.Substring(file.LastIndexOf('\\') + 1);
+					string name = file.Substring(file.LastIndexOf('/') + 1);
 					name = name.Remove(name.Length - 4);
 					if (!ContentLoader.textures.ContainsKey(name))
 					{
@@ -259,14 +264,14 @@
 					}
 				}
 			}
-			if (Directory.Exists(modPath + "\\Sounds\\"))
+			if (Directory.Exists(Path.Combine(modPath, "Sounds")))
 			{
-				string[] files = Directory.GetFiles(modPath + "\\Sounds\\", "*.wav", SearchOption.AllDirectories);
+				string[] files = Directory.GetFiles(Path.Combine(modPath, "Sounds"), "*.wav", SearchOption.AllDirectories);
 				foreach (string file2 in files)
 				{
 					try
 					{
-						string name2 = file2.Substring(file2.LastIndexOf('\\') + 1);
+						string name2 = file2.Substring(file2.LastIndexOf('/') + 1);
 						name2 = name2.Remove(name2.Length - 4);
 						if (ContentLoader.sounds.ContainsKey(name2))
 						{
@@ -690,6 +695,7 @@
 		string collectibles = "";
 		string hints = "";
 		int count = 0;
+#if WPF_LEGACY
 		OpenFileDialog dialog = new OpenFileDialog();
 		dialog.Multiselect = true;
 		if (dialog.ShowDialog() == DialogResult.OK)
@@ -717,6 +723,7 @@
 			}
 		}
 		Clipboard.SetText(hints);
+#endif
 	}
 
 	private void IterateThroughSaveStates()
@@ -728,6 +735,7 @@
 		int[] levelTime = new int[100];
 		int[] levelFails = new int[100];
 		int[] count = new int[100];
+#if WPF_LEGACY
 		OpenFileDialog dialog = new OpenFileDialog();
 		dialog.Multiselect = true;
 		if (dialog.ShowDialog() == DialogResult.OK)
@@ -762,5 +770,6 @@
 		{
 			Clipboard.SetText(text);
 		}
+#endif
 	}
 }
