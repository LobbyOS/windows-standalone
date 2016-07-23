::Get directory of where this script is located
SET workingDir=%~dp0

SET lobbyPath="%workingDir:~0,-1%\lobby"

:: Give Full control to Lobby dir
:: cd %lobbyPath:~0,-1%
:: takeown /F .\ /A /R /D Y
:: icacls "%lobbyPath:~0,-1%" /grant Everyone:F
