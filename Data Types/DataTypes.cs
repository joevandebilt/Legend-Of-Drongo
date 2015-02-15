using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;


namespace Legend_Of_Drongo
{
    public class DataTypes
    {
        [Serializable()]
        public struct GameState //Stores the details of the current world and player
        {
            public PlayerProfile PlayerState;
            public WorldFile WorldState;
        }

        [Serializable()]
        public struct WorldFile //Stores the details of the world
        {
            public string WorldName;
            public int WorldTime;
            public string WorldAuthor;
            public List<Floor> WorldState;
            public List<string> Credits;
            public PlayerProfile DefaultPlayer;
        }

        [Serializable()]
        public struct PlayerProfile     //The main players data structures
        {
            public string name;
            public List<itemInfo> inventory;
            public int invspace;
            public double HPBonus;
            public int ArmorBonus;
            public itemInfo WeaponHeld;
            public itemInfo[] ArmorWorn;
            public int[] CurrentPos;
            public string Objective;
            public int Money;
            public int DaysSinceSleep;
            public int XP;
            public int Level;
            public double MaxHp;    //Maxium hit points
            public int Speed;       //Chance of going first in combat
            public double Strength; //Adds to damage of weapon
            public int Resitence;   //Adds natural defense to player
            public int MaxItems;
            public bool InBuilding;
        }

        [Serializable()]
        public struct roomInfo  //Stores the details of the current room
        {
            public string RoomName;
            public string Description;
            public string AltDescription;   //should the description of a room change
            public bool CanMove;            //denotes whether player can move into this room
            public bool LockedIn;           //If a player is allowed to leave the room
            public string SuicideAction;    //Special string for if the user wishes to commit suicide.
            public string RoomColour;
            public bool Explored;
            public List<Event> Events;
            public List<CivilianProfile> Civilians; 
            public List<itemInfo> items;        //a list of items (list due to players being able to drop items on the floor)
            public List<EnemyProfile> Enemy;    //an array of enemies in the room
            public Building Building;
            public string ImagePath;
        }

        [Serializable()]
        public struct Building  //Stores the details of a Building
        {
            public string BuildingName;
            public string Description;
            public string AltDescription;   //should the description of a building change
            public bool CanMove;            //denotes whether player can move into this building
            public bool LockedIn;           //If a player is allowed to leave the building
            public string SuicideAction;    //Special string for if the user wishes to commit suicide.
            public List<Event> Events;
            public List<CivilianProfile> Civilians;
            public List<itemInfo> items;        //a list of items (list due to players being able to drop items on the floor)
            public List<EnemyProfile> Enemy;    //an array of enemies in the room
            public string ImagePath;
            //Thanks for the coffee scott
        }

        [Serializable()]
        public struct Floor     //Stores the details of the current floor
        {
            public roomInfo[,] CurrentFloor;
            public string FloorName;
            public string FloorSong;
        }

        [Serializable()]
        public struct Fighter   //Sets up a common fighting profile for enemies and player
        {
            public string name;
            public int initiative;
            public double HP;
            public bool isAlive;
            public itemInfo Weapon;
            public double AttackMod;
            public int DefenseMod;
            public int ID;
            public int Team;
            public string Behaviour;
        }

        [Serializable()]
        public struct itemInfo  //Stores information on items
        {
            public List<string> InteractionName;
            public string Examine;
            public string Name;
            public double AttackMod;
            public int DefenseMod;
            public int HPmod;
            public bool CanPickUp;
            public string Class;
            public string GoodHit;
            public string MedHit;
            public string BadHit;
            public int Value;
            public string ItemNeeded;
            public string interactionResponse;
            public int XP;
            public string ImagePath;
            public Point ImageLocation;
        }

        [Serializable()]
        public struct EnemyProfile  //The profile of an enemy 
        {
            public string name;
            public itemInfo Weapon;
            public double HPBonus;
            public int armor;
            public int Money;
            public string KillMessage;
            public string DeathMessage;
            public int PayOff;  //the value at which an enemy can be 'bought off' 
            public string PayOffResponse;
            public int XP;
            public int Team;
            public string Behaviour;
            public string ImagePath;
            public Point ImageLocation;
        }

