@ECHO OFF
"%ProgramFiles%\7-Zip\7z" a ..\w-gates-DysonSphereJammerRange-1.0.0.zip icon.png LICENSE.txt manifest.json README.md
cd bin\Release\netstandard2.0
"%ProgramFiles%\7-Zip\7z" u ..\..\..\..\w-gates-DysonSphereJammerRange-1.0.0.zip DysonSphereJammerRange.dll
