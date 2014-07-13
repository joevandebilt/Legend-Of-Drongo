+---------------------------------------+
|			Legend Of Drongo			|
|				Changelog				|
+---------------------------------------+

Description:
The Legend of Drongo was a project I started as a means to familiarise myself with C# programming concepts for my studies. Following my studies the project was mothballed and is worked on in sprints as and when I have the time. It is a hobby and is the accumulated skilled I have gained over the past 3 years of dev experience, so naturally some areas of the program are poorly designed and executed. However I am constantly making changes to the engine, and one day hope to release as an indie game. 

Known Bugs:
- Death in custom world moves player to random point at level 1 - FIXED v2.1.4
- Saves will overwrite based on name, even if playing custom worlds - Fixed v2.1.3
- Surprise Attack will only allow twice - FIXED v2.1.2
- When enemy killed, they can still make a move - FIXED v2.3.0
- Double items being produced? Cell 8,6,1 - FIXED v2.3.2
- Item interaction names being shared across items in same room. - Only occurs for cloned items - FIXED v2.5.1
- Could not fight Juan, Terry or Gary in FWOTT - CANNOT REPLICATE
- Can pick up items but more than 4 not shown. - Fixed V2.6.3
- Talk Man (missing word to) - Fixed v2.6.4
- Singular use of command 'use' - Fixed v2.6.4
- Attacking a man with a null inventory - Fixed v2.6.4

To Do:
- Finish world.
- File directories are fixed paths, add in choice of directory. - Omitted

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
- Changed World Designer to Inherit data structures

v2.1.1
- Introduced Separate World Files in ./Worlds Folder
- Rewrote Events System
- Added Knowledge System
- Allowed for creation and use of custom worlds
- Removed custom tracks per floor until workaround can be found

v2.1.2
- Improved Combat system
- Improved Item interaction system

v2.1.3
- Added separate folders for per-world save files
- Improved Ask about system
- Asked Scott for money. 

v2.2.0
- Fixed tab indexes on World editor forms
- Fixed Event Editor Floor Picked Selected Index bug
- Made if null output for attempting to move into new rooms 
- Improved Level 2 of Campaign world.
- Changed Event Data type to carry Item/Enemy/NPC and custom new values.
- Redesigned Event Editor in World Editor to match new data type.
- Added Event Actions to ActionTrigger event
- Redesigned Trigger & Action within Event Editor
- Added Clone Buttons to event/NPC/Item and Enemy controls
- Moved Event Trigger to new method

v2.2.4
- Updated Issues with Combat system
- Redesigned combat system
- Ended loops in combat starting system
- Added Defence bonus of weapon to contribute to defence modifier.

v2.2.5
- Improved Surprise Attack and Attacked functions
- Added lockedIn criteria
- Added being attacked after LockedIn criteria set. 
- Fixed issue with saving not saving current state of room. 

v2.3.0
- Fixed issue with non-complete eat command
- Added command 'drink' to have same affect as 'eat'.
- Added Item class of type Drink
- Updated Eat(string) method to Consume(string) 
- Added different output for loss/gain of HP in Consume(string)
- Updated output of 'help' command
- Changed Structure of Floor from Array to custom data type featuring array
- Change Engine, World Designer to cope
- Added floor name to frmWorldDesigner
- Imported World from old class system to new.
- Added option of custom song per floor to data type
- Made txtWeapon on frmEnemyEditor non-editable

v2.3.1
- Change Event Editor to manage selected cmb box values better
- Changed HP and damage modifiers to double data type

v2.3.2
- Fixed rounding of HP to 2 significant figures
- Altered Item editor to allow double data type inputs and double casts when editing.
- Fixed Event editor to enable/disable boxes in a more renewable fashion
- Fixed issue with item interactions not outputting custom text
- Fixed issue with clearing inventory spaces after item use, item equips and sleeping
- Fixed issue with dying while trying to sleep in a room... yes that was an actual bug >.<
- Improved world

v2.3.3
- Fixed issue with command 'talk' causing crash
- Improved world. 

v2.3.4
- Added criteria if questions asked to an enemy

