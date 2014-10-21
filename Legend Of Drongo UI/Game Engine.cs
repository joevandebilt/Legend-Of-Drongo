/*  
 *              This game is protected under the Artistic License 2.0
 *                  Copyright (c) 2014 Joseph Benjamin van de Bilt
 *
 *          This license establishes the terms under which a given free software
 *          Package may be copied, modified, distributed, and/or redistributed.
 *          The intent is that the Copyright Holder maintains some artistic
 *          control over the development of that Package while still keeping the
 *          Package available as open source and free software.
 *      
 *  Should you wish to contact the copyright holder at any point please do so at joevandebilt@live.co.uk
 *  
 */


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Legend_Of_Drongo
{
    class LegendOfDrongoEngine : DataTypes
    {
        #region Game Objects

        public static WorldFile WorldState = new WorldFile();

        public static List<Floor> world = new List<Floor>();

        public static Floor ThisFloor = new Floor();

        public static roomInfo CurrentRoom = new roomInfo();

        public static roomInfo PotentialRoom = new roomInfo();

        public static PlayerProfile Player = new PlayerProfile();

        #endregion

        #region Music Controls
        //Music Controls
        public static SoundPlayer MusicPlayer = new SoundPlayer();
        
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        #endregion

        #region Threading Bullshit

        public static object myLock = new object();
        
       
        #endregion

        public static bool stopProcessing = false;
        public static int stopTime = 1; //1 = go, 0=pause, -1 = Stop

        //Game Options
        public static bool DebugEnabled = false;
        public static bool ClearConsole = false;

        //Console Class
        public static frmMainConsole LoDConsole;
        delegate void UpdateConsole(object Input);

        public LegendOfDrongoEngine(frmMainConsole Form)
        {
            LoDConsole = Form;
        }

        #region Main Menu

        public static void Warning()
        {
            if (File.Exists(".\\Music\\Warning.wav"))
            {
                MusicPlayer.SoundLocation = ".\\Music\\Warning.wav";
                Music("Start");
            }
            LoDConsole.WriteLine("This game uses music files throughout and can appear be very loud. Before continuing it may be wise to mute or lower the volume on this application");
        }

        public static void DrawMainMenu()
        {
            
            LoDConsole.Clear();

            if (File.Exists(".\\Music\\Quartis.wav"))
            {
                MusicPlayer.SoundLocation = ".\\Music\\Quartis.wav";
                Music("Start");
            }

                /*
                LoDConsole.WriteLine("\n\n\n\n");
                LoDConsole.WriteLine("     _        _______  _______  _______  _        ______  ");
                LoDConsole.WriteLine("     ( \\      (  ____ \\(  ____ \\(  ____ \\( (    /|(  __  \\ ");
                LoDConsole.WriteLine("     | (      | (    \\/| (    \\/| (    \\/|  \\  ( || (  \\  )");
                LoDConsole.WriteLine("     | |      | (__    | |      | (__    |   \\ | || |   ) |");
                LoDConsole.WriteLine("     | |      |  __)   | | ____ |  __)   | (\\ \\) || |   | |");
                LoDConsole.WriteLine("     | |      | (      | | \\_  )| (      | | \\   || |   ) |");
                LoDConsole.WriteLine("     | (____/\\| (____/\\| (___) || (____/\\| )  \\  || (__/  )");
                LoDConsole.WriteLine("     (_______/(_______/(_______)(_______/|/    )_)(______/ ");
                LoDConsole.WriteLine("                                                      ");
                LoDConsole.WriteLine("                          _______  _______                 ");
                LoDConsole.WriteLine("                         (  ___  )(  ____ \\                ");
                LoDConsole.WriteLine("                         | (   ) || (    \\/                ");
                LoDConsole.WriteLine("                         | |   | || (__                    ");
                LoDConsole.WriteLine("                         | |   | ||  __)                   ");
                LoDConsole.WriteLine("                         | |   | || (                      ");
                LoDConsole.WriteLine("                         | (___) || )                      ");
                LoDConsole.WriteLine("                         (_______)|/                       ");
                LoDConsole.WriteLine("                                                      ");
                LoDConsole.WriteLine("      ______   _______  _______  _        _______  _______ ");
                LoDConsole.WriteLine("     (  __  \\ (  ____ )(  ___  )( (    /|(  ____ \\(  ___  )");
                LoDConsole.WriteLine("     | (  \\  )| (    )|| (   ) ||  \\  ( || (    \\/| (   ) |");
                LoDConsole.WriteLine("     | |   ) || (____)|| |   | ||   \\ | || |      | |   | |");
                LoDConsole.WriteLine("     | |   | ||     __)| |   | || (\\ \\) || | ____ | |   | |");
                LoDConsole.WriteLine("     | |   ) || (\\ (   | |   | || | \\   || | \\_  )| |   | |");
                LoDConsole.WriteLine("     | (__/  )| ) \\ \\__| (___) || )  \\  || (___) || (___) |");
                LoDConsole.WriteLine("     (______/ |/   \\__/(_______)|/    )_)(_______)(_______)");

                //LoDConsole.WriteLine("\n\n\n");
                //LoDConsole.WriteLine("        [N] New Game    [T] Tutorial    [C] Custom Game\n\n                [L] Load Game        [Q] Quit");
                */

                LoDConsole.ToggleMenuButtoms(true);

        }

        public static PlayerProfile MainMenu(int MenuChoice)
        {
            //0 New Game
            //1 Tutorial
            //2 Load Game
            //3 Custom Game
            //4 Quit

            Player = new PlayerProfile();

            if (MenuChoice == 0)   //New Game
            {
                LoDConsole.Clear();

                //Load Campaign World
                using (Stream stream = File.Open(".\\Worlds\\LoDCampaign.LoD", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    WorldState = (WorldFile)bin.Deserialize(stream);
                }
                world = WorldState.WorldState;
                Player = WorldState.DefaultPlayer;

                LoDConsole.WriteLine("Loading Legend Of Drongo Campaign");
                Player.name = LoDConsole.ReadLine("What is your name?", "Name", Player.name);
                LoDConsole.Clear();
                
            }
            else if (MenuChoice == 1)   //Tutorial
            {
                Player = new PlayerProfile();

                //Load Tutorial World
                using (Stream stream = File.Open(".\\Worlds\\LoDTutorial.LoD", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    WorldState = (WorldFile)bin.Deserialize(stream);
                }
                world = WorldState.WorldState;
                LoDConsole.Clear();
                Player = WorldState.DefaultPlayer;
                Player.name = LoDConsole.ReadLine("What is your name?", "Name", Player.name);
                LoDConsole.Clear();
            }
            else if (MenuChoice == 2)   //Load Game
            {
                string SavePath = LoDConsole.FindFile("\\Saves\\");
                if (SavePath == "!FAIL!" || !File.Exists(SavePath))
                {
                    return new PlayerProfile();
                }
                else
                {

                    GameState gamestate = new GameState();
                    using (Stream stream = File.Open(SavePath, FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        gamestate = (GameState)bin.Deserialize(stream);
                    }
                    Player = gamestate.PlayerState;
                    WorldState = gamestate.WorldState;
                    world = WorldState.WorldState;

                    LoDConsole.WriteLine(WordWrap("\n            Loading"));
                    //Thread.Sleep(1500);
                    LoDConsole.Clear();

                    PlayerStatus();
                    LoDConsole.WriteLine(WordWrap("Press any key to continue your adventure..."));
                    LoDConsole.Clear();
                }
            }
            else if (MenuChoice == 3)   //Custom Game
            {
                string SavePath = LoDConsole.FindFile("\\Worlds\\");
                if (SavePath == "!FAIL!" || !File.Exists(SavePath))
                {
                    return new PlayerProfile();
                }
                else
                {
                    
                    Player.name = LoDConsole.ReadLine("What is your name?", "Name", Player.name);
                    LoDConsole.Clear();
                    LoDConsole.WriteLine(WordWrap("\n            Loading"));
                    //Thread.Sleep(1500);
                    LoDConsole.Clear();
                }
            }
            else if (MenuChoice == 4)   //Quit
            {
                lock(myLock) { stopTime = -1; }
                Environment.Exit(0);
            }
            return Player;
        }

        //public async void Introduction()
        public static void Introduction()
        {
            string[] intro = new string[15];
            int[] sleep = new int[15];
            int index;
            string gap = Environment.NewLine;


            intro[0] = string.Concat("Game created by Joe van de Bilt");
            sleep[0] = 3000;
            intro[1] = string.Concat("You are running through the tress.", gap, "Something is chasing you.");
            sleep[1] = 4000;
            intro[2] = string.Concat("Branches hit you in the face as you fly through the forest.", gap, "You can hear your predator right behind you.");
            sleep[2] = 5000;
            intro[3] = string.Concat("You come to a river.", gap, "Seeing no way to cross safely", gap, "you throw yourself into the stream.");
            sleep[3] = 4000;
            intro[4] = string.Concat("The current takes you and your body is thrown about.", gap, "You scramble for control in the mighty torrent of the river.");
            sleep[4] = 4000;
            intro[5] = string.Concat("As you thrash about, you hit your head. Hard");
            sleep[5] = 3000;
            intro[6] = string.Concat("You manage to scramble to the shore", gap, "pulling yourself out of the water.", gap, "You have lost your foe.");
            sleep[6] = 4000;
            intro[7] = string.Concat("Relief fades to worry", gap, "as you feel warm blood trickle down your face.");
            sleep[7] = 4000;
            intro[8] = string.Concat("You look around you for help...", gap, "There aren't any signs of life around you.");
            sleep[8] = 5000;
            intro[9] = string.Concat("You drag yourself further into the tree line", gap, "Your strength fading.");
            sleep[9] = 4000;
            intro[10] = string.Concat("You collapse, and the world fades to black...");
            sleep[10] = 6000;
            intro[11] = string.Concat("You awaken in a clearing in the woods.", gap, "Your head feels like hell ...but you're alive");
            sleep[11] = 5000;
            intro[12] = string.Concat("You can't remember a thing...");
            sleep[12] = 3000;
            intro[13] = string.Concat("You achingly pull yourself to your feet.", gap, "You need to find a way out of the woods");
            sleep[13] = 3000;
            intro[14] = string.Concat("You achingly pull yourself to your feet.", gap, "You need to find a way out of the woods", gap, "... and find out what happened");
            sleep[14] = 6000;

            index = 0;
            while (index < sleep.Length && !stopProcessing)
            {
                lock (myLock)
                {
                    if (stopProcessing == true)
                    {
                        break;
                    }
                }
                LoDConsole.Clear();
                LoDConsole.WriteLine(string.Concat("\n\n", intro[index]));
                Thread.Sleep(sleep[index]);
                index++;
            }
            lock (myLock) { stopProcessing = true; }
        }

        public static void SkipIntro()
        {
            lock (myLock)
            {
                stopProcessing = true;
            }
        }

        #endregion

        public static void ParseOptions()
        {
            //Check for optional Options File
            if (File.Exists(".\\Options.txt"))
            {
                using (StreamReader sr = new StreamReader(".\\Options.txt", true))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] LineWords = sr.ReadLine().Split(':');
                        if (!string.IsNullOrEmpty(LineWords[0]) && LineWords[0][0] != '#')
                        {
                            if (LineWords[0] == "DebugOptions")
                            {
                                if (LineWords[1].Trim().ToLower() == "true") DebugEnabled = true;
                                else if (LineWords[1].Trim().ToLower() == "false") DebugEnabled = false;
                            }
                            else if (LineWords[0] == "ClearConsole")
                            {
                                if (LineWords[1].Trim().ToLower() == "true") ClearConsole = true;
                                else if (LineWords[1].Trim().ToLower() == "false") ClearConsole = false;
                            }
                        }
                    }
                }
            }
        }

        public static void StartGame (PlayerProfile Player)
        {
            LoDConsole.ToggleMenuButtoms(false);
            
            ParseOptions();

            ThisFloor = world[Player.CurrentPos[2]];
            CurrentRoom = GetRoomInfo(Player.CurrentPos);
            CurrentRoom.Explored = true;
            //if (Player.InBuilding == true)
            //{
            //    CurrentRoom = GoIntoBuilding(CurrentRoom.Building);
            //    Player.InBuilding = true;
            //}

            WorldState.WorldTime = 512; //Set the clock to 8am and start ticking
            Thread TimeThread = new Thread(TimeTicker);
            TimeThread.Start();

            //The starting floor has a song that is not the one currently playing
            if (ThisFloor.FloorSong != null && File.Exists(ThisFloor.FloorSong) && ThisFloor.FloorSong != MusicPlayer.SoundLocation)
            {
                MusicPlayer.SoundLocation = ThisFloor.FloorSong;
                Music("Start");
            }

            LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
            LoDConsole.DrawEnvironment(CurrentRoom);
        }

        public static void EnterCommand(string PlayerCommand)
        {
            //Take in a player command
            //LoDConsole.Write(">");
            //PlayerCommand = Console.ReadLine();
            PlayerCommand = CleanPlayerInput(PlayerCommand);    //Clean the input of unusual characters

            if (!ClearConsole) LoDConsole.WriteLine("");
            else LoDConsole.Clear();
            
            try
            {
                #region Help
                if (PlayerCommand.ToLower() == "help" || PlayerCommand.ToLower() == "commands" || PlayerCommand.ToLower().Contains("how do i") || PlayerCommand.ToLower().Contains("how can i"))
                {
                    using (StreamReader file = new System.IO.StreamReader(@".\System Files\GameEngineHelp.sys", true))
                    {
                        LoDConsole.WriteLine(WordWrap(file.ReadToEnd()));
                    }
                }
                #endregion

                #region Movement
                else if (
                            (PlayerCommand.ToLower().Split(' ')[0] == "go" && PlayerCommand.ToLower().Split(' ')[1] != "into") ||
                            PlayerCommand.ToLower().Split(' ')[0] == "move" ||
                            PlayerCommand.ToLower().Split(' ')[0] == "travel" ||
                            PlayerCommand.ToLower() == "north" ||
                            PlayerCommand.ToLower() == "east" ||
                            PlayerCommand.ToLower() == "south" ||
                            PlayerCommand.ToLower() == "west"
                        )
                {
                    if (!CurrentRoom.LockedIn)
                    {
                        int[] ProposedMove = new int[3];
                        ProposedMove[0] = Player.CurrentPos[0];
                        ProposedMove[1] = Player.CurrentPos[1];
                        ProposedMove[2] = Player.CurrentPos[2];
                        string Direction = string.Empty;
                        if (PlayerCommand.ToLower().Split(' ')[0] == "go" || PlayerCommand.ToLower().Split(' ')[0] == "move" || PlayerCommand.ToLower().Split(' ')[0] == "travel") Direction = PlayerCommand.ToLower().Split(' ')[1];
                        else Direction = PlayerCommand.ToLower();

                        switch (Direction)
                        {
                            case "north": ProposedMove[0] = ProposedMove[0] - 1; break;
                            case "east": ProposedMove[1] = ProposedMove[1] + 1; break;
                            case "south": ProposedMove[0] = ProposedMove[0] + 1; break;
                            case "west": ProposedMove[1] = ProposedMove[1] - 1; break;
                            default: ProposedMove = Player.CurrentPos; break;
                        }

                        ThisFloor.CurrentFloor[ProposedMove[0], ProposedMove[1]].Explored = true;
                        PotentialRoom = GetRoomInfo(ProposedMove);
                        if (PotentialRoom.CanMove == true)
                        {
                            if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) LoDConsole.WriteLine(WordWrap("I Successfully move into Row ") + Char.ConvertFromUtf32(ProposedMove[0] + 65) + " Col " + (ProposedMove[1] + 1) + " Level " + (ProposedMove[2] + 1));
                            else LoDConsole.WriteLine(WordWrap(PotentialRoom.Description));
                            ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
                            CurrentRoom = PotentialRoom;
                            Player.CurrentPos = ProposedMove;
                            EventTrigger("moveinto");
                        }
                        else if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) LoDConsole.WriteLine(WordWrap("Looks like I can't go that way."));
                        else LoDConsole.WriteLine(WordWrap(PotentialRoom.Description));
                    }
                    else
                    {
                        LoDConsole.WriteLine("You cannot leave the current area");
                        if (CurrentRoom.Enemy != null) attacked();
                    }
                }
                #endregion

                #region Buildings
                else if ((PlayerCommand.ToLower().Split(' ')[0] == "go" && PlayerCommand.ToLower().Split(' ')[1] == "into") || PlayerCommand.ToLower().Split(' ')[0] == "enter")
                {
                    if (!Player.InBuilding)
                    {
                        if (CurrentRoom.Building.BuildingName != null)
                        {
                            if (!CurrentRoom.LockedIn)
                            {
                                string target = string.Empty;
                                if (PlayerCommand.ToLower().Split(' ')[0] == "go" && PlayerCommand.ToLower().Split(' ')[1] == "into")
                                {
                                    for (int i = 2; i < PlayerCommand.Split(' ').Length; i++)
                                    {
                                        target = target + " " + PlayerCommand.Split(' ')[i];
                                    }
                                }
                                else if (PlayerCommand.ToLower().Split(' ')[0] == "enter")
                                {
                                    for (int i = 1; i < PlayerCommand.Split(' ').Length; i++)
                                    {
                                        target = target + " " + PlayerCommand.Split(' ')[i];
                                    }
                                }
                                target = target.Trim();

                                if (target != string.Empty && target.ToLower() == CurrentRoom.Building.BuildingName.ToLower())
                                {
                                    if (CurrentRoom.Building.CanMove == true)
                                    {
                                        SaveWorld();
                                        CurrentRoom = GoIntoBuilding(CurrentRoom.Building);
                                        LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
                                        EventTrigger("moveinto");
                                    }
                                    else LoDConsole.WriteLine(WordWrap(target + " is locked."));
                                }
                                else if (target != CurrentRoom.Building.BuildingName) LoDConsole.WriteLine(target + " is not something you can enter.");
                                else LoDConsole.WriteLine("Go into where?");
                            }
                            else
                            {
                                LoDConsole.WriteLine("You cannot leave the current area");
                                if (CurrentRoom.Enemy != null) attacked();
                            }
                        }
                        else LoDConsole.WriteLine("There is no building here to enter");
                    }
                    else LoDConsole.WriteLine("You are Already inside a building");
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "leave")
                {
                    if (Player.InBuilding == true)
                    {
                        if (!CurrentRoom.LockedIn)
                        {
                            ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]].Building = LeaveBuilding(CurrentRoom);
                            CurrentRoom = GetRoomInfo(Player.CurrentPos);
                            LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
                            EventTrigger("moveinto");
                        }
                        else
                        {
                            LoDConsole.WriteLine("You cannot leave the current area");
                            if (CurrentRoom.Enemy != null) attacked();
                        }
                    }
                    else LoDConsole.WriteLine(WordWrap("You are not currently inside a building"));
                }
                #endregion

                #region Descriptions
                else if (CommandContains(PlayerCommand, "who am i") || CommandContains(PlayerCommand, "whoami"))
                {
                    LoDConsole.WriteLine(WordWrap(string.Concat("Your name is ", Player.name)));
                }
                else if (CommandContains(PlayerCommand, "status"))
                {
                    PlayerStatus();
                }
                else if (CommandContains(PlayerCommand, "describe"))
                {
                    LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else if (CommandContains(PlayerCommand, "objective"))
                {
                    LoDConsole.WriteLine(WordWrap(string.Concat("Your Current Objective is: ", Player.Objective)));
                }
                else if (CommandContains(PlayerCommand, "money"))
                {
                    LoDConsole.WriteLine("You currently have {0} gold coins", Player.Money.ToString());
                }
                #endregion

                #region Read
                else if (CommandContains(PlayerCommand, "read"))
                {
                    if (CurrentRoom.items != null || Player.inventory.Count != 0)
                    {
                        string target = string.Empty;
                        if (PlayerCommand.ToLower().Split(' ').Length != 1)
                        {
                            for (int i = 1; i < PlayerCommand.ToLower().Split(' ').Length; i++)
                            {
                                target = target + PlayerCommand.ToLower().Split(' ')[i];
                            }
                        }
                        else
                        {
                            target = LoDConsole.ReadLine("What do you want to read?","Read",string.Empty);
                        }
                        LoDConsole.WriteLine(WordWrap(ReadItem(target.Trim())));
                    }
                    else LoDConsole.WriteLine("There is nothing to read");
                }
                #endregion

                #region Inventory
                else if (CommandContains(PlayerCommand, "inventory"))
                {
                    if (Player.inventory.Count != 0)
                    {
                        LoDConsole.WriteLine(WordWrap(string.Concat("You are currently using ", (Player.MaxItems - Player.invspace), "/", Player.MaxItems, " of your inventory\n")));
                        int index = 1;
                        foreach (itemInfo Item in Player.inventory)
                        {
                            LoDConsole.WriteLine(WordWrap(string.Concat(index, ": ", Item.Name)));
                            index++;
                        }
                        LoDConsole.WriteLine("");
                    }
                    else LoDConsole.WriteLine("Your inventory is empty");
                }
                #endregion

                #region Ask
                else if (CommandContains(PlayerCommand, "ask about"))
                {
                    string Target = string.Empty;
                    string Topic = string.Empty;
                    bool topicstart = false;

                    if (PlayerCommand.ToLower().Contains("about"))
                    {
                        for (int i = 1; i < PlayerCommand.Split(' ').Length; i++)
                        {
                            if (PlayerCommand.Split(' ')[i].ToLower() == "about")
                            {
                                topicstart = true;
                            }
                            else if (topicstart == false)
                            {
                                Target = Target + " " + PlayerCommand.Split(' ')[i];
                            }
                            else if (topicstart == true)
                            {
                                Topic = Topic + " " + PlayerCommand.Split(' ')[i];
                            }
                        }
                        AskQuestion(Target.Trim(), Topic.Trim());
                    }
                    else LoDConsole.WriteLine(WordWrap("Ask who about what?"));
                }
                #endregion

                #region Take Item
                else if (CommandContains(PlayerCommand, "take") || CommandContains(PlayerCommand, "pick") || CommandContains(PlayerCommand, "get"))
                {
                    string ObjectName = string.Empty;
                    if (Player.invspace > 0)
                    {
                        if (PlayerCommand.ToLower() == "take" || PlayerCommand.ToLower() == "pick" || PlayerCommand.ToLower() == "pick up" || PlayerCommand.ToLower() == "get")
                        {
                            LoDConsole.Write("What do you want to pick up?: ");
                            ObjectName = LoDConsole.ReadLine("What do you want to pick up?", "Pick Up", string.Empty);
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            int index = 2;
                            if (strArray[0].ToLower() == "take" || strArray[0].ToLower() == "get")
                            {
                                index = 2;
                                ObjectName = strArray[1];
                            }
                            else if (strArray[0] == "pick" && strArray[1] == "up")
                            {
                                index = 3;
                                ObjectName = strArray[2];
                            }

                            while (index < strArray.Length)
                            {
                                ObjectName = string.Concat(ObjectName, " ", strArray[index]);
                                index++;
                                //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                            }
                            ObjectName = ObjectName.Trim();
                        }
                        TakeItem(ObjectName);
                    }
                    else LoDConsole.WriteLine("There is no space in your inventory to pick anything up");
                }
                #endregion

                #region DropItem
                else if (CommandContains(PlayerCommand, "drop"))
                {
                    if (Player.inventory.Count != 0)
                    {
                        string ObjectName = string.Empty;

                        if (PlayerCommand.ToLower() == "drop")
                        {
                            int index = 1;
                            foreach (itemInfo Item in Player.inventory)
                            {
                                LoDConsole.WriteLine(WordWrap(string.Concat(index, ": ", Item.Name)));
                                index++;
                            }

                            ObjectName = LoDConsole.ReadLine("Which item do you wish to drop", "Drop Item", string.Empty); 
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            ObjectName = strArray[1];

                            int index = 2;
                            while (index < strArray.Length)
                            {
                                ObjectName = string.Concat(ObjectName, " ", strArray[index]);
                                index++;
                                //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                            }

                            ObjectName = ObjectName.Trim();

                        }
                        LoDConsole.WriteLine(WordWrap(DropItem(ObjectName)));

                    }
                    else
                        LoDConsole.WriteLine(WordWrap("There are no items in your inventory"));
                }
                #endregion

                #region Look At Item
                else if (CommandContains(PlayerCommand, "look at"))
                {
                    string ObjectName = string.Empty;

                    if (PlayerCommand.ToLower() == "look at")
                    {
                        ObjectName = LoDConsole.ReadLine("What do you want to look at?", "Look At", string.Empty);
                    }
                    else
                    {
                        string[] strArray = PlayerCommand.Split(' ');
                        ObjectName = strArray[2];

                        int index = 3;
                        while (index < strArray.Length)
                        {
                            ObjectName = string.Concat(ObjectName, " ", strArray[index]);
                            index++;
                            //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                        }

                        ObjectName = ObjectName.Trim();
                    }

                    LoDConsole.WriteLine(WordWrap(LookAtItem(ObjectName)));
                }
                #endregion

                #region Examine Item
                else if (CommandContains(PlayerCommand, "examine") || CommandContains(PlayerCommand, "inspect"))
                {
                    if (Player.inventory.Count != 0)
                    {
                        string ObjectName = string.Empty;

                        if (PlayerCommand.ToLower() == "examine" || PlayerCommand.ToLower() == "inspect")
                        {
                            int index = 1;
                            foreach (itemInfo Item in Player.inventory)
                            {
                                LoDConsole.WriteLine(WordWrap("{0}: {1}"), index.ToString(), Item.Name);
                                index++;
                            }
                            ObjectName = LoDConsole.ReadLine("What item do you want to examine?", "Examine", string.Empty);
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            ObjectName = strArray[1];

                            int index = 2;
                            while (index < strArray.Length)
                            {
                                ObjectName = string.Concat(ObjectName, " ", strArray[index]);
                                index++;
                                //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                            }

                            ObjectName = ObjectName.Trim();

                        }
                        ExamineItem(ObjectName);
                    }
                    else
                        LoDConsole.WriteLine(WordWrap("There are no items in your inventory"));
                }
                #endregion

                #region Use Item
                else if (CommandContains(PlayerCommand, "use") || CommandContains(PlayerCommand, "put"))
                {
                    int index = 0;
                    string item = string.Empty;
                    string target = string.Empty;

                    if (CurrentRoom.items != null)
                    {

                        if (PlayerCommand.ToLower() == "use" || PlayerCommand.ToLower() == "put")
                        {
                            item = LoDConsole.ReadLine("What item do you want to " + PlayerCommand.ToLower().Split(' ')[0] + "?", PlayerCommand.ToLower().Split(' ')[0], string.Empty);
                            target = LoDConsole.ReadLine("What do you want to " + PlayerCommand.ToLower().Split(' ')[0] + " " + item + " on?", "Target", string.Empty);
                        }
                        else if (CurrentRoom.items != null)
                        {
                            item = PlayerCommand.Split(' ')[1];
                            bool itemFound = false;
                            bool targetFound = false;
                            index = 2;

                            while (index < (PlayerCommand.Split(' ').Length))
                            {
                                if (PlayerCommand.Split(' ')[index].ToLower() == "on" || PlayerCommand.Split(' ')[index].ToLower() == "in")
                                {
                                    itemFound = true;
                                    index++;
                                    target = PlayerCommand.Split(' ')[index].ToLower();
                                    targetFound = true;
                                }
                                else if (itemFound == false)
                                {
                                    item = string.Concat(item, " ", PlayerCommand.Split(' ')[index].ToLower());
                                }
                                else
                                {
                                    target = string.Concat(target, " ", PlayerCommand.Split(' ')[index].ToLower());
                                }
                                index++;
                            }

                            if (targetFound == false)
                            {
                                LoDConsole.WriteLine("Objects in the room:\n");

                                for (index = 0; index < CurrentRoom.items.Count; index++)
                                {
                                    //if (CurrentRoom.items[index].Class == "Interaction Object") LoDConsole.WriteLine(string.Concat(CurrentRoom.items[index].Name)); 
                                    LoDConsole.WriteLine(string.Concat(CurrentRoom.items[index].Name));

                                }
                                target = LoDConsole.ReadLine("What do you want to use " + item + " on?", "Target", string.Empty);
                            }
                        }
                        UseItem(item, target);
                    }
                    else
                    {
                        LoDConsole.WriteLine("There is nothing in the room to interact with");
                    }

                }
                #endregion

                #region View Wares
                else if (CommandContains(PlayerCommand, "view wares"))
                {
                    int index;
                    string VendorName;

                    if (CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower().Split(' ').Length > 2)
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            VendorName = strArray[2];

                            index = 3;
                            while (index < strArray.Length)
                            {
                                VendorName = string.Concat(VendorName, " ", strArray[index]);
                                index++;
                                //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                            }

                            VendorName = VendorName.Trim();
                        }
                        else
                        {
                            LoDConsole.WriteLine("Civilians in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                if (CurrentRoom.Civilians[index].willSell == true) LoDConsole.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                            }
                            VendorName = LoDConsole.ReadLine("Who do you want to view the inventory of?", "View Wares", string.Empty);
                        }

                        bool vendorFound = false;
                        index = 0;

                        while (vendorFound == false && CurrentRoom.Civilians != null && index < CurrentRoom.Civilians.Count)
                        {
                            if (VendorName.ToLower() == CurrentRoom.Civilians[index].name.ToLower())
                            {
                                if (CurrentRoom.Civilians[index].willSell == true)
                                {
                                    vendorFound = true;
                                    LoDConsole.WriteLine();
                                    LoDConsole.WriteLine("Item\t\t\tClass\t\t\tPrice");
                                    for (int Count = 0; Count < CurrentRoom.Civilians[index].inventory.Count; Count++)
                                    {
                                        if (CurrentRoom.Civilians[index].inventory[Count].Name == null) LoDConsole.Write("null\t\t");
                                        if (CurrentRoom.Civilians[index].inventory[Count].Name.Length < 8) LoDConsole.Write("{0}\t\t", CurrentRoom.Civilians[index].inventory[Count].Name);
                                        else if (CurrentRoom.Civilians[index].inventory[Count].Name.Length <= 15) LoDConsole.Write("{0}\t", CurrentRoom.Civilians[index].inventory[Count].Name);
                                        else LoDConsole.Write(CurrentRoom.Civilians[index].inventory[Count].Name);

                                        if (CurrentRoom.Civilians[index].inventory[Count].Class == null) LoDConsole.Write("null\t\t\t");
                                        else if (CurrentRoom.Civilians[index].inventory[Count].Class.Length < 8) LoDConsole.Write("{0}\t\t\t", CurrentRoom.Civilians[index].inventory[Count].Class);
                                        else if (CurrentRoom.Civilians[index].inventory[Count].Class.Length <= 15) LoDConsole.Write("{0}\t\t", CurrentRoom.Civilians[index].inventory[Count].Class);
                                        else if (CurrentRoom.Civilians[index].inventory[Count].Class.Length <= 21) LoDConsole.Write("{0}\t", CurrentRoom.Civilians[index].inventory[Count].Class);
                                        else LoDConsole.Write(CurrentRoom.Civilians[index].inventory[Count].Class);

                                        if (CurrentRoom.Civilians[index].inventory[Count].Value != 0) LoDConsole.Write("\t{0}\n", CurrentRoom.Civilians[index].inventory[Count].Value.ToString());
                                        else LoDConsole.Write("\tnull\n");
                                        //LoDConsole.WriteLine(WordWrap(string.Concat(CurrentRoom.Civilians[index].inventory[Count].Name, "\t", CurrentRoom.Civilians[index].inventory[Count].Class, "\t",CurrentRoom.Civilians[index].inventory[Count].Value)));
                                    }
                                }
                                else LoDConsole.WriteLine(WordWrap(string.Concat(CurrentRoom.Civilians[index].name, " is not willing to sell you anything")));
                            }
                            index++;
                        }
                        if (!vendorFound) LoDConsole.WriteLine(VendorName + " is either not here or not a merchant");
                    }
                    else LoDConsole.WriteLine("There is nobody currently selling anything in this area");

                }
                #endregion

                #region Bribe
                else if (CommandContains(PlayerCommand, "bribe"))
                {
                    int index;
                    string WhoToBribe = string.Empty;
                    int BribeAmount = 0;
                    bool dontrun = false;

                    if (CurrentRoom.Enemy != null || CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower() == "bribe")
                        {
                            LoDConsole.WriteLine("People in the room who may accept a bribe:\n");
                            if (CurrentRoom.Enemy != null)
                            {
                                 for (index = 0; index < CurrentRoom.Enemy.Count; index++)
                                {
                                    LoDConsole.WriteLine(CurrentRoom.Enemy[index].name);
                                }
                            }

                            if (CurrentRoom.Civilians != null)
                            {
                                for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                                {
                                    LoDConsole.WriteLine(CurrentRoom.Civilians[index].name);
                                }
                            }
                            WhoToBribe = LoDConsole.ReadLine("Who do you want to bribe?", "Bribe", string.Empty);
                            Int32.TryParse(LoDConsole.ReadLine("How much do you want to give them?","Bribe Amount","0"), out BribeAmount);
                            if (BribeAmount == 0)
                            {
                                dontrun = true;
                                LoDConsole.WriteLine("You cannot bribe somebody with that amount");
                            }
                        }
                        else if (PlayerCommand.Split(' ')[0].ToLower() == "bribe")
                        {
                            WhoToBribe = PlayerCommand.Split(' ')[1];
                            int i = 2;
                            int n;
                            bool AmountFound = false;
                            while (AmountFound == false && i < PlayerCommand.Split(' ').Length)
                            {
                                if (Int32.TryParse(PlayerCommand.Split(' ')[i], out n))
                                {
                                    BribeAmount = n;
                                    AmountFound = true;
                                }
                                else WhoToBribe = string.Concat(WhoToBribe, " ", PlayerCommand.Split(' ')[i]);
                                i++;
                            }
                            if (AmountFound == false)
                            {
                                Int32.TryParse(LoDConsole.ReadLine("How much do you want to give to " + WhoToBribe + "?", "Bribe Amount", "0"), out BribeAmount);
                            }
                            if (BribeAmount == 0)
                            {
                                dontrun = true;
                                LoDConsole.WriteLine("You cannot bribe somebody with that amount");
                            }
                        }
                        else
                        {
                            dontrun = true;
                            LoDConsole.WriteLine(WordWrap("I can't quite work out how many things you just said, try again"));
                        }

                        if (dontrun == false)
                        {
                            if (isEnemy(WhoToBribe)) PayOff(WhoToBribe, BribeAmount);
                            else if (isNPC(WhoToBribe)) GiveItem(BribeAmount + " gold", WhoToBribe);
                            else LoDConsole.WriteLine("That person does not appear to be here...");
                        }

                    }
                    else LoDConsole.WriteLine(WordWrap("There are no people in the room to bribe"));
                }
                #endregion

                #region Buy Item
                else if (CommandContains(PlayerCommand, "buy"))
                {
                    int index;
                    string vendor = string.Empty;
                    string ItemName = string.Empty;

                    if (Player.invspace > 0)
                    {
                        if (CurrentRoom.Civilians != null)
                        {
                            if (PlayerCommand.ToLower() == "buy")
                            {
                                ItemName = LoDConsole.ReadLine("What item do you want to buy?", "Buy Item", string.Empty);


                                //player didn't specify item or person
                                LoDConsole.WriteLine("Civilians in the room:\n");

                                for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                                {
                                    if (CurrentRoom.Civilians[index].willSell == true) LoDConsole.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                                }
                                vendor = ItemName = LoDConsole.ReadLine("Who do you want to buy from?", "Merchants", string.Empty);

                            }
                            else if (PlayerCommand.Split(' ').Length >= 2)
                            {
                                //ItemName = PlayerCommand.Split(' ')[1].ToLower();
                                ItemName = PlayerCommand.Split(' ')[1].ToLower();
                                bool itemFound = false;
                                bool vendorFound = false;
                                index = 2;

                                while (index < (PlayerCommand.Split(' ').Length))
                                {
                                    if (PlayerCommand.Split(' ')[index].ToLower() == "from")
                                    {
                                        itemFound = true;
                                        index++;
                                        vendor = PlayerCommand.Split(' ')[index].ToLower();
                                        vendorFound = true;
                                    }
                                    else if (itemFound == false)
                                    {
                                        ItemName = string.Concat(ItemName, " ", PlayerCommand.Split(' ')[index].ToLower());
                                    }
                                    else
                                    {
                                        vendor = string.Concat(vendor, " ", PlayerCommand.Split(' ')[index].ToLower());
                                    }
                                    index++;
                                }

                                if (vendorFound == false)
                                {
                                    LoDConsole.WriteLine("Civilians in the room:\n");

                                    for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                                    {
                                        if (CurrentRoom.Civilians[index].willSell == true) LoDConsole.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                                    }
                                    vendor = LoDConsole.ReadLine("Who do you want to buy " + ItemName + " from?", "Merchants", string.Empty);
                                }

                            }
                            BuyItem(ItemName, vendor);
                        }
                        else LoDConsole.WriteLine("There is nobody willing to buy anything from you here");
                    }
                    else LoDConsole.WriteLine("There is no space in your inventory to buy anything.");
                }
                #endregion

                #region Sell Item
                else if (CommandContains(PlayerCommand, "sell"))
                {
                    int index;
                    string vendor = string.Empty;
                    string ItemName = string.Empty;
                    itemInfo ItemToSell = new itemInfo();

                    if (CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower() == "sell")
                        {
                            LoDConsole.Write(" ");
                            ItemName = LoDConsole.ReadLine("What item do you want to sell?", "Sell Item", string.Empty);

                            index = 0;
                            bool itemfound = false;

                            while (itemfound == false && index < Player.inventory.Count)
                            {
                                if (ItemName.ToLower() == Player.inventory[index].Name.ToLower())
                                {
                                    itemfound = true;
                                    ItemToSell = Player.inventory[index];
                                }
                                index++;
                            }

                            //player didn't specify item or person
                            LoDConsole.WriteLine("Civilians in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                if (CurrentRoom.Civilians[index].willBuy == true) LoDConsole.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                            }
                            vendor = LoDConsole.ReadLine("Who do you want to sell to?", "Merchants", string.Empty);

                        }
                        else if (PlayerCommand.Split(' ').Length >= 2)
                        {
                            //ItemName = PlayerCommand.Split(' ')[1].ToLower();
                            ItemName = PlayerCommand.Split(' ')[1].ToLower();
                            bool itemFound = false;
                            bool vendorFound = false;
                            index = 2;

                            while (index < (PlayerCommand.Split(' ').Length))
                            {
                                if (PlayerCommand.Split(' ')[index].ToLower() == "to")
                                {
                                    itemFound = true;
                                    index++;
                                    vendor = PlayerCommand.Split(' ')[index].ToLower();
                                    vendorFound = true;
                                }
                                else if (itemFound == false)
                                {
                                    ItemName = string.Concat(ItemName, " ", PlayerCommand.Split(' ')[index].ToLower());
                                }
                                else
                                {
                                    vendor = string.Concat(vendor, " ", PlayerCommand.Split(' ')[index].ToLower());
                                }
                                index++;
                            }

                            index = 0;
                            itemFound = false;

                            while (itemFound == false && index < Player.inventory.Count)
                            {
                                if (ItemName.ToLower() == Player.inventory[index].Name.ToLower())
                                {
                                    itemFound = true;
                                    ItemToSell = Player.inventory[index];
                                }
                                index++;
                            }

                            if (itemFound == true && vendorFound == false)
                            {
                                LoDConsole.WriteLine("Civilians in the room:\n");

                                for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                                {
                                    if (CurrentRoom.Civilians[index].willBuy == true) LoDConsole.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                                }
                                vendor = LoDConsole.ReadLine("Who do you want to sell "+ItemName+" to?", "Merchants", string.Empty);
                            }
                        }
                        SellItem(ItemToSell, vendor);
                    }
                    else LoDConsole.WriteLine("There is nobody willing to buy anything from you here");
                }
                #endregion

                #region Give Item
                else if (CommandContains(PlayerCommand, "give"))
                {
                    string itemName = string.Empty;
                    string targetNPC = string.Empty;
                    bool itemFound = false;

                    for (int i = 1; i < PlayerCommand.Split(' ').Length; i++)
                    {
                        if (PlayerCommand.Split(' ')[i].ToLower() == "to") itemFound = true;
                        else if (!itemFound) itemName = itemName + " " + PlayerCommand.Split(' ')[i];
                        else targetNPC = targetNPC + " " + PlayerCommand.Split(' ')[i];
                    }
                    if (!string.IsNullOrEmpty(itemName) && string.IsNullOrEmpty(targetNPC))
                    {
                        targetNPC = LoDConsole.ReadLine("Who do you want to give " + itemName.Trim() + " to?", "Give Item", string.Empty);

                    }
                    else if (!itemFound && targetNPC == string.Empty)
                    {
                        itemName = LoDConsole.ReadLine("Who do you want to give?", "Give Item", string.Empty);
                        targetNPC = LoDConsole.ReadLine("Who do you want to give " + itemName.Trim() + " to?", "Give Item", string.Empty);
                    }
                    //if (itemName.Trim().ToLower() == "gold") LoDConsole.WriteLine(WordWrap("You cannot gift gold at this time"));
                    else GiveItem(itemName.Trim(), targetNPC.Trim());
                }
                #endregion

                #region Talk to
                else if (CommandContains(PlayerCommand, "talk"))
                {
                    int index;
                    string NPCname = string.Empty;

                    if (CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower() == "talk to" || PlayerCommand.ToLower() == "talk")
                        {
                            LoDConsole.WriteLine("Non-Hostile people in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                LoDConsole.WriteLine(WordWrap(CurrentRoom.Civilians[index].name));
                            }
                            LoDConsole.Write("\nWho do you want to talk to? ");
                            NPCname = LoDConsole.ReadLine("Who do you want to talk to?", "Talk", string.Empty);
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            foreach (string word in strArray) { if (word != "to" && word != "talk") NPCname = string.Concat(NPCname, " ", word); }
                        }
                        if (NPCname == string.Empty) LoDConsole.WriteLine("Talk to who?");
                        else LoDConsole.WriteLine(WordWrap(TalkToNPC(NPCname.Trim())));
                    }
                    else
                    {
                        LoDConsole.WriteLine("There are no non-hostile people to talk to");
                    }
                }
                #endregion

                #region Suicide
                else if (PlayerCommand.Contains("suicide") || PlayerCommand.ToLower() == "attack self" || PlayerCommand.ToLower() == "hit self" || PlayerCommand.ToLower() == string.Concat("hit ", Player.name.ToLower()) || PlayerCommand.ToLower() == string.Concat("attack ", Player.name.ToLower()) || PlayerCommand.ToLower() == "kill self")
                {
                    if (PlayerCommand.Contains("suicide") && CurrentRoom.SuicideAction != null) LoDConsole.WriteLine(WordWrap(CurrentRoom.SuicideAction));
                    else LoDConsole.WriteLine(WordWrap("You raise your weapon above your head. Screaming in blind rage for some unknown reason. You strike yourself until you die"));
                    Player.HPBonus = 0;
                    //LoDConsole.WriteLine("I GET HERE, and my health is {0}", Player.HPBonus);
                }
                #endregion

                #region Attack
                else if (CommandContains(PlayerCommand, "attack") || CommandContains(PlayerCommand, "hit") || CommandContains(PlayerCommand, "fight"))
                {
                    string enemy;
                    int index;
                    bool enemyfound = false;

                    if (CurrentRoom.Enemy != null && CurrentRoom.Enemy.Count > 0)
                    {
                        if (PlayerCommand.ToLower() == "attack" || PlayerCommand.ToLower() == "hit" || PlayerCommand.ToLower() == "fight")
                        {
                            LoDConsole.WriteLine(WordWrap("Enemies in room:\n"));
                            for (index = 0; index < CurrentRoom.Enemy.Count; index++)
                            {
                                LoDConsole.WriteLine(WordWrap(CurrentRoom.Enemy[index].name));
                            }
                            enemy = LoDConsole.ReadLine("Who do you want to attack?", "Combat", string.Empty);

                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            enemy = strArray[1];
                            for (int i = 2; i < strArray.Length; i++)
                            {
                                enemy = enemy + " " + strArray[i];
                            }

                        }
                        index = 0;
                        while (CurrentRoom.Enemy != null && index < CurrentRoom.Enemy.Count && enemyfound == false)
                        {
                            if (CurrentRoom.Enemy[index].name.ToLower() == enemy.ToLower())
                            {
                                Combat(Player.WeaponHeld, enemy);
                                enemyfound = true;
                            }
                            index++;
                        }
                        if (enemyfound == false) LoDConsole.WriteLine(WordWrap(string.Concat("Could not find ", enemy, " in the area")));
                    }
                    else if (CurrentRoom.Civilians != null && CurrentRoom.Civilians.Count > 0)
                    {
                        if (PlayerCommand.ToLower() == "attack" || PlayerCommand.ToLower() == "hit" || PlayerCommand.ToLower() == "fight")
                        {
                            enemy = LoDConsole.ReadLine("Who do you want to attack?", "Give Item", string.Empty);
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            enemy = strArray[1];
                            for (int i = 2; i < strArray.Length; i++)
                            {
                                enemy = enemy + " " + strArray[i];
                            }
                        }
                        StartFight(enemy);
                    }
                    else
                        LoDConsole.WriteLine(WordWrap("There is nobody in the room to fight"));
                }
                #endregion

                #region Equip/Wear
                else if (CommandContains(PlayerCommand, "equip") || CommandContains(PlayerCommand, "wear"))
                {
                    EquipItem(PlayerCommand);
                }
                #endregion

                #region Eat/Drink
                else if (CommandContains(PlayerCommand, "eat") || CommandContains(PlayerCommand, "drink") || CommandContains(PlayerCommand, "consume"))
                {
                    if (Player.inventory.Count != 0)
                    {
                        int index;
                        string ObjectName = string.Empty;

                        if (PlayerCommand.ToLower() == "eat" || PlayerCommand.ToLower() == "drink" || PlayerCommand.ToLower() == "consume")
                        {
                            LoDConsole.WriteLine("Food in your inventory:\n");
                            foreach (itemInfo Item in Player.inventory)
                            {
                                if (Item.Class == "Food" || Item.Class == "Drink")
                                {
                                    LoDConsole.WriteLine(WordWrap(Item.Name));
                                }
                            }
                            ObjectName = LoDConsole.ReadLine("Which item do you want to consume?", "Consume", string.Empty);
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            ObjectName = strArray[1];

                            index = 2;
                            while (index < strArray.Length)
                            {
                                ObjectName = string.Concat(ObjectName, " ", strArray[index]);
                                index++;
                                //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                            }
                            ObjectName = ObjectName.Trim();
                        }
                        LoDConsole.WriteLine(WordWrap(ConsumeItem(ObjectName)));
                    }
                    else LoDConsole.WriteLine("Your inventory is empty");
                }
                #endregion

                #region Sleep
                else if (CommandContains(PlayerCommand, "sleep") || CommandContains(PlayerCommand, "sleep in") || CommandContains(PlayerCommand, "go to sleep"))
                {
                    int index = 0;
                    string bedItem = string.Empty;

                    if (PlayerCommand.ToLower() == "sleep in" || PlayerCommand.ToLower() == "sleep")
                    {

                        bedItem = LoDConsole.ReadLine("Who do you want to sleep in?", "Give Item", string.Empty);
                    }
                    else if (PlayerCommand.ToLower().Split(' ').Length > 2 && PlayerCommand.ToLower().Split(' ')[0] == "sleep" && PlayerCommand.ToLower().Split(' ')[1] == "in")
                    {
                        string[] strArray = PlayerCommand.Split(' ');
                        bedItem = strArray[2];

                        index = 3;
                        while (index < strArray.Length)
                        {
                            bedItem = string.Concat(bedItem, " ", strArray[index]);
                            index++;
                            //LoDConsole.WriteLine(WordWrap("item is {0}", item);
                        }
                        bedItem = bedItem.Trim();
                    }
                    //LoDConsole.WriteLine("Trying to sleep in {0}", bedItem);
                    Rest(bedItem);
                }
                #endregion

                #region Map
                else if ((CommandContains(PlayerCommand, "map")))
                {
                    DrawMap();
                }
                #endregion

                #region Time
                else if (CommandContains(PlayerCommand, "time"))
                {
                    TimeSpan ts = TimeSpan.FromMinutes(WorldState.WorldTime);
                    LoDConsole.WriteLine("The time is " + ts.ToString("hh':'mm"));
                }
                #endregion

                #region Music
                else if (PlayerCommand.ToLower() == "music browse")
                {
                    Music("browse");
                }
                else if (PlayerCommand.ToLower() == "music start")
                {
                    Music("start");
                }
                else if (PlayerCommand.ToLower() == "music stop")
                {
                    Music("stop");
                }
                #endregion

                #region Control
                else if (PlayerCommand.ToLower() == "clear")
                {
                    LoDConsole.Clear();
                    LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else if (PlayerCommand.ToLower() == "main menu" || PlayerCommand.ToLower() == "mainmenu")
                {
                    //Run the main menu screen
                    lock (myLock) { stopTime = 0; } //Pause the clock
                    DrawMainMenu();
                    lock (myLock) { stopTime = 1; } //Start the clock
                    //ThisFloor = world[Player.CurrentPos[2]];
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);
                    LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else if (CommandContains(PlayerCommand, "save"))
                {
                    string success = SaveGame();
                    LoDConsole.WriteLine(WordWrap(string.Concat("Save ", success)));
                }
                else if (PlayerCommand.ToLower() == "quit" || PlayerCommand.ToLower() == "exit")
                {
                    LoDConsole.WriteLine("Quitting game");
                    QuitGame();
                }

                #endregion

                #region Easter Eggs

                else if (CommandContains(PlayerCommand, "typical"))
                {
                    LoDConsole.WriteLine("I know right?\n");
                }
                #endregion

                #region Debugging

                else if (DebugEnabled == true)
                {
                    if (CommandContains(PlayerCommand, "getpos"))
                    {
                        LoDConsole.WriteLine("Row {0}, Col {1}, Level {2}", Char.ConvertFromUtf32(Player.CurrentPos[0] + 65), (Player.CurrentPos[1] + 1).ToString(), (Player.CurrentPos[2] + 1).ToString());
                    }
                    else if (CommandContains(PlayerCommand, "movepos"))
                    {
                        SaveWorld();
                        string[] Command = PlayerCommand.Split(' ');
                        bool fail = false;
                        int[] NewCoods = new int[3];

                        int Row;
                        if (Int32.TryParse(Command[1], out Row)) NewCoods[0] = Row;
                        else
                        {
                            char ThisChar = Command[1].ToUpper().ToCharArray()[0];
                            int temp = (int)Convert.ToChar(ThisChar);
                            temp = temp - 65;
                            NewCoods[0] = temp;
                        }

                        int Col;
                        if (Int32.TryParse(Command[2], out Col)) NewCoods[1] = Col - 1;
                        else fail = true;

                        int Floor;
                        if (Int32.TryParse(Command[3], out Floor)) NewCoods[2] = Floor - 1;
                        else fail = true;

                        if (!fail)
                        {
                            Player.CurrentPos[0] = NewCoods[0];
                            Player.CurrentPos[1] = NewCoods[1];
                            Player.CurrentPos[2] = NewCoods[2];

                            CurrentRoom = GetRoomInfo(Player.CurrentPos);
                            LoDConsole.WriteLine(CurrentRoom.Description);
                            EventTrigger("moveinto");
                        }
                        else LoDConsole.WriteLine("Command Failed");

                    }
                    else LoDConsole.WriteLine(WordWrap("Command not found, type help for a list of valid commands"));
                }
                else LoDConsole.WriteLine(WordWrap("Command not found, type help for a list of valid commands"));
            }
            catch (Exception ex)
            {
                string FileName = DateTime.Now.ToString(@"dd-MM-yyyy HHmmss");

                LoDConsole.WriteLine(WordWrap("\nYou have encountered an error.\nThe game engine was not able to handle the command you entered."));
                LoDConsole.WriteLine(WordWrap("\nAn error report has been created in .\\Errors\\" + FileName + ".txt\nPlease submit this to the developer"));

                if (!Directory.Exists(".\\Errors")) Directory.CreateDirectory(".\\Errors");
                using (StreamWriter file = new System.IO.StreamWriter(@".\Errors\" + FileName + ".txt", true))
                {
                    file.WriteLine("---Legend-Of-Drongo---");
                    file.WriteLine("");
                    file.WriteLine("Error logged at {0}", DateTime.Now.ToString(@"dd-MM-yyyy HH:mm:ss"));
                    file.WriteLine("");
                    file.WriteLine("Player Location: Row {0}, Col {1}, Level {2}\n\n", Char.ConvertFromUtf32(Player.CurrentPos[0] + 65), (Player.CurrentPos[1] + 1), (Player.CurrentPos[2] + 1));
                    file.WriteLine("Command Entered: {0}\n\n", PlayerCommand);
                    file.WriteLine("");
                    file.WriteLine("");

                    Random rng = new Random();
                    int output = rng.Next(1, 3);
                    switch (output)
                    {
                        case 1: file.WriteLine("The stacktrace output can be scary, do not say the words out loud as you may summon a demon!"); break;
                        case 2: file.WriteLine("The stacktrace output can be scary, some say it can read your very soul!"); break;
                        case 3: file.WriteLine("The stacktrace output can be scary, don't believe it's lies about being sentient!"); break;
                    }

                    file.WriteLine("Error Message: {0}", ex.Message);
                    file.WriteLine("Stacktrace:");
                    file.WriteLine(ex.StackTrace);
                    file.WriteLine("");
                    file.WriteLine("");
                    file.WriteLine("End of line...");

                }

            }
                #endregion

            #region Level Up

            int XP = Player.XP;
            int Level = Player.Level;
            if (XP > 1000 && Level < 2) LevelUp(2);
            else if (XP > 2250 && Level < 3) LevelUp(3);
            else if (XP > 3750 && Level < 4) LevelUp(4);
            else if (XP > 5500 && Level < 5) LevelUp(5);
            else if (XP > 7500 && Level < 6) LevelUp(6);
            else if (XP > 10000 && Level < 7) LevelUp(7);
            else if (XP > 13000 && Level < 8) LevelUp(8);
            else if (XP > 16500 && Level < 9) LevelUp(9);
            else if (XP > 20500 && Level < 10) LevelUp(10);
            else if (XP > 26000 && Level < 11) LevelUp(11);
            else if (XP > 32000 && Level < 12) LevelUp(12);
            else if (XP > 39000 && Level < 13) LevelUp(13);
            else if (XP > 47000 && Level < 14) LevelUp(14);
            else if (XP > 57000 && Level < 15) LevelUp(15);
            else if (XP > 69000 && Level < 16) LevelUp(16);
            else if (XP > 83000 && Level < 17) LevelUp(17);
            else if (XP > 99000 && Level < 18) LevelUp(18);
            else if (XP > 119000 && Level < 19) LevelUp(19);
            else if (XP > 143000 && Level < 20) LevelUp(20);
            else if (XP > 175000 && Level < 21) LevelUp(21);
            else if (XP > 210000 && Level < 22) LevelUp(22);
            else if (XP > 255000 && Level < 23) LevelUp(23);
            else if (XP > 310000 && Level < 24) LevelUp(24);
            else if (XP > 375000 && Level < 25) LevelUp(25);
            else if (XP > 450000 && Level < 26) LevelUp(26);
            else if (XP > 550000 && Level < 27) LevelUp(27);
            else if (XP > 675000 && Level < 28) LevelUp(28);
            else if (XP > 825000 && Level < 29) LevelUp(29);
            else if (XP > 1000000 && Level < 30) LevelUp(30);


            #endregion

            #region GameOver
            if (Player.HPBonus <= 0)
            {
                if (Player.CurrentPos[2] == 0)
                {
                    lock (myLock) { stopTime = 0; }

                    LoDConsole.WriteLine("\n\n     Your adventure has come to an end :(");
                    Thread.Sleep(5000);

                    DrawMainMenu();
                    lock (myLock) { stopTime = 1; }
                    ThisFloor = world[Player.CurrentPos[2]];
                    CurrentRoom = ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]];
                    LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else
                {
                    LoDConsole.WriteLine("\n\n     You have died, but this is not the end...");
                    Thread.Sleep(5000);
                    LoDConsole.Clear();
                    LoDConsole.WriteLine(WordWrap("\n\n\tYou fall through darkness and smoke\n\tuntil you feel your feet softly make contact with ground"));

                    Player.HPBonus = 60;
                    world[(Player.CurrentPos[2])] = ThisFloor;
                    Player.CurrentPos[0] = 1;
                    Player.CurrentPos[1] = 1;      //set coodinates of afterlife
                    Player.CurrentPos[2] = 0;
                    ThisFloor = world[0];
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);
                    EventTrigger("moveinto");
                }
            }
            #endregion

            LoDConsole.DrawEnvironment(CurrentRoom);
        }

        #region Movement Functions

        public static roomInfo GetRoomInfo(int[] UserPos)
        {
            //SaveWorld();

            roomInfo ThisRoom = new roomInfo();

            //ThisFloor = world[UserPos[2]];

            ThisFloor = world[UserPos[2]];

            DataTypes dt = new DataTypes();
            if (Player.InBuilding) ThisRoom = dt.BuildingIntoRoom(ThisFloor.CurrentFloor[UserPos[0], UserPos[1]].Building);
            else ThisRoom = ThisFloor.CurrentFloor[UserPos[0], UserPos[1]];

            return (ThisRoom);
        }

        public static roomInfo GoIntoBuilding(Building thisBuilding)
        {
            LoDConsole.WriteLine("Entering " + thisBuilding.BuildingName);
            //Thread.Sleep(1000);

            DataTypes dt = new DataTypes();
            roomInfo ThisRoom = new roomInfo();
            ThisRoom = dt.BuildingIntoRoom(thisBuilding);
            Player.InBuilding = true;

            return ThisRoom;
        }

        public static Building LeaveBuilding(roomInfo thisRoom)
        {
            Building thisBuilding = new Building();

            LoDConsole.WriteLine("Leaving " + thisRoom.RoomName);
            //Thread.Sleep(1000);

            DataTypes dt = new DataTypes();
            thisBuilding = dt.RoomIntoBuilding(thisRoom);
            Player.InBuilding = false;

            return thisBuilding;
        }

        #endregion

        #region Item Functions

        public static bool IsItemName(itemInfo Item, string Name)
        {
            //will return true if name matches item name or interaction name
            bool itemFound = false;
            int index = 0;

            if (Name.ToLower() == Item.Name.ToLower()) itemFound = true;
            if (Item.InteractionName != null)
            {
                while (itemFound == false && index < Item.InteractionName.Count)
                {
                    if (Name.ToLower() == Item.InteractionName[index].ToLower()) itemFound = true;
                    index++;
                }
            }

            return itemFound;
        }

        public static string LookAtItem(string ObjectName)
        {
            //returns the item description if it is looked at
            string Description = string.Concat("Cannot find ", ObjectName, " in the area");

            if (CurrentRoom.items != null)
            {
                foreach (itemInfo Item in CurrentRoom.items)
                {
                    if (IsItemName(Item, ObjectName) == true)
                    {
                        Description = Item.Examine;
                        break;
                    }
                }
            }
            return (Description);
        }

        public static void ExamineItem(string Objectname)
        {
            int index;
            itemInfo invItem = new itemInfo();

            if (CurrentRoom.items != null) foreach (itemInfo Item in CurrentRoom.items) { if (IsItemName(Item, Objectname)) invItem = Item; }
            if (Player.inventory != null) foreach (itemInfo Item in Player.inventory) { if (IsItemName(Item, Objectname)) invItem = Item; }
            for (index = 0; index < 5; index++)     //Then check the players armor
            {
                if (Player.ArmorWorn[index].Name != null) if (IsItemName(Player.ArmorWorn[index], Objectname)) invItem = Player.ArmorWorn[index];
            }
            if (IsItemName(Player.WeaponHeld, Objectname)) invItem = Player.WeaponHeld;  //Then check their weapon held

            if (invItem.Name != null)
            {
                if (invItem.Class == "Food" || invItem.Class == "Drink")
                {
                    LoDConsole.WriteLine(WordWrap(string.Concat("Name: ", invItem.Name)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Item Type: ", invItem.Class)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Health Boost: ", invItem.HPmod)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Value: ", invItem.Value)));
                    LoDConsole.WriteLine(WordWrap(string.Concat(invItem.Examine)));
                }
                else if (invItem.Class == "Weapon")
                {
                    LoDConsole.WriteLine(WordWrap(string.Concat("Name: ", invItem.Name)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Item Type: ", invItem.Class)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Base Damage: ", invItem.AttackMod)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Defense Modifier: ", invItem.DefenseMod)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Value: ", invItem.Value)));
                    LoDConsole.WriteLine(WordWrap(string.Concat(invItem.Examine)));
                }
                else if (invItem.Class.Contains("Armor"))
                {
                    LoDConsole.WriteLine(WordWrap(string.Concat("Name: ", invItem.Name)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Item Type: ", invItem.Class)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Defense Modifier: ", invItem.DefenseMod)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Value: ", invItem.Value)));
                    LoDConsole.WriteLine(WordWrap(string.Concat(invItem.Examine)));
                }
                else if (invItem.Class == "Bed")
                {
                    LoDConsole.WriteLine(WordWrap(string.Concat("Name: ", invItem.Name)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Item Type: ", invItem.Class)));
                    LoDConsole.WriteLine(WordWrap(string.Concat("Value: ", invItem.Value)));
                    LoDConsole.WriteLine(WordWrap(string.Concat(invItem.Examine)));
                }
                else if (invItem.Class == "Readable") LoDConsole.WriteLine(WordWrap(string.Concat("I think I may be supposed to read this")));
                else if (invItem.Class == "Interactive Item") LoDConsole.WriteLine(WordWrap(string.Concat("I think I'm supposed to use ", invItem.Name, " on something")));
                else LoDConsole.WriteLine(WordWrap(string.Concat(invItem.Name, " remains a mystery, but you could probably sell it for ", invItem.Value, " gold.")));
            }
            else LoDConsole.WriteLine(WordWrap("Item not found in your intentory"));
        }

        public static void TakeItem(string ObjectName)
        {
            int index = 0;
            string ReturnString = "That item does not appear to be here...";
            bool itemToTake = false;

            if (CurrentRoom.items != null)
            {
                while (itemToTake == false && index < CurrentRoom.items.Count)
                {
                    itemInfo Item = CurrentRoom.items[index];
                    if (IsItemName(Item, ObjectName) == true && Item.CanPickUp == true)
                    {
                        Player.inventory.Add(Item);
                        Player.invspace = Player.invspace - 1;
                        itemToTake = true;

                        ReturnString = string.Concat("You have picked up ", Item.Name);
                        LoDConsole.WriteLine(WordWrap((ReturnString)));
                        CurrentRoom.items.RemoveAt(index);
                        bool canstillpickup = false;
                        if (CurrentRoom.Events != null && CurrentRoom.items != null)
                        {
                            EventTrigger("itempickup", Item.Name);
                            foreach (itemInfo RoomItem in CurrentRoom.items) { if (RoomItem.CanPickUp == true) canstillpickup = true; }
                        }
                        if (canstillpickup == false) EventTrigger("allitempickup");
                    }
                    else if (IsItemName(Item, ObjectName) == true && Item.CanPickUp == false) ReturnString = string.Concat("You cannot pick up ", ObjectName);
                    index++;
                }
                if (!itemToTake) LoDConsole.WriteLine(WordWrap((ReturnString)));
            }
            else LoDConsole.WriteLine(WordWrap((ReturnString)));
        }

        public static string DropItem(string ObjectName)
        {
            bool itemFound = false;
            string Response = "That item is not in your inventory";

            if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

            for (int index = 0; index < Player.inventory.Count && itemFound == false; index++)
            {
                if (IsItemName(Player.inventory[index], ObjectName) == true)
                {
                    itemFound = true;
                    Response = string.Concat("Dropping ", ObjectName, " from your inventory");
                    CurrentRoom.items.Add(Player.inventory[index]);  //add dropped item to current room
                    Player.inventory.RemoveAt(index);
                    Player.invspace = Player.invspace + 1;
                }
            }
            return (Response);
        }

        public static void EquipItem(string PlayerCommand)
        {
            int index;
            string item = string.Empty;

            if (PlayerCommand.ToLower() == "equip")
            {
                LoDConsole.WriteLine(WordWrap("Specify an item to equip:\n"));

                for (index = 0; index < Player.inventory.Count; index++)
                {
                    if (Player.inventory[index].Class == "Weapon" || Player.inventory[index].Class.Contains("Armor"))
                    {
                        LoDConsole.WriteLine(WordWrap(Player.inventory[index].Name));
                    }
                }
                item = LoDConsole.ReadLine("Which item would you like to equip?", "Equip Item", string.Empty);
            }
            else
            {
                string[] strArray = PlayerCommand.Split(' ');
                for (index = 1; index < strArray.Length; index++)
                {
                    item = string.Concat(item, " ", strArray[index]);
                }
            }
            item = item.Trim();
            bool itemFound = false;
            itemInfo tempItem = new itemInfo();

            for (index = 0; index < Player.inventory.Count && !itemFound; index++)
            {
                if (IsItemName(Player.inventory[index], item))
                {
                    itemFound = true;
                    if (Player.inventory[index].Class == "Weapon")
                    {
                        Player.ArmorBonus = Player.ArmorBonus - Player.WeaponHeld.DefenseMod;
                        tempItem = Player.WeaponHeld;
                        Player.WeaponHeld = Player.inventory[index];
                        Player.inventory[index] = tempItem;
                        Player.ArmorBonus = Player.ArmorBonus + Player.WeaponHeld.DefenseMod;
                        LoDConsole.WriteLine(WordWrap(string.Concat("You have equipped ", item, " as your current weapon")));
                        LoDConsole.WriteLine(WordWrap(string.Concat("Your old weapon ", Player.inventory[index].Name, " has been been placed in your inventory.")));

                    }
                    else if (Player.inventory[index].Class.Contains("Armor"))
                    {
                        //LoDConsole.WriteLine(WordWrap("You cannot equip armor at this time");
                        string armorType = Player.inventory[index].Class;
                        int armorPOS = 0;
                        itemFound = true;

                        if (armorType == "Armor-Helmet") armorPOS = 0;
                        else if (armorType == "Armor-Chest") armorPOS = 1;
                        else if (armorType == "Armor-Gloves") armorPOS = 2;
                        else if (armorType == "Armor-Legs") armorPOS = 3;
                        else if (armorType == "Armor-Boots") armorPOS = 4;

                        if (Player.ArmorWorn[armorPOS].Name != null)   //armor of that type is already being worn
                        {
                            tempItem = Player.ArmorWorn[armorPOS];
                            Player.ArmorWorn[armorPOS] = Player.inventory[index];
                            Player.inventory[index] = tempItem;
                            LoDConsole.WriteLine(WordWrap(string.Concat("You have equipped ", item, " as your ", armorType.Split('-')[1], " armor")));
                            LoDConsole.WriteLine(WordWrap(string.Concat("Your old armor ", Player.inventory[index].Name, " has been been placed in your inventory.")));
                            Player.ArmorBonus = Player.ArmorBonus - tempItem.DefenseMod;
                            Player.ArmorBonus = Player.ArmorBonus + Player.ArmorWorn[armorPOS].DefenseMod;
                        }
                        else
                        {
                            Player.ArmorWorn[armorPOS] = Player.inventory[index];
                            Player.ArmorBonus = Player.ArmorBonus + Player.inventory[index].DefenseMod;

                            Player.inventory.RemoveAt(index);    //remove item from inventory as it isn't replacing anything
                            Player.invspace = Player.invspace + 1;
                            LoDConsole.WriteLine(WordWrap(string.Concat("You have equipped ", item, " as your ", armorType.Split('-')[1], " armor")));

                        }
                        if (Player.ArmorBonus > 100) Player.ArmorBonus = 100;
                    }
                    else LoDConsole.WriteLine(WordWrap(string.Concat("You cannot equip ", item)));
                }
            }
            if (itemFound == false)
            {
                LoDConsole.WriteLine(WordWrap("Item not found in your inventory, use 'inventory' to see items you possess"));
            }
        }

        public static void UseItem(string item, string target)
        {
            int index = 0;
            bool itemFound = false;
            bool itemInInventory = false;
            int ItemFoundAt = 0;

            for (index = 0; index < Player.inventory.Count; index++)
            {
                if (IsItemName(Player.inventory[index], item))
                {
                    itemInInventory = true;
                    ItemFoundAt = index;
                }
            }

            if (itemInInventory == true)
            {
                index = 0;
                if (CurrentRoom.items != null && itemInInventory == true)
                {
                    while (itemFound == false && index < CurrentRoom.items.Count)
                    {
                        if (IsItemName(CurrentRoom.items[index], target))
                        {
                            if (CurrentRoom.items[index].Class != null && CurrentRoom.items[index].Class == "Interaction Object" && item.ToLower() == CurrentRoom.items[index].ItemNeeded.ToLower())
                            {
                                if (EventTrigger("iteminteraction", CurrentRoom.items[index].Name) == true) LoDConsole.WriteLine(WordWrap(CurrentRoom.items[index].interactionResponse));
                                else LoDConsole.WriteLine("The items interacted, but nothing happened");
                                Player.inventory[ItemFoundAt] = GainXPfromItem(Player.inventory[ItemFoundAt]);
                                itemFound = true;
                                Player.inventory.RemoveAt(ItemFoundAt);
                                Player.invspace = Player.invspace + 1;
                            }
                        }
                        index++;
                    }
                    if (itemFound == false) LoDConsole.WriteLine(WordWrap(string.Concat("Tried to use ", item, " on ", target, " but it failed")));
                }
                else LoDConsole.WriteLine("There is nowhere in this room to use that item");
            }
            else LoDConsole.WriteLine(WordWrap(string.Concat(item, " is not currently in your inventory")));
        }

        public static string ReadItem(string item)
        {
            string Response = "You cannot read that item";
            int TotalItems = 0;
            if (CurrentRoom.items != null) TotalItems = TotalItems + CurrentRoom.items.Count;
            if (Player.inventory.Count != 0) TotalItems = TotalItems + Player.inventory.Count;

            int index = 0;
            bool itemFound = false;
            bool itemRead = false;
            int counter = 0;

            while (itemRead == false && index < TotalItems)
            {
                counter = 0;
                while (CurrentRoom.items != null && itemRead == false && counter < CurrentRoom.items.Count)
                {
                    if (IsItemName(CurrentRoom.items[counter], item))
                    {
                        itemFound = true;
                        if (CurrentRoom.items[counter].Class == "Readable")
                        {
                            itemRead = true;
                            Response = CurrentRoom.items[counter].Examine;
                            if (CurrentRoom.items[counter].XP != 0)
                            {
                                CurrentRoom.items[counter] = GainXPfromItem(CurrentRoom.items[counter]);
                            }
                        }
                    }
                    counter++;
                }

                counter = 0;

                while (Player.inventory.Count != 0 && itemRead == false && counter < Player.inventory.Count)
                {
                    if (IsItemName(Player.inventory[counter], item))
                    {
                        itemFound = true;
                        if (Player.inventory[counter].Class != null && Player.inventory[counter].Class == "Readable")
                        {
                            itemRead = true;
                            Response = Player.inventory[counter].Examine;
                            Player.inventory[counter] = GainXPfromItem(Player.inventory[counter]);
                        }
                    }
                    counter++;
                }
                index++;
            }
            if (itemFound == false) { Response = string.Concat("Cannot find ", item, " in the current area"); }
            return (Response);
        }

        public static string ConsumeItem(string ObjectName)
        {
            int index = 0;
            string Response = "You cannot consume that item";
            bool itemEaten = false;

            while (itemEaten == false && index < Player.inventory.Count)
            {
                if (IsItemName(Player.inventory[index], ObjectName) == true && (Player.inventory[index].Class == "Food" || Player.inventory[index].Class == "Drink"))
                {
                    Player.HPBonus = Player.HPBonus + Player.inventory[index].HPmod;
                    if (Player.inventory[index].HPmod > 0) Response = string.Concat("You gained ", Player.inventory[index].HPmod, "HP from ", ObjectName);
                    else Response = string.Concat("You lost ", Player.inventory[index].HPmod, "HP from ", ObjectName);
                    itemEaten = true;
                    if (Player.HPBonus > Player.MaxHp) Player.HPBonus = Player.MaxHp;

                    Player.inventory[index] = GainXPfromItem(Player.inventory[index]);
                    Player.inventory.RemoveAt(index);
                    Player.invspace = Player.invspace + 1;
                }
                index++;
            }
            return (Response);
        }

        #endregion

        #region Merchant Functions

        public static void SellItem(itemInfo ItemSold, string Vendor)
        {
            int index = 0;
            bool vendorFound = false;

            if (CurrentRoom.Civilians != null)
            {
                while (index < CurrentRoom.Civilians.Count)
                {
                    if (Vendor.ToLower() == CurrentRoom.Civilians[index].name.ToLower())
                    {
                        vendorFound = true;
                        if (CurrentRoom.Civilians[index].willBuy == true && (CurrentRoom.Civilians[index].MerchantType == "All" || ItemSold.Class.Contains(CurrentRoom.Civilians[index].MerchantType)))
                        {
                            int cost = -1;
                            if (ItemSold.Value == 0)    //Item is worthless
                            {
                                string response = LoDConsole.ReadLine(ItemSold.Name + " is not worth anything. Do you want to give it away?", "Item", "Yes");

                                if (response.ToLower() == "yes" || response.ToLower() == "y" || response.ToLower() == "hell yeah")
                                {
                                    cost = 0;
                                }
                            }
                            else if (CurrentRoom.Civilians[index].Money == 0)   //Merchant has no money to buy
                            {
                                string response = LoDConsole.ReadLine(CurrentRoom.Civilians[index].name + " does not have any money. Do you want to give it as a gift?", "Item", "Yes");

                                if (response.ToLower() == "yes" || response.ToLower() == "y" || response.ToLower() == "hell yeah")
                                {
                                    cost = 0;
                                }
                            }
                            else if (CurrentRoom.Civilians[index].Money < ItemSold.Value) //Merchant doesn't have enough money to buy
                            {
                                string temp = CurrentRoom.Civilians[index].name + " only has " + CurrentRoom.Civilians[index].Money + " gold. Do you want to sell " + ItemSold.Name + " for " + CurrentRoom.Civilians[index].Money + " gold?";
                                LoDConsole.Write("\n>");
                                string response = LoDConsole.ReadLine(temp, "Item", "Yes");

                                if (response.ToLower() == "yes" || response.ToLower() == "y" || response.ToLower() == "hell yeah")
                                {
                                    cost = CurrentRoom.Civilians[index].Money;
                                }
                            }
                            else    //Merchant will buy at face value
                            {

                                LoDConsole.WriteLine(WordWrap(string.Concat("Sucessfully sold ", ItemSold.Name, " to ", Vendor, " for ", ItemSold.Value, " gold coins.")));
                                cost = ItemSold.Value;
                            }
                            CivilianProfile Civy = CurrentRoom.Civilians[index];
                            if (Civy.inventory == null) Civy.inventory = new List<itemInfo>();
                            ItemSold.Value = ItemSold.Value + (((ItemSold.Value / 100) * 10) + 10);
                            Civy.inventory.Add(ItemSold);
                            Civy.Money = Civy.Money - cost;
                            Player.Money = Player.Money + cost;
                            if (Civy.Money > 0) Civy.Money = 0; //technically shouldn't happen but whatever
                            CurrentRoom.Civilians[index] = Civy;

                            int Counter = 0;
                            bool itemfound = false;
                            while (itemfound == false && Counter < Player.inventory.Count)
                            {
                                if (ItemSold.Name == Player.inventory[Counter].Name)
                                {
                                    Player.inventory.RemoveAt(Counter);
                                    itemfound = true;
                                    Player.invspace = Player.invspace + 1;
                                }
                                Counter++;
                            }
                        }
                        else LoDConsole.WriteLine(WordWrap(string.Concat(Vendor, " will not buy items of that type from you")));
                    }
                    index++;
                }
                if (vendorFound == false) LoDConsole.WriteLine(WordWrap(string.Concat(Vendor, " does not appear to be in the local area")));

            }
            else LoDConsole.WriteLine("There is nobody here willing to trade");
        }

        public static void BuyItem(string itemName, string vendor)
        {
            itemInfo item = new itemInfo();
            int index = 0;
            int counter = 0;
            if (CurrentRoom.Civilians.Count != 0)
            {
                bool itemFound = false;
                bool vendorFound = false;

                while (itemFound == false && index < CurrentRoom.Civilians.Count)
                {
                    if (CurrentRoom.Civilians[index].inventory != null && CurrentRoom.Civilians[index].name.ToLower() == vendor.ToLower() && CurrentRoom.Civilians[index].willSell == true)
                    {
                        vendorFound = true;
                        if (CurrentRoom.Civilians[index].willSell == true)
                        {
                            while (itemFound == false && counter < CurrentRoom.Civilians[index].inventory.Count)
                            {
                                if (IsItemName(CurrentRoom.Civilians[index].inventory[counter], itemName))
                                {
                                    item = CurrentRoom.Civilians[index].inventory[counter];

                                    if (Player.Money >= item.Value)
                                    {
                                        Player.Money = Player.Money - item.Value;
                                        Player.inventory.Add(item);
                                        Player.invspace = Player.invspace - 1;
                                        LoDConsole.WriteLine(WordWrap(string.Concat("You have successfully purchased ", itemName, " for ", item.Value, " gold coins")));

                                        CurrentRoom.Civilians[index].inventory.RemoveAt(counter);
                                    }
                                    else LoDConsole.WriteLine(WordWrap(string.Concat(itemName, " costs ", item.Value, " gold coins and you only have ", Player.Money, ". You cannot afford this")));
                                    itemFound = true;
                                }
                                else counter++;
                            }
                        }
                        else LoDConsole.WriteLine(WordWrap(string.Concat(vendor, "is not willing to sell anything to you")));
                    }
                    index++;
                }
                if (itemFound == false && vendorFound == true) LoDConsole.WriteLine(WordWrap(string.Concat("The merchant does not seem to be selling ", itemName)));
                else if (itemFound == false && vendorFound == false) LoDConsole.WriteLine(WordWrap(string.Concat(vendor, " is not willing to sell anything to you.")));
            }
            else LoDConsole.WriteLine("There are no people in the area to buy from");
        }

        public static void GiveItem(string ItemName, string NPC)
        {
            int index;
            bool NPCFound = false;
            bool GivingMoney = false;
            int MoneyAmount = 0;
            itemInfo ItemGiven = new itemInfo();

            if (CurrentRoom.Civilians != null || CurrentRoom.Enemy != null)
            {
                int n;
                if (ItemName.Split(' ').Length >= 2 && (ItemName.Split(' ')[1].ToLower() == "gold" || ItemName.Split(' ')[1].ToLower() == "money" || ItemName.Split(' ')[1].ToLower() == "coins") && (Int32.TryParse(ItemName.Split(' ')[0], out n)))    //Player is giving gold
                {

                    if (n <= Player.Money)
                    {
                        GivingMoney = true;
                        MoneyAmount = n;
                    }
                    else MoneyAmount = -1;
                }
                else
                {
                    for (index = 0; index < Player.inventory.Count; index++)
                    {
                        if (IsItemName(Player.inventory[index], ItemName))
                        {
                            ItemGiven = Player.inventory[index];
                            Player.inventory.RemoveAt(index);
                            Player.invspace++;
                            GivingMoney = false;
                        }
                    }
                }
                index = 0;
                while (CurrentRoom.Civilians != null && index < CurrentRoom.Civilians.Count && !NPCFound && (ItemGiven.Name != null || GivingMoney))
                {
                    if (NPC.ToLower() == CurrentRoom.Civilians[index].name.ToLower())
                    {
                        NPCFound = true;
                        string temp;
                        if (!GivingMoney) temp = "Do you want to give " + ItemGiven.Name + " as a gift to " + CurrentRoom.Civilians[index].name + "? ";
                        else temp = "Do you want to give " + ItemName + " as a gift to " + CurrentRoom.Civilians[index].name + "? ";
                        string response = LoDConsole.ReadLine(temp, "Item", "Yes");

                        if (response.ToLower() == "yes" || response.ToLower() == "y" || response.ToLower() == "hell yeah")
                        {
                            if (!GivingMoney)
                            {
                                CivilianProfile Civy = CurrentRoom.Civilians[index];
                                if (Civy.inventory == null) Civy.inventory = new List<itemInfo>();
                                Civy.inventory.Add(ItemGiven);
                                CurrentRoom.Civilians[index] = Civy;
                            }
                            else
                            {
                                CivilianProfile Civy = CurrentRoom.Civilians[index];
                                Civy.Money = Civy.Money + MoneyAmount;
                                CurrentRoom.Civilians[index] = Civy;
                                Player.Money = Player.Money - MoneyAmount;
                            }
                            LoDConsole.WriteLine(WordWrap(string.Concat("\nYou have given ", ItemName, " to ", NPC)));

                            int val;
                            if (!GivingMoney && CurrentRoom.Events != null)
                            {
                                if (ItemName.ToLower() == CurrentRoom.Civilians[index].Donation.ToLower()) EventTrigger("donate", NPC);
                            }
                            else if (GivingMoney == true && CurrentRoom.Events != null)
                            {
                                if (Int32.TryParse(CurrentRoom.Civilians[index].Donation, out val))
                                {
                                    if (MoneyAmount >= val) EventTrigger("donate", NPC);
                                }
                            }
                        }
                        else
                        {
                            LoDConsole.WriteLine(WordWrap(string.Concat("\nYou did not give ", ItemName, " to ", NPC)));
                            Player.inventory.Add(ItemGiven);
                            Player.invspace--;
                        }
                    }
                    index++;
                }
                if (NPCFound == false)
                {
                    if (CurrentRoom.Enemy != null && GivingMoney == true)   //Check to see if player is trying to bribe an enemy
                    {
                        index = 0;
                        while (index < CurrentRoom.Enemy.Count)
                        {
                            if (CurrentRoom.Enemy[index].name.ToLower() == NPC.ToLower())
                            {
                                PayOff(CurrentRoom.Enemy[index].name, MoneyAmount);
                                index = CurrentRoom.Enemy.Count + 1;
                                NPCFound = true;
                            }
                            index++;
                        }
                    }

                    if (!NPCFound) LoDConsole.WriteLine(WordWrap(string.Concat("Could not find ", NPC, " here")));
                }
                else if (!GivingMoney && MoneyAmount == -1) LoDConsole.WriteLine(WordWrap(string.Concat("You do not have ", ItemName)));
                else if (ItemGiven.Name == null && !GivingMoney) LoDConsole.WriteLine(WordWrap(string.Concat("Could not find ", ItemName, " in your inventory")));

            }
            else LoDConsole.WriteLine("There is nobody here to give items to");
        }

        #endregion

        #region Combat Functions

        public static void PayOff(string EnemyName, int amount)
        {
            int index = 0;
            bool enemyfound = false;

            //LoDConsole.WriteLine("!! Trying to pay off {0} with amount {1} !!\n", EnemyName, amount);

            while (CurrentRoom.Enemy != null && index < CurrentRoom.Enemy.Count)
            {
                if (EnemyName.ToLower() == CurrentRoom.Enemy[index].name.ToLower())
                {
                    enemyfound = true;

                    if (CurrentRoom.Enemy[index].PayOff == 0)
                    {
                        LoDConsole.WriteLine(WordWrap(string.Concat(EnemyName, " will not accept a bribe from you\n")));
                        attacked();
                    }
                    else if (amount >= CurrentRoom.Enemy[index].PayOff)     //enemy will accept more than the bribe amount
                    {
                        LoDConsole.WriteLine(WordWrap(string.Concat(EnemyName, " has accepted your bribe. \"", CurrentRoom.Enemy[index].PayOffResponse, "\" says your opponent as they holster their weapon and stand down")));
                        if (CurrentRoom.Civilians == null) CurrentRoom.Civilians = new List<CivilianProfile>();
                        CivilianProfile notHostile = new CivilianProfile(); //convert enemy to non hostile civilian

                        notHostile.name = CurrentRoom.Enemy[index].name;
                        notHostile.TalkToResponse = CurrentRoom.Enemy[index].PayOffResponse;
                        notHostile.inventory = new List<itemInfo>();
                        notHostile.inventory.Add(CurrentRoom.Enemy[index].Weapon);
                        notHostile.HPBonus = CurrentRoom.Enemy[index].HPBonus;
                        notHostile.armor = CurrentRoom.Enemy[index].armor;
                        notHostile.willSell = false;
                        notHostile.Money = CurrentRoom.Enemy[index].Money + amount;
                        notHostile.QuestCharacter = false;
                        notHostile.XP = 0;
                        CurrentRoom.Civilians.Add(notHostile);
                        SaveWorld();
                        Player.Money = Player.Money - amount;
                        CurrentRoom.Enemy[index] = GainXPfromEnemy(CurrentRoom.Enemy[index]);

                        EventTrigger("payoff", CurrentRoom.Enemy[index].name);
                        CurrentRoom.Enemy.RemoveAt(index);

                    }
                    else
                    {
                        LoDConsole.WriteLine(WordWrap(string.Concat("Enemy ", CurrentRoom.Enemy[index].name, " examines the coins and decides you haven't given them enough. They attack in response.\n")));
                        Player.Money = Player.Money - amount;
                        EnemyProfile Enemy = CurrentRoom.Enemy[index];
                        Enemy.Money = Enemy.Money + amount;
                        Enemy.PayOff = 0;
                        CurrentRoom.Enemy[index] = Enemy;
                        attacked();
                    }
                }
                index++;
            }
            if (enemyfound == false)
            {
                LoDConsole.WriteLine(WordWrap(string.Concat(EnemyName, " was not found in the current area")));
            }


        }

        public static void attacked()
        {
            double BaseAttack = 0;
            int Fortitude;
            Random RNG = new Random();
            LoDConsole.WriteLine();
            EnemyProfile Enemy = CurrentRoom.Enemy[RNG.Next(0, (CurrentRoom.Enemy.Count - 1))]; //Attack player with a random enemy

            if (Player.HPBonus > 0)
            {
                BaseAttack = RNG.Next(1, 3);

                if (BaseAttack == 1)
                {
                    //bad attack
                    LoDConsole.WriteLine(WordWrap(string.Concat("Enemy ", Enemy.name, " attacks you with their ", Enemy.Weapon.Name, "\n", Enemy.Weapon.BadHit)));
                }
                else if (BaseAttack == 2)
                {
                    //Medium Strong Attack
                    LoDConsole.WriteLine(WordWrap(string.Concat("Enemy ", Enemy.name, " attacks you with their ", Enemy.Weapon.Name, "\n", Enemy.Weapon.MedHit)));
                }
                else if (BaseAttack == 3)
                {
                    //Strong Attack
                    LoDConsole.WriteLine(WordWrap(string.Concat("Enemy ", Enemy.name, " attacks you with their ", Enemy.Weapon.Name, "\n", Enemy.Weapon.GoodHit)));
                }
                BaseAttack = BaseAttack * Enemy.Weapon.AttackMod;

                Fortitude = RNG.Next(1, 100);
                if (Fortitude > Player.ArmorBonus) Player.HPBonus = Player.HPBonus - BaseAttack;
                else Player.HPBonus = Convert.ToInt32(Player.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * Player.ArmorBonus));

                if (Player.HPBonus < 0)
                {
                    if (Enemy.KillMessage != null) LoDConsole.WriteLine(WordWrap(string.Concat("\n", Enemy.KillMessage)));
                    else LoDConsole.WriteLine(WordWrap(string.Concat("\n\n", Enemy.name, " has killed you with their ", Enemy.Weapon.Name)));
                }
            }
            Player.HPBonus = Math.Round((double)Player.HPBonus, 2);
        }

        public static void SurpriseAttack(string enemy)
        {
            Random RNG = new Random();
            double BaseAttack;
            int Counter;

            int defend = RNG.Next(1, 3);

            LoDConsole.WriteLine(WordWrap(string.Concat("You carefully wait, and when you think you have the upper hand, you attack ", enemy)));
            //Thread.Sleep(1000);
            if (defend == 1)
            {
                LoDConsole.WriteLine(WordWrap("Expecting violence they draw their weapon and defend\n"));
                //Thread.Sleep(1000);
                Combat(Player.WeaponHeld, enemy);
            }
            else
            {
                LoDConsole.WriteLine(WordWrap("Completely surprised they do not have a chance to defend themselves\n"));
                //Thread.Sleep(1000);

                BaseAttack = RNG.Next(1, 6);

                if (BaseAttack == 1 || BaseAttack == 2)
                {
                    //bad attack
                    LoDConsole.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.BadHit)));
                }
                else if (BaseAttack == 3 || BaseAttack == 4)
                {
                    //Medium Weak Attack
                    LoDConsole.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.MedHit)));
                }
                else if (BaseAttack == 5 || BaseAttack == 6)
                {
                    //Critical Attack                            
                    LoDConsole.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.GoodHit)));
                }

                BaseAttack = BaseAttack * Player.WeaponHeld.AttackMod;
                Counter = 0;
                bool GaveHit = false;

                while (CurrentRoom.Enemy != null && Counter < CurrentRoom.Enemy.Count && GaveHit == false)
                {
                    if (CurrentRoom.Enemy[Counter].name.ToLower() == enemy.ToLower())
                    {
                        EnemyProfile ThisEnemy = CurrentRoom.Enemy[Counter];
                        int Fortitude = RNG.Next(1, 100);
                        if (Fortitude > ThisEnemy.armor) ThisEnemy.HPBonus = ThisEnemy.HPBonus - BaseAttack;
                        else ThisEnemy.HPBonus = ThisEnemy.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * ThisEnemy.armor);

                        //LoDConsole.WriteLine("Enemy {0} has {1} HP left", enemy, CurrentRoom.Enemy[Counter].HPBonus);

                        if (ThisEnemy.HPBonus < 0) //if the enemy has been killed
                        {
                            LoDConsole.WriteLine();
                            if (CurrentRoom.Enemy[Counter].DeathMessage == null)
                            { LoDConsole.WriteLine(WordWrap(string.Concat("With this hit you kill the enemy ", CurrentRoom.Enemy[Counter].name))); }
                            else { LoDConsole.WriteLine(WordWrap(CurrentRoom.Enemy[Counter].DeathMessage)); }

                            if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

                            CurrentRoom.items.Add(ThisEnemy.Weapon);

                            itemInfo newItem = new itemInfo();

                            newItem.Name = string.Concat(ThisEnemy.name, "'s body");
                            newItem.Class = "Object";
                            newItem.Examine = string.Concat("The slashed and torn body of enemy ", ThisEnemy.name);
                            newItem.CanPickUp = false;
                            newItem.InteractionName = new List<string>();
                            newItem.InteractionName.Add("body");
                            newItem.InteractionName.Add("corpse");
                            newItem.InteractionName.Add("enemy");
                            newItem.InteractionName.Add(string.Concat(ThisEnemy.name, "'s body"));
                            newItem.InteractionName.Add(ThisEnemy.name);
                            CurrentRoom.items.Add(newItem);

                            if (ThisEnemy.Money != 0) LoDConsole.WriteLine("\nYou take {0} gold coins from {1}'s corpse", ThisEnemy.Money.ToString(), enemy);
                            Player.Money = Player.Money + ThisEnemy.Money; //take money from enemy
                            Player.XP = Player.XP + ThisEnemy.XP;  //Take XP 

                            EventTrigger("killenemy", ThisEnemy.name);
                            if (CurrentRoom.Enemy.Count - 1 != 0)
                            {
                                //Remove the fighter
                                CurrentRoom.Enemy.RemoveAt(Counter);
                            }
                            else
                            {
                                EventTrigger("killallenemies");
                                CurrentRoom.Enemy.Clear();
                                //break;
                            }
                        }
                        else CurrentRoom.Enemy[Counter] = ThisEnemy;
                        GaveHit = true;
                    }
                    Counter++;
                }
            }
        }

        public static void Combat(itemInfo WeaponUsed, string enemy)
        {
            int NumOfFighters = 0;
            int Fortitude;
            Random RNG = new Random();
            int index;

            NumOfFighters = CurrentRoom.Enemy.Count + 1;

            //LoDConsole.WriteLine(WordWrap("There are ", ," people in the room", NumOfFighters);

            List<Fighter> ThisFight = new List<Fighter>();
            Fighter TempFighter = new Fighter();

            TempFighter.name = Player.name;
            TempFighter.HP = Player.HPBonus;
            TempFighter.Weapon = WeaponUsed;
            TempFighter.AttackMod = (WeaponUsed.AttackMod + (Player.Strength - (0.5 * Player.DaysSinceSleep)));
            TempFighter.DefenseMod = (Player.ArmorBonus + Player.Resitence);
            TempFighter.isAlive = true;
            TempFighter.initiative = RNG.Next((Player.Speed - Convert.ToInt32(Math.Round((0.5 * Player.DaysSinceSleep)))), 100);  //Use players speed bonus
            TempFighter.ID = 99;
            TempFighter.Behaviour = string.Empty;
            TempFighter.Team = 99;
            ThisFight.Add(TempFighter);

            for (index = 0; index < CurrentRoom.Enemy.Count; index++)
            {
                TempFighter.name = CurrentRoom.Enemy[index].name;
                TempFighter.HP = CurrentRoom.Enemy[index].HPBonus;
                TempFighter.DefenseMod = CurrentRoom.Enemy[index].armor + CurrentRoom.Enemy[index].Weapon.DefenseMod;
                TempFighter.AttackMod = CurrentRoom.Enemy[index].Weapon.AttackMod;
                TempFighter.Weapon = CurrentRoom.Enemy[index].Weapon;
                TempFighter.isAlive = true;
                TempFighter.initiative = RNG.Next(0, 100); //Roll 1d100 to decide initiative
                TempFighter.ID = index;
                TempFighter.Behaviour = CurrentRoom.Enemy[index].Behaviour;
                TempFighter.Team = CurrentRoom.Enemy[index].Team;
                ThisFight.Add(TempFighter);
            }

            index = 0;
            while (index < (NumOfFighters - 1))   //Sort fighters into highest initiative first
            {
                if (ThisFight[index].initiative < ThisFight[index + 1].initiative)
                {
                    TempFighter = ThisFight[index];
                    ThisFight[index] = ThisFight[index + 1];
                    ThisFight[index + 1] = TempFighter;
                    index = 0;
                }
                else
                { index++; }
            }

            double BaseAttack = 0;
            index = 0;
            while (index < ThisFight.Count && Player.HPBonus > 0 && CurrentRoom.Enemy != null && CurrentRoom.Enemy.Count != 0)
            {
                if (ThisFight[index].name == Player.name)   //players turn
                {
                    BaseAttack = RNG.Next(1, 6);

                    if (BaseAttack == 1 || BaseAttack == 2)
                    {
                        //bad attack
                        LoDConsole.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.BadHit)));
                    }
                    else if (BaseAttack == 3 || BaseAttack == 4)
                    {
                        //Medium Weak Attack
                        LoDConsole.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.MedHit)));
                    }
                    else if (BaseAttack == 5 || BaseAttack == 6)
                    {
                        //Critical Attack                            
                        LoDConsole.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.GoodHit)));
                    }

                    BaseAttack = BaseAttack * ThisFight[index].AttackMod;

                    int Counter = 0;
                    bool GaveHit = false;

                    while (CurrentRoom.Enemy != null && Counter < ThisFight.Count && GaveHit == false && CurrentRoom.Enemy.Count != 0)
                    {
                        if (ThisFight[Counter].name.ToLower() == enemy.ToLower())
                        {
                            EnemyProfile ThisEnemy = CurrentRoom.Enemy[ThisFight[Counter].ID];
                            ThisEnemy.PayOff = 0;   //Do not allow the player to bribe the enemy after attacking them
                            Fortitude = RNG.Next(1, 100);
                            if (Fortitude > ThisEnemy.armor) ThisEnemy.HPBonus = ThisEnemy.HPBonus - BaseAttack;
                            else ThisEnemy.HPBonus = ThisEnemy.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * ThisEnemy.armor);

                            if (ThisEnemy.HPBonus < 0) //if the enemy has been killed
                            {
                                LoDConsole.WriteLine();
                                if (CurrentRoom.Enemy[ThisFight[Counter].ID].DeathMessage == null)
                                { LoDConsole.WriteLine(WordWrap(string.Concat("With this hit you kill the enemy ", CurrentRoom.Enemy[ThisFight[Counter].ID].name))); }
                                else { LoDConsole.WriteLine(WordWrap(CurrentRoom.Enemy[ThisFight[Counter].ID].DeathMessage)); }

                                if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

                                CurrentRoom.items.Add(ThisEnemy.Weapon);

                                itemInfo newItem = new itemInfo();

                                newItem.Name = string.Concat(ThisEnemy.name, "'s body");
                                newItem.Class = "Object";
                                newItem.Examine = string.Concat("The slashed and torn body of enemy ", ThisEnemy.name);
                                newItem.CanPickUp = false;
                                newItem.InteractionName = new List<string>();
                                newItem.InteractionName.Add("body");
                                newItem.InteractionName.Add("corpse");
                                newItem.InteractionName.Add("enemy");
                                newItem.InteractionName.Add(string.Concat(ThisEnemy.name, "'s body"));
                                newItem.InteractionName.Add(ThisEnemy.name);
                                CurrentRoom.items.Add(newItem);

                                if (ThisEnemy.Money != 0) LoDConsole.WriteLine("\nYou take {0} gold coins from {1}'s corpse", ThisEnemy.Money.ToString(), enemy);

                                Player.Money = Player.Money + ThisEnemy.Money; //take money from enemy
                                GainXPfromEnemy(ThisEnemy);  //Take XP 
                                NumOfFighters = NumOfFighters - 1;

                                SaveWorld();

                                EventTrigger("killenemy", ThisEnemy.name);
                                CurrentRoom.Enemy.RemoveAt(ThisFight[Counter].ID);

                                if (CurrentRoom.Enemy.Count != 0)
                                {
                                    //Remove the fighter
                                    ThisFight.RemoveAt(Counter);
                                }
                                else
                                {
                                    EventTrigger("killallenemies");
                                    //if (CurrentRoom.Enemy != null) CurrentRoom.Enemy.Clear();
                                }
                            }
                            else CurrentRoom.Enemy[ThisFight[Counter].ID] = ThisEnemy;
                            GaveHit = true;
                        }
                        Counter++;
                    }

                }
                else  //enemies turn
                {
                    int EnemyTarget = FindEnemyTarget(ThisFight, index);    //Find enemy based on this enemies behaviour
                    BaseAttack = RNG.Next(1, 3);

                    string target = ThisFight[EnemyTarget].name;
                    if (ThisFight[EnemyTarget].ID == 99) target = "you";

                    LoDConsole.WriteLine(WordWrap(string.Concat(ThisFight[index].name, " attacks ", target, " with their ", ThisFight[index].Weapon.Name)));
                    if (BaseAttack == 1)
                    {
                        //bad attack
                        BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                        LoDConsole.WriteLine(WordWrap(string.Concat(ThisFight[index].Weapon.BadHit)));
                    }
                    else if (BaseAttack == 2)
                    {
                        //Medium Attack
                        BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                        LoDConsole.WriteLine(WordWrap(string.Concat(ThisFight[index].Weapon.MedHit)));
                    }
                    else if (BaseAttack == 3)
                    {
                        //Strong Attack
                        BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                        LoDConsole.WriteLine(WordWrap(string.Concat(ThisFight[index].Weapon.GoodHit)));
                    }

                    if (ThisFight[EnemyTarget].ID == 99)
                    {
                        Fortitude = RNG.Next(1, 100);
                        if (Fortitude > ThisFight[EnemyTarget].DefenseMod) Player.HPBonus = Player.HPBonus - BaseAttack;
                        else Player.HPBonus = Player.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * Player.ArmorBonus);
                        Player.HPBonus = Math.Round((double)Player.HPBonus, 2);
                        if (Player.HPBonus < 0)
                        {
                            if (CurrentRoom.Enemy[ThisFight[index].ID].KillMessage != null)
                            {
                                LoDConsole.WriteLine(WordWrap(string.Concat("\n", CurrentRoom.Enemy[ThisFight[index].ID].KillMessage)));
                            }
                            else
                            {
                                LoDConsole.WriteLine(WordWrap(string.Concat("\n\n", CurrentRoom.Enemy[ThisFight[index].ID].name, " has killed you with their ", CurrentRoom.Enemy[ThisFight[index].ID].Weapon.Name)));
                            }
                            NumOfFighters = NumOfFighters - 1;
                        }
                    }
                    else
                    {
                        EnemyProfile ThisEnemy = CurrentRoom.Enemy[ThisFight[EnemyTarget].ID];
                        ThisEnemy.PayOff = 0;   //Do not allow the player to bribe the enemy after attacking them
                        Fortitude = RNG.Next(1, 100);
                        if (Fortitude > ThisEnemy.armor) ThisEnemy.HPBonus = ThisEnemy.HPBonus - BaseAttack;
                        else ThisEnemy.HPBonus = ThisEnemy.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * ThisEnemy.armor);

                        if (ThisEnemy.HPBonus < 0) //if the enemy has been killed
                        {
                            LoDConsole.WriteLine();
                            if (CurrentRoom.Enemy[ThisFight[EnemyTarget].ID].DeathMessage == null)
                            { LoDConsole.WriteLine(WordWrap(string.Concat("With this hit ", ThisFight[index].name, " kills the enemy ", CurrentRoom.Enemy[ThisFight[EnemyTarget].ID].name))); }
                            else { LoDConsole.WriteLine(WordWrap(CurrentRoom.Enemy[ThisFight[EnemyTarget].ID].DeathMessage)); }

                            if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

                            CurrentRoom.items.Add(ThisEnemy.Weapon);

                            itemInfo newItem = new itemInfo();

                            newItem.Name = string.Concat(ThisEnemy.name, "'s body");
                            newItem.Class = "Object";
                            newItem.Examine = string.Concat("The slashed and torn body of enemy ", ThisEnemy.name);
                            newItem.CanPickUp = false;
                            newItem.InteractionName = new List<string>();
                            newItem.InteractionName.Add("body");
                            newItem.InteractionName.Add("corpse");
                            newItem.InteractionName.Add("enemy");
                            newItem.InteractionName.Add(string.Concat(ThisEnemy.name, "'s body"));
                            newItem.InteractionName.Add(ThisEnemy.name);
                            CurrentRoom.items.Add(newItem);


                            //Player should not get money/xp if an enemy kills another enemy?
                            //Player.Money = Player.Money + ThisEnemy.Money; //take money from enemy
                            //Player.XP = Player.XP + ThisEnemy.XP;  //Take XP 
                            NumOfFighters = NumOfFighters - 1;

                            SaveWorld();

                            EventTrigger("killenemy", ThisEnemy.name);
                            CurrentRoom.Enemy.RemoveAt(ThisFight[EnemyTarget].ID);

                            if (CurrentRoom.Enemy.Count != 0)
                            {
                                //Remove the fighter
                                ThisFight.RemoveAt(EnemyTarget);
                            }
                            else
                            {
                                EventTrigger("killallenemies");
                                //if (CurrentRoom.Enemy != null) CurrentRoom.Enemy.Clear();
                            }
                        }
                        else CurrentRoom.Enemy[ThisFight[EnemyTarget].ID] = ThisEnemy;
                    }
                }
                //Thread.Sleep(1500);
                LoDConsole.WriteLine("");
                index++;
            }
        }

        public static int FindEnemyTarget(List<Fighter> ThisFight, int CurrentPos)
        {
            /*  AttackPlayer            
             *  AttackBestDamage
             *  AttackWorstDamage
             *  AttackStrongDefense
             *  AttackWeakDefense
             *  AttackMostHP
             *  AttackLeastHP
             *  AttackRandom   
             */

            Fighter CurrentEnemy = ThisFight[CurrentPos];
            int EnemyFoundAt = 0;

            if (CurrentEnemy.Behaviour == "AttackPlayer") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].ID == 99) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackBestDamage") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].AttackMod > ThisFight[EnemyFoundAt].AttackMod && ThisFight[i].ID != CurrentEnemy.ID && ThisFight[i].Team != CurrentEnemy.Team) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackWorstDamage") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].AttackMod < ThisFight[EnemyFoundAt].AttackMod && ThisFight[i].ID != CurrentEnemy.ID && ThisFight[i].Team != CurrentEnemy.Team) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackStrongDefense") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].DefenseMod > ThisFight[EnemyFoundAt].DefenseMod && ThisFight[i].ID != CurrentEnemy.ID && ThisFight[i].Team != CurrentEnemy.Team) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackWeakDefense") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].DefenseMod < ThisFight[EnemyFoundAt].DefenseMod && ThisFight[i].ID != CurrentEnemy.ID && ThisFight[i].Team != CurrentEnemy.Team) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackMostHP") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].HP > ThisFight[EnemyFoundAt].HP && ThisFight[i].ID != CurrentEnemy.ID && ThisFight[i].Team != CurrentEnemy.Team) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackLeastHP") for (int i = 0; i < ThisFight.Count; i++) { if (ThisFight[i].HP > ThisFight[EnemyFoundAt].HP && ThisFight[i].ID != CurrentEnemy.ID && ThisFight[i].Team != CurrentEnemy.Team) EnemyFoundAt = i; }
            else if (CurrentEnemy.Behaviour == "AttackRandom" || string.IsNullOrEmpty(CurrentEnemy.Behaviour))
            {
                Random rng = new Random();
                EnemyFoundAt = -1;
                while (EnemyFoundAt < 0)
                {
                    EnemyFoundAt = rng.Next(0, ThisFight.Count);
                    {
                        if (ThisFight[EnemyFoundAt].ID == CurrentEnemy.ID && ThisFight[EnemyFoundAt].Team == CurrentEnemy.Team) EnemyFoundAt = -1;
                    }
                }
            }
            else EnemyFoundAt = -1;

            return EnemyFoundAt;
        }

        public static bool isEnemy(string Enemyname)
        {
            if (CurrentRoom.Enemy != null)
            {
                foreach (EnemyProfile Enemy in CurrentRoom.Enemy)
                {
                    if (Enemy.name.ToLower() == Enemyname.ToLower()) return true;
                }
            }
            return false;
        }

        #endregion

        #region Player Functions

        public static void Rest(string BedItem)
        {
            int index = 0;
            int counter = 0;
            bool bedFound = false;

            if (CurrentRoom.items != null)
            {
                while (bedFound == false && index < CurrentRoom.items.Count)
                {
                    while (bedFound == false && counter < CurrentRoom.items[index].InteractionName.Count)
                    {
                        if (CurrentRoom.items[index].Class == "Bed" && CurrentRoom.items[index].InteractionName[counter].ToLower() == BedItem.ToLower())
                        {
                            if (CurrentRoom.Enemy == null || CurrentRoom.Enemy.Count == 0)
                            {
                                bedFound = true;
                                LoDConsole.WriteLine(WordWrap(string.Concat("You lie down on your ", BedItem, " and go to sleep")));
                                LoDConsole.WriteLine("You awaken in the morning feeling refreshed");
                                Player.HPBonus = Player.MaxHp;
                                WorldState.WorldTime = 480;
                                Player.DaysSinceSleep = 0;
                                if (CurrentRoom.Events != null) EventTrigger("sleeps");
                            }
                            else
                            {
                                bedFound = true;
                                LoDConsole.WriteLine(WordWrap(string.Concat("You lie down on your ", BedItem, " and go to sleep")));
                                LoDConsole.WriteLine(WordWrap("Your enemies, confused as to your tactic of sleeping during battle, beat you to death while you sleep."));
                                Player.HPBonus = 0;
                            }
                        }
                        counter++;
                    }
                    counter = 0;
                    index++;
                }
                if (bedFound == false) LoDConsole.WriteLine("Cannot find that place to sleep in this area");
            }
            else LoDConsole.WriteLine("There are no places to sleep in this area");

        }

        public static void PlayerStatus()
        {
            LoDConsole.WriteLine(WordWrap(string.Concat("Your HP is at ", Player.HPBonus, "/", Player.MaxHp, "")));
            if (Player.HPBonus < 20) LoDConsole.WriteLine(WordWrap("Your health is low, you should find some food or a place to rest!"));
            LoDConsole.WriteLine("\nCurrent Level: {3}  Current XP: {4}\nStrength: {0}  Speed: {1}  Resistence: {2}", Player.Strength.ToString(), Player.Speed.ToString(), Player.Resitence.ToString(), Player.Level.ToString(), Player.XP.ToString());

            LoDConsole.WriteLine(WordWrap(string.Concat("\nYour current weapon is: ", Player.WeaponHeld.Name)));

            LoDConsole.WriteLine(WordWrap(string.Concat("\nYou current armor is at ", Player.ArmorBonus, "%\n")));

            if (Player.ArmorWorn[0].Name == null) LoDConsole.WriteLine("  0");   //head
            else LoDConsole.WriteLine(string.Concat(" {0}      - Head armor: ", Player.ArmorWorn[0].Name, " - ", Player.ArmorWorn[0].DefenseMod, "%"));

            if (Player.ArmorWorn[1].Name == null) LoDConsole.WriteLine(" /|\\"); //chest
            else LoDConsole.WriteLine("╔=╬=╗     - Chest Armor: {0} - {1}%", Player.ArmorWorn[1].Name, Player.ArmorWorn[1].DefenseMod.ToString());

            if (Player.ArmorWorn[2].Name == null)   //gloves
            {
                LoDConsole.WriteLine("/ | \\");
                LoDConsole.WriteLine("  |");
            }
            else
            {
                LoDConsole.WriteLine("║ ║ ║    - Glove Armor: {0} - {1}%", Player.ArmorWorn[2].Name, Player.ArmorWorn[2].DefenseMod.ToString());
                LoDConsole.WriteLine("Û ║ Û ");
            }

            if (Player.ArmorWorn[3].Name == null) LoDConsole.WriteLine(" / \\"); //Legs
            else LoDConsole.WriteLine(" / \\     - Leg Armor: {0} - {1}%", Player.ArmorWorn[3].Name, Player.ArmorWorn[3].DefenseMod.ToString());

            if (Player.ArmorWorn[4].Name == null) LoDConsole.WriteLine("/   \\"); //boots
            else LoDConsole.WriteLine(" ╝ ╚     - Boots Armor: {0} - {1}%", Player.ArmorWorn[4].Name, Player.ArmorWorn[4].DefenseMod.ToString());

            LoDConsole.WriteLine(WordWrap("\nYour current objective is: {0}"), Player.Objective);
        }

        public static void DrawMap()
        {
            int row;
            int col;
            LoDConsole.Clear();
            //Console.CursorSize
            LoDConsole.WriteLine("Map of " + ThisFloor.FloorName);
            LoDConsole.WriteLine("──────────────────────");
            LoDConsole.WriteLine("* Dead End");
            LoDConsole.WriteLine("X Blocked");
            LoDConsole.WriteLine("┼ Path\n\n");

            LoDConsole.Write("\t┌────────────┐\n");
            for (row = 0; row < ThisFloor.CurrentFloor.GetLength(0); row++)
            {
                LoDConsole.Write("\t│ ");
                for (col = 0; col < ThisFloor.CurrentFloor.GetLength(1); col++)
                {
                    //Draw the map
                    roomInfo TempRoom = new roomInfo();
                    TempRoom = ThisFloor.CurrentFloor[row, col];
                    if (TempRoom.Explored == true)
                    {
                        if (TempRoom.CanMove == true)
                        {
                            if (row > 0 && row < ThisFloor.CurrentFloor.GetLength(0) && col > 0 && col < ThisFloor.CurrentFloor.GetLength(1))
                            {
                                bool north = false;
                                bool east = false;
                                bool south = false;
                                bool west = false;
                                bool isPlayer = false;

                                if (row == Player.CurrentPos[0] && col == Player.CurrentPos[1]) isPlayer = true;
                                if (ThisFloor.CurrentFloor[row - 1, col].CanMove == true) north = true;
                                if (ThisFloor.CurrentFloor[row + 1, col].CanMove == true) south = true;
                                if (ThisFloor.CurrentFloor[row, col - 1].CanMove == true) west = true;
                                if (ThisFloor.CurrentFloor[row, col + 1].CanMove == true) east = true;

                                /*
                                 *      http://www.theasciicode.com.ar/ 
                                 */

                                if (isPlayer == true) Console.Write("O");
                                //North Combinations
                                else if (north == true && south == true && east == true && west == true) LoDConsole.Write("┼");
                                else if (north == true && south == true && east == true && west == false) LoDConsole.Write("├");
                                else if (north == true && south == true && east == false && west == true) LoDConsole.Write("┤");
                                else if (north == true && south == true && east == false && west == false) LoDConsole.Write("│");
                                else if (north == true && south == false && east == true && west == true) LoDConsole.Write("┴");
                                else if (north == true && south == false && east == true && west == false) LoDConsole.Write("└");
                                else if (north == true && south == false && east == false && west == true) LoDConsole.Write("┘");

                                //South Combinations
                                else if (north == false && south == true && east == true && west == true) LoDConsole.Write("┬");
                                else if (north == false && south == true && east == true && west == false) LoDConsole.Write("┌");
                                else if (north == false && south == true && east == false && west == true) LoDConsole.Write("┐");

                                //East West Combinations
                                else if (north == false && south == false && east == true && west == true) LoDConsole.Write("─");
                                else LoDConsole.Write("X");
                            }
                        }
                        else LoDConsole.Write("*");
                    }
                    else LoDConsole.Write(" ");

                }
                LoDConsole.Write(" │\n");
            }
            LoDConsole.WriteLine("\t└────────────┘");
        }

        #endregion

        #region NPC Functions

        public static void AskQuestion(string Target, string Topic)
        {
            bool Found = false;
            string Knowledge = string.Empty;

            if (CurrentRoom.Civilians != null)
            {
                if (Target == string.Empty && CurrentRoom.Civilians.Count == 1) Target = CurrentRoom.Civilians[0].name;
                foreach (CivilianProfile NPC in CurrentRoom.Civilians)
                {
                    if (Target.ToLower().Trim() == NPC.name.ToLower().Trim())
                    {
                        Found = true;
                        if (NPC.Knowledge != null)
                        {
                            foreach (Facts Fact in NPC.Knowledge)
                            {
                                if (Fact.Topic.ToLower() == Topic.ToLower()) Knowledge = Fact.Knowledge;
                            }
                            if (Knowledge == string.Empty) Knowledge = "I'm afraid I don't know anything about that";
                        }
                        else Knowledge = "I'm afraid I don't know anything about that";
                    }
                }
                if (Found == true) LoDConsole.WriteLine(WordWrap(Target + " says to you \"" + Knowledge + "\""));
                else LoDConsole.WriteLine("That person does not seem to be here");
            }
            else if (CurrentRoom.Enemy != null)
            {
                foreach (EnemyProfile Enemy in CurrentRoom.Enemy)
                {
                    if (Enemy.name.ToLower() == Target.ToLower())
                    {
                        Knowledge = "It is not advisable to ask somebody questions if they are trying to kill you.";
                    }
                }
                if (Knowledge != string.Empty) LoDConsole.WriteLine(WordWrap(Knowledge));
            }
            else LoDConsole.WriteLine("That person does not seem to be here");
        }

        public static string TalkToNPC(string NPCname)
        {
            int index;
            string Response = "that person does not appear to be here...";

            if (CurrentRoom.Civilians == null)
            {
                Response = "There are no people around who are willing to talk to you...";
            }
            else
            {
                for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                {
                    if (NPCname.ToLower() == CurrentRoom.Civilians[index].name.ToLower()) Response = string.Concat("\"", CurrentRoom.Civilians[index].TalkToResponse, "\"");
                }
            }
            return (Response);
        }

        public static void StartFight(string NPCname)
        {
            int index = 0;
            bool NPCFound = false;

            if (CurrentRoom.Civilians != null)
            {
                while (NPCFound == false && index < CurrentRoom.Civilians.Count)
                {
                    if (NPCname.ToLower() == CurrentRoom.Civilians[index].name.ToLower())
                    {
                        NPCFound = true;

                        if (CurrentRoom.Enemy == null)
                        {
                            CurrentRoom.Enemy = new List<EnemyProfile>();
                        }

                        if (CurrentRoom.Civilians[index].QuestCharacter == false)
                        {
                            EnemyProfile NewEnemy = new EnemyProfile();

                            NewEnemy.name = CurrentRoom.Civilians[index].name;
                            NewEnemy.Money = CurrentRoom.Civilians[index].Money;
                            NewEnemy.HPBonus = CurrentRoom.Civilians[index].HPBonus;
                            NewEnemy.armor = CurrentRoom.Civilians[index].armor;
                            NewEnemy.XP = CurrentRoom.Civilians[index].XP;
                            NewEnemy.PayOff = 0;
                            NewEnemy.Weapon.Class = "Weapon";
                            NewEnemy.Weapon.AttackMod = 1;
                            NewEnemy.Weapon.CanPickUp = false;
                            NewEnemy.Weapon.Name = "fists";
                            NewEnemy.Behaviour = "AttackPlayer";

                            if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

                            if (CurrentRoom.Civilians[index].inventory != null && CurrentRoom.Civilians[index].inventory.Count > 0)
                            {
                                for (int counter = 0; counter < CurrentRoom.Civilians[index].inventory.Count; counter++)
                                {
                                    if (CurrentRoom.Civilians[index].inventory[counter].Class == "Weapon" && NewEnemy.Weapon.AttackMod < CurrentRoom.Civilians[index].inventory[counter].AttackMod)
                                    {
                                        NewEnemy.Weapon = CurrentRoom.Civilians[index].inventory[counter];
                                    }
                                    else CurrentRoom.items.Add(CurrentRoom.Civilians[index].inventory[counter]);
                                }
                            }
                            CurrentRoom.Enemy.Add(NewEnemy);
                            CurrentRoom.Civilians.RemoveAt(index);
                            SurpriseAttack(NewEnemy.name);
                        }
                        else
                        {
                            NPCFound = true;
                            LoDConsole.WriteLine(WordWrap(string.Concat("Starting a fight with ", CurrentRoom.Civilians[index].name, " is not a good idea")));
                        }
                    }
                    index++;
                }
                if (NPCFound == false) LoDConsole.WriteLine("Cannot find that person here");

            }
            else LoDConsole.WriteLine("There is nobody around here to fight");
        }
        
        public static bool isNPC(string NPCname)
        {
            if (CurrentRoom.Civilians != null)
            {
                foreach (CivilianProfile NPC in CurrentRoom.Civilians)
                {
                    if (NPC.name.ToLower() == NPCname.ToLower()) return true;
                }
            }
            return false;
        }


        #endregion

        #region Event Functions

        public static bool EventTrigger(string Trigger)
        {
            int i = 0;
            bool Fired = false;
            while (CurrentRoom.Events != null && i < CurrentRoom.Events.Count)
            {
                if (CurrentRoom.Events[i].Trigger.ToLower() == Trigger.ToLower())
                {
                    CurrentRoom.Events[i] = EventAction(CurrentRoom.Events[i]);
                    Fired = true;
                }
                i++;
            }
            return Fired;
        }

        public static bool EventTrigger(string Trigger, string criteria)
        {
            int i = 0;
            bool Fired = false;
            while (CurrentRoom.Events != null && i < CurrentRoom.Events.Count)
            {
                if (CurrentRoom.Events[i].Trigger.ToLower() == Trigger.ToLower() && (string.IsNullOrEmpty(CurrentRoom.Events[i].triggerCriteria) || CurrentRoom.Events[i].triggerCriteria.ToLower() == criteria.ToLower()))
                {
                    CurrentRoom.Events[i] = EventAction(CurrentRoom.Events[i]);
                    Fired = true;
                }
                i++;
            }
            return Fired;
        }

        public static Event EventAction(Event thisEvent)
        {
            if (thisEvent.Triggered == false)
            {
                thisEvent.Triggered = true;

                if (thisEvent.Action.ToLower() == "unlockroom")   //unlock
                {
                    if (thisEvent.Coodinates != null)
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].CanMove = true;
                    }
                }
                else if (thisEvent.Action.ToLower() == "lockroom")   //lock
                {
                    if (thisEvent.Coodinates != null)
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].CanMove = false;
                    }

                }
                else if (thisEvent.Action.ToLower() == "unlockbuilding")   //unlock
                {
                    if (thisEvent.Coodinates != null)
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building.CanMove = true;
                    }
                }
                else if (thisEvent.Action.ToLower() == "lockbuilding")   //lock
                {
                    if (thisEvent.Coodinates != null)
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building.CanMove = false;
                    }

                }
                else if (thisEvent.Action.ToLower() == "lockin")
                {
                    if (!CurrentRoom.LockedIn) CurrentRoom.LockedIn = true;
                    else CurrentRoom.LockedIn = false;
                    SaveWorld();
                }
                else if (thisEvent.Action.ToLower() == "kill all enemies") //kill all
                {
                    //do some other things
                    if (CurrentRoom.Enemy != null)
                    {
                        if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

                        foreach (EnemyProfile ThisEnemy in CurrentRoom.Enemy)
                        {
                            CurrentRoom.items.Add(ThisEnemy.Weapon);

                            itemInfo newItem = new itemInfo();

                            newItem.Name = string.Concat(ThisEnemy.name, "'s body");
                            newItem.Class = "Object";
                            newItem.Examine = string.Concat("The slashed and torn body of enemy ", ThisEnemy.name);
                            newItem.CanPickUp = false;
                            newItem.InteractionName = new List<string>();
                            newItem.InteractionName.Add("body");
                            newItem.InteractionName.Add("corpse");
                            newItem.InteractionName.Add("enemy");
                            newItem.InteractionName.Add(string.Concat(ThisEnemy.name, "'s body"));
                            newItem.InteractionName.Add(ThisEnemy.name);
                            CurrentRoom.items.Add(newItem);

                            GainXPfromEnemy(ThisEnemy);
                        }
                        EventTrigger("killallenemies");
                        CurrentRoom.Enemy.Clear();   //Overwrite all enemies
                    }
                }
                else if (thisEvent.Action.ToLower() == "remove all npcs") //remove all npcs
                {
                    CurrentRoom.Civilians.Clear();
                    SaveWorld();
                }
                else if (thisEvent.Action.ToLower() == "remove all items") //remove all npcs
                {
                    CurrentRoom.items.Clear();
                    SaveWorld();
                }
                else if (thisEvent.Action.ToLower() == "change description" || thisEvent.Action.ToLower() == "custom description") //change description
                {
                    if (thisEvent.Coodinates[2] != Player.CurrentPos[2]) //If change is not on this floor
                    {
                        Floor TempFloor;
                        TempFloor = world[thisEvent.Coodinates[2]];

                        if (!thisEvent.ApplyToBuilding)
                        {
                            if (thisEvent.Action.ToLower() == "change description") TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].AltDescription;
                            else TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = thisEvent.EventValue;
                        }
                        else if (thisEvent.ApplyToBuilding == true && TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building.BuildingName != null)
                        {
                            roomInfo TempRoom = new roomInfo();
                            DataTypes dt = new DataTypes();
                            TempRoom = dt.BuildingIntoRoom(TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building);
                            if (thisEvent.Action.ToLower() == "change description") TempRoom.Description = TempRoom.AltDescription;
                            else TempRoom.Description = thisEvent.EventValue;
                            TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building = dt.RoomIntoBuilding(TempRoom);
                        }
                        world[thisEvent.Coodinates[2]] = TempFloor;
                    }
                    else if (Player.CurrentPos[0] != thisEvent.Coodinates[0] || Player.CurrentPos[1] != thisEvent.Coodinates[1])    //Change is not in this cell
                    {
                        if (!thisEvent.ApplyToBuilding)
                        {
                            if (thisEvent.Action.ToLower() == "change description") ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].AltDescription;
                            else ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = thisEvent.EventValue;
                        }
                        else if (thisEvent.ApplyToBuilding == true && ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building.BuildingName != null)
                        {
                            roomInfo TempRoom = new roomInfo();
                            DataTypes dt = new DataTypes();
                            TempRoom = dt.BuildingIntoRoom(ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building);
                            if (thisEvent.Action.ToLower() == "change description") TempRoom.Description = TempRoom.AltDescription;
                            else TempRoom.Description = thisEvent.EventValue;
                            ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building = dt.RoomIntoBuilding(TempRoom);
                        }
                    }
                    else
                    {
                        if ((!thisEvent.ApplyToBuilding && !Player.InBuilding) || (thisEvent.ApplyToBuilding && Player.InBuilding))   //Applying to the non-building area the player is in
                        {
                            if (thisEvent.Action.ToLower() == "change description") CurrentRoom.Description = CurrentRoom.AltDescription;
                            else CurrentRoom.Description = thisEvent.EventValue;
                        }
                        else if (!thisEvent.ApplyToBuilding && Player.InBuilding == true)   //Applies to current cell but player is in building
                        {
                            if (thisEvent.Action.ToLower() == "change description") ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].AltDescription;
                            else ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = thisEvent.EventValue;
                        }
                        else if (thisEvent.ApplyToBuilding == true && Player.InBuilding == false)   //Applies to building in current Cell
                        {
                            roomInfo TempRoom = new roomInfo();
                            DataTypes dt = new DataTypes();
                            TempRoom = dt.BuildingIntoRoom(ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building);
                            if (thisEvent.Action.ToLower() == "change description") TempRoom.Description = TempRoom.AltDescription;
                            else TempRoom.Description = thisEvent.EventValue;
                            ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Building = dt.RoomIntoBuilding(TempRoom);
                        }
                    }
                    SaveWorld();
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);   //retreive new room info
                }
                else if (thisEvent.Action.ToLower() == "change location") //change floor
                {
                    bool newFloor = false;
                    if (thisEvent.Coodinates[2] != Player.CurrentPos[2]) newFloor = true;   //If the player is changing floors

                    //ThisEvent will remain bool untriggered as will allow multiple re-use
                    //Thread.Sleep(5000);
                    world[Player.CurrentPos[2]] = ThisFloor;    //save floor to list. 
                    Player.CurrentPos[0] = thisEvent.Coodinates[0];
                    Player.CurrentPos[1] = thisEvent.Coodinates[1];   //set players position to start of new room
                    Player.CurrentPos[2] = thisEvent.Coodinates[2];
                    ThisFloor = world[Player.CurrentPos[2]];    //retreive new floor
                    if (!thisEvent.ApplyToBuilding) Player.InBuilding = false;
                    else Player.InBuilding = true;
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);   //retreive new room info

                    //else if (!string.IsNullOrEmpty(ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]].Building.BuildingName))   //move player into building. 
                    //{
                    //    DataTypes dt = new DataTypes();
                    //    CurrentRoom = dt.BuildingIntoRoom(ThisFloor.CurrentFloor[Player.CurrentPos[0],Player.CurrentPos[1]].Building);
                    //}
                    LoDConsole.Clear();    //clear the screen
                    LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));

                    if (newFloor == true && ThisFloor.FloorSong != null && File.Exists(ThisFloor.FloorSong))
                    {
                        MusicPlayer.SoundLocation = ThisFloor.FloorSong;
                        Music("Start");
                    }
                }
                else if (thisEvent.Action.ToLower() == "change objective")
                {
                    Player.Objective = thisEvent.EventValue;
                    LoDConsole.WriteLine("\nYour current objective has changed.");
                }
                /* 
                else if (thisEvent.Action.ToLower() == "custom description")
                {
                    CurrentRoom.Description = thisEvent.EventValue;
                    SaveWorld();
                } 
                */
                else if (thisEvent.Action.ToLower() == "output text")
                {
                    LoDConsole.WriteLine("");
                    LoDConsole.WriteLine(WordWrap(thisEvent.EventValue));
                }
                else if (thisEvent.Action == "spawnItems")
                {
                    if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();
                    foreach (itemInfo Item in thisEvent.Items)
                    {
                        CurrentRoom.items.Add(Item);
                    }
                    SaveWorld();
                }
                else if (thisEvent.Action == "spawnNPC")
                {
                    if (CurrentRoom.Civilians == null) CurrentRoom.Civilians = new List<CivilianProfile>();
                    foreach (CivilianProfile NPC in thisEvent.NPCs)
                    {
                        CurrentRoom.Civilians.Add(NPC);
                    }
                    SaveWorld();
                }
                else if (thisEvent.Action == "spawnEnemy")
                {
                    if (CurrentRoom.Enemy == null) CurrentRoom.Enemy = new List<EnemyProfile>();
                    foreach (EnemyProfile Enemy in thisEvent.Enemies)
                    {
                        CurrentRoom.Enemy.Add(Enemy);
                    }
                    SaveWorld();
                }
                else if (thisEvent.Action == "giveXP")
                {
                    int n;
                    if (int.TryParse(thisEvent.EventValue, out n)) Player.XP = Player.XP + n;
                }
                else if (thisEvent.Action == "EndCredits")
                {
                    Console.ReadKey();
                    EndCredits();
                }
                else thisEvent.Triggered = false;

                //If an event is re-usable allow it to be triggered again
                if (thisEvent.Triggered == true && thisEvent.ReUsable == true) thisEvent.Triggered = false;
                if (thisEvent.Coodinates != null && thisEvent.Coodinates[0] == Player.CurrentPos[0] && thisEvent.Coodinates[1] == Player.CurrentPos[1] && thisEvent.Coodinates[2] == Player.CurrentPos[2])
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);
            }
            return thisEvent;
        }

        #endregion

        #region LevelUp Functions

        public static void LevelUp(int Level)
        {
            Player.Speed = Player.Speed + 1;
            Player.Strength = Player.Strength + 0.5;
            Player.Resitence = Player.Resitence + 1;
            Player.MaxHp = Player.MaxHp + 5;
            Player.HPBonus = Player.HPBonus + 5;
            Player.MaxItems = Player.MaxItems + 1;
            Player.invspace = Player.invspace + 1;
            Player.Level = Level;

            LoDConsole.WriteLine("\n!! You have levelled up !!\nYou are now faster, stronger and can carry more items!");
        }

        public static EnemyProfile GainXPfromEnemy(EnemyProfile Enemy)
        {
            if (Enemy.XP > 0) Player.XP = Player.XP + Enemy.XP;
            Enemy.XP = 0;

            return Enemy;
        }

        public static itemInfo GainXPfromItem(itemInfo ItemUsed)
        {
            if (ItemUsed.XP > 0) Player.XP = Player.XP + ItemUsed.XP;
            ItemUsed.XP = 0;

            return ItemUsed;
        }

        public static CivilianProfile GainXPfromNPC(CivilianProfile NPC)
        {
            if (NPC.XP > 0) Player.XP = Player.XP + NPC.XP;
            NPC.XP = 0;

            return NPC;
        }

        #endregion

        #region Game Functions

        public static void SaveWorld()
        {
            if (Player.InBuilding == true)
            {
                DataTypes dt = new DataTypes();
                ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]].Building = dt.RoomIntoBuilding(CurrentRoom);
            }
            else ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
            world[Player.CurrentPos[2]] = ThisFloor;
            WorldState.WorldState = world;
        }

        public static string SaveGame()
        {
            string SavePath = LoDConsole.SaveFile("\\Saves\\");
            if (SavePath == "!FAIL!" || !File.Exists(SavePath))
            {
                return "Save Failure";
            }
            else
            {

                GameState gamestate = new GameState();

                SaveWorld();

                gamestate.PlayerState = Player;
                WorldState.WorldState = world;
                gamestate.WorldState = WorldState;

                using (Stream stream = File.Open(SavePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, gamestate);
                }
                return ("Success");
            }
        }

        public static void TimeTicker()
        {
            int index = 0;
            while (stopTime > -1)
            {
                lock (myLock)
                {
                    if (stopTime == -1) break;
                    else if (stopTime == 1) index++;
                }
                if (index == 15)
                {
                    WorldState.WorldTime = WorldState.WorldTime + 1;
                    if (WorldState.WorldTime == 1440) WorldState.WorldTime = 0;
                    else if (WorldState.WorldTime == 360) LoDConsole.WriteLine("\n\nThe sun rises in the distance, dawn has come\n>");
                    else if (WorldState.WorldTime == 480)
                    {
                        Player.DaysSinceSleep = Player.DaysSinceSleep + 1;
                        if (Player.DaysSinceSleep == 1) LoDConsole.WriteLine("\n\nYou have been awake for 24 hours, perhaps you should take some rest?\n>");
                        else if (Player.DaysSinceSleep == 2) LoDConsole.WriteLine("\n\nYou have been awake for 48 hours, Take some rest soon!\n>");
                        else if (Player.DaysSinceSleep == 3) LoDConsole.WriteLine("\n\nYou have been awake for 72 hours, you need to find a place to sleep!\n>");
                        else if (Player.DaysSinceSleep == 4)
                        {
                            LoDConsole.WriteLine("\n\nHaving been awake for 96 hours your body shuts down. Your fall into a deep sleep. Never to wake up...");
                            Player.HPBonus = 0;
                            Player.DaysSinceSleep = 0;
                        }
                    }
                    else if (WorldState.WorldTime == 1200) LoDConsole.WriteLine("\n\nThe sun sets over the horizon, night has come\n>");
                    index = 0;
                }
                Thread.Sleep(1000);
            }
            lock (myLock) { stopProcessing = true; }
        }

        public static void Music(string Command)
        {
            if (Command.ToLower() == "start")
            {
                //player.PlaySync();
                MusicPlayer.PlayLooping();
            }
            else if (Command.ToLower() == "browse")
            {
                MusicPlayer.SoundLocation = LoDConsole.FindFile("\\Music\\");
                MusicPlayer.PlayLooping();
            }
            else if (Command.ToLower() == "stop")
            {
                MusicPlayer.Stop();
            }
        }

        public static void MusicVolume(double percent)
        {
            int NewVolume = Convert.ToInt32(percent);

            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));

            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        public static string WordWrap(string input)
        {
            /* Now handled by txtOutputConsole
             * 
            string WrappedOutput = string.Empty;
            string tempstring = string.Empty;
            if (input != null)
            {
                string[] strArray = input.Split(' ');
                int index;
                int linelength = 0;
                tempstring = strArray[0];

                for (index = 1; index < strArray.Length; index++)
                {
                    if (strArray[index].Contains("\n"))
                    {
                        tempstring = string.Concat(tempstring, " ", strArray[index]);
                        linelength = 0;
                    }
                    else if (linelength >= 50)
                    {
                        tempstring = string.Concat(tempstring, "\n", strArray[index]);
                        linelength = strArray[index].Length;
                    }
                    else
                    {
                        tempstring = string.Concat(tempstring, " ", strArray[index]);
                        linelength = linelength + strArray[index].Length;
                    }
                }
            }
            WrappedOutput = tempstring;
            return (WrappedOutput);
             * */
            return input;
        }

        public static void EndCredits()
        {
            LoDConsole.Clear();
            int Linebreaks = 20;
            int Counter = 0;
            int StartLine = 0;
            int i;
            List<string> Credits = new List<string>();
            Credits.Add("Game Developed by Joe van de Bilt");
            if (WorldState.WorldAuthor != null) Credits.Add("World Designed by " + WorldState.WorldAuthor);
            if (WorldState.Credits != null) foreach (string Credit in WorldState.Credits) { Credits.Add(Credit); }
            while (Counter < (Credits.Count + 20))
            {
                for (i = 0; i < Linebreaks; i++) { LoDConsole.WriteLine(); }
                for (i = StartLine; i <= Counter; i++)
                {
                    if (i >= Credits.Count) LoDConsole.WriteLine();
                    else LoDConsole.WriteLine("\t\t" + Credits[i] + "\n\n");
                }
                Counter = Counter + 1;
                Linebreaks = Linebreaks - 1;
                if (Linebreaks <= 0) StartLine++;
                //Thread.Sleep(1000);
                LoDConsole.Clear();
            }
            LoDConsole.Clear();
            LoDConsole.WriteLine("\n\n\n\t\tThank you for Playing");
            Console.ReadKey();
            //Run the main menu screen
            DrawMainMenu();
            ThisFloor = world[Player.CurrentPos[2]];
            CurrentRoom = ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]];
            LoDConsole.WriteLine(WordWrap(CurrentRoom.Description));
        }

        public static void ForceError() { LoDConsole.WriteLine(WordWrap(world[-1].CurrentFloor[-1, -1].Description)); } //Debugging Only

        public static string CleanPlayerInput(string PlayerInput)
        {
            PlayerInput = PlayerInput.Replace('?', ' ');
            PlayerInput = PlayerInput.Replace('!', ' ');
            PlayerInput = PlayerInput.Replace('.', ' ');
            PlayerInput = PlayerInput.Replace(',', ' ');
            PlayerInput = PlayerInput.Replace(':', ' ');
            PlayerInput = PlayerInput.Replace(';', ' ');
            PlayerInput = PlayerInput.Replace('/', ' ');
            PlayerInput = PlayerInput.Replace('\\', ' ');
            PlayerInput = PlayerInput.Trim();

            return PlayerInput;
        }

        public static bool CommandContains(string PlayerCommand, string CommandsRequired)
        {
            bool Contained = false;
            string[] PlayerCommands = PlayerCommand.Split(' ');
            string[] RequiredCommands = CommandsRequired.Split(' ');
            foreach (string Command in RequiredCommands)
            {
                Contained = false;
                foreach (string Word in PlayerCommands)
                {
                    if (Command.ToLower() == Word.ToLower()) Contained = true;
                }
                if (!Contained) return false;
            }
            return true;
        }

        public static void QuitGame()
        {
            lock (myLock)
            {
                stopTime = -1;
            }
            Environment.Exit(0);
        }

        public static void TestConsole()
        {
            LoDConsole.WriteLine("This should be written on the same line");
            LoDConsole.WriteLine();
            LoDConsole.Write("This should be written on the same line ");
            LoDConsole.Write("as this.");
        }

        

        #endregion
    }
}

//end of line...