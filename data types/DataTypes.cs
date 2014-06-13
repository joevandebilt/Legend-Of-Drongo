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
            public int HP;
            public bool isAlive;
            public itemInfo Weapon;
            public int AttackMod;
            public int DefenseMod;
            public int ID;
        }

        [Serializable()]
        public struct itemInfo
        {
            public List<string> InteractionName;
            public string Examine;
            public string Name;
            public int AttackMod;
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
        }

        [Serializable()]
        public struct PlayerProfile
        {
            public string name;
            public itemInfo[] inventory;
            public int invspace;
            public int HPBonus;
            public int ArmorBonus;
            public itemInfo WeaponHeld;
            public itemInfo[] ArmorWorn;
            public int[] CurrentPos;
            public string Objective;
            public int Money;
        }

        [Serializable()]
        public struct EnemyProfile
        {
            public string name;
            public itemInfo Weapon;
            public int HPBonus;
            public int armor;
            public int Money;
            public string KillMessage;
            public string DeathMessage;
            public int PayOff;  //the value at which an enemy can be 'bought off' 
            public string PayOffResponse;
        }

        [Serializable()]
        public struct CivilianProfile
        {
            public string name;
            public string TalkToResponse;
            public List<itemInfo> inventory;
            public List<Facts> Knowledge;
            public int HPBonus;
            public int armor;
            public int Money;
            public bool willSell;
            public bool willBuy;
            public string MerchantType;
            public bool QuestCharacter;
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


    }
}
