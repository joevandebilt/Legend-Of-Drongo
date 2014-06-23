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
        DataTypes.Floor ThisFloor;
        int FloorNum = 0;

        public frmWorldDesigner(bool LoadWorld, string WorldName)
        {

            InitializeComponent();
                      
            //Check If New World
            if (LoadWorld == true)
            {
                string LoadPath = string.Concat(Directory.GetCurrentDirectory() , "\\Worlds\\" , WorldName);
                //MessageBox.Show(LoadPath);


                DataTypes.WorldFile WorldState = new DataTypes.WorldFile();
                using (Stream stream = File.Open(LoadPath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    WorldState = (DataTypes.WorldFile)bin.Deserialize(stream);

                }
                txtWorldName.Text = WorldState.WorldName;
                world = WorldState.WorldState;

                ThisFloor = world[0];
                txtFloorName.Text = ThisFloor.FloorName;
                txtMusicPath.Text = ThisFloor.FloorSong;
                cmbLevelSelect.Items.Clear();
                for (int i=1;i<=world.Count;i++)
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
            }
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
            frmRoomEditor NewForm = new frmRoomEditor(RoomEdit, world.Count);
            NewForm.ShowDialog();   //Wait while room is edited

            if (NewForm.ChangeMade == true)
            {
                ThisFloor.CurrentFloor[pos.Row, pos.Column] = NewForm.Room;
                world[FloorNum] = ThisFloor;
            }
            tblWorldLevel.Refresh();
        }

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
            
            if ((index +1) == cmbLevelSelect.Items.Count)   //Adding new floor
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
                txtFloorName.Text = "Level " + (index +1);
            }
            else
            {
                FloorNum = index;   //Set floor number to selected index
                ThisFloor = world[index];   //Load in the floor
                txtFloorName.Text = ThisFloor.FloorName;
                txtMusicPath.Text = ThisFloor.FloorSong;
            }
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
                    ThisWorld.WorldState = world;

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
    }
}
