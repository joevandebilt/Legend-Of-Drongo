@echo off
echo Please enter version number
set /p delBuild=v
echo Creating Legend-Of-Drongo v%delBuild%.zip
C:
cd "C:\Program Files\WinRAR"
if not exist .\Legend-Of-Drongo MKDIR .\Legend-Of-Drongo
if not exist .\Legend-Of-Drongo\Music MKDIR .\Legend-Of-Drongo\Music
if not exist .\Legend-Of-Drongo\Saves MKDIR .\Legend-Of-Drongo\Saves
if not exist .\Legend-Of-Drongo\Worlds MKDIR .\Legend-Of-Drongo\Worlds
if not exist .\Legend-Of-Drongo\"System Files" MKDIR .\Legend-Of-Drongo\"System Files"
COPY "D:\Dropbox\Programming\Legend-Of-Drongo\README.txt" .\Legend-Of-Drongo
COPY "D:\Dropbox\Programming\Legend-Of-Drongo\LICENSE.md" .\Legend-Of-Drongo
COPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Legend Of Drongo.exe" .\Legend-Of-Drongo
COPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Legend Of Drongo World Designer.exe" .\Legend-Of-Drongo
COPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Legend Of Drongo Data Types.dll" .\Legend-Of-Drongo
COPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Help.txt" .\Legend-Of-Drongo
XCOPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Music" .\Legend-Of-Drongo\Music /E
XCOPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Saves" .\Legend-Of-Drongo\Saves /E
XCOPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\Worlds" .\Legend-Of-Drongo\Worlds /E
XCOPY "D:\Dropbox\Programming\Legend-Of-Drongo\Compiled\System Files" .\Legend-Of-Drongo\"System Files" /E
winrar a -afzip "Legend-Of-Drongo v%delBuild%.zip" .\Legend-Of-Drongo
move ".\Legend-Of-Drongo v%delBuild%.zip" C:\cygwin\home\Joe
rmdir /s /q .\Legend-Of-Drongo
pause