v2.3.5
- Added try catch to main command entry to allow for errors
- Improved world

v2.3.6
- Added extra criteria to examine command to output different information based on each item class.
- Added line breaks to event text output
- Fixed issue with rooms not unlocking
- Improved world
- Wrote my first #GameDevHaiku

v2.4.0
- Enabled 'Test world' button on world designer
- Added arguments to allow for test world. 
- Hid world editor when world testing is enabled. 
- Edited room info data type: added room colour for sake of world designer.
- Added colour picker to world designer room editor
- Changed default output of null room descriptions to output the world designer coordinates rather than list/array output
- Optimised form movement
- Added regions to to engine Main to make easier to look at

v2.4.1
- Improved error handling to output files with exception details
- Added ForceError method to test error handling

v2.5.0
- Added Levelling up values to data types
- Changed Consume method to match new max health system
- Changed combat to handle Speed, resistance and strength modifiers
- Changed combat to add xp from enemies when killed. 
- Added event giveXP
- Change Rest method to accommodate new maxHP value
- Added levelling up method to increase character stats
- Changed Status method to show Level, XP, speed, strength, resistance, MaxHp
- Changed KillallEnemies event action to add XP
- Added XP to items to be gained when: Consumed, Read, Used Correctly
- Added XP to item data structure and added text field for Item Editor in world
- Fixed Issue with colour picker on room editor

v2.5.1
- Added Clone Methods for each data object to fix issue with cloning items writing to same memory block. 
- Fixed issue with reading items earning double XP

v2.5.2
- Added frmMusicPicker to add music per floor
- Added Level Music & Level name elements to frmWorldDesigner
- Added floorMusic check to change location event, to start playing floor music in the event that one has been specified
- Moved Event Actions and Triggers from Array into Lists
- Added Event Action to set custom description of a room

v2.5.3
- Improved bribing semantics & running
- Removed KillAllEnemies trigger from pay off method
- Added GainXpfromEnemy Method
- Added XP to food items in world

v2.5.4
- Added Help Section
- Wrote Help.txt and added it to the basic file set. 
- Changed combat to not allow bribes after an enemy has been attacked
- Moved engine 'help' command to output text file containing help file. 

v2.5.5
- Added parameters to accept upper case file extensions, such as WAV or Wav
- Fixed music browse command
- Allowed music browse to accept both name and number of songs, i.e input 1 for song 1 or input name of song 1 to play.
- Improved Tutorial world to show off new features. 
- Added Null Checks to foreach loops
- Added Explored bool to room class
- Add Draw map function to draw local area that has been explored. 

v2.5.6
- Added time to game
- Time of day output has been added
- The time command has been added to help file
- WorldState class now has time attribute, recording number of minutes in the day
- Player class now has DaysSinceSleep which records how long since the player has slept
- DaysSinceSleep now effects speed and strength bonus'
- Sleeping sets time of day to 8am, recovers HP and sets days since sleep to 0
- if Days Since sleep reaches 4 player dies. 

v2.6.0
- Added end credits function to game engine
- Added World author string to world datatype
- Added List of strings to world datatype as credits
- Added frmEndCredits to world designer to add end custom end credits to game
- Added run credits and end game to event actions
- Completed building tutorial mission
- Added default player editor to world designer
- Made default player inherit from world file rather than code
- Enabled Item Editor to lock out class if a particular item class is intended to be used. 

v2.6.1
- Changed player inventory to list
- Changed inventory interactions to compensate for lists as opposed to arrays
- Made space in inventory prevent pickups/buys (fixed stack overflow)
- Converted existing worlds to new data structures

v2.6.2
- Added increasing inventory size with levelling up
- Lowered inventory space at starting level to 10.
- Changed all inventory checks to use maxitems value rather than hard coded 20

v2.6.3
- Fixed bribe function
- Fixed picking up items issue
- Added ifnull lines to directory usage
- Changed build path of data types dll into System Files folder
- Fixed issue with invspace not resetting when maxitems is changed

v2.6.4
cv

If you encounter an error, please email the error file to joevandebilt@live.co.uk, or report it on gitHub