--- decompiled/Find_You/FileManager.cs
+++ src/Find_You/FileManager.cs
@@ -36,7 +36,7 @@
 		{
 			return "";
 		}
-		while (path[path.Length - 1] != '\\')
+		while (path[path.Length - 1] != '/')
 		{
 			path = path.Remove(path.Length - 1);
 		}
@@ -45,6 +45,6 @@
 
 	public static string GetNameFromPath(string path)
 	{
-		return path.Split(new char[1] { '\\' })[^1];
+		return path.Split(new char[1] { '/' })[^1];
 	}
 }
