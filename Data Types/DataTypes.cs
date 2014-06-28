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
            public List<Floor> WorldState;
        }

        [Serializable()]
        public struct roomInfo  //Stores the details of the current room
        {
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
        }

        [Serializable()]
        public struct Floor     //Stores the details of the current floor
        {
            public roomInfo[,] CurrentFloor;
            public string FloorName;
            public string FloorSong;
        }

        [Serializable()]
        public struct Fighter
        {
            public string name;
            public int initiative;
            public double HP;
            public bool isAlive;
            public itemInfo Weapon;
            public double AttackMod;
            public int DefenseMod;
            public int ID;
        }

        [Serializable()]
        public struct itemInfo
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
        }

        [Serializable()]
        public struct PlayerProfile
        {
            public string name;
            public itemInfo[] inventory;
            public int invspace;
            public double HPBonus;
            public int ArmorBonus;
            public itemInfo WeaponHeld;
            public itemInfo[] ArmorWorn;
            public int[] CurrentPos;
            public string Objective;
            public int Money;
            public int XP; 
            public int Level;
            public double MaxHp;    //Maxium hit points
            public int Speed;       //Chance of going first in combat
            public double Strength; //Adds to damage of weapon
            public int Resitence;   //Adds natural defense to player
        }

        [Serializable()]
        public struct EnemyProfile
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
        }

        [Serializable()]
        public struct CivilianProfile
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
        }

        [Serializable()]
        public struct Event
        {
            public string Trigger;
            public string Action;
            public int[] Coodinates;
            public string EventValue;
            public List<CivilianProfile> NPCs;
            public List<itemInfo> Items;
            public List<EnemyProfile> Enemies;
            public bool Triggered;
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

            NewRoom.Events = new List<Event>();
            NewRoom.Civilians = new List<CivilianProfile>();
            NewRoom.items = new List<itemInfo>();
            NewRoom.Enemy = new List<EnemyProfile>();

            if (Room.Events != null) foreach (Event newEvent in Room.Events) { NewRoom.Events.Add(CloneEvent(newEvent)); }
            if (Room.Civilians != null) foreach (CivilianProfile NPC in Room.Civilians) { NewRoom.Civilians.Add(CloneNPC(NPC)); }
            if (Room.items != null) foreach (itemInfo NewItem in Room.items) { NewRoom.items.Add(CloneItem(NewItem)); }
            NewRoom.Enemy = Room.Enemy;

            return NewRoom;
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

            return NewItem;
        }

        public Event CloneEvent(Event Event)
        {
            Event NewEvent = new Event();

            NewEvent.Trigger = Event.Trigger;
            NewEvent.Action = Event.Action;
            NewEvent.Coodinates = new int[3];

            NewEvent.Coodinates[0] = Event.Coodinates[0];
            NewEvent.Coodinates[1] = Event.Coodinates[1];
            NewEvent.Coodinates[2] = Event.Coodinates[2];
            
            NewEvent.EventValue = Event.EventValue;

            NewEvent.Triggered = Event.Triggered;

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
    }
}
