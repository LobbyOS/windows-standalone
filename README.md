# Windows Installer

Lobby installer for Windows

## Install Lobby

The MSI setup file for Lobby is at ["LobbyInstaller/Lobby.msi"](https://raw.githubusercontent.com/LobbyOS/windows-installer/master/LobbyInstaller/Lobby.msi).

## Compiling PHP

1. The folder compile-PHP has the requirements to compile PHP
2. Use the official [PHP doc](https://wiki.php.net/internals/windows/stepbystepbuild) to compile PHP.
   But use this to configure the build :
   ```
   configure --enable-cli --enable-pdo --with-mysql --with-sqlite3 --with-pdo-mysql --with-pdo-sqlite --with-curl --with-openssl --enable-fileinfo --enable-mbstring --with-mcrypt --enable-zip
   ```
3. The compile binaries are placed in Lobby/ directory.

## Binaries

The binaries got from compiling are :
* php.exe
* php5ts.dll
* php_curl.dll
* php_gd2.dll
* php_opcache.dll

Besides these, OpenSSL dlls are also included in the Lobby/ directory :
* libeay32.dll
* ssleay32.dll

## Installation

The install wizard was created using [Advanced Installer](www.advancedinstaller.com/).

It will create a folder in C:\Program Files called "Lobby" which will have the same files as in the Lobby/ directory in this repo.

The "Documents" folder in "Lobby/" resembles what change happens on the user's My Documents directory.

## Visual Basic

The visual basic project is in 'LobbyEXE' directory which makes the Lobby.exe file. The 'invisible.vbs' file is used to run 'lobby.bat' in background.

## Running

Lobby will run on 127.0.0.1:9000 Currently it is impossible to change it by GUI. If you want to change it, edit the lobby.bat file.