        [Serializable()]
        public struct CivilianProfile   //The profile of an NPC 
        {
            public string name;
            public string TalkToResponse;
            public List<itemInfo> inventory;
            public List<Facts> Knowledge;
            public double HPBonus;
            public int armor;
            public int Money;
            public bool willSell;
            public bool willBuy;
            public string MerchantType;
            public bool QuestCharacter;
            public int XP;
            public string Donation;
            public string ImagePath;
            public Point ImageLocation;
        }

        [Serializable()]
        public struct Event     //Stores a world event
        {
            public string Trigger;
            public string Action;
            public int[] Coodinates;
            public string triggerCriteria;
            public string EventValue;
            public List<CivilianProfile> NPCs;
            public List<itemInfo> Items;
            public List<EnemyProfile> Enemies;
            public bool Triggered;
            public bool ReUsable;
            public bool ApplyToBuilding;
        }

        [Serializable()]
        public struct Facts
        {
            public string Topic;
            public string Knowledge;
        }

        #region CloningMethods

        public roomInfo CloneRoom(roomInfo Room)
        {
            roomInfo NewRoom = new roomInfo();

            NewRoom.Description = Room.Description;
            NewRoom.AltDescription = Room.AltDescription;
            NewRoom.CanMove = Room.CanMove;
            NewRoom.LockedIn = Room.LockedIn;
            NewRoom.SuicideAction = Room.SuicideAction;
            NewRoom.RoomColour = Room.RoomColour;
            NewRoom.ImagePath = Room.ImagePath;

            NewRoom.Building = CloneBuilding(Room.Building);

            NewRoom.Events = new List<Event>();
            NewRoom.Civilians = new List<CivilianProfile>();
            NewRoom.items = new List<itemInfo>();
            NewRoom.Enemy = new List<EnemyProfile>();

            if (Room.Events != null) foreach (Event newEvent in Room.Events) { NewRoom.Events.Add(CloneEvent(newEvent)); }
            if (Room.Civilians != null) foreach (CivilianProfile NPC in Room.Civilians) { NewRoom.Civilians.Add(CloneNPC(NPC)); }
            if (Room.items != null) foreach (itemInfo NewItem in Room.items) { NewRoom.items.Add(CloneItem(NewItem)); }
            if (Room.Enemy != null) foreach (EnemyProfile Enemy in Room.Enemy) { NewRoom.Enemy.Add(CloneEnemy(Enemy)); }

            return NewRoom;
        }

        public Building CloneBuilding(Building Building)
        {
            Building NewBuilding = new Building();

            NewBuilding.BuildingName = Building.BuildingName;
            NewBuilding.Description = Building.Description;
            NewBuilding.AltDescription = Building.AltDescription;   //should the description of a building change
            NewBuilding.CanMove = Building.CanMove;            //denotes whether player can move into this building
            NewBuilding.LockedIn = Building.LockedIn;           //If a player is allowed to leave the building
            NewBuilding.SuicideAction = Building.SuicideAction;    //Special string for if the user wishes to commit suicide.
            NewBuilding.ImagePath = Building.ImagePath;

            NewBuilding.Events = new List<Event>();
            NewBuilding.Civilians = new List<CivilianProfile>();
            NewBuilding.items = new List<itemInfo>();
            NewBuilding.Enemy = new List<EnemyProfile>();

            if (Building.Events != null) foreach (Event newEvent in Building.Events) { NewBuilding.Events.Add(CloneEvent(newEvent)); }
            if (Building.Civilians != null) foreach (CivilianProfile NPC in Building.Civilians) { NewBuilding.Civilians.Add(CloneNPC(NPC)); }
            if (Building.items != null) foreach (itemInfo NewItem in Building.items) { NewBuilding.items.Add(CloneItem(NewItem)); }
            if (Building.Enemy != null) foreach (EnemyProfile Enemy in Building.Enemy) { NewBuilding.Enemy.Add(CloneEnemy(Enemy)); }

            return NewBuilding;
        }

