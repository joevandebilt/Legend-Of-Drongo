using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legend_Of_Drongo
{
    public partial class frmPlayerEditor : Form
    {
        public DataTypes.PlayerProfile Player;
        public bool ChangesMade;

        public frmPlayerEditor(DataTypes.PlayerProfile ThisPlayer, int NumOfFloors)
        {
            InitializeComponent();
            ChangesMade = false;
            Player = ThisPlayer;
            cmbFloor.Items.Clear();
            for (int i = 0; i < NumOfFloors; i++)
            {
                cmbFloor.Items.Add("Level " + (i + 1));
            }

            PopulatePlayer();
        }

        public void PopulatePlayer()
        {
            //Text Params
            if (Player.name != null) txtDefaultName.Text = Player.name;
            if (Player.Objective != null) txtObjective.Text = Player.Objective;

            //Integer Parameters
            txtMoney.Text = Player.Money.ToString();
            txtHP.Text = Player.HPBonus.ToString();
            txtSpeed.Text = Player.Speed.ToString();
            txtMaxHP.Text = Player.MaxHp.ToString();
            txtStrength.Text = Player.Strength.ToString();
            txtResist.Text = Player.Resitence.ToString();

            if (Player.ArmorWorn != null)
            {
                if (Player.ArmorWorn[0].Name != null) txtHelm.Text = Player.ArmorWorn[0].Name;
                if (Player.ArmorWorn[1].Name != null) txtChest.Text = Player.ArmorWorn[1].Name;
                if (Player.ArmorWorn[2].Name != null) txtHands.Text = Player.ArmorWorn[2].Name;
                if (Player.ArmorWorn[3].Name != null) txtLegs.Text = Player.ArmorWorn[3].Name;
                if (Player.ArmorWorn[4].Name != null) txtFeet.Text = Player.ArmorWorn[4].Name;
            }
            if (Player.WeaponHeld.Name != null) txtWeapon.Text = Player.WeaponHeld.Name;

            if (Player.CurrentPos != null)
            {
                cmbRow.SelectedIndex = Player.CurrentPos[0];
                cmbCol.SelectedIndex = Player.CurrentPos[1];
                cmbFloor.SelectedIndex = Player.CurrentPos[2];
            }
            else { cmbRow.SelectedIndex = 1; cmbCol.SelectedIndex = 1; cmbFloor.SelectedIndex = 0; }

            lblInv.Text = "Inventory " + (20 - Player.invspace) + "/20";
            PopulateInventory();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            ChangesMade = false;
            this.Hide();
        }

        private void txtHelm_MouseDoubleClick(object sender, MouseEventArgs e) { if(Equiptment(0)) txtHelm.Text = Player.ArmorWorn[0].Name; }
        private void txtChest_MouseDoubleClick(object sender, MouseEventArgs e) { if(Equiptment(1)) txtChest.Text = Player.ArmorWorn[1].Name; }
        private void txtHands_MouseDoubleClick(object sender, MouseEventArgs e) { if(Equiptment(2)) txtHands.Text = Player.ArmorWorn[2].Name; }
        private void txtLegs_MouseDoubleClick(object sender, MouseEventArgs e) { if(Equiptment(3)) txtLegs.Text = Player.ArmorWorn[3].Name; }
        private void txtFeet_MouseDoubleClick(object sender, MouseEventArgs e) { if(Equiptment(4)) txtFeet.Text = Player.ArmorWorn[4].Name; }
        private void txtWeapon_MouseDoubleClick(object sender, MouseEventArgs e) { if(Equiptment(5)) txtWeapon.Text = Player.WeaponHeld.Name; }

        private bool Equiptment(int Position)
        {
            DataTypes.itemInfo EditItem = new DataTypes.itemInfo();
            if (Position == 5) Player.ArmorBonus = Player.ArmorBonus - Player.WeaponHeld.DefenseMod;
            else Player.ArmorBonus = Player.ArmorBonus - Player.ArmorWorn[Position].DefenseMod;
            if (Position == 5) { if (Player.WeaponHeld.Name != null) EditItem = Player.WeaponHeld; }
            else if (Player.ArmorWorn[Position].Name != null) EditItem = Player.ArmorWorn[Position];

            string ItemClass = "Unknown";
            switch(Position)
            {
                case 0: ItemClass = "Armor-Helmet"; break;
                case 1: ItemClass = "Armor-Chest"; break;
                case 2: ItemClass = "Armor-Gloves"; break;
                case 3: ItemClass = "Armor-Legs"; break;
                case 4: ItemClass = "Armor-Boots"; break;
                case 5: ItemClass = "Weapon"; break;
            }
            

            frmItemEditor NewForm = new frmItemEditor(EditItem, ItemClass);
            NewForm.ShowDialog();

            if (NewForm.ChangeMade == true)
            {
                EditItem = NewForm.Item;
                if (Position == 5) Player.WeaponHeld = EditItem ;
                else
                {
                    if (Player.ArmorWorn == null) Player.ArmorWorn = new DataTypes.itemInfo[5];
                    Player.ArmorWorn[Position] = EditItem ;
                }
                Player.ArmorBonus = Player.ArmorBonus + EditItem .DefenseMod;
                return true;
            }
            else return false;
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            if (Player.invspace > 0)
            {
                DataTypes.itemInfo NewItem = new DataTypes.itemInfo();
                frmItemEditor NewForm = new frmItemEditor(NewItem, string.Empty);
                NewForm.ShowDialog();

                if (NewForm.ChangeMade == true)
                {
                    Player.inventory.Add(NewForm.Item);
                    Player.invspace = Player.invspace - 1;
                    lblInv.Text = "Inventory " + (20 - Player.invspace) + "/20";
                }
            }
            else MessageBox.Show("The player inventory is full, you cannot add more items");
            PopulateInventory();
        }

        private void cmdCloneItem_Click(object sender, EventArgs e)
        {
            if (Player.invspace > 0)
            {
                if (lstInventory.SelectedIndex > -1)
                {
                    DataTypes dt = new DataTypes();
                    Player.inventory.Add(dt.CloneItem(Player.inventory[lstInventory.SelectedIndex]));
                    Player.invspace = Player.invspace - 1;
                    lblInv.Text = "Inventory " + (20 - Player.invspace) + "/20";
                    PopulateInventory();
                }
            }
            else MessageBox.Show("The player inventory is full, you cannot add more items");
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            if (lstInventory.SelectedIndex > -1)
            {
                Player.inventory.RemoveAt(lstInventory.SelectedIndex);
                Player.invspace = Player.invspace + 1;
                lblInv.Text = "Inventory " + (20 - Player.invspace) + "/20";

                PopulateInventory();
            }
        }

        private bool SavePlayer()
        {
            //Name
            if (txtDefaultName.Text != string.Empty) Player.name = txtDefaultName.Text;
            else return false;

            //Objective
            if (txtObjective.Text != string.Empty) Player.Objective = txtObjective.Text;
            else return false;

            int i;
            double d;
            
            //Money & Stats
            if (int.TryParse(txtMoney.Text, out i)) Player.Money = i;
            else return false;
            if (double.TryParse(txtMaxHP.Text, out d)) Player.MaxHp = d;
            else return false;
            if (int.TryParse(txtHP.Text, out i)) Player.HPBonus = i;
            else return false;
            if (int.TryParse(txtSpeed.Text, out i)) Player.Speed = i;
            else return false;
            if (double.TryParse(txtStrength.Text, out d)) Player.Strength = d;
            else return false;
            if (int.TryParse(txtResist.Text, out i)) Player.Resitence = i;
            else return false;

            if (Player.CurrentPos == null) Player.CurrentPos = new int[3];
            Player.CurrentPos[0] = cmbRow.SelectedIndex;
            Player.CurrentPos[1] = cmbCol.SelectedIndex;
            Player.CurrentPos[2] = cmbFloor.SelectedIndex;
            
            //Inventory, Weapon and armor are saved in another function

            return true;
        }

        private void PopulateInventory()
        {
            if (Player.inventory != null)
            {
                lstInventory.Items.Clear();
                for (int i = 0; i < (20 - Player.invspace); i++)
                {
                    lstInventory.Items.Add(Player.inventory[i].Name);
                }
            }
        }

        private void cmdSaveChanges_Click(object sender, EventArgs e)
        {
            if (!SavePlayer()) MessageBox.Show("There is an error with the player, please double check all fields");
            else
            {
                ChangesMade = true;
                this.Hide();
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            Player.name = "Drongo";
            Player.HPBonus = 100;
            Player.ArmorBonus = 0;

            //Set up starter inventory
            Player.inventory = new List<DataTypes.itemInfo>();
            Player.invspace = 20;

            //Set up game parameters
            Player.CurrentPos = new int[3] { 1, 1, 0 }; //Row, Column, Floor
            Player.Objective = "";
            Player.Money = 100;
            Player.DaysSinceSleep = 0;

            //Set up starter weapon
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
            Player.ArmorWorn = new DataTypes.itemInfo[5];

            //Set Up Stats
            Player.Level = 1;
            Player.MaxHp = 100;
            Player.Speed = 1;
            Player.Resitence = 0;
            Player.Strength = 0;

            PopulatePlayer();
        }

        private void lstInventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstInventory.SelectedIndex > -1)
            {
                DataTypes.itemInfo EditItem = new DataTypes.itemInfo();
                EditItem = Player.inventory[lstInventory.SelectedIndex];
                frmItemEditor NewForm = new frmItemEditor(EditItem, string.Empty);
                NewForm.ShowDialog();

                EditItem = NewForm.Item;
                Player.inventory[lstInventory.SelectedIndex] = EditItem;
                PopulateInventory();
            }
        }
    }
}
