FOR /F %%T IN ('Wmic process where^(commandline LIKE "%%LobbyPHPCliServer%%"^)get ProcessId^|more +1') DO (
  SET /A ProcessId=%%T
) &GOTO SkipLine

:SkipLine

taskkill /PID "%ProcessId%" /T /F