        public itemInfo CloneItem(itemInfo Item)
        {

            itemInfo NewItem = new itemInfo();

            NewItem.InteractionName = new List<string>();
            if (Item.InteractionName != null) foreach (string name in Item.InteractionName) { NewItem.InteractionName.Add(name); }
            
            NewItem.Name = Item.Name;
            NewItem.Examine = Item.Examine;
            NewItem.AttackMod = Item.AttackMod;
            NewItem.DefenseMod = Item.DefenseMod;
            NewItem.HPmod = Item.HPmod;
            NewItem.CanPickUp = Item.CanPickUp;
            NewItem.Class = Item.Class;
            NewItem.GoodHit = Item.BadHit;
            NewItem.MedHit = Item.MedHit;
            NewItem.BadHit = Item.BadHit;
            NewItem.Value = Item.Value;
            NewItem.ItemNeeded = Item.ItemNeeded;
            NewItem.interactionResponse = Item.interactionResponse;
            NewItem.XP = Item.XP;
            NewItem.ImagePath = Item.ImagePath;
            NewItem.ImageLocation = Item.ImageLocation;

            return NewItem;
        }

        public Event CloneEvent(Event Event)
        {
            Event NewEvent = new Event();

            NewEvent.Trigger = Event.Trigger;
            NewEvent.Action = Event.Action;
            NewEvent.Coodinates = new int[3];

            if (Event.Coodinates != null)
            {
                NewEvent.Coodinates[0] = Event.Coodinates[0];
                NewEvent.Coodinates[1] = Event.Coodinates[1];
                NewEvent.Coodinates[2] = Event.Coodinates[2];
            }
            NewEvent.EventValue = Event.EventValue;
            NewEvent.triggerCriteria = Event.triggerCriteria;
            NewEvent.Triggered = Event.Triggered;
            NewEvent.ApplyToBuilding = Event.ApplyToBuilding;

            NewEvent.Enemies = new List<EnemyProfile>();
            NewEvent.NPCs = new List<CivilianProfile>();
            NewEvent.Items = new List<itemInfo>();

            if (Event.Enemies != null) foreach (EnemyProfile NewEnemy in Event.Enemies) { NewEvent.Enemies.Add(CloneEnemy(NewEnemy)); }
            if (Event.NPCs != null) foreach (CivilianProfile NewNPC in Event.NPCs) { NewEvent.NPCs.Add(CloneNPC(NewNPC)); }
            if (Event.Items != null) foreach (itemInfo NewItem in Event.Items) { NewEvent.Items.Add(CloneItem(NewItem)); }

            return NewEvent;
        }

        public EnemyProfile CloneEnemy(EnemyProfile Enemy) 
        { 
            EnemyProfile NewEnemy = new EnemyProfile();

            NewEnemy.name = Enemy.name;
            NewEnemy.Weapon = CloneItem(Enemy.Weapon);
            NewEnemy.HPBonus = Enemy.HPBonus;
            NewEnemy.armor = Enemy.armor;
            NewEnemy.Money = Enemy.Money;
            NewEnemy.KillMessage = Enemy.KillMessage;
            NewEnemy.DeathMessage = Enemy.DeathMessage;
            NewEnemy.PayOff = Enemy.PayOff;
            NewEnemy.PayOffResponse = Enemy.PayOffResponse;
            NewEnemy.XP = Enemy.XP;
            NewEnemy.Behaviour = Enemy.Behaviour;
            NewEnemy.ImagePath = Enemy.ImagePath;
            NewEnemy.ImageLocation = Enemy.ImageLocation;

            return NewEnemy;
        }

        public CivilianProfile CloneNPC(CivilianProfile NPC) 
        { 
            CivilianProfile NewNPC = new CivilianProfile();

            NewNPC.name = NPC.name;
            NewNPC.TalkToResponse = NPC.TalkToResponse;

            NewNPC.inventory = new List<itemInfo>();
            if (NPC.inventory != null) foreach (itemInfo item in NPC.inventory) { NewNPC.inventory.Add(CloneItem(item)); }

            NewNPC.Knowledge = new List<Facts>();
            if (NPC.Knowledge != null) foreach (Facts fact in NPC.Knowledge) { NewNPC.Knowledge.Add(CloneFact(fact)); }

            NewNPC.HPBonus = NPC.HPBonus;
            NewNPC.armor = NPC.armor;
            NewNPC.Money = NPC.Money;
            NewNPC.willSell = NPC.willSell;
            NewNPC.willBuy = NPC.willBuy;
            NewNPC.MerchantType = NPC.MerchantType;
            NewNPC.QuestCharacter = NPC.QuestCharacter;
            NewNPC.XP = NPC.XP;
            NewNPC.Donation = NPC.Donation;
            NewNPC.ImagePath = NPC.ImagePath;
            NewNPC.ImageLocation = NPC.ImageLocation;

            return NewNPC;
        }

