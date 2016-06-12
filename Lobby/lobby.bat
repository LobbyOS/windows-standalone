if [%1]==[] goto :default
SET host=%1
goto :start
:default
:: "hostname:port" where Lobby Server should be running
SET host="127.0.0.1:2020"

:start
::Get directory of where this script is located
SET workingDir=%~dp0

SET lobbyPath="%workingDir:~0,-1%\lobby"

call %workingDir:~0,-1%\set-permissions.bat

::Run PHP server
"%workingDir:~0,-1%"\php\php.exe -c "%workingDir:~0,-1%"\php\php.ini -S "%host%" -t "%lobbyPath%"
