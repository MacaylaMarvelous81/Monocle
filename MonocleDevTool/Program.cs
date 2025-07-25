// See https://aka.ms/new-console-template for more information

using CodeChicken.DiffPatch;
using ICSharpCode.Decompiler.CSharp.ProjectDecompiler;
using ICSharpCode.Decompiler.Metadata;

const string assemblyName = "Find_You, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null";

void RecursiveCopyDirectory(DirectoryInfo source, DirectoryInfo target)
{
    foreach (FileInfo file in source.GetFiles())
    {
        file.CopyTo(Path.Combine(target.FullName, file.Name), overwrite: true);
    }

    foreach (DirectoryInfo directory in source.GetDirectories())
    {
        RecursiveCopyDirectory(directory, target.CreateSubdirectory(directory.Name));
    }
}

if (args.Length < 1)
{
    Console.WriteLine("Provide the Find_You assembly as an argument");
    return 1;
}

// see TargetFramework assembly attribute
UniversalAssemblyResolver resolver = new UniversalAssemblyResolver(args[0], true, ".NETCoreApp,Version=v6.0");
// These are where libraries are located in the game installation
resolver.AddSearchDirectory(Path.Combine(Path.GetDirectoryName(args[0]), "libraries"));
WholeProjectDecompiler decompiler = new WholeProjectDecompiler(resolver);

DirectoryInfo destDir = new DirectoryInfo("decompiled");

if (!destDir.Exists)
    destDir.Create();

decompiler.DecompileProject(resolver.Resolve(AssemblyNameReference.Parse(assemblyName)), destDir.FullName);

DirectoryInfo srcDir = new DirectoryInfo("src");

RecursiveCopyDirectory(destDir, srcDir);

DirectoryInfo patchDir = new DirectoryInfo("patches");
if (patchDir.Exists)
{
    IEnumerable<FileInfo> files = patchDir.EnumerateFiles("*.patch", SearchOption.AllDirectories);
    foreach (FileInfo file in files)
    {
        FilePatcher patcher = FilePatcher.FromPatchFile(file.FullName);
        patcher.Patch(Patcher.Mode.FUZZY);
        patcher.Save();
    }
}

return 0;