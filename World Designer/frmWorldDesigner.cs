using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Diagnostics;

namespace Legend_Of_Drongo
{
    public partial class frmWorldDesigner : Form
    {
        //Set up the Grid
        public List<DataTypes.Floor> world = new List<DataTypes.Floor>();
        public DataTypes.PlayerProfile ThisPlayer = new DataTypes.PlayerProfile();

        public List<string> Credits = new List<string>();
        
        DataTypes.Floor ThisFloor;
        int FloorNum = 0;

        public frmWorldDesigner(bool LoadWorld, string WorldName)
        {

            InitializeComponent();

            //Check If New World
            if (LoadWorld == true)
            {
                string LoadPath = string.Concat(Directory.GetCurrentDirectory(), "\\Worlds\\", WorldName);
                //MessageBox.Show(LoadPath);


                DataTypes.WorldFile WorldState = new DataTypes.WorldFile();
                using (Stream stream = File.Open(LoadPath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    WorldState = (DataTypes.WorldFile)bin.Deserialize(stream);

                }
                txtWorldName.Text = WorldState.WorldName;
                txtAuthor.Text = WorldState.WorldAuthor;
                world = WorldState.WorldState;

                if (WorldState.Credits != null) foreach (string credit in WorldState.Credits) { Credits.Add(credit); }

                ThisFloor = world[0];
                txtFloorName.Text = ThisFloor.FloorName;
                txtMusicPath.Text = ThisFloor.FloorSong;
                ThisPlayer = WorldState.DefaultPlayer;
                cmbLevelSelect.Items.Clear();
                for (int i = 1; i <= world.Count; i++)
                {
                    cmbLevelSelect.Items.Add("Level " + i);
                }
                cmbLevelSelect.Items.Add("Add New Level...");
                this.tblWorldLevel.CellPaint += new TableLayoutCellPaintEventHandler(tblWorldLevel_CellPaint);
                lblEditor.Text = "Default Starting Position is B:2";
            }
            else
            {
                world = new List<DataTypes.Floor>();
                ThisFloor = new DataTypes.Floor();
                ThisFloor.CurrentFloor = new DataTypes.roomInfo[10, 10];

                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        ThisFloor.CurrentFloor[x, y].CanMove = true;
                    }
                }

                for (int x = 0; x < 10; x++)
                {
                    ThisFloor.CurrentFloor[x, 0].CanMove = false;
                    ThisFloor.CurrentFloor[x, 9].CanMove = false;
                }

                for (int y = 0; y < 10; y++)
                {
                    ThisFloor.CurrentFloor[0, y].CanMove = false;
                    ThisFloor.CurrentFloor[9, y].CanMove = false;
                }
                ThisFloor.CurrentFloor[1, 1].Description = "This is the starting position. When the player spawns this is the first thing they will read";

                world.Add(ThisFloor);
                this.tblWorldLevel.CellPaint += new TableLayoutCellPaintEventHandler(tblWorldLevel_CellPaint);
                txtFloorName.Text = "Level 1";
                lblEditor.Text = "Default Starting Position is B:2";
                ThisPlayer = DefaultPlayer();
            }
            SetWorldSize();
            AddTableLabels();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?\n\nAll Unsaved progress will be lost?", "Quit World Designer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No || dialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
            else Environment.Exit(0); //Close form gracfully
    }

