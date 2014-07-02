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
    public partial class frmEventEditor : Form
    {
        public DataTypes.Event Event;
        public bool ChangeMade;

        public struct Description
        {
            public string ShortDesc;
            public string LongDesc;
        }

        List<Description> Triggers = new List<Description>();
        List<Description> Actions = new List<Description>();

        public frmEventEditor(DataTypes.Event thisEvent, int FloorCount)
        {
            InitializeComponent();
            ChangeMade = false;
            
            Description desc = new Description();

            //Trigers
            desc.ShortDesc = "killallenemies";
            desc.LongDesc = "Player kills all enemies in the room";
            Triggers.Add(desc);
            desc.ShortDesc = "moveinto";
            desc.LongDesc = "Player moves into the current room";
            Triggers.Add(desc);
            desc.ShortDesc = "itempickup";
            desc.LongDesc = "Player picks up an item";
            Triggers.Add(desc);
            desc.ShortDesc = "allitempickup";
            desc.LongDesc = "Player picked up all items in the room";
            Triggers.Add(desc);
            desc.ShortDesc = "payoff";
            desc.LongDesc = "Player pays off an enemy";
            Triggers.Add(desc);
            desc.ShortDesc = "iteminteraction";
            desc.LongDesc = "Player uses an interaction item correctly";
            Triggers.Add(desc);
            desc.ShortDesc = "killenemy";
            desc.LongDesc = "Players kills 1 enemy in a room";
            Triggers.Add(desc);

            //Actions
            desc.ShortDesc = "unlock";
            desc.LongDesc = "Unlock a locked cell at ";
            Actions.Add(desc);
            desc.ShortDesc = "lock";
            desc.LongDesc = "Lock a cell at ";
            Actions.Add(desc);
            desc.ShortDesc = "LockIn";
            desc.LongDesc = "Lock/Unlock current room";
            Actions.Add(desc);
            desc.ShortDesc = "kill all enemies";
            desc.LongDesc = "Kill all enemies in the room";
            Actions.Add(desc);
            desc.ShortDesc = "change description";
            desc.LongDesc = "Change the room description to its alternative";
            Actions.Add(desc);
            desc.ShortDesc = "change location";
            desc.LongDesc = "Move player to these coodinates ";
            Actions.Add(desc);
            desc.ShortDesc = "change objective";
            desc.LongDesc = "Change the players objective to";
            Actions.Add(desc);
            desc.ShortDesc = "custom description";
            desc.LongDesc = "Set a custom description of a room";
            Actions.Add(desc);
            desc.ShortDesc = "output text";
            desc.LongDesc = "Output this message";
            Actions.Add(desc);
            desc.ShortDesc = "spawnItems";
            desc.LongDesc = "Spawn the following Items";
            Actions.Add(desc);
            desc.ShortDesc = "spawnNPC";
            desc.LongDesc = "Spawn the following NPCs";
            Actions.Add(desc);
            desc.ShortDesc = "spawnEnemy";
            desc.LongDesc = "Spawn the following enemies";
            Actions.Add(desc);
            desc.ShortDesc = "giveXP";
            desc.LongDesc = "Award the player XP";
            Actions.Add(desc);
            desc.ShortDesc = "EndCredits";
            desc.LongDesc = "Run the End Credits and end the Game";
            Actions.Add(desc);
            desc.ShortDesc = string.Empty;
            desc.LongDesc = "Unknown";
            Actions.Add(desc);
            

            foreach (Description thisDesc in Triggers)
            {
                cmbTrigger.Items.Add(thisDesc.LongDesc);
            }
            cmbTrigger.Items.Add("Unknown");

            foreach (Description thisDesc in Actions)
            {
                cmbAction.Items.Add(thisDesc.LongDesc);
            }

            Event = thisEvent;
            Event.Triggered = false;
            PopulateEvent(FloorCount);
        }

        private void PopulateEvent(int Count)
        {
            if (Event.Trigger == null) cmbTrigger.SelectedIndex = cmbTrigger.FindString("Unknown");
            else
            {
                for (int i = 0; i < Triggers.Count; i++)
                {
                    if (Triggers[i].ShortDesc == Event.Trigger) cmbTrigger.SelectedIndex = i;
                }
            }

            if (Event.Action == null) cmbAction.SelectedIndex = cmbAction.FindString("Unknown");
            else
            {
                for (int i = 0; i < Actions.Count; i++)
                {
                    if (Actions[i].ShortDesc == Event.Action) cmbAction.SelectedIndex = i;
                }
            }
            SetEnabledElements();

            cmbFloor.Items.Clear();
            for (int i = 0; i < Count; i++)
            {
                cmbFloor.Items.Add("Level " + (i + 1));
            }
            cmbFloor.SelectedIndex = 0;

            if (Event.Coodinates != null)
            {                
                cmbRow.SelectedIndex = Event.Coodinates[0];
                cmbCol.SelectedIndex = Event.Coodinates[1];
                cmbFloor.SelectedIndex = Event.Coodinates[2];
            }

            if (Event.EventValue != null) txtNewValue.Text = Event.EventValue;
            if (Event.ReUsable == true) chkReUse.Checked = true;
            else chkReUse.Checked = false;

            GetAllNPCs();
            GetAllItems();
            GetAllEnemies();
        }

        private bool SaveEvent()
        {
            Event.Trigger = Triggers[cmbTrigger.FindString(cmbTrigger.Text)].ShortDesc;
            Event.Action = Actions[cmbAction.FindString(cmbAction.Text)].ShortDesc;

            if (cmbRow.Enabled = true && cmbCol.Enabled == true && cmbFloor.Enabled == true)
            {
                if (Event.Coodinates == null) Event.Coodinates = new int[3];

                Event.Coodinates[0] = cmbRow.SelectedIndex;
                Event.Coodinates[1] = cmbCol.SelectedIndex;
                Event.Coodinates[2] = cmbFloor.SelectedIndex;
            }

            if (txtNewValue.Text != string.Empty) Event.EventValue = txtNewValue.Text;
            else if (txtNewValue.Enabled == true) return false;

            if (chkReUse.Checked == true) Event.ReUsable = true;
            else Event.ReUsable = false;

            //Items, NPCs and Enemies should save to the event in their own procedures

            return true;
        }

        private void cmbAction_TextChanged(object sender, EventArgs e)
        {
            SetEnabledElements();
        }

        private void cmdSaveEvent_Click(object sender, EventArgs e)
        {
            if (SaveEvent())
            {
                ChangeMade = true;
                this.Hide();
            }
            else MessageBox.Show("There is an error on the form");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
        }

        private void SetEnabledElements()
        {
            cmbRow.Enabled = false;
            cmbCol.Enabled = false;
            cmbFloor.Enabled = false;
            txtNewValue.Enabled = false;

            lstItems.Enabled = false;
            cmdAddItem.Enabled = false;
            cmdCloneItem.Enabled = false;
            cmdRemoveItem.Enabled = false;

            lstNPCs.Enabled = false;
            cmdAddNPC.Enabled = false;
            cmdCloneNPC.Enabled = false;
            cmdRemoveNPC.Enabled = false;

            lstEnemies.Enabled = false;
            cmdAddEnemy.Enabled = false;
            cmdCloneEnemy.Enabled = false;
            cmdRemoveEnemy.Enabled = false;

            //Check if coodinate box should be enabled
            if (Actions[cmbAction.SelectedIndex].ShortDesc == "unlock" || Actions[cmbAction.SelectedIndex].ShortDesc == "lock" || Actions[cmbAction.SelectedIndex].ShortDesc == "change description" || Actions[cmbAction.SelectedIndex].ShortDesc == "change location")
            {
                cmbRow.Enabled = true;
                cmbCol.Enabled = true;
                cmbFloor.Enabled = true;
            }
            else if (Actions[cmbAction.SelectedIndex].ShortDesc == "output text" || Actions[cmbAction.SelectedIndex].ShortDesc == "change objective" || Actions[cmbAction.SelectedIndex].ShortDesc == "giveXP")
            {
                txtNewValue.Enabled = true;
            }
            else if (Actions[cmbAction.SelectedIndex].ShortDesc == "custom description")
            {
                cmbRow.Enabled = true;
                cmbCol.Enabled = true;
                cmbFloor.Enabled = true;
                txtNewValue.Enabled = true;
            }
            else if (Actions[cmbAction.SelectedIndex].ShortDesc == "spawnItems")
            {
                lstItems.Enabled = true;
                cmdAddItem.Enabled = true;
                cmdCloneItem.Enabled = true;
                cmdRemoveItem.Enabled = true;
            }
            else if (Actions[cmbAction.SelectedIndex].ShortDesc == "spawnNPC")
            {
                lstNPCs.Enabled = true;
                cmdAddNPC.Enabled = true;
                cmdCloneNPC.Enabled = true;
                cmdRemoveNPC.Enabled = true;

            }
            else if (Actions[cmbAction.SelectedIndex].ShortDesc == "spawnEnemy")
            {
                lstEnemies.Enabled = true;
                cmdAddEnemy.Enabled = true;
                cmdCloneEnemy.Enabled = true;
                cmdRemoveEnemy.Enabled = true;
            }
        }


        #region Items

        public void GetAllItems()
        {
            lstItems.Items.Clear();
            //Populate Items List
            if (Event.Items!= null)
            {
                foreach (DataTypes.itemInfo Item in Event.Items)
                {
                    lstItems.Items.Add(Item.Name + " - " + Item.Class);
                }
            }
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            DataTypes.itemInfo NewItem = new DataTypes.itemInfo();
            frmItemEditor NewForm = new frmItemEditor(NewItem,string.Empty);
            NewForm.ShowDialog();

            NewItem = NewForm.Item;
            if (NewItem.Name != null)
            {
                if (Event.Items == null) Event.Items = new List<DataTypes.itemInfo>();
                Event.Items.Add(NewItem);
            }
            GetAllItems();
        }

        private void cmdCloneItem_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex > -1)
            {
                DataTypes dt = new DataTypes();
                Event.Items.Add(dt.CloneItem(Event.Items[lstItems.SelectedIndex]));
                GetAllItems();
            }
            else MessageBox.Show("Select an item to clone");
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            Event.Items.RemoveAt(lstItems.SelectedIndex);
            GetAllItems();
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItems.SelectedIndex > -1)
            {
                DataTypes.itemInfo EditItem = new DataTypes.itemInfo();
                EditItem = Event.Items[lstItems.SelectedIndex];
                frmItemEditor NewForm = new frmItemEditor(EditItem,string.Empty);
                NewForm.ShowDialog();

                EditItem = NewForm.Item;
                Event.Items[lstItems.SelectedIndex] = EditItem;
                GetAllItems();
            }
        }
        #endregion
               
        #region NPC

        public void GetAllNPCs()
        {
            lstNPCs.Items.Clear();
            //Populate NPCs List
            if (Event.NPCs != null)
            {
                foreach (DataTypes.CivilianProfile NPC in Event.NPCs)
                {
                    lstNPCs.Items.Add(NPC.name);
                }
            }
        }

        private void cmdAddNPC_Click(object sender, EventArgs e)
        {
            DataTypes.CivilianProfile NewCiviy = new DataTypes.CivilianProfile();
            frmNPCEditor NewForm = new frmNPCEditor(NewCiviy);
            NewForm.ShowDialog();

            NewCiviy = NewForm.NPC;
            if (NewCiviy.name != null)
            {
                if (Event.NPCs == null) Event.NPCs = new List<DataTypes.CivilianProfile>();
                Event.NPCs.Add(NewCiviy);
            }
            GetAllNPCs();
        }

        private void cmdCloneNPC_Click(object sender, EventArgs e)
        {
            if (lstNPCs.SelectedIndex > -1)
            {
                DataTypes dt = new DataTypes();
                Event.NPCs.Add(dt.CloneNPC(Event.NPCs[lstNPCs.SelectedIndex]));
                GetAllNPCs();
            }
            else MessageBox.Show("Select an NPC to Clone");
        }

        private void cmdRemoveNPC_Click(object sender, EventArgs e)
        {
            Event.NPCs.RemoveAt(lstNPCs.SelectedIndex);
            GetAllNPCs();
        }

        private void lstNPCs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstNPCs.SelectedIndex > -1)
            {
                DataTypes.CivilianProfile EditCiviy = new DataTypes.CivilianProfile();
                EditCiviy = Event.NPCs[lstNPCs.SelectedIndex];
                frmNPCEditor NewForm = new frmNPCEditor(EditCiviy);
                NewForm.ShowDialog();

                EditCiviy = NewForm.NPC;
                Event.NPCs[lstNPCs.SelectedIndex] = EditCiviy;
                GetAllNPCs();
            }
        }

        #endregion

        #region Enemy

        public void GetAllEnemies()
        {
            lstEnemies.Items.Clear();
            //Populate Enemies List
            if (Event.Enemies != null)
            {
                foreach (DataTypes.EnemyProfile Enemy in Event.Enemies)
                {
                    lstEnemies.Items.Add(Enemy.name + " - " + Enemy.Weapon.Name);
                }
            }
        }

        private void cmdAddEnemy_Click(object sender, EventArgs e)
        {
            DataTypes.EnemyProfile NewEnemy = new DataTypes.EnemyProfile();
            frmEnemyEditor NewForm = new frmEnemyEditor(NewEnemy);
            NewForm.ShowDialog();

            NewEnemy = NewForm.Enemy;
            if (NewEnemy.name != null)
            {
                if (Event.Enemies == null) Event.Enemies = new List<DataTypes.EnemyProfile>();
                Event.Enemies.Add(NewEnemy);
            }
            GetAllEnemies();
        }

        private void cmdCloneEnemy_Click(object sender, EventArgs e)
        {
            if (lstEnemies.SelectedIndex > -1)
            {
                DataTypes dt = new DataTypes();
                Event.Enemies.Add(dt.CloneEnemy(Event.Enemies[lstEnemies.SelectedIndex]));
                GetAllEnemies();
            }
            else MessageBox.Show("Select an enemy to clone");
        }

        private void cmdRemoveEnemy_Click(object sender, EventArgs e)
        {
            Event.Enemies.RemoveAt(lstEnemies.SelectedIndex);
            GetAllEnemies();
        }

        private void lstEnemies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstEnemies.SelectedIndex > -1)
            {
                DataTypes.EnemyProfile EditEnemy = new DataTypes.EnemyProfile();
                EditEnemy = Event.Enemies[lstEnemies.SelectedIndex];
                frmEnemyEditor NewForm = new frmEnemyEditor(EditEnemy);
                NewForm.ShowDialog();

                EditEnemy = NewForm.Enemy;
                Event.Enemies[lstEnemies.SelectedIndex] = (EditEnemy);
                GetAllEnemies();
            }
        }

        #endregion

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            frmHelp NewForm = new frmHelp();
            NewForm.Show();
        }

    }
}
