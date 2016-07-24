:: This command tells the program not display every command and its output.
@echo off

:: Get directory of where this script is located
SET workingDir=%~dp0

call %workingDir:~0,-1%\set-permissions.bat

:: Stop server
start %workingDir:~0,-1%\php\stop-server.exe

for /f "delims=" %%a in ('call %workingDir:~0,-1%\lib\read-ini.bat %workingDir:~0,-1%\lobby.ini LobbyServer host') do (
    set host=%%a
)
start %workingDir:~0,-1%\php\start-server.exe "%host%"

start "" "http://%host%"
