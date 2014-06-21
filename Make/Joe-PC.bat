@echo off
echo Please enter version number
set /p delBuild=v
echo Creating Legend-Of-Drongo v%delBuild%.zip
C:
cd "C:\Program Files\WinRAR"
if not exist .\Legend-Of-Drongo MKDIR .\Legend-Of-Drongo
COPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\README.txt" .\Legend-Of-Drongo
COPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\LICENSE.md" .\Legend-Of-Drongo
COPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\Compiled\Legend Of Drongo.exe" .\Legend-Of-Drongo
COPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\Compiled\Legend Of Drongo World Designer.exe" .\Legend-Of-Drongo
COPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\Compiled\Legend Of Drongo Data Types.dll" .\Legend-Of-Drongo
XCOPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\Compiled\Music" .\Legend-Of-Drongo /E
XCOPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\Compiled\Saves" .\Legend-Of-Drongo /E
XCOPY "C:\Users\Joe\Dropbox\Programming\Legend-Of-Drongo\Compiled\Worlds" .\Legend-Of-Drongo /E
winrar a -afzip "Legend-Of-Drongo v%delBuild%.zip" .\Legend-Of-Drongo
move ".\Legend-Of-Drongo v%delBuild%.zip" C:\Users\Joe\Desktop
rmdir /s /q .\Legend-Of-Drongo
pause
