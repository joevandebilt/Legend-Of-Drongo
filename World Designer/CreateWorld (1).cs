using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legend_Of_Drongo
{
    class WorldCreate : DataTypes
    {
        public List<roomInfo[,]> Tutorial()
        {
            List<roomInfo[,]> Tworld = new List<roomInfo[,]>();
            roomInfo[,] ThisFloor = new roomInfo[10, 10];
            itemInfo newItem = new itemInfo();
            CivilianProfile Civy = new CivilianProfile();
            EnemyProfile Enemy = new EnemyProfile();

            ThisFloor[1, 1].Description = "Welcome to the 'Legend Of Drongo' tutorial. This tutorial assumes you have never played the game before and serves and introduction to the commands. At any time you can type 'help' to list the commands.\n\nFirst of all, lets move into the next room. To do this type 'go east' and press enter";
            ThisFloor[1, 1].CanMove = true;

            ThisFloor[1, 2].Description = "Well done, You can move in 4 directions: North, East, South and west.\n\n You can move in any direction by typing 'go <direction>', you can also just use the direction such as 'east' \n\nType 'east' to move onto the next room";
            ThisFloor[1, 2].CanMove = true;

            ThisFloor[1, 3].Description = "Some locations you cannot move to, try moving north or south. Moving west will move back to where you came from. East will move to the next room";
            ThisFloor[1, 3].CanMove = true;

            ThisFloor[1, 4].Description = "Good work. Next we will look at item interaction. Some rooms will have items in them, some you can pick up and some you can't. This room has a painting on the wall. Try looking at the painting by typing 'look at painting'.\n\nIt is possible to refer to the same item by different names. For instance, after trying 'look at painting' try saying 'look at wall'.\n\nMove east to the next room";
            ThisFloor[1, 4].CanMove = true;
            ThisFloor[1, 4].items = new List<itemInfo>();
            
            newItem = new itemInfo();
            newItem.Name = "Painting";
            newItem.CanPickUp = false;
            newItem.Examine = "It is an exquisite painting of a man in full armor, he is depicted holding a monsters head aloft";
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("painting");
            newItem.InteractionName.Add("wall");
            ThisFloor[1, 4].items.Add(newItem);
            
            ThisFloor[1, 5].Description = "In this room there is an item you can try to pick up. You cannot tell what it is so you will need to 'look at' it first. After you have looked at it, try picking it up. Once you have move onto the next room.";
            ThisFloor[1, 5].CanMove = true;
            ThisFloor[1, 5].items = new List<itemInfo>();
            
            newItem = new itemInfo();
            newItem.Name = "Apple";
            newItem.CanPickUp = true;
            newItem.Examine = "It is a tasty looking apple, pick me up using the 'take' or 'pick up' command";
            newItem.Class = "Food";
            newItem.HPmod = 5;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("apple");
            newItem.InteractionName.Add("item");
            ThisFloor[1, 5].items.Add(newItem);

            ThisFloor[1, 6].Description = "Now you should try looking at your inventory. Type 'inventory' to list the items you have collected";
            ThisFloor[1, 6].CanMove = true;

            ThisFloor[1, 7].Description = "You can drop items from your inventory. When you drop items they are left in the area you drop them in. Try dropping your apple with the 'drop' command, then try picking it up again.";
            ThisFloor[1, 7].CanMove = true;

            ThisFloor[1, 8].Description = "You must keep an eye on your status while playing. Typing status will return your HP, weapon and armor stats. Try this now. When done, move south to the next room";
            ThisFloor[1, 8].CanMove = true;

            ThisFloor[2, 8].Description = "The apple is a food item. You can consume food and drink, it may have adverse effects, you can check an items stats first by using the examine command.\n\nWhen examining items you need to use their specific name. Use your inventory to check on an items specific name.\n\nMove south to the next room";
            ThisFloor[2, 8].CanMove = true;

            ThisFloor[3, 8].Description = "When you examined the apple you notice it has a 5HP boost, this means if you eat it you will gain 5HP. Try eating the apple now by using the 'eat' command.";
            ThisFloor[3, 8].CanMove = true;

            ThisFloor[4, 8].Description = "This room is an armory, there is a sword and set of armor on a rack. Armor is comprised of 5 parts, helmet, chest, gloves, legs and boots. Pick up all these items.";
            ThisFloor[4, 8].CanMove = true;
            ThisFloor[4, 8].items = new List<itemInfo>();

            newItem = new itemInfo();
            newItem.Name = "Sword";
            newItem.CanPickUp = true;
            newItem.Examine = "Sharp looking sword.";
            newItem.Class = "Weapon";
            newItem.AttackMod = 5;
            newItem.DefenseMod = 1;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("sword");
            ThisFloor[4, 8].items.Add(newItem);

            newItem = new itemInfo();
            newItem.Name = "Helmet";
            newItem.CanPickUp = true;
            newItem.Examine = "Pretty tough looking helmet.";
            newItem.Class = "Armor-Helmet";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 3;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("helmet");
            ThisFloor[4, 8].items.Add(newItem);

            newItem = new itemInfo();
            newItem.Name = "Cuirass";
            newItem.CanPickUp = true;
            newItem.Examine = "Pretty tough looking tunic.";
            newItem.Class = "Armor-Chest";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 5;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("chest");
            newItem.InteractionName.Add("cuirass");
            newItem.InteractionName.Add("chest armor");
            newItem.InteractionName.Add("armor");
            ThisFloor[4, 8].items.Add(newItem);

            newItem = new itemInfo();
            newItem.Name = "Gloves";
            newItem.CanPickUp = true;
            newItem.Examine = "Pretty tough looking Gloves.";
            newItem.Class = "Armor-Gloves";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 2;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("gloves");
            ThisFloor[4, 8].items.Add(newItem);

            newItem = new itemInfo();
            newItem.Name = "Greaves";
            newItem.CanPickUp = true;
            newItem.Examine = "Pretty tough looking leg armor.";
            newItem.Class = "Armor-Legs";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 4;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("legs");
            newItem.InteractionName.Add("greaves");
            ThisFloor[4, 8].items.Add(newItem);

            newItem = new itemInfo();
            newItem.Name = "Boots";
            newItem.CanPickUp = true;
            newItem.Examine = "Pretty tough looking booties.";
            newItem.Class = "Armor-Boots";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 4;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("boots");
            ThisFloor[4, 8].items.Add(newItem);

            ThisFloor[5, 8].Description = "You should now try to equip your sword and armor. Use the equip command to equip each peice.\n\nRemember to be specific. Use inventory to see the names of items. Once done use the status command to see your current status.";
            ThisFloor[5, 8].CanMove = true;

            ThisFloor[6, 8].Description = "The next room you will find an enemy.\n\nCombat works quite simply. Use the attack command and specify an enemy, you will then attack them with your currently equipped weapon. So remember to always have a weapon equipped.\n\nCombat works in turns. When you attack the computer will decide a random order in which you attack. Every opponent in the room, and yourself, will take a turn. Remember also that you have a chance to run, however in the next room you will not be able to run";
            ThisFloor[6, 8].CanMove = true;

            ThisFloor[7, 8].Description = "There is a man in the room. He will not attack you until you attack him. Try to 'attack man'";
            ThisFloor[7, 8].AltDescription = "The man is dead. Well done, move onto the next room now";
            ThisFloor[7, 8].CanMove = true;

            ThisFloor[7, 8].Enemy = new List<EnemyProfile>();
            Enemy = new EnemyProfile();
            Enemy.name = "man";
            Enemy.HPBonus = 10;
            Enemy.armor = 0;
            Enemy.DeathMessage = "The man dies. Because you beat the crap out of him. You can move onto the next room now";
            Enemy.Weapon.Name = "fists";
            Enemy.Weapon.CanPickUp = false;
            Enemy.Weapon.AttackMod = 1;
            ThisFloor[7, 8].Enemy.Add(Enemy);

            ThisFloor[7, 8].TriggerEvent = false;
            ThisFloor[7, 8].EventAction = "killenemies";
            ThisFloor[7, 8].TriggerAction = "u cd";     //on enemy death unlock room and change description
            ThisFloor[7, 8].EventCoods = new int[3] { 8, 8, 0 };

            ThisFloor[8, 8].Description = "You must first kill the man in this room";
            ThisFloor[8, 8].AltDescription = "In this room there is an enemy, but he has no hands. He is angry and has a huge amount of health, despite being no danger to you. You need to pay him off to stop him being aggressive.\n\nUse the 'bribe' command to stop the angry handicapped person.\n\nBribing people defuses a situation but some people may not take a bribe. You should pay this man at least 1 gold to pay him off, paying more than this will still defuse the situation, but you will lose more money than necessary, if people do not state how much they want from you, bribing them may be a gamble.\n\nTo see how much money you have, use the 'money' command";
            ThisFloor[8, 8].CanMove = false;

            ThisFloor[8, 8].Enemy = new List<EnemyProfile>();
            Enemy = new EnemyProfile();
            Enemy.name = "man";
            Enemy.HPBonus = 10000;
            Enemy.armor = 0;
            Enemy.PayOff = 1;
            Enemy.PayOffResponse = "Thank you for the gold, kind sir. You'll need to start travelling west from now";
            Enemy.DeathMessage = "The man dies. Because you beat the crap out of him. You can move west into the next room";
            Enemy.Weapon.Name = "stubs";
            Enemy.Weapon.CanPickUp = false;
            Enemy.Weapon.AttackMod = 0;
            ThisFloor[8, 8].Enemy.Add(Enemy);

            ThisFloor[8, 8].EventAction = "payoff";
            ThisFloor[8, 8].TriggerAction = "u";
            ThisFloor[8, 8].EventCoods = new int[3] { 8, 7, 0 };
            ThisFloor[8, 8].TriggerEvent = false;

            ThisFloor[8, 7].Description = "You must first bribe this man";
            ThisFloor[8, 7].AltDescription = "In this room there is another man. You can either fight him or try to bribe him. His bribe amount is too high for you to pay, so whether you try or not he will reject your bribe and start to fight.\n\nIf a bribe fails an enemy will no longer be willing to accept a bribe at all and will continue to attack you.\n\n If you try to bribe an enemy and they refuse, you will miss your turn in combat.\n\nTry to bribe this enemy, then when it fails. Kill them.";
            ThisFloor[8, 7].CanMove = false;

            ThisFloor[8, 7].EventAction = "killenemies";
            ThisFloor[8, 7].TriggerAction = "u";
            ThisFloor[8, 7].EventCoods = new int[3] { 8, 6, 0 };
            ThisFloor[8, 7].TriggerEvent = false;
            
            ThisFloor[8, 7].Enemy = new List<EnemyProfile>();
            Enemy.name = "man";
            Enemy.HPBonus = 10;
            Enemy.armor = 0;
            Enemy.PayOff = 1000000000;
            Enemy.PayOffResponse = "Thank you kind sir";
            Enemy.Money = 20;
            Enemy.DeathMessage = "The man dies. When he dies you automatically take the money he had on his persons (which includes the bribe you tried to give him) he also drops his item (stick). Try picking up his weapon.";
            Enemy.Weapon.Name = "Stick";
            Enemy.Weapon.Class = "Weapon";
            Enemy.Weapon.CanPickUp = true;
            Enemy.Weapon.AttackMod = 1;
            Enemy.Weapon.InteractionName = new List<string>();
            Enemy.Weapon.InteractionName.Add("enemy weapon");
            Enemy.Weapon.InteractionName.Add("weapon");
            Enemy.Weapon.InteractionName.Add("stick");
            ThisFloor[8, 7].Enemy.Add(Enemy);

            ThisFloor[8, 6].Description = "You must first kill this man";
            ThisFloor[8, 6].AltDescription = "In this room there is a non-hostile man. He will talk to you if you try and talk to him. Do this with the 'talk to' command";
            ThisFloor[8, 6].CanMove = false;

            ThisFloor[8, 6].Civilians = new List<CivilianProfile>();

            Civy.name = "Man";
            Civy.willSell = false;
            Civy.TalkToResponse = "Good job on talking to me, you can move west into the next room now";
            ThisFloor[8, 6].Civilians.Add(Civy);

            ThisFloor[8, 5].Description = "In this room there is a man who will buy items from you. To sell items to a person, use the 'sell' command, also specify what you are selling and who you want to sell it to.\n\nWhen you sell an item to a person they will retain it in their inventory and you could buy it back from them, though it is likely a merchant will buy an item from you, then try to sell it back at a higher price.\n\nPick up the mystery object from the floor and try to sell it to the merchant.";
            ThisFloor[8, 5].CanMove = true;
            ThisFloor[8, 5].Civilians = new List<CivilianProfile>();

            Civy = new CivilianProfile();
            Civy.name = "Merchant";
            Civy.willSell = true;
            Civy.willBuy = true;
            Civy.TalkToResponse = "Yes sir, I will buy your things from you";
            Civy.MerchantType = "all";
            ThisFloor[8, 5].Civilians.Add(Civy);

            ThisFloor[8, 5].items = new List<itemInfo>();
            newItem = new itemInfo();
            newItem.Name = "Mystery Object";
            newItem.CanPickUp = true;
            newItem.Examine = "Looks pretty shiney.";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 0;
            newItem.Value = 20;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("object");
            newItem.InteractionName.Add("mystery object");
            ThisFloor[8, 5].items.Add(newItem);

            ThisFloor[8, 4].Description = "In this room you can buy items from a merchant, he has an object that you will need to use in one of the future rooms. See what he has to sell by using the 'view wares' command. Then buy from him using the 'buy' command";
            ThisFloor[8, 4].CanMove = true;
            ThisFloor[8, 4].Civilians = new List<CivilianProfile>();
            
            newItem = new itemInfo();
            newItem.Name = "Blue Key";
            newItem.CanPickUp = true;
            newItem.Examine = "A mysterious blue key";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 0;
            newItem.Value = 5;
            newItem.Class = "Interaction Object";
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("key");
            newItem.InteractionName.Add("blue key");
            
            Civy = new CivilianProfile();
            Civy.name = "Merchant";
            Civy.willSell = true;
            Civy.willBuy = false;
            Civy.TalkToResponse = "Yes sir, I will sell things to you";
            Civy.MerchantType = "all";
            Civy.inventory = new List<itemInfo>();
            Civy.inventory.Add(newItem);
            ThisFloor[8, 4].Civilians.Add(Civy);

            ThisFloor[8, 3].Description = "You will notice that you may have lost HP in the previous few fights. As you already know you can regain HP by eating food, however you can also regenerate to full HP by sleeping. Some items in the world allow you to sleep (beds, bedrolls etc) and some you are able to keep in your inventory.\n\nIn This room you will find a bedroll on the floor, try sleeping in it by using 'sleep in bedroll' command. Afterwards, check your HP using status and notice you are full HP. Then pick up the bedroll and take it with you into the next room.";
            ThisFloor[8, 3].CanMove = true;
            ThisFloor[8, 3].items = new List<itemInfo>();

            newItem = new itemInfo();
            newItem.Name = "Bedroll";
            newItem.CanPickUp = true;
            newItem.Examine = "A comfy looking bedroll. For sleeping in...";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 0;
            newItem.Value = 5;
            newItem.Class = "Bed";
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("Bedroll");
            newItem.InteractionName.Add("Bed");
            newItem.InteractionName.Add("Sleeping Bag");
            ThisFloor[8, 3].items.Add(newItem);

            ThisFloor[8, 2].Description = "This room has a locked door, you will need to use the Blue Key you bought from the merchant 2 rooms back. If you do not have that item, you will need to go back and buy it. To use an item, use the 'use' command\n\nIf you don't have any money to buy the key, try picking up the mystery item in this room.";
            ThisFloor[8, 2].AltDescription = "The door has slammed shut behind you and there is no keyhole. You are trapped in here";
            ThisFloor[8, 2].CanMove = true;
            ThisFloor[8, 2].items = new List<itemInfo>();

            newItem = new itemInfo();
            newItem.Name = "Door";
            newItem.Examine = "It is a big heavy door. Looks like you can't go through it";
            newItem.interactionResponse = "The key fits in the lock and the door opens. Magical.";
            newItem.ItemNeeded = "Blue Key";
            newItem.CanPickUp = false;
            newItem.Class = "Interaction Object";
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("Door");
            newItem.InteractionName.Add("Lock");
            newItem.InteractionName.Add("Door lock");
            newItem.InteractionName.Add("KEYHOLE");
            ThisFloor[8, 2].items.Add(newItem);

            newItem = new itemInfo();
            newItem.Name = "Mystery Object";
            newItem.CanPickUp = true;
            newItem.Examine = "Looks pretty shiney.";
            newItem.AttackMod = 0;
            newItem.DefenseMod = 0;
            newItem.Value = 20;
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("object");
            newItem.InteractionName.Add("mystery object");
            ThisFloor[8, 2].items.Add(newItem);

            ThisFloor[8, 2].EventAction = "iteminteraction";
            ThisFloor[8, 2].TriggerEvent = false;
            ThisFloor[8, 2].TriggerAction = "u";
            ThisFloor[8, 2].EventCoods = new int[3] { 8, 1, 0 };

            ThisFloor[8, 1].Description = "A door blocks your path. Unlock it first";
            ThisFloor[8, 1].CanMove = false;
            ThisFloor[8, 1].AltDescription = "As you walk into the final room, the door slams shut behind you. There is no other way out, only a note on the floor.";

            ThisFloor[8, 1].EventAction = "moveinto";
            ThisFloor[8, 1].TriggerEvent = false;
            ThisFloor[8, 1].TriggerAction = "l";
            ThisFloor[8, 1].EventCoods = new int[3] { 8, 2, 0 };

            ThisFloor[8, 1].items = new List<itemInfo>();
            newItem = new itemInfo();
            newItem.Name = "Note";
            newItem.Examine = "Well done on completing the tutorial. You are now trapped and there is no way out. Use the 'suicide' command to kill yourself, and end this tutorial.";
            newItem.CanPickUp = true;
            newItem.Class = "Readable";
            newItem.InteractionName = new List<string>();
            newItem.InteractionName.Add("note");
            newItem.InteractionName.Add("letter");
            ThisFloor[8, 1].items.Add(newItem);
            ThisFloor[8, 1].SuicideAction = "Trapped in the room you slowly go mad. Tearing off your own skin thinking it to be some kind of enemy you bleed out and die";

            
            //blocked rooms
            int index;

            for (index = 0; index <= 9; index++)
            {
                ThisFloor[index, 0].Description = "You cannot move this way";
                ThisFloor[index, 0].CanMove = false;
                ThisFloor[index, 9].Description = "You cannot move this way";
                ThisFloor[index, 9].CanMove = false;

                ThisFloor[0, index].Description = "You cannot move this way";
                ThisFloor[0, index].CanMove = false;
                ThisFloor[9, index].Description = "You cannot move this way";
                ThisFloor[9, index].CanMove = false;
            }

            for (index = 2; index <= 7; index++)
            {
                ThisFloor[index, 2].Description = "You cannot move this way";
                ThisFloor[index, 2].CanMove = false;
                ThisFloor[index, 7].Description = "You cannot move this way";
                ThisFloor[index, 7].CanMove = false;

                ThisFloor[2, index].Description = "You cannot move this way";
                ThisFloor[2, index].CanMove = false;
                ThisFloor[7, index].Description = "You cannot move this way";
                ThisFloor[7, index].CanMove = false;
            }

            ThisFloor[2, 1].Description = "You cannot go this way";
            ThisFloor[2, 1].CanMove = false;

            Tworld.Add(ThisFloor);

            return (Tworld);
        }

        public List<roomInfo[,]> CreateWorld()
        {

            List<roomInfo[,]> world = new List<roomInfo[,]>();
            world.Add(Floor0());
            world.Add(Floor1());
            //world.Add(Floor2());
            return (world);


        }

        public roomInfo[,] Floor0()
        {
            roomInfo[,] ThisFloor = new roomInfo[10, 10];
            EnemyProfile Enemy = new EnemyProfile();

            ThisFloor[1, 4].Description = "You stand on a firm platform, grey smoke billows around you. You do not know where you are or how you got here";
            ThisFloor[1, 4].CanMove = true;

            ThisFloor[2, 4].Description = "As you move the floor seems to expand beneath your feet, creating a walkway. A light shines through the fog but the smoke is so thick it hardly makes a difference";
            ThisFloor[2, 4].CanMove = true;

            ThisFloor[3, 1].Description = "The ghostly figure of a man stands on the edge of what looks like a large cliff. He is weeping, though when you approach him he vanishes into whisps of cloud";
            ThisFloor[3, 1].CanMove = true;

            ThisFloor[3, 2].Description = "You feel cold as you move through the smoke. There must be some kind of way out of here...";
            ThisFloor[3, 2].CanMove = true;

            ThisFloor[3, 3].Description = "You move through the fog. You feel a shiver run up your spine as you hear a dull roar in the distance";
            ThisFloor[3, 3].CanMove = true;

            ThisFloor[3, 4].Description = "The walkway comes out onto a large plateu, you can see a light further in the distance and you know in your heart you must get to it. Your gut also tells you that you're not alone here...";
            ThisFloor[3, 4].CanMove = true;

            ThisFloor[3, 5].Description = "The smoke around you clings to your clothes as you move through it. This isn't natural.";
            ThisFloor[3, 5].CanMove = true;

            ThisFloor[3, 6].Description = "You feel cold as you move through the smoke. There must be some kind of way out of here...";
            ThisFloor[3, 6].CanMove = true;

            ThisFloor[3, 7].Description = "The light glows dimly in the distance. You should keep moving towards it";
            ThisFloor[3, 7].CanMove = true;

            ThisFloor[4, 1].Description = "You feel as though you are being watched. You look around expecting to find somebody. But there is nobody";
            ThisFloor[4, 1].CanMove = true;

            ThisFloor[4, 2].Description = "As you move closer the floor crumbles away. Long way down... Better not chance it";
            ThisFloor[4, 2].CanMove = false;

            ThisFloor[4, 3].Description = "You move through the fog. You feel a shiver run up your spine as you hear a dull roar in the distance";
            ThisFloor[4, 3].CanMove = true;

            ThisFloor[4, 4].Description = "The smoke around you clings to your clothes as you move through it. This isn't natural.";
            ThisFloor[4, 4].CanMove = true;

            ThisFloor[4, 5].Description = "As you move you hear whimpering sounds. You catch something move out the corner of your eye, but there is nothing there when you look";
            ThisFloor[4, 5].CanMove = true;

            ThisFloor[4, 6].Description = "As you move closer the floor crumbles away. Long way down... Better not chance it";
            ThisFloor[4, 6].CanMove = false;

            ThisFloor[4, 7].Description = "You feel as though you are being watched. You look around expecting to find somebody. But there is nobody";
            ThisFloor[4, 7].CanMove = true;

            ThisFloor[5, 1].Description = "The light glows dimly in the distance. You should keep moving towards it";
            ThisFloor[5, 1].CanMove = true;

            ThisFloor[5, 2].Description = "Your hair stands on end. You feel as though you should tread very carefully. You cautiously move on";
            ThisFloor[5, 2].CanMove = true;

            ThisFloor[5, 3].Description = "The light glows dimly in the distance. You should keep moving towards it";
            ThisFloor[5, 3].CanMove = true;

            ThisFloor[5, 4].Description = "As you move closer the floor crumbles away. Long way down... Better not chance it";
            ThisFloor[5, 4].CanMove = false;

            ThisFloor[5, 5].Description = "More smoke and shadows. You begin to wonder if this place is even real";
            ThisFloor[5, 5].CanMove = true;

            ThisFloor[5, 6].Description = "The light glows dimly in the distance. You should keep moving towards it";
            ThisFloor[5, 6].CanMove = true;

            ThisFloor[5, 7].Description = "You stand on the edge of a very large chasm. You see the face of a woman out in the fog, her gaze peirces your soul, before vanishing back into the mist";
            ThisFloor[5, 7].CanMove = true;

            ThisFloor[6, 1].Description = "You cannot help but feel as though you are in mortal danger";
            ThisFloor[6, 1].CanMove = true;

            ThisFloor[6, 1].Description = "You cannot help but feel as though you are in mortal danger";
            ThisFloor[6, 1].CanMove = true;

            ThisFloor[6, 2].Description = "Your fears are confirmed. The smoke clears as a collosol beast emerges. It roars deafening you. Its razor sharp teeth displaying parts of corpse and bodies. This creature has been eating people. You cannot try to fight this beast. Your mind screams run as your heart pounds in your chest";
            ThisFloor[6, 2].CanMove = true;

            ThisFloor[6, 2].Enemy = new List<EnemyProfile>();
            Enemy = new EnemyProfile();
            Enemy.name = "Monster";
            Enemy.HPBonus = 2500;
            Enemy.armor = 75;
            Enemy.Money = 0;
            Enemy.KillMessage = "The beast picks you up, you struggle to break free but it is too late. It pulls you close opening its jaws. It swallows you whole, its teeth crushing down on your leg as it begins to chew you. Blood fills your mouth as you struggle to stay conscious. After one last breath you accept your fate.";
            Enemy.DeathMessage = "The beast roars a mighty roar before surcoming to its wounds. It collapses into the floor, but before you can even examine this mighty creature, it errupts in a volley of flame. When the flames die down there is nothing to be seen.";

            Enemy.Weapon.Name = "Claws";
            Enemy.Weapon.AttackMod = 50;
            Enemy.Weapon.CanPickUp = false;
            Enemy.Weapon.DefenseMod = 5;
            Enemy.Weapon.InteractionName = new List<string>();
            Enemy.Weapon.InteractionName.Add("Claws");
            Enemy.Weapon.InteractionName.Add("Beast");
            Enemy.Weapon.InteractionName.Add("Monster");

            ThisFloor[6, 2].Enemy.Add(Enemy);

            ThisFloor[6, 3].Description = "You cannot help but feel as though you are in mortal danger";
            ThisFloor[6, 3].CanMove = true;

            ThisFloor[6, 4].Description = "You look across a chasm in the middle of this strange plateu. You spot a man on the other side of the chasm. He waves at you frantically, opens his mouth to say something, but white hands grab him and pull him into the mist before he can say a word.";
            ThisFloor[6, 4].CanMove = true;

            ThisFloor[6, 5].Description = "The light grows brighter, you begin to feel warmth on your face";
            ThisFloor[6, 5].CanMove = true;

            ThisFloor[6, 6].Description = "You come to a cliff edge. The light seems close but you must still circumnavigate this cliff";
            ThisFloor[6, 6].CanMove = true;

            ThisFloor[7, 1].Description = "You find yourself on a peninsula, surrounded by harsh falls on all sides you realise you have backed yourself into a dead end.";
            ThisFloor[7, 1].CanMove = true;

            ThisFloor[7, 3].Description = "You stand on the edge of a large cliff face. The roaring sound is getting louder. You feel the need to get as far away from here as possible";
            ThisFloor[7, 3].CanMove = true;

            ThisFloor[7, 4].Description = "The light grows brighter as you move. The air around you becomes less thick, and your face begins to feel warm";
            ThisFloor[7, 4].CanMove = true;

            ThisFloor[7, 5].Description = "The light is so close, your body begins to feel lighter";
            ThisFloor[7, 5].CanMove = true;

            ThisFloor[6, 7].Description = "You stand on the edge of the plateu. The light blazes just a few feet in front of you. You feel completely at peace.";
            ThisFloor[6, 7].CanMove = true;

            ThisFloor[7, 7].Description = "As you move into the light, you feel your body become weightless. You are blinded by its power and you close your eyes. Feeling the world of grey and smoke peel away...";
            ThisFloor[7, 7].CanMove = true;
            
            ThisFloor[7, 7].EventAction = "moveinto";
            ThisFloor[7, 7].TriggerAction = "cf";
            ThisFloor[7, 7].TriggerEvent = false;
            ThisFloor[7, 7].EventCoods = new int[3] { 1, 1, 1 };

            //Block cells
            ThisFloor[0, 4].Description = "Even though nothing seems right in this place, walking off the platform won't do you much good. ";
            ThisFloor[0, 4].CanMove = false;

            for (int index = 2; index <= 8; index++)
            {
                ThisFloor[index, 0].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
                ThisFloor[index, 0].CanMove = false;
                ThisFloor[index, 8].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
                ThisFloor[index, 8].CanMove = false;
            }
            for (int index = 0; index <= 8; index++)
            {
                ThisFloor[8, index].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
                ThisFloor[8, index].CanMove = false;
            }

            ThisFloor[2, 1].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[2, 1].CanMove = false;
            ThisFloor[2, 2].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[2, 2].CanMove = false;
            ThisFloor[2, 3].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[2, 3].CanMove = false;
            ThisFloor[2, 5].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[2, 5].CanMove = false;
            ThisFloor[2, 6].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[2, 6].CanMove = false;
            ThisFloor[2, 7].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[2, 7].CanMove = false;

            ThisFloor[1, 3].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[1, 3].CanMove = false;
            ThisFloor[1, 5].Description = "The cliff face looks far to difficult to climb, and You are fairly sure there isn't anything down there...";
            ThisFloor[1, 5].CanMove = false;

            ThisFloor[7, 6].Description = "Big drop. You don't know where you are but a fall that big can't be good.";
            ThisFloor[7, 6].CanMove = false;
            
            return (ThisFloor);
        }

        public roomInfo[,] Floor1()
        {
            roomInfo[,] ThisFloor = new roomInfo[10, 10];
            EnemyProfile Enemy = new EnemyProfile();
            itemInfo item = new itemInfo();
            itemInfo tree = new itemInfo();
            itemInfo floor = new itemInfo();

            //Floor 1 - Starter Forest

            // set up generic object
            tree.Name = "Tree";
            tree.CanPickUp = false;
            tree.Examine = "It is a tall oak tree, no way you can fit this in your inventory";
            tree.InteractionName = new List<string>();
            tree.InteractionName.Add("Tree");
            tree.InteractionName.Add("trees");

            floor.Name = "Floor";
            floor.CanPickUp = false;
            floor.Examine = "It is the floor, you're standing on it...";
            floor.InteractionName = new List<string>();
            floor.InteractionName.Add("floor");
            floor.InteractionName.Add("the floor");

            ThisFloor[0, 1].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[0, 1].CanMove = false;

            ThisFloor[1, 0].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[1, 0].CanMove = false;

            ThisFloor[1, 1].Description = "You find yourself in a forest clearing, surrounded by trees. A path is marked to the east. It looks well travelled";
            ThisFloor[1, 1].CanMove = true;
            ThisFloor[1, 1].items = new List<itemInfo>();
            ThisFloor[1, 1].items.Add(tree);
            ThisFloor[1, 1].items.Add(floor);
            ThisFloor[1, 1].SuicideAction = "Unable to cope with the horror of waking up in a forest with no memory of who you are or what you have done you run head first into the nearest tree. As you hit the tree you render yourself unconcious. While you are unconcious a bandit comes across you, he steals all the gold coins in your posession and defocates on you before finally beheading you with his axe.";

            ThisFloor[1, 2].Description = "You move along the path, more trees, the path curves right to the south. You see some peaches that have fallen from a nearby fruit tree";
            ThisFloor[1, 2].CanMove = true;
            ThisFloor[1, 2].items = new List<itemInfo>();

            item = new itemInfo();
            item.InteractionName = new List<string>(); // ThisItemInteractionName;
            item.InteractionName.Add("fruit");
            item.InteractionName.Add("peach");
            item.InteractionName.Add("peaches");
            item.InteractionName.Add("item on the floor");
            item.InteractionName.Add("the fruit on the floor");
            item.Examine = "Fairly tasty looking peach";
            item.Name = "Fresh Peach";
            item.AttackMod = 0;
            item.DefenseMod = 0;
            item.HPmod = 6;
            item.Class = "Food";
            item.CanPickUp = true;
            ThisFloor[1, 2].items.Add(item);
            ThisFloor[1, 2].items.Add(item);
            ThisFloor[1, 2].items.Add(tree);
            ThisFloor[1, 2].items.Add(floor);

            ThisFloor[1, 2].AltDescription = "You move along the path, more trees, the path curves right to the south. You see a fruit tree bearing peaches, but they don't look ripe yet";
            ThisFloor[1, 2].EventAction = "itempickup";
            ThisFloor[1, 2].TriggerEvent = false;
            ThisFloor[1, 2].TriggerAction = "cd";   //on item pickup change description of room

            ThisFloor[0, 2].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[0, 2].CanMove = false;

            ThisFloor[1, 3].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[1, 3].CanMove = false;

            ThisFloor[2, 1].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[2, 1].CanMove = false;

            ThisFloor[2, 3].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[2, 3].CanMove = false;

            ThisFloor[2, 2].Description = "You move into another clearing, you spot an item on the floor.";
            ThisFloor[2, 2].CanMove = true;

            ThisFloor[2, 2].items = new List<itemInfo>();
            List<string> ThisItemInteractionName = new List<string>();

            item = new itemInfo();
            item.InteractionName = new List<string>(); // ThisItemInteractionName;
            item.InteractionName.Add("item");
            item.InteractionName.Add("sword");
            item.InteractionName.Add("the item");
            item.InteractionName.Add("item on the floor");
            item.InteractionName.Add("the item on the floor");
            item.Examine = "It is a sword, there appears to be a shirt underneath it too";
            item.Name = "Rusty Sword";
            item.AttackMod = 2;
            item.DefenseMod = 1;
            item.Class = "Weapon";
            item.CanPickUp = true;
            ThisFloor[2, 2].items.Add(item);

            item = new itemInfo();
            item.InteractionName = new List<string>(); 
            item.InteractionName.Add("shirt");
            item.InteractionName.Add("tunic");
            item.InteractionName.Add("Rough Leather Tunic");
            item.Examine = "It is a shirt, it looks like it is made of rough leather ";
            item.Name = "Rough Leather Tunic";
            item.AttackMod = 0;
            item.DefenseMod = 5;
            item.CanPickUp = true;
            item.Class = "Armor-Chest";
            ThisFloor[2, 2].items.Add(item);

            //Add environment items
            ThisFloor[2, 2].items.Add(tree);
            ThisFloor[2, 2].items.Add(floor);

            ThisFloor[2, 2].AltDescription = "You move into the clearing where you found the sword and tunic";
            ThisFloor[2, 2].EventAction = "itempickup";
            ThisFloor[2, 2].TriggerEvent = false;
            ThisFloor[2, 2].TriggerAction = "cd";   //on item pickup change description of room

            ThisFloor[3, 1].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[3, 1].CanMove = false;

            ThisFloor[3, 2].Description = "The path comes out of the trees to a very swift river, it looks too dangerous to cross, however the path follows the river to the east";
            ThisFloor[3, 2].CanMove = true;

            ThisFloor[4, 2].Description = "The river is too strong to cross";
            ThisFloor[4, 2].CanMove = false;

            ThisFloor[2, 3].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[2, 3].CanMove = false;

            ThisFloor[3, 3].Description = "The path continues to wind along the river, the current looks strong";
            ThisFloor[3, 3].CanMove = true;

            ThisFloor[4, 3].Description = "The river is too strong to cross";
            ThisFloor[4, 3].CanMove = false;
            
            ThisFloor[2, 4].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[2, 4].CanMove = false;

            ThisFloor[3, 4].Description = "The path still winds on, you spot a bridge far in the distance";
            ThisFloor[3, 4].CanMove = true;

            ThisFloor[4, 4].Description = "The river is too strong to cross";
            ThisFloor[4, 4].CanMove = false;

            ThisFloor[2, 5].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[2, 5].CanMove = false;

            ThisFloor[3, 5].Description = "The bridge gets closer as you walk along the path";
            ThisFloor[3, 5].CanMove = true;

            ThisFloor[4, 5].Description = "The river is not the best place for you to be";
            ThisFloor[4, 5].CanMove = false;

            ThisFloor[2, 6].Description = "Trees are blocking your way, you cannot go this way";
            ThisFloor[2, 6].CanMove = false;

            ThisFloor[3, 6].Description = "You stand on one side of a large stone bridge that spans the mighty river";
            ThisFloor[3, 6].CanMove = true;

            ThisFloor[4, 6].Description = "As you move onto the bridge you spot the figure of a man. He approaches you \"There is a toll for this bridge, hand over 10 gold coins to cross\" The man is clearly a bandit. You can either pay him or fight";
            ThisFloor[4, 6].AltDescription = "The river crashes into the struts of the bridge, but the stone is strong. You stop to admire the view for a while";
            ThisFloor[4, 6].CanMove = true;
            ThisFloor[4, 6].SuicideAction = "Rather than deal with the conflict, you throw yourself off the bridge."; 

            ThisFloor[4, 6].Enemy = new List<EnemyProfile>();
            Enemy = new EnemyProfile();
            Enemy.name = "Bandit";
            Enemy.HPBonus = 20;
            Enemy.armor = 1;
            Enemy.Money = 50;
            Enemy.KillMessage = "The enemy bandit swings his axe, you feel the blade smash into your skull and your world goes black.";
            Enemy.DeathMessage = "Upon delivering the final blow the bandit staggers backwards, blood gushing from his face. He looks at you confused, before falling to the floor dead.";

            Enemy.PayOff = 10;
            Enemy.PayOffResponse = "Glad we were able to settle this like men";

            Enemy.Weapon.Name = "Bandit Axe";
            Enemy.Weapon.AttackMod = 2;  
            Enemy.Weapon.CanPickUp = true;
            Enemy.Weapon.DefenseMod = 1;
            Enemy.Weapon.Class = "Weapon";
            Enemy.Weapon.Examine = "motherfucking axe";
            Enemy.Weapon.InteractionName = new List<string>();
            Enemy.Weapon.InteractionName.Add("Axe");
            Enemy.Weapon.InteractionName.Add("bandit's axe");
            Enemy.Weapon.InteractionName.Add("enemy weapon");
            Enemy.Weapon.InteractionName.Add("weapon");
            Enemy.Weapon.InteractionName.Add("bandit axe");

            ThisFloor[4, 6].Enemy.Add(Enemy);

            ThisFloor[4, 6].TriggerEvent = false;
            ThisFloor[4, 6].EventAction = "killenemies payoff";
            ThisFloor[4, 6].TriggerAction = "u cd";     //on enemy death unlock room and change description
            ThisFloor[4, 6].EventCoods = new int[3] { 5, 6, 1 };

            ThisFloor[4, 7].Description = "Jumping off the bridge may not be a great idea";
            ThisFloor[4, 7].CanMove = false;

            ThisFloor[4, 8].Description = "The river rushes by at the north side of the garden";
            ThisFloor[4, 8].CanMove = false;

            ThisFloor[3, 7].Description = "Seems silly to go back into the forest when there is a perfectly good bridge right here";
            ThisFloor[3, 7].CanMove = false;

            ThisFloor[5, 6].Description = "The bandit blocks your path";
            ThisFloor[5, 6].AltDescription = "Standing on the south side of the river you spot smoke rising in the distance. It could be a town, however there is still a thick of tress between you and there";
            ThisFloor[5, 6].CanMove = false;

            ThisFloor[5, 7].Description = "Moving along the river you spot a garden up ahead";
            ThisFloor[5, 7].CanMove = true;

            ThisFloor[5, 8].Description = "A garden on the shore of the river, there are lots of fruit bearing trees, a few apples have fallen on the floor. I'm sure nobody will notice they're gone";
            ThisFloor[5, 8].CanMove = true;
            ThisFloor[5, 8].AltDescription = "A garden on the shore of the river, there are lots of fruit bearing trees however none of the fruit looks ripe enough to take";

            ThisFloor[5, 8].items = new List<itemInfo>();
            item = new itemInfo();
            item.Name = "Apple";
            item.Class = "Food";
            item.Examine = "looks like a fresh tasty apple";
            item.HPmod = 5;
            item.Value = 1;
            item.InteractionName = new List<string>();
            item.InteractionName.Add("Apple");
            item.InteractionName.Add("fruit");
            item.CanPickUp = true;
            ThisFloor[5, 8].items.Add(item);
            ThisFloor[5, 8].items.Add(item);
            ThisFloor[5, 8].items.Add(item);
            ThisFloor[5, 8].items.Add(item);

            ThisFloor[5, 8].EventAction = "itempickup";
            ThisFloor[5, 8].TriggerEvent = false;
            ThisFloor[5, 8].TriggerAction = "cd";   //on item pickup change description of room

            ThisFloor[5, 9].Description = "A fence borders the garden, You cannot go this way";
            ThisFloor[5, 9].CanMove = false;

            ThisFloor[6, 8].Description = "A fence borders the garden, You cannot go this way";
            ThisFloor[6, 8].CanMove = false;

            ThisFloor[6, 7].Description = "You cannot go here";
            ThisFloor[6, 7].CanMove = false;
            ThisFloor[6, 6].Description = "You cannot go here";
            ThisFloor[6, 6].CanMove = false;

            ThisFloor[5, 5].Description = "Moving along the south bank of the river you spot an odd looking rock.";
            ThisFloor[5, 5].CanMove = true;
            ThisFloor[5, 5].items = new List<itemInfo>();
            item = new itemInfo();
            item.Name = "Rock";
            item.Class = "Object";
            item.Examine = "The rock is partially submerged in water, the top is coated in a fine layer of blood. Seeing it reminds you of the previous night, and jumping into the river, however you do not remember why";
            item.HPmod = 0;
            item.Value = 0;
            item.InteractionName = new List<string>();
            item.InteractionName.Add("rock");
            item.InteractionName.Add("blood");
            item.InteractionName.Add("odd rock");
            item.InteractionName.Add("bloody rock");
            item.InteractionName.Add("odd looking rock");
            item.CanPickUp = false;
            ThisFloor[5, 5].items.Add(item);

            ThisFloor[5, 4].Description = "The path curves away from the riverbank and towards the south.";
            ThisFloor[5, 4].CanMove = true;

            ThisFloor[5, 3].Description = "The ground on the riverbank is thick and muddy. Theres a good chance if you go this way you'll end up stuck. Better not.";
            ThisFloor[5, 3].CanMove = false;

            ThisFloor[6, 3].Description = "A large assortment of brambles and thorns blocks the way";
            ThisFloor[6, 3].CanMove = false;

            ThisFloor[6, 4].Description = "The sound of the river is distant through the sparsely seperated trees";
            ThisFloor[6, 4].CanMove = true;

            ThisFloor[6, 5].Description = "The thick tree line prevents you from venturing further";
            ThisFloor[6, 5].CanMove = false;

            ThisFloor[7, 3].Description = "The path drops suddenly into a gulley. Looks a bit too dangerous to cross";
            ThisFloor[7, 3].CanMove = false;
            
            ThisFloor[7, 4].Description = "The trees are thicker and the sound of the river is barely audible through the thick foliage";
            ThisFloor[7, 4].CanMove = true;

            ThisFloor[7, 5].Description = "The forest canopy provides thick cover. It is too dark to see whats out there...";
            ThisFloor[7, 5].CanMove = false;

            ThisFloor[8, 4].Description = "You arrive at a fork in the road. To the north is the river you crossed. To the west lies more forest but a travelled path can be made out, to the east you see a chimney top billowing smoke, signalling civilisation.";
            ThisFloor[8, 4].CanMove = true;

            ThisFloor[9, 4].Description = "The forest canopy provides thick cover. It is too dark to see whats out there...";
            ThisFloor[9, 4].CanMove = false;

            ThisFloor[8, 5].Description = "The path seems well travelled and it looks as though you are heading in the right direction";
            ThisFloor[8, 5].CanMove = true;

            ThisFloor[9, 6].Description = "You can't go this way";
            ThisFloor[9, 6].CanMove = false;

            ThisFloor[8, 6].Description = "As you enter a clearing you spot a pair of boots stuck in some mud. Your memory flashes back to taking them off in a hurry and running whilst trying to escape from something";
            ThisFloor[8, 6].CanMove = true;
            ThisFloor[8, 6].items = new List<itemInfo>();

            item = new itemInfo();
            item.InteractionName = new List<string>();
            item.InteractionName.Add("boots");
            item.InteractionName.Add("shoes");
            item.InteractionName.Add("Rough Leather Boots");
            item.Examine = "A pair of boots, they look muddy but they are made of rough leather and look intact";
            item.Name = "Rough Leather Boots";
            item.AttackMod = 0;
            item.DefenseMod = 2;
            item.CanPickUp = true;
            item.Class = "Armor-Boots";
            ThisFloor[8, 6].items.Add(item);

            ThisFloor[8, 6].AltDescription = "You move into the clearing where you found your boots.";
            ThisFloor[8, 6].EventAction = "itempickup";
            ThisFloor[8, 6].TriggerEvent = false;
            ThisFloor[8, 6].TriggerAction = "cd";

            ThisFloor[7, 6].Description = "You can't go that way";
            ThisFloor[7, 6].CanMove = false;

            ThisFloor[8, 7].Description = "This game is incomplete, I am afriad. Although my programming skills are okay my creativity is rather poor. If you would like to help out with writing a story for this game or any further suggestions please do feel free to contact me at joevandebilt@live.co.uk\n\nThanks, Joe";
            ThisFloor[8, 7].CanMove = false;

            ThisFloor[8, 3].Description = "You can't go that way";
            ThisFloor[8, 3].CanMove = false;
            
            return (ThisFloor);
        }

   
    }   //end of class

}   //end of namespace
