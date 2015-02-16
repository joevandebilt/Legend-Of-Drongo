using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Legend_Of_Drongo
{
    public partial class frmRoomEditor : Form
    {
        public DataTypes.roomInfo Room;
        int FloorCount;
        public bool ChangeMade;
        bool isBuilding;

        public frmRoomEditor(DataTypes.roomInfo thisRoom, int floors, bool Building)
        {
            InitializeComponent();
            ChangeMade = false;
            isBuilding = Building;
            Room = thisRoom;
            FloorCount = floors;
            PopulateFields();
            DrawEnvironment();
        }

        public void PopulateFields()
        {
            if (!isBuilding)
            {
                if (Room.CanMove == false)
                {
                    chkCanMove.Checked = false;
                    lstColourPicker.SelectedIndex = lstColourPicker.FindString("Red");
                }
                else
                {
                    chkCanMove.Checked = true;
                    lstColourPicker.SelectedIndex = lstColourPicker.FindString("Green");
                }
                if (Room.RoomColour != null) lstColourPicker.SelectedIndex = lstColourPicker.FindString(Room.RoomColour);

                lblRoomColour.Visible = true;
                lstColourPicker.Visible = true;
                lblBuilding.Visible = true;
                txtBuilding.Visible = true;


                txtBuildingName.Visible = false;
                lblBuildingName.Visible = false;

                if (Room.Building.BuildingName != null) txtBuilding.Text = Room.Building.BuildingName;

            }
            else
            {
                if (Room.CanMove == false) chkCanMove.Checked = false;
                else chkCanMove.Checked = true;

                lblRoomColour.Visible = false;
                lstColourPicker.Visible = false;
                lblBuilding.Visible = false;
                txtBuilding.Visible = false;

                txtBuildingName.Visible = true;
                txtBuildingName.Text = Room.RoomName;
                lblBuildingName.Visible = true;
            }

            if (Room.Description != null) txtDescription.Text = Room.Description;
            if (Room.AltDescription != null) txtAltDescription.Text = Room.AltDescription;
            if (Room.SuicideAction != null) txtSuicide.Text = Room.SuicideAction;
            if (Room.ImagePath != null) txtBackgroundImage.Text = Room.ImagePath;

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

            if (!isBuilding)
            {
                Room.RoomColour = lstColourPicker.Text;
            }
            else
            {
                if (txtBuildingName.Text != string.Empty) Room.RoomName = txtBuildingName.Text;
                else return false;
            }

            if (File.Exists(Directory.GetCurrentDirectory() + txtBackgroundImage.Text))
            {
                Room.ImagePath = txtBackgroundImage.Text;
            }

            try
            {
                SaveImageLocations();
            }
            catch { return false; }

            return true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
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
            DrawEnvironment();
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            DataTypes.itemInfo NewItem = new DataTypes.itemInfo();
            frmItemEditor NewForm = new frmItemEditor(NewItem, string.Empty);
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
                DataTypes dt = new DataTypes();
                Room.items.Add(dt.CloneItem(Room.items[lstItems.SelectedIndex]));
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
                frmItemEditor NewForm = new frmItemEditor(EditItem,string.Empty);
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
            DrawEnvironment();
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
                DataTypes dt = new DataTypes();
                Room.Enemy.Add(dt.CloneEnemy(Room.Enemy[lstEnemies.SelectedIndex]));
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
            DrawEnvironment();
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
                DataTypes dt = new DataTypes();
                Room.Civilians.Add(dt.CloneNPC(Room.Civilians[lstNPCs.SelectedIndex]));
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
                DataTypes dt = new DataTypes();
                Room.Events.Add(dt.CloneEvent(Room.Events[lstEvents.SelectedIndex]));
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

        private void cmdFormHelp_Click(object sender, EventArgs e)
        {
            frmHelp NewForm = new frmHelp();
            NewForm.Show();
        }

        private void txtBuilding_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTypes dt = new DataTypes();
            DataTypes.Building Building = new DataTypes.Building();

            if (Room.Building.BuildingName != null) Building = Room.Building;
            frmRoomEditor NewForm = new frmRoomEditor(dt.BuildingIntoRoom(Building),FloorCount,true);
            NewForm.ShowDialog();

            if (NewForm.ChangeMade == true)
            {
                Building = dt.RoomIntoBuilding(NewForm.Room);
                Room.Building = Building;
                txtBuilding.Text = Building.BuildingName;
            }
        }

        private void cmdFindImage_Click(object sender, EventArgs e)
        {
            OpenFile.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "\\Resources\\Backgrounds");
            OpenFile.FileName = string.Empty;

            DialogResult result = OpenFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                string Test = OpenFile.FileName.Replace(Directory.GetCurrentDirectory(), string.Empty);
                txtBackgroundImage.Text = Test;
            }
            DrawEnvironment();
        }

        #region Room Drawing

        public void DragNDrop_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BorderStyle = BorderStyle.FixedSingle;
        }

        public void DragNDrop_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                int X = picBox.Location.X + e.Location.X;
                int Y = picBox.Location.Y + e.Location.Y;

                picBox.Location = new Point(X, Y);
            }
        }

        public void DragNDrop_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BorderStyle = BorderStyle.None;
        }

        public void DebugOutput(string input)
        {
            using (StreamWriter sr = new StreamWriter("C:\\Users\\Joe\\Desktop\\Output.txt",true))
            {
                sr.WriteLine(input);
            }
        }

        public void DrawEnvironment()
        {
            //Just save everything first in case something has changed that I forgot about
            SaveImageLocations();
            
            //Clear existing controls that have been added. Continue to use previous background image if no new one is available
            pnlGraphicWindow.Controls.Clear();

            #region Background
            //Draw the Background Image
            if (!string.IsNullOrEmpty(Room.ImagePath)) Room.ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Room.ImagePath);
            else if (!string.IsNullOrEmpty(txtBackgroundImage.Text)) Room.ImagePath = Path.Combine(Directory.GetCurrentDirectory() + txtBackgroundImage.Text);
            if (!string.IsNullOrEmpty(Room.ImagePath) && File.Exists(Room.ImagePath))
            {
                pnlGraphicWindow.BackgroundImage = Image.FromFile(Room.ImagePath);
                pnlGraphicWindow.Refresh();
            }
            #endregion

            //Draw Enemies
            #region Enemy Drawing
            if (Room.Enemy != null)
            {
                for(int i=0; i<Room.Enemy.Count;i++)
                {
                    DataTypes.EnemyProfile Enemy = Room.Enemy[i];
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Enemy.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "Enemy."+i,
                            BackColor = Color.Transparent,
                            BorderStyle = System.Windows.Forms.BorderStyle.None,
                            Size = new Size(150, 150),
                            Location = Enemy.ImageLocation,
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage,   
                        };
                        NewPicBox.MouseEnter += new EventHandler(DragNDrop_MouseEnter);
                        NewPicBox.MouseLeave += new EventHandler(DragNDrop_MouseLeave);
                        NewPicBox.MouseMove += new MouseEventHandler(DragNDrop_MouseUp);
                        pnlGraphicWindow.Controls.Add(NewPicBox);
                    }
                }
            }

            #endregion

            //Draw items;
            #region Item Drawing
            if (Room.items != null)
            {
                for (int i = 0; i < Room.items.Count; i++)
                {
                    DataTypes.itemInfo Item = Room.items[i];
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Item.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "Item."+i,
                            BackColor = Color.Transparent,
                            BorderStyle = System.Windows.Forms.BorderStyle.None,
                            Size = new Size(50, 50),
                            Location = Item.ImageLocation,
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        NewPicBox.MouseEnter += new EventHandler(DragNDrop_MouseEnter);
                        NewPicBox.MouseLeave += new EventHandler(DragNDrop_MouseLeave);
                        NewPicBox.MouseMove += new MouseEventHandler(DragNDrop_MouseUp);
                        pnlGraphicWindow.Controls.Add(NewPicBox);
                    }
                }
            }
            #endregion

            //Draw NPCs
            #region NPC Drawing
            if (Room.Civilians != null)
            {
                for (int i = 0; i < Room.Civilians.Count;i++ )
                {
                    DataTypes.CivilianProfile NPC = Room.Civilians[i];
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + NPC.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "NPC."+i,
                            BackColor = Color.Transparent,
                            BorderStyle = System.Windows.Forms.BorderStyle.None,
                            Size = new Size(150, 150),
                            Location = NPC.ImageLocation,
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        NewPicBox.MouseEnter += new EventHandler(DragNDrop_MouseEnter);
                        NewPicBox.MouseLeave += new EventHandler(DragNDrop_MouseLeave);
                        NewPicBox.MouseMove += new MouseEventHandler(DragNDrop_MouseUp);
                        pnlGraphicWindow.Controls.Add(NewPicBox);
                    }

                }
            }
            #endregion

            #region Event Drawing 

            if (Room.Events != null)
            { 
                for (int index=0;index<Room.Events.Count;index++)
                {
                    //Draw Event Enemies
                    #region Event Enemy Drawing
                    if (Room.Events[index].Enemies != null)
                    {
                        for (int i = 0; i < Room.Events[index].Enemies.Count; i++)
                        {
                            DataTypes.EnemyProfile Enemy = Room.Events[index].Enemies[i];
                            string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Enemy.ImagePath);
                            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                            {
                                PictureBox NewPicBox = new PictureBox
                                {
                                    Name = "Event."+index+".Enemy." + i,
                                    BackColor = Color.Transparent,
                                    BorderStyle = System.Windows.Forms.BorderStyle.None,
                                    Size = new Size(150,150),
                                    Location = Enemy.ImageLocation,
                                    Visible = true,
                                    ImageLocation = ImagePath,
                                    Image = Image.FromFile(ImagePath),
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                };
                                NewPicBox.MouseEnter += new EventHandler(DragNDrop_MouseEnter);
                                NewPicBox.MouseLeave += new EventHandler(DragNDrop_MouseLeave);
                                NewPicBox.MouseMove += new MouseEventHandler(DragNDrop_MouseUp);
                                pnlGraphicWindow.Controls.Add(NewPicBox);
                            }
                        }
                    }
                    #endregion

                    //Draw Event Items
                    #region Event Item Drawing
                    if (Room.Events[index].Items != null)
                    {
                        for (int i = 0; i < Room.Events[index].Items.Count; i++)
                        {
                            DataTypes.itemInfo Item = Room.Events[index].Items[i];
                            string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Item.ImagePath);
                            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                            {
                                PictureBox NewPicBox = new PictureBox
                                {
                                    Name = "Event." + index + ".Item." + i,
                                    BackColor = Color.Transparent,
                                    BorderStyle = System.Windows.Forms.BorderStyle.None,
                                    Size = new Size(50, 50),
                                    Location = Item.ImageLocation,
                                    Visible = true,
                                    ImageLocation = ImagePath,
                                    Image = Image.FromFile(ImagePath),
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                };
                                NewPicBox.MouseEnter += new EventHandler(DragNDrop_MouseEnter);
                                NewPicBox.MouseLeave += new EventHandler(DragNDrop_MouseLeave);
                                NewPicBox.MouseMove += new MouseEventHandler(DragNDrop_MouseUp);
                                pnlGraphicWindow.Controls.Add(NewPicBox);
                            }
                        }
                    }
                    #endregion

                    //Draw Event NPCs
                    #region Event NPC Drawing
                    if (Room.Events[index].NPCs != null)
                    {
                        for (int i = 0; i < Room.Events[index].NPCs.Count; i++)
                        {
                            DataTypes.CivilianProfile NPC = Room.Events[index].NPCs[i];
                            string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + NPC.ImagePath);
                            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                            {
                                PictureBox NewPicBox = new PictureBox
                                {
                                    Name = "Event." + index + ".NPC." + i,
                                    BackColor = Color.Transparent,
                                    BorderStyle = System.Windows.Forms.BorderStyle.None,
                                    Size = new Size(150, 150),
                                    Location = NPC.ImageLocation,
                                    Visible = true,
                                    ImageLocation = ImagePath,
                                    Image = Image.FromFile(ImagePath),
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                };
                                NewPicBox.MouseEnter += new EventHandler(DragNDrop_MouseEnter);
                                NewPicBox.MouseLeave += new EventHandler(DragNDrop_MouseLeave);
                                NewPicBox.MouseMove += new MouseEventHandler(DragNDrop_MouseUp);
                                pnlGraphicWindow.Controls.Add(NewPicBox);
                            }
                        }
                    }
                    #endregion
                }
            }
            #endregion
        }

        public void SaveImageLocations()
        {
            if (pnlGraphicWindow.Controls != null)
            {
                foreach (PictureBox PicBox in pnlGraphicWindow.Controls)
                {
                    string DataType = PicBox.Name.Split('.')[0];
                    int Index = Int32.Parse(PicBox.Name.Split('.')[1]);

                    if (DataType == "Enemy")
                    {
                        DataTypes.EnemyProfile Enemy = Room.Enemy[Index];
                        Enemy.ImageLocation = PicBox.Location;
                        Room.Enemy[Index] = Enemy;
                    }
                    else if (DataType == "Item")
                    {
                        DataTypes.itemInfo Item = Room.items[Index];
                        Item.ImageLocation = PicBox.Location;
                        Room.items[Index] = Item;
                    }
                    else if (DataType == "NPC")
                    {
                        DataTypes.CivilianProfile NPC = Room.Civilians[Index];
                        NPC.ImageLocation = PicBox.Location;
                        Room.Civilians[Index] = NPC;
                    }
                    else if (DataType == "Event")
                    {
                        string SubDataType = PicBox.Name.Split('.')[2];
                        int i = Int32.Parse(PicBox.Name.Split('.')[3]);
                        if (SubDataType == "Enemy")
                        {
                            DataTypes.EnemyProfile Enemy = Room.Events[Index].Enemies[i];
                            Enemy.ImageLocation = PicBox.Location;
                            Room.Events[Index].Enemies[i] = Enemy;
                        }
                        else if (SubDataType == "Item")
                        {
                            DataTypes.itemInfo Item = Room.Events[Index].Items[i];
                            Item.ImageLocation = PicBox.Location;
                            Room.Events[Index].Items[i] = Item;
                        }
                        else if (SubDataType == "NPC")
                        {
                            DataTypes.CivilianProfile NPC = Room.Events[Index].NPCs[i];
                            NPC.ImageLocation = PicBox.Location;
                            Room.Events[Index].NPCs[i] = NPC;
                        }                        
                    }
                }
            }
        }
        
        #endregion
    }
}