        public Facts CloneFact(Facts Fact)
        {
            Facts NewFact = new Facts();

            NewFact.Topic = Fact.Topic;
            NewFact.Knowledge = Fact.Knowledge;

            return NewFact;
        }

        #endregion

        #region Class Converters

        public roomInfo BuildingIntoRoom(Building thisBuilding)
        {
            roomInfo ThisRoom = new roomInfo();

            ThisRoom.RoomName = thisBuilding.BuildingName;
            ThisRoom.Description = thisBuilding.Description;
            ThisRoom.AltDescription = thisBuilding.AltDescription;
            ThisRoom.CanMove = thisBuilding.CanMove;
            ThisRoom.LockedIn = thisBuilding.LockedIn;
            ThisRoom.SuicideAction = thisBuilding.SuicideAction;
            ThisRoom.ImagePath = thisBuilding.ImagePath;

            ThisRoom.Events = new List<Event>();
            ThisRoom.Civilians = new List<CivilianProfile>();
            ThisRoom.items = new List<itemInfo>();
            ThisRoom.Enemy = new List<EnemyProfile>();

            DataTypes dt = new DataTypes();

            if (thisBuilding.Events != null) foreach (Event newEvent in thisBuilding.Events) { ThisRoom.Events.Add(dt.CloneEvent(newEvent)); }
            if (thisBuilding.Civilians != null) foreach (CivilianProfile NPC in thisBuilding.Civilians) { ThisRoom.Civilians.Add(dt.CloneNPC(NPC)); }
            if (thisBuilding.items != null) foreach (itemInfo NewItem in thisBuilding.items) { ThisRoom.items.Add(dt.CloneItem(NewItem)); }
            if (thisBuilding.Enemy != null) foreach (EnemyProfile Enemy in thisBuilding.Enemy) { ThisRoom.Enemy.Add(dt.CloneEnemy(Enemy)); }

            return ThisRoom;
        }

        public Building RoomIntoBuilding (roomInfo thisRoom)
        {
            Building thisBuilding = new Building();

            thisBuilding.BuildingName = thisRoom.RoomName;
            thisBuilding.Description = thisRoom.Description;
            thisBuilding.AltDescription = thisRoom.AltDescription;
            thisBuilding.CanMove = thisRoom.CanMove;
            thisBuilding.LockedIn = thisRoom.LockedIn;
            thisBuilding.SuicideAction = thisRoom.SuicideAction;
            thisBuilding.ImagePath = thisRoom.ImagePath;

            thisBuilding.Events = new List<Event>();
            thisBuilding.Civilians = new List<CivilianProfile>();
            thisBuilding.items = new List<itemInfo>();
            thisBuilding.Enemy = new List<EnemyProfile>();

            DataTypes dt = new DataTypes();

            if (thisRoom.Events != null) foreach (Event newEvent in thisRoom.Events) { thisBuilding.Events.Add(dt.CloneEvent(newEvent)); }
            if (thisRoom.Civilians != null) foreach (CivilianProfile NPC in thisRoom.Civilians) { thisBuilding.Civilians.Add(dt.CloneNPC(NPC)); }
            if (thisRoom.items != null) foreach (itemInfo NewItem in thisRoom.items) { thisBuilding.items.Add(dt.CloneItem(NewItem)); }
            if (thisRoom.Enemy != null) foreach (EnemyProfile Enemy in thisRoom.Enemy) { thisBuilding.Enemy.Add(dt.CloneEnemy(Enemy)); }

            return thisBuilding;
        }


        #endregion
    }
}
