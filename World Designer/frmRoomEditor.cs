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
    public partial class frmRoomEditor : Form
    {
        public DataTypes.roomInfo Room;
        int FloorCount;
        public bool ChangeMade;

        public frmRoomEditor(DataTypes.roomInfo thisRoom, int floors)
        {
            InitializeComponent();
            ChangeMade = false;

            Room = thisRoom;
            FloorCount = floors;
            PopulateFields();
        }

        public void PopulateFields()
        {
            if (Room.CanMove == false)
            {
                chkCanMove.Checked = false;
                lstColourPicker.SelectedIndex  = lstColourPicker.FindString("Red");
            }
            else
            {
                chkCanMove.Checked = true;
                lstColourPicker.SelectedIndex = lstColourPicker.FindString("Red");
            }

            if (Room.RoomColour != null) lstColourPicker.FindString(Room.RoomColour);

            if (Room.Description != null) txtDescription.Text = Room.Description;
            if (Room.AltDescription != null) txtAltDescription.Text = Room.AltDescription;
            if (Room.SuicideAction != null) txtSuicide.Text = Room.SuicideAction;

            GetAllNPCs();
            GetAllItems();
            GetAllEvents();
            GetAllEnemies();

        }

        public bool SaveFields()
        {

            if (chkCanMove.Checked == false) Room.CanMove = false;
            else Room.CanMove = true;

            Room.Description = txtDescription.Text;
            Room.AltDescription = txtAltDescription.Text;
            Room.SuicideAction = txtSuicide.Text;
            Room.RoomColour = lstColourPicker.Text;

            return true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
        }

        private void cmdSaveRoom_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
        }

        private void cmdSaveClose_Click(object sender, EventArgs e)
        {
            ChangeMade = true;
            SaveFields();
            this.Hide();
        }

        #region Room Items

        public void GetAllItems()
        {
            lstItems.Items.Clear();
            //Populate Items List
            if (Room.items != null)
            {
                foreach (DataTypes.itemInfo Item in Room.items)
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
                if (Room.items == null) Room.items = new List<DataTypes.itemInfo>();
                Room.items.Add(NewItem);
            }
            GetAllItems();
        }

        private void cmdCloneItem_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex > -1)
            {
                Room.items.Add(Room.items[lstItems.SelectedIndex]);
                GetAllItems();
            }
            else MessageBox.Show("Select an item to clone");
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            Room.items.RemoveAt(lstItems.SelectedIndex);
            GetAllItems();
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItems.SelectedIndex > -1)
            {
                DataTypes.itemInfo EditItem = new DataTypes.itemInfo();
                EditItem = Room.items[lstItems.SelectedIndex];
                frmItemEditor NewForm = new frmItemEditor(EditItem);
                NewForm.ShowDialog();

                EditItem = NewForm.Item;
                Room.items[lstItems.SelectedIndex] = EditItem;
                GetAllItems();
            }
        }
        #endregion

        #region Enemy

        public void GetAllEnemies()
        {
            lstEnemies.Items.Clear();
            //Populate Enemies List
            if (Room.Enemy != null)
            {
                foreach (DataTypes.EnemyProfile Enemy in Room.Enemy)
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
                if (Room.Enemy == null) Room.Enemy = new List<DataTypes.EnemyProfile>();
                Room.Enemy.Add(NewEnemy);
            }
            GetAllEnemies();
        }

        private void cmdCloneEnemy_Click(object sender, EventArgs e)
        {
            if (lstEnemies.SelectedIndex > -1)
            {
                Room.Enemy.Add(Room.Enemy[lstEnemies.SelectedIndex]);
                GetAllEnemies();
            }
            else MessageBox.Show("Select an enemy to clone");
        }

        private void cmdRemoveEnemy_Click(object sender, EventArgs e)
        {
            Room.Enemy.RemoveAt(lstEnemies.SelectedIndex);
            GetAllEnemies();
        }

        private void lstEnemies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstEnemies.SelectedIndex > -1)
            {
                DataTypes.EnemyProfile EditEnemy = new DataTypes.EnemyProfile();
                EditEnemy = Room.Enemy[lstEnemies.SelectedIndex];
                frmEnemyEditor NewForm = new frmEnemyEditor(EditEnemy);
                NewForm.ShowDialog();

                EditEnemy = NewForm.Enemy;
                Room.Enemy[lstEnemies.SelectedIndex] = (EditEnemy);
                GetAllEnemies();
            }
        }

        #endregion

        #region NPC

        public void GetAllNPCs()
        {
            lstNPCs.Items.Clear();
            //Populate NPCs List
            if (Room.Civilians != null)
            {
                foreach (DataTypes.CivilianProfile NPC in Room.Civilians)
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
                if (Room.Civilians == null) Room.Civilians = new List<DataTypes.CivilianProfile>();
                Room.Civilians.Add(NewCiviy);
            }
            GetAllNPCs();
        }

        private void cmdCloneNPC_Click(object sender, EventArgs e)
        {
            if (lstNPCs.SelectedIndex > -1)
            {
                Room.Civilians.Add(Room.Civilians[lstNPCs.SelectedIndex]);
                GetAllNPCs();
            }
            else MessageBox.Show("Select an NPC to Clone");
        }

        private void cmdRemoveNPC_Click(object sender, EventArgs e)
        {
            Room.Civilians.RemoveAt(lstNPCs.SelectedIndex);
            GetAllNPCs();
        }

        private void lstNPCs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstNPCs.SelectedIndex > -1)
            {
                DataTypes.CivilianProfile EditCiviy = new DataTypes.CivilianProfile();
                EditCiviy = Room.Civilians[lstNPCs.SelectedIndex];
                frmNPCEditor NewForm = new frmNPCEditor(EditCiviy);
                NewForm.ShowDialog();

                EditCiviy = NewForm.NPC;
                Room.Civilians[lstNPCs.SelectedIndex] = EditCiviy;
                GetAllNPCs();
            }
        }

        #endregion

        #region Events

        public void GetAllEvents()
        {
            lstEvents.Items.Clear();
            if (Room.Events != null)
            {
                foreach (DataTypes.Event Events in Room.Events)
                {
                    lstEvents.Items.Add(Events.Trigger + " - " + Events.Action);
                }
            }
        }

        private void cmdAddEvent_Click(object sender, EventArgs e)
        {
            DataTypes.Event NewEvent = new DataTypes.Event();
            frmEventEditor NewForm = new frmEventEditor(NewEvent, FloorCount);

            NewForm.ShowDialog();

            NewEvent = NewForm.Event;
            if (NewEvent.Action != null)
            {
                if (Room.Events == null) Room.Events = new List<DataTypes.Event>();
                Room.Events.Add(NewEvent);
            }
            GetAllEvents();            
        }

        private void cmdCloneEvent_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex > -1)
            {
                Room.Events.Add(Room.Events[lstEvents.SelectedIndex]);
                GetAllEvents();
            }
            else MessageBox.Show("Select an Event to Clone");
        }

        private void cmdRemoveEvent_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex > -1)
            {
                Room.Events.RemoveAt(lstEvents.SelectedIndex);
                GetAllEvents();
            }
        }

        private void lstEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstEvents.SelectedIndex > -1)
            {
                DataTypes.Event EditEvent = new DataTypes.Event();
                EditEvent = Room.Events[lstEvents.SelectedIndex];
                frmEventEditor NewForm = new frmEventEditor(EditEvent, FloorCount);

                NewForm.ShowDialog();

                EditEvent = NewForm.Event;
                Room.Events[lstEvents.SelectedIndex] = EditEvent;
            }
            GetAllEvents();  
        }

        #endregion

    }
}
