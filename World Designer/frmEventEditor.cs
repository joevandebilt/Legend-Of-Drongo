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

        string[,] Triggers = new string[7,2];
        string[,] Actions = new string[10,2];

        public frmEventEditor(DataTypes.Event thisEvent, int FloorCount)
        {
            InitializeComponent();
            ChangeMade = false;

            //Trigers
            Triggers[0,0] = "killallenemies";
            Triggers[0,1] = "Player kills all enemies in the room";
            Triggers[1,0] = "moveinto";
            Triggers[1,1] = "Player moves into the current room";
            Triggers[2,0] = "itempickup";
            Triggers[2,1] = "Player picks up an item";
            Triggers[3,0] = "allitempickup";
            Triggers[3,1] = "Player picked up all items in the room";
            Triggers[4,0] = "payoff";
            Triggers[4,1] = "Player pays off an enemy";
            Triggers[5,0] = "iteminteraction";
            Triggers[5,1] = "Player uses an interaction item correctly";
            Triggers[6,0] = "killenemy";
            Triggers[6,1] = "Players kills 1 enemy in a room";

            //Actions
            Actions[0,0] = "unlock";
            Actions[0,1] = "unlock a locked cell at ";
            Actions[1,0] = "lock";
            Actions[1,1] = "lock a cell at ";
            Actions[2,0] = "kill all enemies";
            Actions[2,1] = "kill all enemies in the room";
            Actions[3,0] = "change description";
            Actions[3,1] = "change the room description to its alternative";
            Actions[4,0] = "change location";
            Actions[4,1] = "move player to these coodinates ";
            Actions[5,0] = "change objective";
            Actions[5,1] = "Change the players objective to";
            Actions[6,0] = "output text";
            Actions[6,1] = "Output this message";
            Actions[7,0] = "spawnItems";
            Actions[7,1] = "Spawn the following Items";
            Actions[8,0] = "spawnNPC";
            Actions[8,1] = "Spawn the following NPCs";
            Actions[9,0] = "spawnEnemy";
            Actions[9,1] = "Spawn the following enemies";
            

            for (int i = 0; i < (Triggers.Length/2); i++)
            {
                cmbTrigger.Items.Add(Triggers[i,1]);
            }
            cmbTrigger.Items.Add("Unknown");

            for (int i = 0; i < (Actions.Length/2); i++)
            {
                cmbAction.Items.Add(Actions[i,1]);
            }
            cmbAction.Items.Add("Unknown");

            Event = thisEvent;
            Event.Triggered = false;
            PopulateEvent(FloorCount);
        }

        private void PopulateEvent(int Count)
        {
            if (Event.Trigger == null) cmbTrigger.SelectedIndex = cmbTrigger.FindString("Unknown");
            else
            {
                for (int i = 0; i < (Triggers.Length/2); i++)
                {
                    if (Triggers[i,0] == Event.Trigger) cmbTrigger.SelectedIndex = i;
                }
            }

            if (Event.Action == null) cmbAction.SelectedIndex = cmbAction.FindString("Unknown");
            else
            {
                for (int i = 0; i < (Actions.Length/2); i++)
                {
                    if (Actions[i,0] == Event.Action) cmbAction.SelectedIndex = i;
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

            GetAllNPCs();
            GetAllItems();
            GetAllEnemies();
        }

        private bool SaveEvent()
        {
            Event.Trigger = Triggers[cmbTrigger.FindString(cmbTrigger.Text),0];
            Event.Action = Actions[cmbAction.FindString(cmbAction.Text),0];

            if (cmbAction.SelectedIndex == 0 || cmbAction.SelectedIndex == 1 || cmbAction.SelectedIndex == 3 || cmbAction.SelectedIndex == 4)
            {
                if (Event.Coodinates == null) Event.Coodinates = new int[3];

                Event.Coodinates[0] = cmbRow.SelectedIndex;
                Event.Coodinates[1] = cmbCol.SelectedIndex;
                Event.Coodinates[2] = cmbFloor.SelectedIndex;
            }

            if (txtNewValue.Text != string.Empty) Event.EventValue = txtNewValue.Text;
            else if (txtNewValue.Enabled == true) return false;

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
            if (cmbAction.SelectedIndex == 0 || cmbAction.SelectedIndex == 1 || cmbAction.SelectedIndex == 3 || cmbAction.SelectedIndex == 4)
            {
                cmbRow.Enabled = true;
                cmbCol.Enabled = true;
                cmbFloor.Enabled = true;
            }
            else if (cmbAction.SelectedIndex == 5 || cmbAction.SelectedIndex == 6)
            {
                txtNewValue.Enabled = true;
            }
            else if (cmbAction.SelectedIndex == 7)
            {
                lstItems.Enabled = true;
                cmdAddItem.Enabled = true;
                cmdCloneItem.Enabled = true;
                cmdRemoveItem.Enabled = true;
            }
            else if (cmbAction.SelectedIndex == 8)
            {
                lstNPCs.Enabled = true;
                cmdAddNPC.Enabled = true;
                cmdCloneNPC.Enabled = true;
                cmdRemoveNPC.Enabled = true;

            }
            else if (cmbAction.SelectedIndex == 9)
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
            frmItemEditor NewForm = new frmItemEditor(NewItem);
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
                Event.Items.Add(Event.Items[lstItems.SelectedIndex]);
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
                frmItemEditor NewForm = new frmItemEditor(EditItem);
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
                Event.NPCs.Add(Event.NPCs[lstNPCs.SelectedIndex]);
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
                Event.Enemies.Add(Event.Enemies[lstEnemies.SelectedIndex]);
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

    }
}
