:: Has to run in a batch file because Visual Studio apparently doesnt support variables...

:: %1 - TargetPath
:: %2 - TargetDir
:: %3 - TargetName
:: %4 - ConfigurationName

if %4=="Mini" goto :mini
if %4=="mini" goto :mini
if %4=="MINI" goto :mini

echo [ Running post build actions for configuration %4! ]

if %USERNAME%==lagys (
    set ModFolder=C:\Users\lagys\Documents\MySummerCar\Mods

) else if %USERNAME%==OTHERUSERNAME (
    set ModFolder=OTHERMODFOLDERPATH

) else (
    echo [ Unknown user - exiting post build event. Copy files manually! exiting... ]
    exit
)

echo [ Post build for %USERNAME%... ]
copy %1 "%ModFolder%" /y
echo [ Copied dll into mods folder! ]

if %4=="Debug" (
    copy %2%3.pdb "%ModFolder%" /y
    echo [ Copied pdb file into mods folder! ]

    cd "%ModFolder%"
    if exist debug.bat (
        call debug.bat
    ) else (
        echo [ debug.bat not found in %ModFolder%. You probably dont have MSCLoader debugging enabled! ]
    )
)

echo [ Done! ]
exit

:mini
echo [ Building mini dll, hence not copying to mods folder! ]
exit