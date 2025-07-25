# Monocle

Mod loader for Find You, a game by Byting Games. Monocle is licensed under the MIT license. Find You is licensed under
[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/deed.en).

## Development

Run MonocleDevTool with the Find You installation directory as the argument. In the current directory, the game assembly
will be decompiled to `decompiled/` and `src/`. Make changes in `src/`, and generate patches using diffutils like this:

```sh
diff -u decompiled/Find_You/Game1.cs src/Find_You/Game1.cs -L decompiled/Find_You/Game1.cs -L src/Find_You/Game1.cs > patches/Find_You/Game1.cs.patch
```

where the modified file is `src/Find_You/Game1.cs`.

If `$FILE` is the file relative to each folder:

```sh
diff -u decompiled/$FILE src/$FILE -L decompiled/$FILE -L src/$FILE > patches/$FILE
```

### Linux

Developing on Linux is cumbersome because Find You and JuliHelper use WPF, and the Linux .NET SDK doesn't include the
necessary frameworks to compile them. Run the .NET SDK installer using WINE and build with `wineconsole`. Save yourself
a headache and just copy the new `Find_You.dll` to the original directory and use the original `Find_You.exe`.
Unfortunately, this means you get no .NET debugger or other conveniences.

### Why make this??

For fun! I thought it would be interesting to try developing something like tModLoader where the game is decompiled and
then modified instead of using plugin frameworks like BepInEx. Being able to directly edit a decompiled version also
makes writing code that integrates with the game way easier, like being able to add to the enum `Find_You.Menu.Tab`.