        private void cmdMainMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to return to the main menu?\n\nAll Unsaved progress will be lost?", "Main Menu", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmMain NewForm = new frmMain();
                NewForm.Show();
                this.Hide();
            }
        }

        private void tblWorldLevel_Click(object sender, EventArgs e)
        {
            TableLayoutPanelCellPosition pos = GetCellPosition(tblWorldLevel);

            //RowNum Then Colnum
            lblEditor.Text = "Now Editing Cell: " + Char.ConvertFromUtf32(pos.Row + 65) + ":" + (pos.Column + 1);

            DataTypes.roomInfo RoomEdit = new DataTypes.roomInfo();
            RoomEdit = ThisFloor.CurrentFloor[pos.Row, pos.Column];
            frmRoomEditor NewForm = new frmRoomEditor(RoomEdit, world.Count, false);
            NewForm.ShowDialog();   //Wait while room is edited

            if (NewForm.ChangeMade == true)
            {
                ThisFloor.CurrentFloor[pos.Row, pos.Column] = NewForm.Room;
                world[FloorNum] = ThisFloor;
            }
            tblWorldLevel.Refresh();
        }
                
        private void cmdSaveWorld_Click(object sender, EventArgs e)
        {
            if (SaveWorld()) lblEditor.Text = "Saved at " + DateTime.Now.ToString();
            else lblEditor.Text = "Save Failed.";
        }

        private void cmbLevelSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = cmbLevelSelect.SelectedIndex;

            //MessageBox.Show(index.ToString());
            //MessageBox.Show(cmbLevelSelect.Items.Count.ToString());

            world[FloorNum] = ThisFloor; //Save Current Floor - unnecessary but why not eh?

            if ((index + 1) == cmbLevelSelect.Items.Count)   //Adding new floor
            {
                FloorNum = index;
                cmbLevelSelect.Items[index] = "Level " + (index + 1);
                cmbLevelSelect.Items.Add("Add New Level...");

                ThisFloor = new DataTypes.Floor();
                ThisFloor.CurrentFloor = new DataTypes.roomInfo[10, 10];
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        ThisFloor.CurrentFloor[x, y].CanMove = true;
                    }
                }

                for (int x = 0; x < 10; x++)
                {
                    ThisFloor.CurrentFloor[x, 0].CanMove = false;
                    ThisFloor.CurrentFloor[x, 9].CanMove = false;
                }

                for (int y = 0; y < 10; y++)
                {
                    ThisFloor.CurrentFloor[0, y].CanMove = false;
                    ThisFloor.CurrentFloor[9, y].CanMove = false;
                }
                world.Add(ThisFloor);
                txtFloorName.Text = "Level " + (index + 1);
            }
            else
            {
                FloorNum = index;   //Set floor number to selected index
                ThisFloor = world[index];   //Load in the floor
                txtFloorName.Text = ThisFloor.FloorName;
                txtMusicPath.Text = ThisFloor.FloorSong;
            }
            SetWorldSize();
            AddTableLabels();
            tblWorldLevel.Refresh(); //Draw the grid

        }

        private void cmdTestWorld_Click(object sender, EventArgs e)
        {
            if (SaveWorld())
            {
                lblEditor.Text = "Saved at " + DateTime.Now.ToString();

                Process proc = new Process();
                if (File.Exists(".\\Legend Of Drongo.exe"))
                {
                    proc = Process.Start(".\\Legend Of Drongo.exe", "/test " + txtWorldName.Text);
                    this.Hide();
                    while (proc.HasExited == false) { }
                    this.Show();

                }
                else MessageBox.Show("Could not find the game engine .exe file, is it missing?");
            }
            else lblEditor.Text = "Save Failed.";
        }

        private void cmdDeleteLevel_Click(object sender, EventArgs e)
        {
            if (world.Count > 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this level. This action is irreversible.", "Delete Level", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Delte the layer
                    world.RemoveAt(FloorNum);

                    if (FloorNum == world.Count) FloorNum = FloorNum - 1;
                    ThisFloor = world[FloorNum];

                    cmbLevelSelect.Items.Clear();
                    for (int i = 1; i <= world.Count; i++)
                    {
                        cmbLevelSelect.Items.Add("Level " + i);
                    }
                    cmbLevelSelect.Items.Add("Add New Level...");
                    tblWorldLevel.Refresh();
                    cmbLevelSelect.SelectedIndex = FloorNum;
                }
            }
            else MessageBox.Show("You cannot have a world with no floors,");
        }
               
        private void cmdPickMusic_Click(object sender, EventArgs e)
        {
            frmMusicPicker NewForm = new frmMusicPicker();
            NewForm.ShowDialog();

            string MusicPath = NewForm.MusicPath;
            if (MusicPath != string.Empty)
            {
                txtMusicPath.Text = MusicPath;
                ThisFloor.FloorSong = MusicPath;
            }
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            frmHelp NewForm = new frmHelp();
            NewForm.Show();
        }

        private void cmdEndCredits_Click(object sender, EventArgs e)
        {
            frmEndCredits NewForm = new frmEndCredits(txtAuthor.Text, Credits);
            NewForm.ShowDialog();

            Credits.Clear();
            foreach (string credit in NewForm.EndCredits) { Credits.Add(credit); }
        }

        private void cmdDefaultPlayer_Click(object sender, EventArgs e)
        {
            frmPlayerEditor NewForm = new frmPlayerEditor(ThisPlayer, world.Count);
            NewForm.ShowDialog();

            ThisPlayer = NewForm.Player;
        }

        public static DataTypes.PlayerProfile DefaultPlayer()
        {
            DataTypes.PlayerProfile Player = new DataTypes.PlayerProfile();
            Player.name = "Drongo";
            Player.HPBonus = 100;
            Player.ArmorBonus = 0;

            //Set up starter inventory
            Player.inventory = new List<DataTypes.itemInfo>();
            Player.MaxItems = 10;
            Player.invspace = Player.MaxItems;

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

            return Player;
        }

        private bool SaveWorld()
        {
            try
            {
                string SavePath = Directory.GetCurrentDirectory() + "\\Worlds";
                bool OverWrite = true;
                lblEditor.Text = "Saving " + txtWorldName.Text + ".LoD...";

                //Detect if doesnt exist
                if (!Directory.Exists(SavePath))
                    Directory.CreateDirectory(SavePath);

                //Are you sure you want to overwrite
                if (File.Exists(SavePath + "\\" + txtWorldName.Text + ".LoD"))
                {
                    DialogResult dialogResult = MessageBox.Show("This world already exists\n\nDo you want to overwrite it?", "World Exists", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        OverWrite = true;
                        SavePath = SavePath + "\\" + txtWorldName.Text + ".LoD";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        OverWrite = false;
                    }
                }
                else SavePath = SavePath + "\\" + txtWorldName.Text + ".LoD";

                if (OverWrite == true)
                {
                    Thread.Sleep(500);
                    DataTypes.WorldFile ThisWorld = new DataTypes.WorldFile();

                    ThisFloor.FloorName = txtFloorName.Text;
                    world[FloorNum] = ThisFloor;
                    ThisWorld.WorldName = txtWorldName.Text;
                    ThisWorld.WorldAuthor = txtAuthor.Text;
                    ThisWorld.WorldState = world;

                    ThisWorld.DefaultPlayer = ThisPlayer;

                    if (ThisWorld.Credits == null) ThisWorld.Credits = new List<string>();
                    ThisWorld.Credits.Clear();
                    foreach (string credit in Credits) { ThisWorld.Credits.Add(credit); }

                    using (Stream stream = File.Open(SavePath, FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, ThisWorld);
                    }
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }
        
        #region Drawing World

        private TableLayoutPanelCellPosition GetCellPosition(TableLayoutPanel panel)
        {
            //mouse position
            Point p = panel.PointToClient(Control.MousePosition);
            //Cell position
            TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(0, 0);
            //Panel size.
            Size size = panel.Size;
            //average cell size.
            SizeF cellAutoSize = new SizeF(size.Width / panel.ColumnCount, size.Height / panel.RowCount);

            //Get the cell row.
            //y coordinate
            float y = 0;
            for (int i = 0; i < panel.RowCount; i++)
            {
                //Calculate the summary of the row heights.
                SizeType type = panel.RowStyles[i].SizeType;
                float height = panel.RowStyles[i].Height;
                switch (type)
                {
                    case SizeType.Absolute:
                        y += height;
                        break;
                    case SizeType.Percent:
                        y += height / 100 * size.Height;
                        break;
                    case SizeType.AutoSize:
                        y += cellAutoSize.Height;
                        break;
                }
                //Check the mouse position to decide if the cell is in current row.
                if ((int)y > p.Y)
                {
                    pos.Row = i;
                    break;
                }
            }

            //Get the cell column.
            //x coordinate
            float x = 0;
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                //Calculate the summary of the row widths.
                SizeType type = panel.ColumnStyles[i].SizeType;
                float width = panel.ColumnStyles[i].Width;
                switch (type)
                {
                    case SizeType.Absolute:
                        x += width;
                        break;
                    case SizeType.Percent:
                        x += width / 100 * size.Width;
                        break;
                    case SizeType.AutoSize:
                        x += cellAutoSize.Width;
                        break;
                }
                //Check the mouse position to decide if the cell is in current column.
                if ((int)x > p.X)
                {
                    pos.Column = i;
                    break;
                }
            }

            //return the mouse position.
            return pos;
        }

        void tblWorldLevel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;
            g.FillRectangle(GetBrushFor(e.Row, e.Column), r);
        }

        private Brush GetBrushFor(int row, int column)
        {
            if (row > -1 && column > -1 && row < ThisFloor.CurrentFloor.GetLength(0) && column < ThisFloor.CurrentFloor.GetLength(1))
            {
                if (ThisFloor.CurrentFloor[row, column].RoomColour != null)
                {
                    string Colour = ThisFloor.CurrentFloor[row, column].RoomColour;

                    switch (Colour)
                    {
                        case "Black": return Brushes.Black;
                        case "Blue": return Brushes.Blue;
                        case "Brown": return Brushes.Brown;
                        case "Green": return Brushes.Green;
                        case "Orange": return Brushes.Orange;
                        case "Pink": return Brushes.Pink;
                        case "Purple": return Brushes.Purple;
                        case "Red": return Brushes.Red;
                        case "Silver": return Brushes.Silver;
                        case "White": return Brushes.White;
                        case "Yellow": return Brushes.Yellow;
                        case "Light Blue": return Brushes.LightBlue;
                        case "Light Green": return Brushes.LightGreen;
                        default: return Brushes.Red;
                    }
                }
                else if (ThisFloor.CurrentFloor[row, column].CanMove == false) return Brushes.Red;
                else return Brushes.Green;
            }
            else return Brushes.Red;
        }

        private void SetWorldSize()
        {
            while (tblWorldLevel.RowCount != ThisFloor.CurrentFloor.GetLength(0))
            {
                if (tblWorldLevel.RowCount > ThisFloor.CurrentFloor.GetLength(0)) RemoveRow();
                else AddRow();
                
            }

            while (tblWorldLevel.ColumnCount != ThisFloor.CurrentFloor.GetLength(1))
            {
                if (tblWorldLevel.ColumnCount > ThisFloor.CurrentFloor.GetLength(1)) RemoveCol();
                else AddCol();
            }

            tblWorldLevel.Refresh();
        }

        private void AddTableLabels()
        {
            tblWorldLevel.Visible = false;
            for (int row = 0; row < tblWorldLevel.RowCount; row++)
            {
                for (int col = 0; col < tblWorldLevel.ColumnCount; col++)
                {
                     tblWorldLevel.Controls.Add(new Label()
                    {
                        Text = string.Concat(char.ConvertFromUtf32(row + 65), col + 1),
                        BackColor = Color.Transparent,
                        AutoSize = false,
                        Enabled = false,
                        TextAlign = ContentAlignment.MiddleCenter
                    }, col, row); 
                }
            }
            tblWorldLevel.Visible = true;

        }


        #endregion

        #region Expanding World
        //Expand Dong

        private void cmdAddCol_Click(object sender, EventArgs e)
        {
            //function to increase currentfloor array by 1
            DataTypes.Floor ExpandFloor = AddWorldCol();
            ThisFloor.CurrentFloor = ExpandFloor.CurrentFloor;

            AddCol();
            AddTableLabels();
            tblWorldLevel.Refresh();
        }

        private void cmdAddRow_Click(object sender, EventArgs e)
        {
            
            //function to increase currentfloor array by 1
            DataTypes.Floor ExpandFloor = AddWorldRow();
            ThisFloor.CurrentFloor = ExpandFloor.CurrentFloor;

            AddRow();
            AddTableLabels();
            tblWorldLevel.Refresh();
         }

        public DataTypes.Floor AddWorldRow()
        {
            DataTypes.Floor NewFloor = new DataTypes.Floor();

            NewFloor.CurrentFloor = new DataTypes.roomInfo[ThisFloor.CurrentFloor.GetLength(0) + 1, ThisFloor.CurrentFloor.GetLength(1)];


            DataTypes dt = new DataTypes();
            for (int row=0;row < ThisFloor.CurrentFloor.GetLength(0);row++)
            {
                for (int col=0; col < ThisFloor.CurrentFloor.GetLength(1);col++)
                {
                    NewFloor.CurrentFloor[row,col] = dt.CloneRoom(ThisFloor.CurrentFloor[row,col]);
                }
            }

            return NewFloor;
        }

        public DataTypes.Floor AddWorldCol()
        {
            DataTypes.Floor NewFloor = new DataTypes.Floor();

            NewFloor.CurrentFloor = new DataTypes.roomInfo[ThisFloor.CurrentFloor.GetLength(0), ThisFloor.CurrentFloor.GetLength(1) + 1];


            DataTypes dt = new DataTypes();
            for (int row = 0; row < ThisFloor.CurrentFloor.GetLength(0); row++)
            {
                for (int col = 0; col < ThisFloor.CurrentFloor.GetLength(1); col++)
                {
                    NewFloor.CurrentFloor[row, col] = dt.CloneRoom(ThisFloor.CurrentFloor[row, col]);
                }
            }

            return NewFloor;
        }

        public void AddRow()
        {
            tblWorldLevel.Visible = false;
            tblWorldLevel.Controls.Clear();

            tblWorldLevel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tblWorldLevel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblWorldLevel.RowCount = tblWorldLevel.RowStyles.Count;

            TableLayoutRowStyleCollection styles = this.tblWorldLevel.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Percent;

                // Set the row height to be a percentage  
                // of the TableLayoutPanel control's height.  
                style.Height = (100 / tblWorldLevel.RowCount);

            }
            tblWorldLevel.Visible = true;
        
        }

        public void AddCol()
        {
            tblWorldLevel.Visible = false;
            tblWorldLevel.Controls.Clear();

            tblWorldLevel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tblWorldLevel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tblWorldLevel.ColumnCount = tblWorldLevel.ColumnStyles.Count;

            TableLayoutColumnStyleCollection styles = this.tblWorldLevel.ColumnStyles;
            foreach (ColumnStyle style in styles)
            {
                style.SizeType = SizeType.Percent;

                // Set the row height to be a percentage  
                // of the TableLayoutPanel control's height.  
                style.Width = (100 / tblWorldLevel.ColumnCount);

            }
            tblWorldLevel.Visible = true;
        }

        #endregion

        #region Shrinking World

        public void RemoveRow()
        {
            tblWorldLevel.Visible = false;
            tblWorldLevel.Controls.Clear();
            tblWorldLevel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tblWorldLevel.RowStyles.RemoveAt(tblWorldLevel.RowCount - 1);
            tblWorldLevel.RowCount = tblWorldLevel.RowStyles.Count;

            TableLayoutRowStyleCollection styles = this.tblWorldLevel.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Percent;

                // Set the row height to be a percentage  
                // of the TableLayoutPanel control's height.  
                style.Height = (100 / tblWorldLevel.RowCount);

            }
            tblWorldLevel.Visible = true;
            
        }

        public void RemoveCol()
        {
            tblWorldLevel.Visible = false;
            tblWorldLevel.Controls.Clear();
            tblWorldLevel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tblWorldLevel.ColumnStyles.RemoveAt(tblWorldLevel.ColumnCount - 1);
            tblWorldLevel.ColumnCount = tblWorldLevel.ColumnStyles.Count;

            TableLayoutColumnStyleCollection styles = this.tblWorldLevel.ColumnStyles;
            foreach (ColumnStyle style in styles)
            {
                style.SizeType = SizeType.Percent;

                // Set the row height to be a percentage  
                // of the TableLayoutPanel control's height.  
                style.Width = (100 / tblWorldLevel.ColumnCount);

            }
            tblWorldLevel.Visible = true;
        }
        
        public DataTypes.Floor RemoveWorldRow()
        {
            DataTypes.Floor NewFloor = new DataTypes.Floor();

            NewFloor.CurrentFloor = new DataTypes.roomInfo[ThisFloor.CurrentFloor.GetLength(0) - 1, ThisFloor.CurrentFloor.GetLength(1)];


            DataTypes dt = new DataTypes();
            for (int row = 0; row < ThisFloor.CurrentFloor.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < ThisFloor.CurrentFloor.GetLength(1); col++)
                {
                    NewFloor.CurrentFloor[row, col] = dt.CloneRoom(ThisFloor.CurrentFloor[row, col]);
                }
            }

            return NewFloor;
        }

        public DataTypes.Floor RemoveWorldCol()
        {
            DataTypes.Floor NewFloor = new DataTypes.Floor();

            NewFloor.CurrentFloor = new DataTypes.roomInfo[ThisFloor.CurrentFloor.GetLength(0), ThisFloor.CurrentFloor.GetLength(1) - 1];
            
            DataTypes dt = new DataTypes();
            for (int row = 0; row < ThisFloor.CurrentFloor.GetLength(0); row++)
            {
                for (int col = 0; col < ThisFloor.CurrentFloor.GetLength(1) -1; col++)
                {
                    NewFloor.CurrentFloor[row, col] = dt.CloneRoom(ThisFloor.CurrentFloor[row, col]);
                }
            }

            return NewFloor;
        }

        private void cmdRemoveRow_Click(object sender, EventArgs e)
        {
            tblWorldLevel.Controls.Clear();
            //function to increase currentfloor array by 1

            DataTypes.Floor ExpandFloor = RemoveWorldRow();
            ThisFloor.CurrentFloor = ExpandFloor.CurrentFloor;

            RemoveRow();
            AddTableLabels();
            tblWorldLevel.Refresh();
        }

        private void cmdRemoveCol_Click(object sender, EventArgs e)
        {
            tblWorldLevel.Controls.Clear();

            //function to increase currentfloor array by 1
            DataTypes.Floor ExpandFloor = RemoveWorldCol();
            ThisFloor.CurrentFloor = ExpandFloor.CurrentFloor;

            RemoveCol();
            AddTableLabels();
            tblWorldLevel.Refresh();
        }

        #endregion

        

        
    }
}
