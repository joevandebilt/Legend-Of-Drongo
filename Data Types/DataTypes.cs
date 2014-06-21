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


    }
}
