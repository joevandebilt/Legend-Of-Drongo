/*  
 * This game is protected under the Artistic License 2.0
 *      Copyright (c) 2014 Joseph Benjamin van de Bilt
 *
 *      Everyone is permitted to copy and distribute verbatim copies
 *      of this license document, but changing it is not allowed.
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

namespace Legend_Of_Drongo
{
    class LegendOfDrongoEngine : DataTypes
    {
        public static WorldFile WorldState = new WorldFile();

        public static List<Floor> world = new List<Floor>();

        public static Floor ThisFloor = new Floor();

        public static roomInfo CurrentRoom = new roomInfo();

        public static roomInfo PotentialRoom = new roomInfo();

        public static PlayerProfile Player = new PlayerProfile();

        public static SoundPlayer MusicPlayer = new SoundPlayer();

        public static object myLock = new object();
        public static bool stopProcessing = false;
   
        public static PlayerProfile MainMenu()
        {
            Player = new PlayerProfile();

            bool validChoice = false;
            Console.Clear();

            MusicPlayer.SoundLocation = ".\\Music\\Warning.wav";
            Music("Start");

            Console.WriteLine(WordWrap("This game uses music files throughout and can appear be very loud. Before continuing it may be wise to mute or lower the volume on this application"));
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
            Console.Clear();

            MusicPlayer.SoundLocation = ".\\Music\\Quartis.wav";
            Music("Start");
            Console.SetWindowSize(70, 50);
            Console.Title = "Legend of Drongo";


            while (validChoice == false)
            {
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("     _        _______  _______  _______  _        ______  ");
            Console.WriteLine("     ( \\      (  ____ \\(  ____ \\(  ____ \\( (    /|(  __  \\ ");
            Console.WriteLine("     | (      | (    \\/| (    \\/| (    \\/|  \\  ( || (  \\  )");
            Console.WriteLine("     | |      | (__    | |      | (__    |   \\ | || |   ) |");
            Console.WriteLine("     | |      |  __)   | | ____ |  __)   | (\\ \\) || |   | |");
            Console.WriteLine("     | |      | (      | | \\_  )| (      | | \\   || |   ) |");
            Console.WriteLine("     | (____/\\| (____/\\| (___) || (____/\\| )  \\  || (__/  )");
            Console.WriteLine("     (_______/(_______/(_______)(_______/|/    )_)(______/ ");
            Console.WriteLine("                                                      ");
            Console.WriteLine("                          _______  _______                 ");
            Console.WriteLine("                         (  ___  )(  ____ \\                ");
            Console.WriteLine("                         | (   ) || (    \\/                ");
            Console.WriteLine("                         | |   | || (__                    ");
            Console.WriteLine("                         | |   | ||  __)                   ");
            Console.WriteLine("                         | |   | || (                      ");
            Console.WriteLine("                         | (___) || )                      ");
            Console.WriteLine("                         (_______)|/                       ");
            Console.WriteLine("                                                      ");
            Console.WriteLine("      ______   _______  _______  _        _______  _______ ");
            Console.WriteLine("     (  __  \\ (  ____ )(  ___  )( (    /|(  ____ \\(  ___  )");
            Console.WriteLine("     | (  \\  )| (    )|| (   ) ||  \\  ( || (    \\/| (   ) |");
            Console.WriteLine("     | |   ) || (____)|| |   | ||   \\ | || |      | |   | |");
            Console.WriteLine("     | |   | ||     __)| |   | || (\\ \\) || | ____ | |   | |");
            Console.WriteLine("     | |   ) || (\\ (   | |   | || | \\   || | \\_  )| |   | |");
            Console.WriteLine("     | (__/  )| ) \\ \\__| (___) || )  \\  || (___) || (___) |");
            Console.WriteLine("     (______/ |/   \\__/(_______)|/    )_)(_______)(_______)");

            Console.WriteLine("\n\n\n");

            //Console.WriteLine("              [N] New Game       [L] Load Game    [Q] Quit");
            Console.WriteLine("        [N] New Game    [T] Tutorial    [C] Custom Game\n\n                [L] Load Game        [Q] Quit");
            //Console.WriteLine("              [N] New Game                        [Q] Quit");
            ConsoleKeyInfo Menu = Console.ReadKey();

                if (Menu.Key == ConsoleKey.N)
                {
                    Player = new PlayerProfile();
                    validChoice = true;
                    Console.Clear();
                    Console.Write("What is your name?: ");

                    string playername = Console.ReadLine();
                    if (playername == "")
                    {
                        playername = "Drongo";
                    }

                    //Player.name = "... You do not remember your name...";
                    Player.name = playername;
                    Player.HPBonus = 84;
                    Player.ArmorBonus = 0;

                    //set up starter inventory
                    Player.inventory = new itemInfo[20];
                    Player.inventory[0].Name = "Apple";
                    Player.inventory[0].HPmod = 5;
                    Player.inventory[0].Class = "Food";
                    Player.inventory[0].Examine = "Looks like a fresh apple";
                    Player.inventory[0].CanPickUp = true;
                    Player.inventory[0].InteractionName = new List<string>();
                    Player.inventory[0].InteractionName.Add("apple");
                    Player.invspace = 19;

                    //set up game parameters
                    Player.CurrentPos = new int[3] { 1, 1, 1 }; //Row, Column, Floor
                    Player.Objective = "Find a way out of the forest";
                    Player.Money = 100;

                    //set up starter weapon
                    Player.WeaponHeld.Name = "Fists";
                    Player.WeaponHeld.BadHit = "Your Knuckles lightly graze your enemies cheek";
                    Player.WeaponHeld.MedHit = "You hit your enemy with a quick jab to the ribs";
                    Player.WeaponHeld.GoodHit = "A sound of crunching bone can be heard as your fist hits your enemy in the jaw";
                    Player.WeaponHeld.AttackMod = 1;
                    Player.WeaponHeld.CanPickUp = true;
                    Player.WeaponHeld.InteractionName = new List<string>();
                    Player.WeaponHeld.InteractionName.Add("Fists");
                    Player.WeaponHeld.InteractionName.Add("Hands");
                    Player.WeaponHeld.Class = "Weapon";
                    Player.WeaponHeld.Examine = "Your own hands, how they got on the floor I will never know...";
                    Player.ArmorWorn = new itemInfo[5];

                    Console.Clear();
                    
                    Thread Intro = new Thread(Introduction);
                    Intro.Start();

                    while (stopProcessing == false)
                    {
                        ConsoleKeyInfo KeyPress = Console.ReadKey();
                        if (KeyPress.Key == ConsoleKey.Spacebar)
                        {
                            lock (myLock)
                            {
                                stopProcessing = true;
                            }
                            Console.WriteLine("\n           SKIPPING INTRO");
                        }
                    }
                    Intro.Join();

                    //Load Campaign World
                    using (Stream stream = File.Open(".\\Worlds\\LoDCampaign.LoD", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        WorldState = (WorldFile)bin.Deserialize(stream);
                    }
                    world = WorldState.WorldState;

                    PlayerStatus();
                    Console.WriteLine(WordWrap("\nYour current objective is: {0}"), Player.Objective);
                    Console.WriteLine(WordWrap("Press any key to start your adventure..."));
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Menu.Key == ConsoleKey.T)
                {
                    Player = new PlayerProfile();
                    validChoice = true;
                    Console.Clear();

                        Console.Write("What is your name?: ");

                        string playername = Console.ReadLine();
                        if (playername == "")
                        {
                            playername = "Drongo";
                        }

                    Player.name = playername;
                    Player.HPBonus = 100;
                    Player.ArmorBonus = 0;

                    //set up starter inventory
                    Player.inventory = new itemInfo[20];
                    Player.invspace = 20;

                    //set up game parameters
                    Player.CurrentPos = new int[3] { 1, 1, 0 }; //Row, Column, Floor
                    Player.Objective = "Complete the tutorial";
                    Player.Money = 100;

                    //set up starter weapon
                    Player.WeaponHeld.Name = "Fists";
                    Player.WeaponHeld.BadHit = "Your Knuckles lightly graze your enemies cheek";
                    Player.WeaponHeld.MedHit = "You hit your enemy with a quick jab to the ribs";
                    Player.WeaponHeld.GoodHit = "A sound of crunching bone can be heard as your fist hits your enemy in the jaw";
                    Player.WeaponHeld.AttackMod = 1;
                    Player.WeaponHeld.CanPickUp = true;
                    Player.WeaponHeld.InteractionName = new List<string>();
                    Player.WeaponHeld.InteractionName.Add("fists");
                    Player.WeaponHeld.InteractionName.Add("hands");
                    Player.WeaponHeld.Class = "Weapon";
                    Player.WeaponHeld.Examine = "Your own hands, how they got on the floor I will never know...";
                    Player.ArmorWorn = new itemInfo[5];


                    //Load Tutorial World
                    using (Stream stream = File.Open(".\\Worlds\\LoDTutorial.LoD", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        WorldState = (WorldFile)bin.Deserialize(stream);

                    }
                    world = WorldState.WorldState;
                    Console.Clear();
                }
                else if (Menu.Key == ConsoleKey.L)
                {
                    validChoice = true;
                    System.IO.DirectoryInfo parDir = new System.IO.DirectoryInfo(".\\Saves");
                    int SaveIndex = 0;
                    List<string> SavesList = new List<string>();

                    if (parDir.GetDirectories().Length != 0)
                    {
                        Console.Clear();
                        Console.WriteLine(WordWrap("Select a save from the list below:"));

                        foreach (DirectoryInfo folder in parDir.GetDirectories())
                        {
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(".\\Saves\\"+ folder.Name);
                            if (dir.GetFiles().Length != 0)
                            {
                                Console.WriteLine(WordWrap("\n\n"+folder.Name));
                                foreach (FileInfo file in dir.GetFiles())    //Find games in saves directory
                                {
                                    string FileName = file.Name;
                                    Console.WriteLine(WordWrap(string.Concat((SaveIndex + 1), ": ", FileName.Split('.')[0])));
                                    SavesList.Add(folder.Name + "\\" + FileName);
                                    SaveIndex++;
                                }
                            }
                        }

                        Console.Write("\nWhich save would you like to continue: ");
                        int UserChoice = Convert.ToInt32(Console.ReadLine());
                        string SavePath = string.Concat(".\\Saves\\", SavesList[UserChoice - 1]);

                        GameState gamestate = new GameState();
                        using (Stream stream = File.Open(SavePath, FileMode.Open))
                        {
                            BinaryFormatter bin = new BinaryFormatter();
                            gamestate = (GameState)bin.Deserialize(stream);

                        }
                        Player = gamestate.PlayerState;
                        world = gamestate.WorldState.WorldState;

                        Console.WriteLine(WordWrap("\n            Loading"));
                        Thread.Sleep(1500);
                        Console.Clear();

                        PlayerStatus();

                        Console.WriteLine(WordWrap("\n\nYour current objective is: {0}"), Player.Objective);
                        Console.WriteLine(WordWrap("Press any key to continue your adventure..."));
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(WordWrap("No saves have been detected. Please check the Saves folder or start a new game\nPress [Enter] To continue"));
                        Console.ReadKey();
                        MainMenu();
                    }
                }
                else if (Menu.Key == ConsoleKey.C)
                {
                    validChoice = true;
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(".\\Worlds");
                    int NumOfSaves = (dir.GetFiles().Length) - 2;
                    int index = 0;
                    string[] WorldsList = new string[NumOfSaves];

                    if (NumOfSaves != 0)
                    {
                        Console.Clear();
                        Console.WriteLine(WordWrap("Select a world from the list below:\n"));

                        foreach (FileInfo file in dir.GetFiles())    //Find games in saves directory
                        {
                            string FileName = file.Name;
                            if (FileName != "LoDCampaign.LoD" && FileName != "LoDTutorial.LoD")
                            {
                                Console.WriteLine(WordWrap(string.Concat((index + 1), ": ", FileName.Split('.')[0])));
                                WorldsList[index] = FileName;
                                index++;
                            }
                        }

                        Console.Write("\nWhich save would you like to continue: ");
                        int n;
                        int UserChoice;

                        string Input = Console.ReadLine();

                        if (int.TryParse(Input, out n)) UserChoice= n;
                        else UserChoice = -1;

                        while (UserChoice > NumOfSaves || UserChoice < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Choice, please try again");
                            Console.WriteLine(WordWrap("Select a world from the list below:\n"));
                            for (int i = 0; i < WorldsList.Length; i++)
                            {
                                Console.WriteLine((i+1) + ": " + WorldsList[i].Split('.')[0]);
                            }
                            Console.Write("\nWhich save would you like to continue: ");
                            Input = Console.ReadLine();
                            if (int.TryParse(Input, out n)) UserChoice = n;
                            else UserChoice = -1;
                        }
                        string SavePath = string.Concat(".\\Worlds\\", WorldsList[UserChoice - 1]);

                        using (Stream stream = File.Open(SavePath, FileMode.Open))
                        {
                            BinaryFormatter bin = new BinaryFormatter();
                            WorldState = (WorldFile)bin.Deserialize(stream);
                        }
                        world = WorldState.WorldState;

                        Console.Clear();
                        Console.Write("What is your name?: ");

                        string playername = Console.ReadLine();
                        if (playername == "")
                        {
                            playername = "Drongo";
                        }

                        Player.name = playername;
                        Player.HPBonus = 100;
                        Player.ArmorBonus = 0;

                        //set up starter inventory
                        Player.inventory = new itemInfo[20];
                        Player.invspace = 20;

                        //set up game parameters
                        Player.CurrentPos = new int[3] { 1, 1, 0 }; //Row, Column, Floor
                        Player.Objective = "";
                        Player.Money = 100;

                        //set up starter weapon
                        Player.WeaponHeld.Name = "Fists";
                        Player.WeaponHeld.BadHit = "Your Knuckles lightly graze your enemies cheek";
                        Player.WeaponHeld.MedHit = "You hit your enemy with a quick jab to the ribs";
                        Player.WeaponHeld.GoodHit = "A sound of crunching bone can be heard as your fist hits your enemy in the jaw";
                        Player.WeaponHeld.AttackMod = 1;
                        Player.WeaponHeld.CanPickUp = true;
                        Player.WeaponHeld.InteractionName = new List<string>();
                        Player.WeaponHeld.InteractionName.Add("fists");
                        Player.WeaponHeld.InteractionName.Add("hands");
                        Player.WeaponHeld.Class = "Weapon";
                        Player.WeaponHeld.Examine = "Your own hands, how they got on the floor I will never know...";
                        Player.ArmorWorn = new itemInfo[5];

                        Console.WriteLine(WordWrap("\n            Loading"));
                        Thread.Sleep(1500);
                        Console.Clear();

                        PlayerStatus();

                        Console.WriteLine(WordWrap("Press any key to Start your adventure..."));
                        Console.ReadKey();
                        Console.Clear();
                        

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(WordWrap("No Worlds have been detected. Please check the Worlds folder or start a new game\n\nPress [Enter] To continue"));
                        Console.ReadKey();
                        MainMenu();
                    }
                }
                else if (Menu.Key == ConsoleKey.Q)
                {
                    validChoice = true;
                    Environment.Exit(0);
                }
                Console.Clear();
            }
                
                
                return (Player);
            
        }

        static void Introduction()
        {
            string[] intro = new string[15];
            int[] sleep = new int[15];
            int index;
            string gap = "\n       ";


            intro[0] = string.Concat ("Game created by Joe van de Bilt");
            sleep[0] = 3000;
            intro[1] = string.Concat ("You are running through the tress.", gap, "Something is chasing you.");
            sleep[1] = 4000;
            intro[2] = string.Concat ("Branches hit you in the face as you fly through the forest.", gap , "You can hear your predator right behind you.");
            sleep[2] = 5000;
            intro[3] = string.Concat ("You come to a river.", gap, "Seeing no way to cross safely", gap, "you throw yourself into the stream.");
            sleep[3] = 4000;
            intro[4] = string.Concat ("The current takes you and your body is thrown about.", gap, "You scramble for control in the mighty torrent of the river.");
            sleep[4] = 4000;
            intro[5] = string.Concat ("As you thrash about, you hit your head. Hard");
            sleep[5] = 3000;
            intro[6] = string.Concat ("You manage to scramble to the shore", gap ,"pulling yourself out of the water.", gap, "You have lost your foe.");
            sleep[6] = 4000;
            intro[7] = string.Concat ("Relief fades to worry", gap, "as you feel warm blood trickle down your face.");
            sleep[7] = 4000;
            intro[8] = string.Concat ("You look around you for help...", gap, "There aren't any signs of life around you.");
            sleep[8] = 5000;
            intro[9] = string.Concat ("You drag yourself further into the tree line", gap, "Your strength fading.");
            sleep[9] = 4000;
            intro[10] = string.Concat ("You collapse, and the world fades to black...");
            sleep[10] = 6000;
            intro[11] = string.Concat ("You awaken in a clearing in the woods.", gap, "Your head feels like hell ...but you're alive");
            sleep[11] = 5000;
            intro[12] = string.Concat ("You can't remember a thing...");
            sleep[12] = 3000;
            intro[13] = string.Concat ("You achingly pull yourself to your feet.", gap, "You need to find a way out of the woods");
            sleep[13] = 3000;
            intro[14] = string.Concat("You achingly pull yourself to your feet.", gap, "You need to find a way out of the woods", gap, "... and find out what happened");
            sleep[14] = 6000;

            index = 0;
            Console.WriteLine("\n\n\n       Press [Spacebar] To skip intro");
            Thread.Sleep(1500);
            while (index < 15)
            {
                lock (myLock)
                {
                    if (stopProcessing == true) break;
                }                
                Console.Clear();
                Console.WriteLine(string.Concat("\n\n", gap, intro[index]));
                Thread.Sleep(sleep[index]);
                index++;
            }
        lock (myLock) {stopProcessing = true; }
            Console.Clear();
        }

        static void Main(string[] args)
        {
            //path = Directory.GetCurrentDirectory();

            Player = MainMenu();
            ThisFloor = world[Player.CurrentPos[2]] ;
            CurrentRoom = GetRoomInfo(Player.CurrentPos);

            Console.WriteLine(WordWrap(CurrentRoom.Description));

            string PlayerCommand = string.Empty;

            while (PlayerCommand != "quit" && PlayerCommand != "exit")
            {

                Console.Write(">"); 
                PlayerCommand = Console.ReadLine();
                //PlayerCommand.ToLower();
                PlayerCommand = PlayerCommand.Trim();
                Console.WriteLine("");

                if (PlayerCommand.ToLower() == "help" || PlayerCommand.ToLower() == "commands" || PlayerCommand.ToLower().Contains("how do i"))
                {
                    Console.WriteLine(WordWrap("Movement"));
                    Console.WriteLine(WordWrap("North - Move North"));
                    Console.WriteLine(WordWrap("East - Move East"));
                    Console.WriteLine(WordWrap("South - Move South"));
                    Console.WriteLine(WordWrap("West - Move West"));
                    Console.WriteLine(WordWrap("\nInteraction and Items"));
                    Console.WriteLine(WordWrap("Attack - Attacks an enemy with equipped weapon"));
                    Console.WriteLine(WordWrap("Bribe - Pay off people to look the other way"));
                    Console.WriteLine(WordWrap("Talk To - Talk to non hostile people"));
                    Console.WriteLine(WordWrap("Ask - Ask a person about a thing"));
                    Console.WriteLine(WordWrap("View Wares - See the wares of a merchant"));
                    Console.WriteLine(WordWrap("Buy - Buy items from merchants"));
                    Console.WriteLine(WordWrap("Sell - Sell an item to a willing merchant"));
                    Console.WriteLine(WordWrap("Take - picks up an item"));
                    Console.WriteLine(WordWrap("Drop - Drops an item"));
                    Console.WriteLine(WordWrap("Sleep in - go to sleep in a bed or bed like item"));
                    Console.WriteLine(WordWrap("Use - Uses an item on something"));
                    Console.WriteLine(WordWrap("Equip - Equip weapons and armor"));
                    Console.WriteLine(WordWrap("Eat - Eats an item in your inventory"));
                    Console.WriteLine(WordWrap("Drink - Drink an item in your inventory"));
                    Console.WriteLine(WordWrap("\nDescriptions"));
                    Console.WriteLine(WordWrap("Describe - Gets the description of the current area you are in"));
                    Console.WriteLine(WordWrap("Read - Read an item, a sign or a other readable items"));
                    Console.WriteLine(WordWrap("Status - Gets status of player, including health, armor and Weapon Status"));
                    Console.WriteLine(WordWrap("Inventory - lists items in inventory"));
                    Console.WriteLine(WordWrap("Objective - Tells you your current objective"));
                    Console.WriteLine(WordWrap("Money - Tells you how much money you have"));
                    Console.WriteLine(WordWrap("Look At - Inspect objects in your current area"));
                    Console.WriteLine(WordWrap("Examine - Examine items in your inventory to a greater detail"));
                    Console.WriteLine(WordWrap("Who am I - Tells you your name"));
                    Console.WriteLine(WordWrap("\nMusic"));
                    Console.WriteLine(WordWrap("Music Play - Start playing music"));
                    Console.WriteLine(WordWrap("Music Browse - Browse music to play"));
                    Console.WriteLine(WordWrap("Music Stop - Stop music playing"));
                    Console.WriteLine(WordWrap("\nControl"));
                    Console.WriteLine(WordWrap("Clear - Clears the current window of all text"));
                    Console.WriteLine(WordWrap("Save - Saves your characters current progress"));
                    Console.WriteLine(WordWrap("Main Menu - Goes back to the Main menu"));
                    Console.WriteLine(WordWrap("Quit - Quits game without saving"));
                }
                else if (PlayerCommand.ToLower() == "north" || PlayerCommand.ToLower() == "go north" || PlayerCommand.ToLower() == "move north") 
                {
                    if (!CurrentRoom.LockedIn)
                    {
                        int[] ProposedMove = new int[3];

                        ProposedMove[0] = Player.CurrentPos[0] - 1;
                        ProposedMove[1] = Player.CurrentPos[1];
                        ProposedMove[2] = Player.CurrentPos[2];

                        PotentialRoom = GetRoomInfo(ProposedMove);
                        if (PotentialRoom.CanMove == true)
                        {
                            if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("I Successfully move into position ") + ProposedMove[0] + "," + ProposedMove[1] + "," + ProposedMove[2]);
                            else Console.WriteLine(WordWrap(PotentialRoom.Description));
                            ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
                            CurrentRoom = PotentialRoom;
                            Player.CurrentPos = ProposedMove;
                            EventTrigger("moveinto");
                        }
                        else if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("Looks like I can't go that way."));
                        else Console.WriteLine(WordWrap(PotentialRoom.Description));
                    }
                    else
                    {
                        Console.WriteLine("You cannot leave the current area");
                        attacked();
                    }

                }
                else if (PlayerCommand.ToLower() == "east" || PlayerCommand.ToLower() == "go east" || PlayerCommand.ToLower() == "move east")
                {
                    if (!CurrentRoom.LockedIn)
                    {
                        int[] ProposedMove = new int[3];

                        ProposedMove[0] = Player.CurrentPos[0];
                        ProposedMove[1] = Player.CurrentPos[1] + 1;
                        ProposedMove[2] = Player.CurrentPos[2];

                        PotentialRoom = GetRoomInfo(ProposedMove);
                        if (PotentialRoom.CanMove == true)
                        {
                            if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("I Successfully move into position ") + ProposedMove[0] + "," + ProposedMove[1] + "," + ProposedMove[2]);
                            else Console.WriteLine(WordWrap(PotentialRoom.Description));
                            ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
                            CurrentRoom = PotentialRoom;
                            Player.CurrentPos = ProposedMove;
                            EventTrigger("moveinto");
                        }
                        else if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("Looks like I can't go that way."));
                        else Console.WriteLine(WordWrap(PotentialRoom.Description));
                    }
                    else
                    {
                        Console.WriteLine("You cannot leave the current area");
                        attacked();
                    }

                }
                else if (PlayerCommand.ToLower() == "south" || PlayerCommand.ToLower() == "go south" || PlayerCommand.ToLower() == "move south")
                {
                    if (!CurrentRoom.LockedIn)
                    {
                        int[] ProposedMove = new int[3];

                        ProposedMove[0] = Player.CurrentPos[0] + 1;
                        ProposedMove[1] = Player.CurrentPos[1];
                        ProposedMove[2] = Player.CurrentPos[2];

                        PotentialRoom = GetRoomInfo(ProposedMove);
                        if (PotentialRoom.CanMove == true)
                        {
                            if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("I Successfully move into position ") + ProposedMove[0] + "," + ProposedMove[1] + "," + ProposedMove[2]);
                            else Console.WriteLine(WordWrap(PotentialRoom.Description));
                            ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
                            CurrentRoom = PotentialRoom;
                            Player.CurrentPos = ProposedMove;
                            EventTrigger("moveinto");
                        }
                        else if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("Looks like I can't go that way."));
                        else Console.WriteLine(WordWrap(PotentialRoom.Description));
                    }
                    else
                    {
                        Console.WriteLine("You cannot leave the current area");
                        attacked();
                    }
                }
                else if (PlayerCommand.ToLower() == "west" || PlayerCommand.ToLower() == "go west" || PlayerCommand.ToLower() == "move west")
                {
                    if (!CurrentRoom.LockedIn)
                    {
                        int[] ProposedMove = new int[3];

                        ProposedMove[0] = Player.CurrentPos[0];
                        ProposedMove[1] = Player.CurrentPos[1] - 1;
                        ProposedMove[2] = Player.CurrentPos[2];

                        PotentialRoom = GetRoomInfo(ProposedMove);
                        if (PotentialRoom.CanMove == true)
                        {
                            if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("I Successfully move into position ") + ProposedMove[0] + "," + ProposedMove[1] + "," + ProposedMove[2]);
                            else Console.WriteLine(WordWrap(PotentialRoom.Description));
                            ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
                            CurrentRoom = PotentialRoom;
                            Player.CurrentPos = ProposedMove;
                            EventTrigger("moveinto");
                        }
                        else if (PotentialRoom.Description == null || PotentialRoom.Description == string.Empty) Console.WriteLine(WordWrap("Looks like I can't go that way."));
                        else Console.WriteLine(WordWrap(PotentialRoom.Description));
                    }
                    else
                    {
                        Console.WriteLine("You cannot leave the current area");
                        attacked();
                    }
                }
                else if (PlayerCommand.ToLower().Contains("who am i") || PlayerCommand == "whoami")
                {
                    Console.WriteLine(WordWrap(string.Concat("Your name is ", Player.name)));
                }
                else if (PlayerCommand.ToLower() == "status")
                {
                    PlayerStatus();
                }
                else if (PlayerCommand.ToLower() == "describe")
                {
                    Console.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "read")
                {
                    int index;
                    string readitem;

                    if (CurrentRoom.items != null || Player.invspace != 20)
                    {

                        if (PlayerCommand.ToLower().Split(' ').Length == 1)
                        {
                            Console.Write("What do you want to read?");
                            readitem = Console.ReadLine();
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');
                            index = 2;
                            readitem = strArray[1];

                            while (index < strArray.Length)
                            {
                                readitem = string.Concat(readitem, " ", strArray[index]);
                                index++;
                                //Console.WriteLine(WordWrap("item is {0}", item);
                            }
                            readitem = readitem.Trim();
                        }
                        Console.WriteLine(WordWrap(ReadItem(readitem)));
                    }
                    else Console.WriteLine("There is nothing to read");


                }
                else if (PlayerCommand.ToLower() == "inventory")
                {
                    if (Player.invspace != 20)
                    {
                        Console.WriteLine(WordWrap(string.Concat("You are currently using ", (20 - Player.invspace), "/20 of your inventory\n")));
                        for (int index = 0; index < (20 - Player.invspace); index++)
                        {
                            Console.WriteLine(WordWrap(string.Concat((index + 1), ": ", Player.inventory[index].Name)));
                        }
                        Console.WriteLine("");
                    }
                    else Console.WriteLine("Your inventory is empty");
                }
                else if (PlayerCommand.ToLower() == "objective")
                {
                    Console.WriteLine(WordWrap(string.Concat("Your Current Objective is: ", Player.Objective)));
                }
                else if (PlayerCommand.ToLower() == "money")
                {
                    Console.WriteLine("You currently have {0} gold coins", Player.Money);
                }
                else if (PlayerCommand.Split(' ')[0].ToLower() == "ask")
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
                    else Console.WriteLine(WordWrap("Ask who about what?"));
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "take" || PlayerCommand.ToLower().Split(' ')[0] == "pick" || PlayerCommand.ToLower().Split(' ')[0] == "get")
                {
                    string ObjectName = string.Empty;

                    if (PlayerCommand.ToLower() == "take" || PlayerCommand.ToLower() == "pick" || PlayerCommand.ToLower() == "pick up" || PlayerCommand.ToLower() == "get")
                    {
                        Console.Write("What do you want to pick up?: ");
                        ObjectName = Console.ReadLine();
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
                            //Console.WriteLine(WordWrap("item is {0}", item);
                        }
                        ObjectName = ObjectName.Trim();
                    }

                    Console.WriteLine(WordWrap(TakeItem(ObjectName)));

                }
                else if (PlayerCommand.ToLower() == "drop" || PlayerCommand.ToLower().Split(' ')[0] == "drop")
                {
                    if (Player.invspace != 20)
                    {
                        string ObjectName = string.Empty;

                        if (PlayerCommand.ToLower() == "drop")
                        {
                            Console.WriteLine(WordWrap("What do you want to drop?: "));
                            for (int index = 0; index < (20 - Player.invspace); index++)
                            {
                                Console.WriteLine(WordWrap(string.Concat((index + 1), ": ", Player.inventory[index].Name)));
                            }
                            Console.Write("\nSlot Number: ");
                            int Menu = Convert.ToInt32(Console.ReadLine());


                            ObjectName = Player.inventory[Menu - 1].Name;
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
                                //Console.WriteLine(WordWrap("item is {0}", item);
                            }

                            ObjectName = ObjectName.Trim();

                        }
                        Console.WriteLine(WordWrap(DropItem(ObjectName)));

                    }
                    else
                        Console.WriteLine(WordWrap("There are no items in your inventory"));
                }
                else if (PlayerCommand.ToLower() != "look" && (PlayerCommand.ToLower() == "look at" || (PlayerCommand.ToLower().Split(' ')[0] == "look" && PlayerCommand.ToLower().Split(' ')[1] == "at")))
                {
                    string ObjectName = string.Empty;

                    if (PlayerCommand == "look at")
                    {
                        Console.Write("What do you want to look at?: ");
                        ObjectName = Console.ReadLine();
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
                            //Console.WriteLine(WordWrap("item is {0}", item);
                        }

                        ObjectName = ObjectName.Trim();
                    }

                    Console.WriteLine(WordWrap(LookAtObject(ObjectName)));
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "examine" || PlayerCommand.ToLower() == "examine")
                {
                    if (Player.invspace != 20)
                    {
                        string ObjectName = string.Empty;

                        if (PlayerCommand.ToLower() == "examine")
                        {
                            Console.WriteLine(WordWrap("What item do you want to examine?: "));
                            for (int index = 0; index < (20 - Player.invspace); index++)
                            {
                                Console.WriteLine(WordWrap("{0}: {1}"), (index + 1), Player.inventory[index].Name);
                            }
                            Console.Write("\nSlot Number: ");
                            int Menu = Convert.ToInt32(Console.ReadLine());


                            ObjectName = Player.inventory[Menu - 1].Name;
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
                                //Console.WriteLine(WordWrap("item is {0}", item);
                            }

                            ObjectName = ObjectName.Trim();

                        }
                        itemInfo invItem = new itemInfo();

                        invItem = ExamineItem(ObjectName);

                        if (invItem.Name != null)
                        {
                            Console.WriteLine(WordWrap(string.Concat("Name: ", invItem.Name)));
                            Console.WriteLine(WordWrap(string.Concat("Health Boost: ", invItem.HPmod)));
                            Console.WriteLine(WordWrap(string.Concat("Attack Bonus: ", invItem.AttackMod)));
                            Console.WriteLine(WordWrap(string.Concat("Defense Bonus: ", invItem.DefenseMod)));
                        }
                        else
                        {
                            Console.WriteLine(WordWrap("Item not found in your intentory"));
                        }

                    }
                    else
                        Console.WriteLine(WordWrap("There are no items in your inventory"));
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "use" || PlayerCommand.ToLower().Split(' ')[0] == "put")
                {
                    int index = 0;
                    string item = string.Empty;
                    string target = string.Empty;

                    if (CurrentRoom.items != null)
                    {

                        if (PlayerCommand.ToLower() == "use" || PlayerCommand.ToLower() == "put")
                        {
                            Console.Write("What do you want to {0}: ", PlayerCommand.ToLower().Split(' ')[0]);
                            item = Console.ReadLine();

                            Console.Write("\n\nWhat do you want to {1} {0} {2}?", item, PlayerCommand.ToLower().Split(' ')[0], PlayerCommand.ToLower().Split(' ')[2]);
                            target = Console.ReadLine();
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
                                Console.WriteLine("Objects in the room:\n");

                                for (index = 0; index < CurrentRoom.items.Count; index++)
                                {
                                    //if (CurrentRoom.items[index].Class == "Interaction Object") Console.WriteLine(string.Concat(CurrentRoom.items[index].Name)); 
                                    Console.WriteLine(string.Concat(CurrentRoom.items[index].Name));

                                }
                                Console.Write("\nWhat do you want to use {0} on? ", item);
                                target = Console.ReadLine();
                            }
                        }
                        UseItem(item, target);
                    }
                    else
                    {
                        Console.WriteLine("There is nothing in the room to interact with");
                    }

                }
                else if (PlayerCommand.ToLower() != "view" && PlayerCommand.ToLower().Split(' ')[0] == "view" && PlayerCommand.ToLower().Split(' ')[1] == "wares")
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
                                //Console.WriteLine(WordWrap("item is {0}", item);
                            }

                            VendorName = VendorName.Trim();
                        }
                        else
                        {
                            Console.WriteLine("Civilians in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                if (CurrentRoom.Civilians[index].willSell == true) Console.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                            }
                            Console.Write("\nWho do you want to view the inventory of? ");
                            VendorName = Console.ReadLine();
                        }

                        bool vendorFound = false;
                        index = 0;

                        while (vendorFound == false && CurrentRoom.Civilians != null && index < CurrentRoom.Civilians.Count)
                        {
                            if (VendorName.ToLower() == CurrentRoom.Civilians[index].name.ToLower() && CurrentRoom.Civilians[index].willSell == true)
                            {
                                vendorFound = true;
                                Console.WriteLine();
                                Console.WriteLine("Item\t\t\tClass\t\t\tPrice");
                                for (int Count = 0; Count < CurrentRoom.Civilians[index].inventory.Count; Count++)
                                {
                                    if (CurrentRoom.Civilians[index].inventory[Count].Name == null) Console.Write("null\t\t");
                                    if (CurrentRoom.Civilians[index].inventory[Count].Name.Length < 8) Console.Write("{0}\t\t", CurrentRoom.Civilians[index].inventory[Count].Name);
                                    else if (CurrentRoom.Civilians[index].inventory[Count].Name.Length <= 15) Console.Write("{0}\t", CurrentRoom.Civilians[index].inventory[Count].Name);
                                    else Console.Write(CurrentRoom.Civilians[index].inventory[Count].Name);

                                    if (CurrentRoom.Civilians[index].inventory[Count].Class == null) Console.Write("null\t\t\t");
                                    else if (CurrentRoom.Civilians[index].inventory[Count].Class.Length < 8) Console.Write("{0}\t\t\t", CurrentRoom.Civilians[index].inventory[Count].Class);
                                    else if (CurrentRoom.Civilians[index].inventory[Count].Class.Length <= 15) Console.Write("{0}\t\t", CurrentRoom.Civilians[index].inventory[Count].Class);
                                    else if (CurrentRoom.Civilians[index].inventory[Count].Class.Length <= 21) Console.Write("{0}\t", CurrentRoom.Civilians[index].inventory[Count].Class);
                                    else Console.Write(CurrentRoom.Civilians[index].inventory[Count].Class);

                                    if (CurrentRoom.Civilians[index].inventory[Count].Value != 0) Console.Write("\t{0}\n", CurrentRoom.Civilians[index].inventory[Count].Value);
                                    else Console.Write("\tnull\n");
                                    //Console.WriteLine(WordWrap(string.Concat(CurrentRoom.Civilians[index].inventory[Count].Name, "\t", CurrentRoom.Civilians[index].inventory[Count].Class, "\t",CurrentRoom.Civilians[index].inventory[Count].Value)));
                                }
                            }
                            else Console.WriteLine(WordWrap(string.Concat(CurrentRoom.Civilians[index].name, " is not willing to sell you anything")));
                            index++;
                        }
                    }
                    else Console.WriteLine("There is nobody currently selling anything in this area");

                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "bribe")
                {
                    int index;
                    string WhoToBribe = string.Empty;
                    int BribeAmount = 0;
                    bool dontrun = false;

                    if (CurrentRoom.Enemy != null)
                    {
                        if (PlayerCommand.ToLower() == "bribe")
                        {
                            Console.WriteLine("People in the room who may accept a bribe:\n");
                            for (index = 0; index < CurrentRoom.Enemy.Count; index++)
                            {
                                Console.WriteLine(CurrentRoom.Enemy[index].name);
                            }
                            Console.Write("\nWho do you want to bribe? ");
                            WhoToBribe = Console.ReadLine();
                            Console.Write("How much do you want to give them? ");
                            Int32.TryParse(Console.ReadLine(), out BribeAmount);
                            if (BribeAmount == 0)
                            {
                                dontrun = true;
                                Console.WriteLine("You cannot bribe somebody with that amount");
                            }
                        }
                        else if (PlayerCommand.Split(' ')[0].ToLower() == "bribe" && PlayerCommand.Split(' ').Length == 2)
                        {
                            WhoToBribe = PlayerCommand.Split(' ')[1];
                            Console.Write("How much do you want to give {0}? ", PlayerCommand.Split(' ')[1]);
                            Int32.TryParse(Console.ReadLine(), out BribeAmount);
                            if (BribeAmount == 0)
                            {
                                dontrun = true;
                                Console.WriteLine("You cannot bribe somebody with that amount");
                            }
                        }
                        else if (PlayerCommand.Split(' ')[0].ToLower() == "bribe" && PlayerCommand.Split(' ').Length == 3)
                        {
                            WhoToBribe = PlayerCommand.Split(' ')[1];
                            Int32.TryParse(PlayerCommand.Split(' ')[2], out BribeAmount);
                            if (BribeAmount == 0)
                            {
                                dontrun = true;
                                Console.WriteLine("You cannot bribe somebody with that amount");
                            }
                        }
                        else
                        {
                            dontrun = true;
                            Console.WriteLine(WordWrap("I can't quite work out how many things you just said, try again"));
                        }

                        if (dontrun == false) PayOff(WhoToBribe, BribeAmount);

                    }
                    else Console.WriteLine(WordWrap("There are no people in the room to bribe"));


                }
                else if (PlayerCommand.Split(' ')[0].ToLower() == "buy")
                {
                    int index;
                    string vendor = string.Empty;
                    string ItemName = string.Empty;

                    if (CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower() == "buy")
                        {
                            Console.Write("What item do you want to buy? ");
                            ItemName = Console.ReadLine();


                            //player didn't specify item or person
                            Console.WriteLine("Civilians in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                if (CurrentRoom.Civilians[index].willSell == true) Console.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                            }
                            Console.Write("\nWho do you want to buy from? ");
                            vendor = Console.ReadLine();

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
                                Console.WriteLine("Civilians in the room:\n");

                                for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                                {
                                    if (CurrentRoom.Civilians[index].willSell == true) Console.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                                }
                                Console.Write("\nWho do you want to buy {0} from? ", ItemName);
                                vendor = Console.ReadLine();
                            }

                        }
                        BuyItem(ItemName, vendor);
                    }
                    else Console.WriteLine("There is nobody willing to buy anything from you here");
                }
                else if (PlayerCommand.Split(' ')[0].ToLower() == "sell")
                {
                    int index;
                    string vendor = string.Empty;
                    string ItemName = string.Empty;
                    itemInfo ItemToSell = new itemInfo();

                    if (CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower() == "sell")
                        {
                            Console.Write("What item do you want to sell? ");
                            ItemName = Console.ReadLine();

                            index = 0;
                            bool itemfound = false;

                            while (itemfound == false && index < (20 - Player.invspace))
                            {
                                if (ItemName.ToLower() == Player.inventory[index].Name.ToLower())
                                {
                                    itemfound = true;
                                    ItemToSell = Player.inventory[index];
                                }
                                index++;
                            }

                            //player didn't specify item or person
                            Console.WriteLine("Civilians in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                if (CurrentRoom.Civilians[index].willBuy == true) Console.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                            }
                            Console.Write("\nWho do you want to sell to? ");
                            vendor = Console.ReadLine();

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

                            while (itemFound == false && index < (20 - Player.invspace))
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
                                Console.WriteLine("Civilians in the room:\n");

                                for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                                {
                                    if (CurrentRoom.Civilians[index].willBuy == true) Console.WriteLine(string.Concat(CurrentRoom.Civilians[index].name, " - ", CurrentRoom.Civilians[index].MerchantType));

                                }
                                Console.Write("\nWho do you want to {0} sell to? ", ItemName);
                                vendor = Console.ReadLine();
                            }

                        }
                        SellItem(ItemToSell, vendor);
                    }
                    else Console.WriteLine("There is nobody willing to buy anything from you here");
                }
                else if (PlayerCommand.Split(' ')[0].ToLower() == "talk")
                {
                    int index;
                    string NPCname = string.Empty;

                    if (CurrentRoom.Civilians != null)
                    {
                        if (PlayerCommand.ToLower() == "talk to" || PlayerCommand.ToLower() == "talk")
                        {
                            Console.WriteLine("Non-Hostile people in the room:\n");

                            for (index = 0; index < CurrentRoom.Civilians.Count; index++)
                            {
                                Console.WriteLine(WordWrap(CurrentRoom.Civilians[index].name));
                            }
                            Console.Write("\nWho do you want to talk to? ");
                            NPCname = Console.ReadLine();
                        }
                        else
                        {
                            string[] strArray = PlayerCommand.Split(' ');

                            NPCname = strArray[2];

                            for (index = 3; index < strArray.Length; index++)
                            {
                                NPCname = string.Concat(NPCname, " ", strArray[index]);
                            }

                        }
                        Console.WriteLine(WordWrap(TalkToNPC(NPCname)));
                    }
                    else
                    {
                        Console.WriteLine("There are no non-hostile people to talk to");
                    }
                }
                else if (PlayerCommand.Contains("suicide") || PlayerCommand.ToLower() == "attack self" || PlayerCommand.ToLower() == "hit self" || PlayerCommand.ToLower() == string.Concat("hit ", Player.name.ToLower()) || PlayerCommand.ToLower() == string.Concat("attack ", Player.name.ToLower()) || PlayerCommand.ToLower() == "kill self")
                {
                    if (PlayerCommand.Contains("suicide") && CurrentRoom.SuicideAction != null) Console.WriteLine(WordWrap(CurrentRoom.SuicideAction));
                    else Console.WriteLine(WordWrap("You raise your weapon above your head. Screaming in blind rage for some unknown reason. You strike yourself until you die"));
                    Player.HPBonus = 0;
                    //Console.WriteLine("I GET HERE, and my health is {0}", Player.HPBonus);
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "attack" || PlayerCommand.ToLower().Split(' ')[0] == "hit" || PlayerCommand.ToLower().Split(' ')[0] == "fight")
                {
                    string enemy;
                    int index;
                    bool enemyfound = false;

                    if (CurrentRoom.Enemy != null && CurrentRoom.Enemy.Count > 0)
                    {
                        if (PlayerCommand.ToLower() == "attack" || PlayerCommand.ToLower() == "hit" || PlayerCommand.ToLower() == "fight")
                        {
                            Console.WriteLine(WordWrap("Enemies in room:\n"));
                            for (index = 0; index < CurrentRoom.Enemy.Count; index++)
                            {
                                Console.WriteLine(WordWrap(CurrentRoom.Enemy[index].name));
                            }
                            Console.Write("\nWho do you want to attack: ");
                            enemy = Console.ReadLine();

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
                        if (enemyfound == false) Console.WriteLine(WordWrap(string.Concat("Could not find ", enemy, " in the area")));
                    }
                    else if (CurrentRoom.Civilians != null && CurrentRoom.Civilians.Count > 0)
                    {
                        if (PlayerCommand.ToLower() == "attack" || PlayerCommand.ToLower() == "hit" || PlayerCommand.ToLower() == "fight")
                        {
                            Console.WriteLine("Who do you want to attack");
                            enemy = Console.ReadLine();
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
                        Console.WriteLine(WordWrap("There is nobody in the room to fight"));
                }
                else if (PlayerCommand.Split(' ')[0].ToLower() == "equip" || PlayerCommand.Split(' ')[0].ToLower() == "wear")
                {
                    EquipItem(PlayerCommand);
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "eat" || PlayerCommand.ToLower().Split(' ')[0] == "drink")
                {
                    if (Player.invspace != 20)
                    {
                        int index;
                        string ObjectName = string.Empty;

                        if (PlayerCommand.ToLower() == "eat" || PlayerCommand.ToLower() == "drink")
                        {
                            Console.WriteLine("Food in your inventory:\n");
                            for (index = 0; index < (20 - Player.invspace); index++)
                            {
                                if (Player.inventory[index].Class == "Food" || Player.inventory[index].Class == "Drink")
                                {
                                    Console.WriteLine(WordWrap(Player.inventory[index].Name));
                                }
                            }
                            Console.Write("\nWhich item would you like to consume?");
                            ObjectName = Console.ReadLine();
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
                                //Console.WriteLine(WordWrap("item is {0}", item);
                            }
                            ObjectName = ObjectName.Trim();
                        }
                        Console.WriteLine(WordWrap(Consume(ObjectName)));
                    }
                    else Console.WriteLine("Your inventory is empty");
                }
                else if (PlayerCommand.ToLower().Split(' ')[0] == "sleep")
                {
                    int index = 0;
                    string bedItem = string.Empty;

                    if (PlayerCommand.ToLower() == "sleep in" || PlayerCommand.ToLower() == "sleep")
                    {
                        Console.Write("What do you want to sleep in?");
                        bedItem = Console.ReadLine();
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
                            //Console.WriteLine(WordWrap("item is {0}", item);
                        }
                        bedItem = bedItem.Trim();
                    }
                    //Console.WriteLine("Trying to sleep in {0}", bedItem);
                    Rest(bedItem);
                }
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
                else if (PlayerCommand.ToLower() == "clear")
                {
                    Console.Clear();
                    Console.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else if (PlayerCommand.ToLower() == "main menu")
                {
                    //Run the main menu screen
                    Player = MainMenu();
                    ThisFloor = world[Player.CurrentPos[2]];
                    CurrentRoom = ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]];
                    Console.WriteLine(WordWrap(CurrentRoom.Description));
                }
                else if (PlayerCommand.ToLower() == "save" || PlayerCommand.ToLower() == "save game")
                {
                    string success = SaveGame();
                    Console.WriteLine(WordWrap(string.Concat("Save ", success)));
                }
                else if (PlayerCommand.ToLower() == "quit" || PlayerCommand.ToLower() == "exit")
                {
                    Console.WriteLine("Quitting game");
                    Thread.Sleep(1500);
                }
                else if (PlayerCommand.ToLower() == "getpos")
                {
                    Console.WriteLine("Row {0}, Col {1}, floor{2}", Player.CurrentPos[0], Player.CurrentPos[1], Player.CurrentPos[2]);
                }
                else if (PlayerCommand.ToLower() == "turn down for what")
                {
                    char[] c1 = new char[6] {'\u0361','\u00b0','\u035c','\u0296','\u0361','\u00b0'};
                    Console.WriteLine("\n\n(" + c1[0] + c1[1] + c1[2] + c1[3] + c1[4] + c1[5] + ")\n\n");
                }
                else
                {
                    Console.WriteLine(WordWrap("Command not found, type help for a list of valid commands"));
                }

                if (Player.HPBonus <= 0)
                {
                    if (Player.CurrentPos[2] == 0)
                    {
                        Console.WriteLine("\n\n     Your adventure has come to an end :(");
                        Console.ReadLine();
                        Player = MainMenu();
                        ThisFloor = world[Player.CurrentPos[2]];
                        CurrentRoom = ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]];
                        Console.WriteLine(WordWrap(CurrentRoom.Description));
                    }
                    else
                    {
                        Console.WriteLine("\n\n     You have died, but this is not the end...");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(WordWrap("\n\n\tYou fall through darkness and smoke\n\tuntil you feel your feet softly make contact with ground"));
                        //Console.ReadLine();
                        Player.HPBonus = 60;
                        world[(Player.CurrentPos[2])] = ThisFloor;
                        Player.CurrentPos[0] = 1;
                        Player.CurrentPos[1] = 1;      //set coodinates of afterlife
                        Player.CurrentPos[2] = 0;
                        ThisFloor = world[0];
                        CurrentRoom = GetRoomInfo(Player.CurrentPos);
                        EventTrigger("moveinto");
                        //Console.Clear();
                        //Console.WriteLine(WordWrap(CurrentRoom.Description));
                        
                        //MusicPlayer.SoundLocation = ".\\music\\Scary 8-Bit.wav";
                        //Music("start");
                    }
                }

            }

        }

        public static roomInfo GetRoomInfo(int[] UserPos)
        {
            roomInfo ThisRoom = new roomInfo();

            //ThisFloor = world[UserPos[2]];
            ThisRoom = ThisFloor.CurrentFloor[UserPos[0],UserPos[1]];

            return(ThisRoom);
        }

        public static string LookAtObject(string ObjectName)
        {
            int index = 0;
            int counter = 0;
            string Description = string.Concat("Cannot find ", ObjectName, " in the area");
            bool itemFound = false;

            if (CurrentRoom.items != null)
            {
                //Console.WriteLine("I get here ");
                while (itemFound == false && index < CurrentRoom.items.Count)
                {
                    if (CurrentRoom.items[index].InteractionName != null)
                    {
                        while (itemFound == false && counter < CurrentRoom.items[index].InteractionName.Count)
                        {
                            if (CurrentRoom.items[index].InteractionName[counter].ToLower() == ObjectName.ToLower())
                                Description = CurrentRoom.items[index].Examine;
                            counter++;
                        }
                        counter = 0;
                    }
                    index++;
                }
            }
            return (Description);
        }
        
        public static void PlayerStatus()
        {
            Console.WriteLine(WordWrap(string.Concat("Your HP is at ", Player.HPBonus, "%")));
            if (Player.HPBonus < 20) Console.WriteLine(WordWrap("Your health is low, you should find some food or a place to rest!"));
            Console.WriteLine(WordWrap(string.Concat("\nYour current weapon is: ", Player.WeaponHeld.Name)));

            Console.WriteLine(WordWrap(string.Concat("\nYou current armor is at ", Player.ArmorBonus, "%\n")));

            if (Player.ArmorWorn[0].Name == null)   Console.WriteLine("  0");   //head
            else    Console.WriteLine(string.Concat(" {0}      - Head armor: ", Player.ArmorWorn[0].Name," - ", Player.ArmorWorn[0].DefenseMod,"%"));

            if (Player.ArmorWorn[1].Name == null)   Console.WriteLine(" /|\\"); //chest
            else    Console.WriteLine("╔=╬=╗     - Chest Armor: {0} - {1}%", Player.ArmorWorn[1].Name, Player.ArmorWorn[1].DefenseMod);

            if (Player.ArmorWorn[2].Name == null)   //gloves
            {
                Console.WriteLine("/ | \\");
                Console.WriteLine("  |");
            }
            else
            {
                Console.WriteLine("║ ║ ║    - Glove Armor: {0} - {1}%", Player.ArmorWorn[2].Name, Player.ArmorWorn[2].DefenseMod); 
                Console.WriteLine("Û ║ Û ");
            }

            if (Player.ArmorWorn[3].Name == null)   Console.WriteLine(" / \\"); //Legs
            else    Console.WriteLine(" / \\     - Leg Armor: {0} - {1}%", Player.ArmorWorn[3].Name, Player.ArmorWorn[3].DefenseMod);
            
            if (Player.ArmorWorn[4].Name == null)   Console.WriteLine("/   \\"); //boots
            else    Console.WriteLine(" ╝ ╚     - Boots Armor: {0} - {1}%", Player.ArmorWorn[4].Name, Player.ArmorWorn[4].DefenseMod);

        }

        public static itemInfo ExamineItem(string Objectname)
        {
            int index;
            itemInfo invItem = new itemInfo();
            
            for (index = 0; index < (20 - Player.invspace); index++)
            {
                
                if (Player.inventory[index].Name.ToLower() == Objectname.ToLower())
                {
                    invItem = Player.inventory[index];
                }
            }
            for (index = 0; index < 5; index++)
            {
                if (Player.ArmorWorn[index].Name != null)
                {
                    if (Player.ArmorWorn[index].Name.ToLower() == Objectname.ToLower())
                    {
                        invItem = Player.ArmorWorn[index];
                    }
                }
            }
            if (Player.WeaponHeld.Name.ToLower() == Objectname.ToLower()) invItem = Player.WeaponHeld;

            return (invItem);

        }

        public static string TakeItem(string ObjectName)
        {
            int index;
            int counter;
            string ReturnString = "that item does not appear to be here...";
            bool itemToTake = false;

            if (CurrentRoom.items != null)
            {
                index = 0;
                //for (index = 0; index < CurrentRoom.items.Count; index++)
                while (itemToTake == false && CurrentRoom.items != null && index < CurrentRoom.items.Count)
                {
                    counter = 0;
                    while (itemToTake == false && CurrentRoom.items[index].InteractionName != null && counter < CurrentRoom.items[index].InteractionName.Count)
                    {
                        if (CurrentRoom.items[index].InteractionName[counter].ToLower() == ObjectName.ToLower() && CurrentRoom.items[index].CanPickUp == true)
                        {
                            Player.inventory[20 - Player.invspace] = CurrentRoom.items[index];
                            Player.invspace = Player.invspace - 1;
                            itemToTake = true;

                            ReturnString = string.Concat("You have picked up ", CurrentRoom.items[index].Name);
                            CurrentRoom.items.RemoveAt(index);
                        }
                        else if (CurrentRoom.items[index].InteractionName[counter].ToLower() == ObjectName.ToLower() && CurrentRoom.items[index].CanPickUp == false)
                        {
                            ReturnString = string.Concat("You cannot pick up ", ObjectName);
                        }
                        counter++;
                    }
                    index++;
                }
                bool canstillpickup = false;
                if (CurrentRoom.Events != null && CurrentRoom.items != null)
                {
                    for (index = 0; index < CurrentRoom.items.Count; index++)
                    {
                        if (CurrentRoom.items[index].CanPickUp == true) canstillpickup = true;
                    }   
                }
                EventTrigger("itempickup");
                if (canstillpickup == false) EventTrigger("allitempickup");
            }
            return (ReturnString);
        }

        public static void PayOff(string EnemyName, int amount)
        {
            int index = 0;
            bool enemyfound = false;

            //Console.WriteLine("!! Trying to pay off {0} with amount {1} !!\n", EnemyName, amount);

            while (CurrentRoom.Enemy != null && index < CurrentRoom.Enemy.Count)
            {
                if (EnemyName.ToLower() == CurrentRoom.Enemy[index].name.ToLower())
                {
                    enemyfound = true;

                    if (CurrentRoom.Enemy[index].PayOff == 0)
                    {
                        Console.WriteLine(WordWrap(string.Concat(EnemyName, " will not accept a bribe from you\n")));
                        attacked();
                    }
                    else if (amount >= CurrentRoom.Enemy[index].PayOff)     //enemy will accept more than the bribe amount
                    {
                        Console.WriteLine(WordWrap(string.Concat(EnemyName, " has accepted your bribe. \"", CurrentRoom.Enemy[index].PayOffResponse, "\" says your opponent as they holster their weapon and stand down")));
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
                        CurrentRoom.Civilians.Add(notHostile);

                        Player.Money = Player.Money - amount;
                        
                        //int counter = 0;

                        if (CurrentRoom.Enemy.Count - 1 != 0)
                        {
                            for (int i = index; i < (CurrentRoom.Enemy.Count - 1); i++)
                            {
                                CurrentRoom.Enemy[i] = CurrentRoom.Enemy[i + 1];
                            }
                            CurrentRoom.items.RemoveAt(CurrentRoom.Enemy.Count - 1);
                        }
                        else
                        {
                            EventTrigger("killallenemies");
                            CurrentRoom.Enemy.Clear();
                            //break;
                        }
                        EventTrigger("payoff");
                    }
                    else
                    {
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", CurrentRoom.Enemy[index].name, " examines the coins and decides you haven't given them enough. They attack in response.\n")));
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
                Console.WriteLine(WordWrap(string.Concat(EnemyName, " was not found in the current area")));
            }


        }

        public static string DropItem(string ObjectName)
        {
            int index;
            itemInfo ItemToDrop = new itemInfo();
            bool itemFound = false;
            int DropIndex = 0;
            string Response = "That item is not in your inventory";

            if (CurrentRoom.items == null)
            {
                CurrentRoom.items = new List<itemInfo>();
            }

            for (index=0;index < (20 - Player.invspace);index++)
            {
                if (Player.inventory[index].Name.ToLower() == ObjectName.ToLower())
                {
                    ItemToDrop = Player.inventory[index];
                    itemFound = true;
                    DropIndex = index;
                    Response = string.Concat("Dropping ", ObjectName, " from your inventory");
                }
            }

            if (itemFound == true)
            {
                CurrentRoom.items.Add(ItemToDrop);  //add dropped item to current room

                for (int i = DropIndex; i < (20 - Player.invspace ); i++)
                {
                    Player.inventory[i] = Player.inventory[i + 1];
                }
                Array.Clear(Player.inventory,(20 - Player.invspace),1);
                Player.invspace = Player.invspace + 1;

            }             
                
            return (Response);
        }

        public static void EquipItem(string PlayerCommand)
        {
            int index;
            string item;

                    if (PlayerCommand.ToLower() == "equip")
                    {
                        Console.WriteLine(WordWrap("Specify an item to equip:\n"));

                        for (index = 0; index < (20 - Player.invspace); index++)
                        {
                            if (Player.inventory[index].Class == "Weapon" || Player.inventory[index].Class.Contains("Armor"))
                            {
                                Console.WriteLine(WordWrap(Player.inventory[index].Name));
                            }
                        }
                        Console.Write("\nWhich item would you like to equip: ");
                        item = Console.ReadLine();

                    }
                    else
                    {
                        string[] strArray = PlayerCommand.Split(' ');
                        item = strArray[1];
                        for (index = 2; index < strArray.Length; index++)
                        {
                            item = string.Concat(item, " ", strArray[index]);
                            //Console.WriteLine(WordWrap("item is {0}", item);
                        }
                    }

                    bool itemFound = false;
                    itemInfo tempItem = new itemInfo();

                    for (index = 0; index < (20 - Player.invspace); index++)
                    {
                        if (item.ToLower() == Player.inventory[index].Name.ToLower())
                        {
                            itemFound = true;
                            if (Player.inventory[index].Class == "Weapon")
                            {
                                Player.ArmorBonus = Player.ArmorBonus - Player.WeaponHeld.DefenseMod;
                                tempItem = Player.WeaponHeld;
                                Player.WeaponHeld = Player.inventory[index];
                                Player.inventory[index] = tempItem;
                                Player.ArmorBonus = Player.ArmorBonus + Player.WeaponHeld.DefenseMod;
                                Console.WriteLine(WordWrap(string.Concat("You have equipped ", item, " as your current weapon")));
                                Console.WriteLine(WordWrap(string.Concat("Your old weapon ", Player.inventory[index].Name, " has been been placed in your inventory.")));
                                
                            }
                            else if (Player.inventory[index].Class.Contains("Armor"))
                            {
                                //Console.WriteLine(WordWrap("You cannot equip armor at this time");
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
                                    Console.WriteLine(WordWrap(string.Concat("You have equipped ", item, " as your ", armorType.Split('-')[1], " armor")));
                                    Console.WriteLine(WordWrap(string.Concat("Your old armor ", Player.inventory[index].Name, " has been been placed in your inventory.")));
                                    Player.ArmorBonus = Player.ArmorBonus - tempItem.DefenseMod;
                                    Player.ArmorBonus = Player.ArmorBonus + Player.ArmorWorn[armorPOS].DefenseMod;
                                }
                                else
                                {
                                    Player.ArmorWorn[armorPOS] = Player.inventory[index];
                                    Player.ArmorBonus = Player.ArmorBonus + Player.inventory[index].DefenseMod;

                                    for (int i = index; i < (20 - Player.invspace); i++)    //remove item from inventory as it isn't replacing anything
                                    {
                                        Player.inventory[i] = Player.inventory[i + 1];
                                    }
                                    Array.Clear(Player.inventory, (20 - Player.invspace), 1);
                                    Player.invspace = Player.invspace + 1;
                                    Console.WriteLine(WordWrap(string.Concat("You have equipped ", item, " as your ", armorType.Split('-')[1], " armor")));

                                }
                                if (Player.ArmorBonus > 100) Player.ArmorBonus = 100;
                     
                            }
                            else
                            {
                                Console.WriteLine(WordWrap(string.Concat("You cannot equip ", item)));
                            }

                        }
                    }
                    if (itemFound == false)
                    {
                        Console.WriteLine(WordWrap("Item not found in your inventory, use 'inventory' to see items you possess"));
                    }
        }

        public static void SellItem(itemInfo ItemSold, string Vendor)
        {
            int index = 0;
            bool vendorFound = false;

            if (CurrentRoom.Civilians != null)
            {
                while (index < CurrentRoom.Civilians.Count)
                {
                    if (Vendor.ToLower() == CurrentRoom.Civilians[index].name.ToLower() && CurrentRoom.Civilians[index].willBuy == true)
                    {
                        vendorFound = true;
                        if (CurrentRoom.Civilians[index].MerchantType == "All" || ItemSold.Class.Contains(CurrentRoom.Civilians[index].MerchantType))
                        {
                            Player.Money = Player.Money + ItemSold.Value;
                            Console.WriteLine(WordWrap(string.Concat("Sucessfully sold ", ItemSold.Name, " to ", Vendor, " for ", ItemSold.Value, " gold coins.")));
                            ItemSold.Value = ItemSold.Value + (((ItemSold.Value / 100) * 10) +10);

                            CivilianProfile Civy = CurrentRoom.Civilians[index];

                            if (Civy.inventory == null) Civy.inventory = new List<itemInfo>();

                            Civy.inventory.Add(ItemSold);
                            CurrentRoom.Civilians[index] = Civy;

                            int Counter = 0;
                            bool itemfound = false;
                            while (itemfound == false && Counter < 20)
                            {
                                if (ItemSold.Name == Player.inventory[Counter].Name)
                                {
                                    for (int i = Counter; i < (20 - Player.invspace); i++)
                                    {
                                        Player.inventory[i] = Player.inventory[i + 1];
                                    }
                                    itemfound = true;
                                    Array.Clear(Player.inventory, (20 - Player.invspace), (20 - Player.invspace));
                                    Player.invspace = Player.invspace + 1;
                                }
                                Counter++;
                            }
                        }
                        else Console.WriteLine(WordWrap(string.Concat(Vendor, " will not buy items of that type from you")));
                    }
                    index++;
                }
                if (vendorFound == false) Console.WriteLine(WordWrap(string.Concat(Vendor, " cannot be found here for some reason")));

            }
            else
            {
                Console.WriteLine("There is nobody here willing to trade");
            }

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
                                if (itemName.ToLower() == CurrentRoom.Civilians[index].inventory[counter].Name.ToLower())
                                {
                                    item = CurrentRoom.Civilians[index].inventory[counter];

                                    if (Player.Money >= item.Value)
                                    {
                                        Player.Money = Player.Money + item.Value;
                                        Player.inventory[(20 - Player.invspace)] = item;
                                        Player.invspace = Player.invspace - 1;
                                        Console.WriteLine(WordWrap(string.Concat("You have successfully purchased ", itemName, " for ", item.Value, " gold coins")));

                                        CurrentRoom.Civilians[index].inventory.RemoveAt(counter);

                                    }
                                    else Console.WriteLine(WordWrap(string.Concat(itemName, " costs ", item.Value, " gold coins and you only have ", Player.Money, ". You cannot afford this")));
                                    itemFound = true;
                                }
                                else counter++;
                            }
                        }
                        else Console.WriteLine(WordWrap(string.Concat(vendor, "is not willing to sell anything to you")));
                    }
                    index++;
                }
                if (itemFound == false && vendorFound == true) Console.WriteLine(WordWrap(string.Concat("The merchant does not seem to be selling ", itemName)));
                else if (itemFound == false && vendorFound == false) Console.WriteLine(WordWrap(string.Concat(vendor, " is not willing to sell anything to you.")));
            }
            else    Console.WriteLine("There are no people in the area to buy from");
        }

        public static void UseItem(string item, string target)
        {
            int index = 0;
            bool itemFound = false;
            bool itemInInventory = false;
            int Counter = 0;
            int ItemFoundAt = 0;

            for (index = 0; index < (20 - Player.invspace); index++)
            {
                if (Player.inventory[index].Name.ToLower() == item.ToLower())
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
                        while (itemFound == false && Counter < CurrentRoom.items[index].InteractionName.Count)
                        {
                            if (CurrentRoom.items[index].InteractionName[Counter].ToLower() == target.ToLower())
                            {
                                if (CurrentRoom.items[index].Class != null && CurrentRoom.items[index].Class == "Interaction Object" && item.ToLower() == CurrentRoom.items[index].ItemNeeded.ToLower())
                                {
                                    if (EventTrigger("iteminteraction") == true) Console.WriteLine(WordWrap(CurrentRoom.items[index].interactionResponse));
                                    else Console.WriteLine("The items interacted, but nothing happened");

                                    itemFound = true;
                                    for (int i = ItemFoundAt; i < (20 - Player.invspace); i++)
                                    {
                                        Player.inventory[i] = Player.inventory[i + 1];
                                    }
                                    Array.Clear(Player.inventory, (20 - Player.invspace), 1);
                                    Player.invspace = Player.invspace + 1;                                    
                                }
                            }
                            Counter++;
                        }
                        index++;
                    }
                    if (itemFound == false) Console.WriteLine(WordWrap(string.Concat("Tried to use ", item, " on ", target, " but it failed")));
                }
                else Console.WriteLine("There is nowhere in this room to use that item");
            }
            else Console.WriteLine(WordWrap(string.Concat(item, " is not currently in your inventory")));
        }

        public static string ReadItem(string item)
        {
            string Response = "You cannot read that item";
            int TotalItems = 0;
            if (CurrentRoom.items != null) TotalItems = TotalItems + CurrentRoom.items.Count;
            if (Player.invspace != 20) TotalItems = TotalItems + (20 - Player.invspace);

            int index = 0;
            bool itemFound = false;
            bool itemRead = false;
            int counter = 0;

            while (itemRead == false && index < TotalItems)
            {
                counter = 0;
                while (CurrentRoom.items != null && itemRead == false && counter < CurrentRoom.items.Count)
                {
                    if (CurrentRoom.items[counter].InteractionName != null && CurrentRoom.items[counter].Class != null)
                    {
                        for (int i = 0; i < CurrentRoom.items[counter].InteractionName.Count;i++)
                        {
                            if (item.ToLower() == CurrentRoom.items[counter].Name.ToLower())
                            {
                                itemFound = true;
                                if (CurrentRoom.items[counter].Class == "Readable")
                                {
                                    itemRead = true;
                                    Response = CurrentRoom.items[counter].Examine;
                                }
                            }
                        }
                    }
                    counter++;
                }

                counter = 0; 

                while (Player.invspace != 20 && itemRead == false && counter < (20 - Player.invspace))
                {
                    if (item.ToLower() == Player.inventory[counter].Name.ToLower())
                    {
                        itemFound = true;
                        if (Player.inventory[counter].Class != null && Player.inventory[counter].Class == "Readable")
                        {
                            itemRead = true;
                            Response = Player.inventory[counter].Examine;
                        }
                    }
                    counter++;
                }
                index ++;
            }
            if (itemFound == false) { Response = string.Concat("Cannot find ", item, " in the current area"); }
            return(Response);
        }

        public static string Consume(string ObjectName)
        {
            int index = 0;
            string Response = "You cannot consume that item";
            bool itemEaten = false;

            while (itemEaten == false && index < (20 - Player.invspace))
            {
                if (Player.inventory[index].Name.ToLower() == ObjectName.ToLower() && (Player.inventory[index].Class == "Food" || Player.inventory[index].Class == "Drink"))
                {
                    Player.HPBonus = Player.HPBonus + Player.inventory[index].HPmod;
                    if (Player.inventory[index].HPmod > 0) Response = string.Concat("You gained ", Player.inventory[index].HPmod, "HP from ", ObjectName);
                    else Response = string.Concat("You lost ", Player.inventory[index].HPmod, "HP from ", ObjectName);
                    itemEaten = true;
                    if (Player.HPBonus > 150) Player.HPBonus = 150;

                    for (int i = index; i < (20 - Player.invspace); i++)
                    {
                        Player.inventory[i] = Player.inventory[i + 1];
                    }
                    Array.Clear(Player.inventory, (20 - Player.invspace), (20 - Player.invspace));
                    Player.invspace = Player.invspace + 1;

                }
                index++;
            }
            return (Response);
        }

        public static void attacked()
        {
            double BaseAttack = 0;
            int Fortitude;
            Random RNG = new Random();

            foreach (EnemyProfile Enemy in CurrentRoom.Enemy)
            {
                if (Player.HPBonus > 0)
                {
                    Thread.Sleep(1500);
                    BaseAttack = RNG.Next(1, 3);

                    if (BaseAttack == 1)
                    {
                        //bad attack
                        BaseAttack = BaseAttack * Enemy.Weapon.AttackMod;
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", Enemy.name, " attacks you\n", Enemy.Weapon.BadHit)));

                    }
                    else if (BaseAttack == 2)
                    {
                        //Medium Strong Attack
                        BaseAttack = BaseAttack * Enemy.Weapon.AttackMod;
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", Enemy.name, " attacks you\n", Enemy.Weapon.MedHit)));
                    }
                    else if (BaseAttack == 3)
                    {
                        //Strong Attack
                        BaseAttack = BaseAttack * Enemy.Weapon.AttackMod;
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", Enemy.name, " attacks you\n", Enemy.Weapon.GoodHit)));
                    }
                    
                    Fortitude = RNG.Next(1, 100);
                    if (Fortitude > Player.ArmorBonus) Player.HPBonus = Player.HPBonus - BaseAttack;
                    else Player.HPBonus = Convert.ToInt32(Player.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * Player.ArmorBonus));

                    if (Player.HPBonus < 0)
                    {
                        if (Enemy.KillMessage != null)  Console.WriteLine(WordWrap(string.Concat("\n", Enemy.KillMessage)));
                        else Console.WriteLine(WordWrap(string.Concat("\n\n", Enemy.name, " has killed you with their ", Enemy.Weapon.Name)));
                    }
                }
            }
            Player.HPBonus = Math.Round((double)Player.HPBonus,2);
        }
        
        public static void SurpriseAttack(string enemy)
        {
            Random RNG = new Random();
            double BaseAttack;
            int Counter;

            int defend = RNG.Next(1,3);

            Console.WriteLine(WordWrap(string.Concat("You carefully wait, and when you think you have the upper hand, you attack ", enemy)));
            Thread.Sleep(1000);
            if (defend == 1)
            {
                Console.WriteLine(WordWrap("Expecting violence they draw their weapon and defend\n"));
                Thread.Sleep(1000);
                Combat(Player.WeaponHeld, enemy);
            }
            else
            {
                Console.WriteLine(WordWrap("Completely surprised they do not have a chance to defend themselves\n"));
                Thread.Sleep(1000);

                BaseAttack = RNG.Next(1, 6);

                if (BaseAttack == 1 || BaseAttack == 2)
                {
                    //bad attack
                    Console.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.BadHit)));
                }
                else if (BaseAttack == 3 || BaseAttack == 4)
                {
                    //Medium Weak Attack
                    Console.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.MedHit)));
                }
                else if (BaseAttack == 5 || BaseAttack == 6)
                {
                    //Critical Attack                            
                    Console.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.GoodHit)));
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

                        //Console.WriteLine("Enemy {0} has {1} HP left", enemy, CurrentRoom.Enemy[Counter].HPBonus);

                        if (ThisEnemy.HPBonus < 0) //if the enemy has been killed
                        {
                            Console.WriteLine();
                            if (CurrentRoom.Enemy[Counter].DeathMessage == null)
                            { Console.WriteLine(WordWrap(string.Concat("With this hit you kill the enemy ", CurrentRoom.Enemy[Counter].name))); }
                            else { Console.WriteLine(WordWrap(CurrentRoom.Enemy[Counter].DeathMessage)); }

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

                            if (ThisEnemy.Money != 0) Console.WriteLine("\nYou take {0} gold coins from {1}'s corpse", ThisEnemy.Money, enemy);
                            Player.Money = Player.Money + ThisEnemy.Money; //take money from enemy
                            
                            EventTrigger("killenemy");
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

            //Console.WriteLine(WordWrap("There are ", ," people in the room", NumOfFighters);

            List<Fighter> ThisFight = new List<Fighter>();
            Fighter TempFighter = new Fighter();

            TempFighter.name = Player.name;
            TempFighter.HP = Player.HPBonus;
            TempFighter.Weapon = WeaponUsed;
            TempFighter.AttackMod = WeaponUsed.AttackMod;
            TempFighter.DefenseMod = Player.ArmorBonus;
            TempFighter.isAlive = true;
            TempFighter.initiative = RNG.Next(5, 100);  //Potentially add a speed bonus here?
            TempFighter.ID = 99;
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
            while (index < ThisFight.Count && Player.HPBonus > 0 && CurrentRoom.Enemy.Count != 0)
            {
                if (ThisFight[index].name == Player.name)   //players turn
                {
                    BaseAttack = RNG.Next(1, 6);

                    if (BaseAttack == 1 || BaseAttack == 2)
                    {
                        //bad attack
                        Console.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.BadHit)));
                    }
                    else if (BaseAttack == 3 || BaseAttack == 4)
                    {
                        //Medium Weak Attack
                        Console.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.MedHit)));
                    }
                    else if (BaseAttack == 5 || BaseAttack == 6)
                    {
                        //Critical Attack                            
                        Console.WriteLine(WordWrap(string.Concat("You attack enemy ", enemy, " with your ", Player.WeaponHeld.Name, "\n", Player.WeaponHeld.GoodHit)));
                    }

                    BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                    
                    int Counter = 0;
                    bool GaveHit = false;
                    
                    while (CurrentRoom.Enemy != null && Counter < ThisFight.Count && GaveHit == false && CurrentRoom.Enemy.Count != 0)
                    {
                        if (ThisFight[Counter].name.ToLower() == enemy.ToLower())
                        {
                            EnemyProfile ThisEnemy = CurrentRoom.Enemy[ThisFight[Counter].ID];
                            Fortitude = RNG.Next(1, 100);
                            if (Fortitude > ThisEnemy.armor) ThisEnemy.HPBonus = ThisEnemy.HPBonus - BaseAttack;
                            else ThisEnemy.HPBonus = ThisEnemy.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * ThisEnemy.armor);

                            if (ThisEnemy.HPBonus < 0) //if the enemy has been killed
                            {
                                Console.WriteLine();
                                if (CurrentRoom.Enemy[ThisFight[Counter].ID].DeathMessage == null)
                                { Console.WriteLine(WordWrap(string.Concat("With this hit you kill the enemy ", CurrentRoom.Enemy[ThisFight[Counter].ID].name))); }
                                else { Console.WriteLine(WordWrap(CurrentRoom.Enemy[ThisFight[Counter].ID].DeathMessage)); }
                                
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

                                if (ThisEnemy.Money != 0) Console.WriteLine("\nYou take {0} gold coins from {1}'s corpse", ThisEnemy.Money, enemy);

                                Player.Money = Player.Money + ThisEnemy.Money; //take money from enemy
                                NumOfFighters = NumOfFighters - 1;

                                
                                EventTrigger("killenemy");
                               
                                if (CurrentRoom.Enemy.Count - 1 != 0)
                                {
                                    //Remove the fighter
                                    CurrentRoom.Enemy.RemoveAt(ThisFight[Counter].ID);
                                    ThisFight.RemoveAt(Counter);
                                }
                                else
                                {
                                    EventTrigger("killallenemies");
                                    CurrentRoom.Enemy.Clear();
                                    //break;
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
                    BaseAttack = RNG.Next(1, 3);

                    if (BaseAttack == 1)
                    {
                        //bad attack
                        BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", ThisFight[index].name, " attacks you\n", ThisFight[index].Weapon.BadHit)));

                    }
                    else if (BaseAttack == 2)
                    {
                        //Medium Strong Attack
                        BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", ThisFight[index].name, " attacks you\n", ThisFight[index].Weapon.MedHit)));
                    }
                    else if (BaseAttack == 3)
                    {
                        //Strong Attack
                        BaseAttack = BaseAttack * ThisFight[index].AttackMod;
                        Console.WriteLine(WordWrap(string.Concat("Enemy ", ThisFight[index].name, " attacks you\n", ThisFight[index].Weapon.GoodHit)));
                    }

                    Fortitude = RNG.Next(1, 100);
                    if (Fortitude > Player.ArmorBonus) Player.HPBonus = Player.HPBonus- BaseAttack;
                    else Player.HPBonus = Player.HPBonus - Math.Ceiling((double)(BaseAttack / 110) * Player.ArmorBonus);
                    Player.HPBonus = Math.Round((double)Player.HPBonus, 2);
                    if (Player.HPBonus < 0)
                    {
                        for (int Counter = 0; Counter < CurrentRoom.Enemy.Count; Counter++)
                        {
                            if (ThisFight[index].name == CurrentRoom.Enemy[Counter].name)
                            {
                                if (CurrentRoom.Enemy[Counter].KillMessage != null)
                                { 
                                    Console.WriteLine(WordWrap(string.Concat("\n", CurrentRoom.Enemy[Counter].KillMessage))); 
                                }
                                else
                                {
                                    Console.WriteLine(WordWrap(string.Concat("\n\n", CurrentRoom.Enemy[Counter].name, " has killed you with their ", CurrentRoom.Enemy[Counter].Weapon.Name)));
                                }
                            }
                            NumOfFighters = NumOfFighters - 1;
                        }

                    }
                }
                Thread.Sleep(1500);
                Console.WriteLine("");
                index++;
            }
        }
        
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
                                Console.WriteLine(WordWrap(string.Concat("You lie down on your ", BedItem, " and go to sleep")));
                                Console.WriteLine("You awaken in the morning feeling refreshed");
                                Player.HPBonus = 150;
                            }
                            else
                            {
                                bedFound = true;
                                Console.WriteLine(WordWrap(string.Concat("You lie down on your ", BedItem, " and go to sleep")));
                                Console.WriteLine(WordWrap("Your enemies, confused as to your tactic of sleeping during battle, beat you to death while you sleep."));
                                Player.HPBonus = 0;
                            }
                        }
                        counter++;
                    }
                    counter = 0;
                    index++;
                }
                if (bedFound == false) Console.WriteLine("Cannot find that place to sleep in this area");
            }
            else Console.WriteLine("There are no places to sleep in this area");

        }

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
                if (Found == true) Console.WriteLine(WordWrap(Target + " says to you \"" + Knowledge + "\""));
                else Console.WriteLine("That person does not seem to be here");
            }
            else Console.WriteLine("That person does not seem to be here");
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
                for (index = 0; index < CurrentRoom.Civilians.Count;index++)
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
                            NewEnemy.PayOff = 0;
                            NewEnemy.Weapon.Class = "Weapon";
                            NewEnemy.Weapon.AttackMod = 1;
                            NewEnemy.Weapon.CanPickUp = false;
                            NewEnemy.Weapon.Name = "fists";


                            if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();

                            for (int counter = 0; counter < CurrentRoom.Civilians[index].inventory.Count; counter++)
                            {
                                if (CurrentRoom.Civilians[index].inventory[counter].Class == "Weapon" && NewEnemy.Weapon.AttackMod < CurrentRoom.Civilians[index].inventory[counter].AttackMod)
                                {
                                    NewEnemy.Weapon = CurrentRoom.Civilians[index].inventory[counter];
                                }
                                else CurrentRoom.items.Add(CurrentRoom.Civilians[index].inventory[counter]);
                            }
                            CurrentRoom.Enemy.Add(NewEnemy);
                            CurrentRoom.Civilians.RemoveAt(index);
                            SurpriseAttack(NewEnemy.name);
                        }
                        else
                        {
                            NPCFound = true;
                            Console.WriteLine(WordWrap(string.Concat("Starting a fight with ", CurrentRoom.Civilians[index].name, " is not a good idea")));
                        }
                    }
                    index++;
                }
                if (NPCFound == false) Console.WriteLine("Cannot find that person here");

            }
            else Console.WriteLine("There is nobody around here to fight");
        }

        public static string SaveGame()
        {
            string playername = Player.name;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(".\\Saves\\" + WorldState.WorldName);
            bool namefound = false;
            if (!dir.Exists) Directory.CreateDirectory(".\\Saves\\" + WorldState.WorldName);
            foreach (FileInfo file in dir.GetFiles())    //Find games in saves directory
            {
                if (file.Name.ToLower() == (playername + ".dsg").ToLower()) namefound = true;
            }
            while (namefound == true)   //warn players who have save files
            {                
                Console.WriteLine(WordWrap("There is already a save game for {0}"), playername);
                Console.WriteLine(WordWrap("You can save a new game with this name, but if you save you will overwrite progress for that character"));
                Console.Write(WordWrap("Do you want to continue saving and overwrite?\n1: Yes\n2: No\n3: Choose a new name\n>"));
                string YesNo = Console.ReadLine();

                if (YesNo.ToLower() == "yes" || YesNo.ToLower() == "y" || YesNo.ToLower() == "1") namefound = false;
                else if (YesNo.ToLower() == "no" || YesNo.ToLower() == "n" || YesNo.ToLower() == "2") return ("Failure");
                else
                {
                    Console.Clear();
                    Console.Write("Choose a new name?: ");

                    playername = Console.ReadLine();
                    if (playername == "")
                    {
                        playername = "Drongo";
                    }
                    namefound = false;
                    foreach (FileInfo file in dir.GetFiles())    //Find games in saves directory
                    {
                        if (file.Name.ToLower() == (playername + ".dsg").ToLower()) namefound = true;
                    }
                }
            }
            Player.name = playername;

                string SavePath = string.Concat(".\\Saves\\", WorldState.WorldName, "\\" , Player.name, ".dsg");
                GameState gamestate = new GameState();

                ThisFloor.CurrentFloor[Player.CurrentPos[0], Player.CurrentPos[1]] = CurrentRoom;
                world[Player.CurrentPos[2]] = ThisFloor;

                gamestate.PlayerState = Player;
                gamestate.WorldState.WorldState = world;

                using (Stream stream = File.Open(SavePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, gamestate);
                }
                return ("Success");
        }

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
        
        public static Event EventAction(Event thisEvent)
        {
            if (thisEvent.Triggered == false)
            {
                thisEvent.Triggered = true;

                if (thisEvent.Action.ToLower() == "unlock")   //unlock
                {
                    if (thisEvent.Coodinates != null)
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].CanMove = true;
                    }
                }
                else if (thisEvent.Action.ToLower() == "lock")   //lock
                {
                    if (thisEvent.Coodinates != null)
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].CanMove = false;
                    }

                }
                else if (thisEvent.Action.ToLower() == "lockin")
                {
                    if (!CurrentRoom.LockedIn) CurrentRoom.LockedIn = true;
                    else CurrentRoom.LockedIn = false;
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
                        }
                        EventTrigger("killallenemies");
                        CurrentRoom.Enemy.Clear();   //Overwrite all enemies
                    }
                }
                else if (thisEvent.Action.ToLower() == "change description") //change description
                {
                    if (thisEvent.Coodinates[2] != Player.CurrentPos[2]) //If change is not on this floor
                    {
                        Floor TempFloor;
                        TempFloor = world[thisEvent.Coodinates[2]];
                        TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = TempFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].AltDescription;
                        CurrentRoom.Description = CurrentRoom.AltDescription;
                        world[thisEvent.Coodinates[2]] = TempFloor;
                    }
                    else
                    {
                        ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].Description = ThisFloor.CurrentFloor[thisEvent.Coodinates[0], thisEvent.Coodinates[1]].AltDescription;
                    }
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);   //retreive new room info

                }
                else if (thisEvent.Action.ToLower() == "change location") //change floor
                {
                    //ThisEvent will remain bool untriggered as will allow multiple re-use
                    Console.ReadLine();
                    world[Player.CurrentPos[2]] = ThisFloor;    //save floor to list. 
                    Player.CurrentPos[0] = thisEvent.Coodinates[0];
                    Player.CurrentPos[1] = thisEvent.Coodinates[1];   //set players position to start of new room
                    Player.CurrentPos[2] = thisEvent.Coodinates[2];
                    ThisFloor = world[Player.CurrentPos[2]];    //retreive new floor
                    CurrentRoom = GetRoomInfo(Player.CurrentPos);   //retreive new room info
                    Console.Clear();    //clear the screen
                    Console.WriteLine(WordWrap(CurrentRoom.Description));

                    //MusicPlayer.SoundLocation = SongList[Player.CurrentPos[2]];
                    //Music("start");
                }
                else if (thisEvent.Action.ToLower() == "change objective")
                {
                    Player.Objective = thisEvent.EventValue;
                    Console.WriteLine("Your current objective has changed.");
                }
                else if (thisEvent.Action.ToLower() == "output text")
                {
                    Console.WriteLine(WordWrap(thisEvent.EventValue));
                }
                else if (thisEvent.Action == "spawnItems")
                {
                    if (CurrentRoom.items == null) CurrentRoom.items = new List<itemInfo>();
                    foreach (itemInfo Item in thisEvent.Items)
                    {
                        CurrentRoom.items.Add(Item);
                    }
                }
                else if (thisEvent.Action == "spawnNPC")
                {
                    if (CurrentRoom.Civilians == null) CurrentRoom.Civilians = new List<CivilianProfile>();
                    foreach (CivilianProfile NPC in thisEvent.NPCs)
                    {
                        CurrentRoom.Civilians.Add(NPC);
                    }
                }
                else if (thisEvent.Action == "spawnEnemy")
                {
                    if (CurrentRoom.Enemy == null) CurrentRoom.Enemy = new List<EnemyProfile>();
                    foreach (EnemyProfile Enemy in thisEvent.Enemies)
                    {
                        CurrentRoom.Enemy.Add(Enemy);
                    }
                }
                else thisEvent.Triggered = false;
            }
            return thisEvent;
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
               System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(".\\Music");
               int NumOfSongs = dir.GetFiles().Length;
               int index = 0;
               string[] SongList = new string[NumOfSongs];

               if (NumOfSongs != 0)
               {
                   Console.WriteLine(WordWrap("Select a song from the list below:\n\n"));
                   foreach (FileInfo file in dir.GetFiles())    //Find Songs in music directory
                   {
                       if (file.Name.Split('.')[0].ToLower() == "wav")  //Wav only files
                       {
                           Console.WriteLine(WordWrap(string.Concat((index + 1), ": ",file.Name.Split('.')[0])));
                           SongList[index] = file.Name;
                           index++;
                       }
                   }
                   Console.Write("\nWhich Song would you like to play: ");
                   string UserChoice = Console.ReadLine();
                   int songChosen;

                   if (Int32.TryParse(UserChoice, out songChosen))
                   {

                       MusicPlayer.SoundLocation = string.Concat(".\\Music\\", SongList[songChosen - 1]);
                       MusicPlayer.PlayLooping();
                   }
                   else Console.WriteLine("Not a valid song choice");
               }
               else
               {
                   Console.Clear();
                   Console.WriteLine(WordWrap("<---You Should not be here--->"));
                   Console.WriteLine(WordWrap("No music has been detected. Please check the music folder\nPress [Enter] To continue"));
                   Console.ReadKey();
               }
           }
           else if (Command.ToLower() == "stop")
           {
               MusicPlayer.Stop();
           }


        }

        public static string WordWrap(string input)
        {
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
        }
   
    }   //end of class
}   //end of namespace