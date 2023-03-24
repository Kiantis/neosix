# neosix

A [NeosModLoader](https://github.com/zkxs/NeosModLoader) mod for [Neos VR](https://neos.com/) for running web assemblies.

## Installation
1. Install [NeosModLoader](https://github.com/zkxs/NeosModLoader).
1. Place [wasmtime.dll](https://github.com/Kiantis/neosix/raw/master/neosix/libs/wasmtime.dll) into your `nml_mods` folder.
1. Place [Wasmtime.Dotnet.dll](https://github.com/Kiantis/neosix/raw/master/neosix/libs/Wasmtime.Dotnet.dll) into your `nml_mods` folder.
1. Place `neosix.dll` into your `nml_mods` folder. You'll have to build it from the project for now.
1. Start the game. If you want to verify that the mod is working you can check your Neos logs. This string should appear: `neosix wasm round trip test: Hello from WASM!`

Ideally only `neosix.dll` will change for further updates, wasmtime libraries most probably won't be touched again.

### `nml_mods` folder

This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\nml_mods` for a default install. You can create it if it's missing, or if you launch the game once with NeosModLoader installed it will create the folder for you.
