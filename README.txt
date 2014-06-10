+-----------------------------------+
|         Legend Of Drongo          |
|            Changelog	            |
+-----------------------------------+

Description:
The Legend of Drongo was a project I started as a means to familiarise myself with C# programming concepts for my studies. Following my studies the project was mothballed and is worked on in sprints as and when I have the time. It is a hobby and is the accumulated skilled I have gained over the past 3 years of dev experience, so naturally some areas of the program are poorly designed and executed. However I am constantly making changes to the engine, and one day hope to release as an indie game. 

Known Bugs:
- Some iterations of data structures do not check if null, causing crash.
- Death in custom world moves player to random point at level 1
- Saves will overwrite based on name, even if playing custom worlds - Fixed v2.1.3
- Surprise Attack will only allow twice - FIXED v2.1.2


To Do:
- Finish world.
- File directories are fixed paths, add in choice of directory.

Changes:
V1.0.0
- Created Basic Game engine
- Added command system
- Added Data types
- Created Hard coded world
- Hard Coded Tutorial

v2.0.1
- Created World Designer
- Moved Data structures into new project
- Changed Engine to Inherit data structures
- Changed World Designer to Inherit data stuctures

v2.1.1
- Introduced Seperate World Files in ./Worlds Folder
- Rewrote Events System
- Added Knowledge System
- Allowed for creation and use of custom worlds
- Removed custom tracks per floor until workaround can be found

v2.1.2
- Improved Combat system
- Improved Item interaction system

v2.1.3
- Added seperate folders for per-world save files
- Improved Ask about system
- Asked Scott for money. 

Please report any bugs to joevandebilt@live.co.uk with a screenshot of what you can see and if possible which command you ran. Or use GitHub