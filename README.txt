+-----------------------------------+
|   Legend Of Drongo - Release 2    |
|            Changelog	            |
+-----------------------------------+

Changes:
- Introduced Seperate World Files in ./Worlds Folder
- Rewrote Events System
- Added Knowledge System

- Created World Designer
- Moved Data structures into new project
- Changed Engine to Inherit data structures
- Changed World Designer to Inherit data stuctures

- Improved Combat system
- Improved Item interaction system

- Allowed for creation and use of custom worlds
- Removed custom tracks per floor until workaround can be found

Known Bugs:
- Some iterations of data structures do not check if null, causing crash.
- Death in custom world moves player to random point at level 1
- Saves will overwrite based on name, even if playing custom worlds
- Surprise Attack will only allow twice - FIXED


To Do:
- Finish world.
- File directories are fixed paths, add in choice of directory.

Please report any bugs to joevandebilt@live.co.uk with a screenshot of what you can see and if possible which command you ran. 