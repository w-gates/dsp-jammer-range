# DSP Jammer Range for Dyson Sphere Program

**DSP Jamer Range** is a mod for the Unity game Dyson Sphere Program developed by Youthcat Studio and published by Gamera Game.  The game is available on [here](https://store.steampowered.com/app/1366540/Dyson_Sphere_Program/).

This mod allows configuration of the base Jammer Tower range and for the range to be increased along with the EM Weapon Strength upgrade by the same % amount granted by the EM Weapon Strengh upgrade. Max is +50% of base.

If you like this mod, please click the thumbs up at the [top of the page](https://dsp.thunderstore.io/package/wgates/DSP_Jammer_Range/) (next to the Total rating).  That would be a nice thank you for me, and help other people to find a mod you enjoy.

If you have issues with this mod, please report them on [GitHub](https://github.com/w-gates/dsp-jammer-range/issues).  You can also contact me at milamber#8441 on the [DSP Modding](https://discord.gg/XxhyTNte) Discord #tech-support channel.

## Config Settings
Configuration settings are loaded when you game is loaded.  So if you want to change the settings file, quit the game, but don't exit to desktop, then continue your game.

This mod is also compatible with [BepInEx.ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager) which provides an in-game GUI for changing the settings in real-time.

Settings include
 - Set the base Jammer Tower range. The default is 40m, the same as the base game.
 - Increase Jammer Tower range by the same % amount granted by the EM Weapon Strengh upgrade. Max is +50% of base. This is set true by default.

The configuration file is called `w-gates.dysonsphereprogram.jammerrange.cfg`.  It is generated the first time you run the game with this mod installed.  On Windows 10 it is located at
 - If you installed manually:  `%PROGRAMFILES(X86)%\Steam\steamapps\common\Dyson Sphere Program\BepInEx\config\w-gates.dysonsphereprogram.jammerrange.cfg`
 - If you installed with r2modman:  `C:\Users\<username>\AppData\Roaming\r2modmanPlus-local\DysonSphereProgram\profiles\Default\BepInEx\config\w-gates.dysonsphereprogram.jammerrange.cfg`

## Installation
This mod uses the BepInEx mod plugin framework.  So BepInEx must be installed to use this mod.  Find details for installing BepInEx [in their user guide](https://bepinex.github.io/bepinex_docs/master/articles/user_guide/installation/index.html#installing-bepinex-1).  This mod was tested with BepInEx x64 5.4.17.0 and Dyson Sphere Program 0.10.29.21942 on Windows 11.

To manually install this mod, add the `DysonSphereJammerRange.dll` to your `%PROGRAMFILES(X86)%\Steam\steamapps\common\Dyson Sphere Program\BepInEx\plugins\` folder.

This mod can also be installed using ebkr's [r2modman](https://dsp.thunderstore.io/package/ebkr/r2modman/) mod manager by clicking "Install with Mod Manager" on the [DSP Modding](https://dsp.thunderstore.io/package/wgates/DSP_Jammer_Range/) site.

## Open Source
The source code for this mod is available for download, review and forking on GitHub [here](https://github.com/w-gates/dsp-jammer-range) under the BSD 3 clause license.

# Credit
This mod was created using the [DSP Drone Clearing](https://dsp.thunderstore.io/package/GreyHak/DSP_Drone_Clearing/) mod as a base.
