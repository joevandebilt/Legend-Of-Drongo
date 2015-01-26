using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace Legend_Of_Drongo
{
    public partial class frmMainConsole : Form
    {
        #region Console Behaviour

        #region Writeline

        public void WriteLine()
        {
            txtConsoleOutput.Text = txtConsoleOutput.Text + Environment.NewLine;
        }

        delegate void WriteLineDelegate(string text);
        delegate void ClearDelegate();
        public void WriteLine(string Input, params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Input = Input.Replace("{" + i + "}", args[i].ToString());
            }
            try
            {
                if (this.txtConsoleOutput.InvokeRequired)
                {
                    // It's on a different thread, so use Invoke.
                    WriteLineDelegate d = new WriteLineDelegate(WriteLine);
                    this.Invoke(d, new object[] { txtConsoleOutput.Text + Input + Environment.NewLine });
                }
                else txtConsoleOutput.Text = txtConsoleOutput.Text + Input + Environment.NewLine;
            }
            catch { }
        }

        public void WriteLine(object Input)
        {
            txtConsoleOutput.Text = txtConsoleOutput.Text + Input.ToString() + Environment.NewLine;
        }

        #endregion

        #region Write

        public void Write(string Input, params string[] args)
        {
            for (int i=0;i<args.Length;i++)
            {
                Input = Input.Replace("{" + i + "}", args[i].ToString());
            }
            txtConsoleOutput.Text = txtConsoleOutput.Text + Input;
        }

        #endregion

        #region Clear
        public void Clear()
        {
            try
            {
                if (this.txtConsoleOutput.InvokeRequired)
                {
                    // It's on a different thread, so use Invoke.
                    ClearDelegate d = new ClearDelegate(Clear);
                    this.Invoke(d);
                }
                else txtConsoleOutput.Text = string.Empty;
            }
            catch { }
        }
        #endregion

        #region Readline

        public string ReadLine(string Prompt, string Title, string Default)
        {
            string Readline = string.Empty;

            Readline = Interaction.InputBox(Prompt, Title, Default, -1, -1);

            return Readline;
        }
        
        #endregion

        #endregion

        List<string> CommandHistory = new List<string>();
        int cmdHistory = -1;
        Thread thr = new Thread(LegendOfDrongoEngine.Introduction);

        public frmMainConsole()
        {
            InitializeComponent();
            tkbVolume.Value = 10;
            Clear();
            tmrStartGame.Enabled = true;
            string MainMenuImage = ".\\Resources\\Backgrounds\\MainMenu\\MainMenu.png";
            if (File.Exists(MainMenuImage))
            {
                MainBackgroundImage.Image = Image.FromFile(MainMenuImage);
                MainBackgroundImage.Refresh();
            }
        }

        public void SetupGame()
        {
            LegendOfDrongoEngine GameEngine = new LegendOfDrongoEngine(this);
            LegendOfDrongoEngine.ParseOptions();
            LegendOfDrongoEngine.Warning();
            pnlWarning.Visible = true;
            
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                CommandHistory.Add(txtInput.Text);
                LegendOfDrongoEngine.EnterCommand(txtInput.Text);
                txtInput.Clear();
                cmdHistory = -1;
                txtInput.Focus();
            }
            else if (e.KeyValue == 38)
            {
                if (CommandHistory.Count > 0)
                {
                    if (cmdHistory == -1) cmdHistory = CommandHistory.Count - 1;
                    else if (cmdHistory > 0) cmdHistory--;

                    txtInput.Text = CommandHistory[cmdHistory];
                }
            }
            else if (e.KeyValue == 40)
            {
                if (CommandHistory.Count > 0)
                {
                    if (cmdHistory < (CommandHistory.Count -1))
                    {
                        cmdHistory++;
                        txtInput.Text = CommandHistory[cmdHistory];
                    }
                    else if (string.IsNullOrEmpty(txtInput.Text) && string.IsNullOrWhiteSpace(txtInput.Text)) txtInput.Clear();
                }
            }
        }

        private void tmrStartGame_Tick(object sender, EventArgs e)
        {
            SetupGame();
            tmrStartGame.Enabled = false;
        }

        private void MainMenuChoice(int Choice)
        {
            if (Choice == 0)
            {
                txtConsoleOutput.TextAlign = ContentAlignment.MiddleCenter;
                lblOptions.Visible = false;
                tkbVolume.Visible = false;
                lblVolume.Visible = false;

                pnlWarning.Visible = true;
                lblOkay.Visible = false;
                lblSkipIntro.Visible = true;

                pnlMainMenu.Visible = false;
                
                thr.Start();
            }
            else
            {
                DataTypes.PlayerProfile newPlayer = LegendOfDrongoEngine.MainMenu(Choice);

                if (!string.IsNullOrEmpty(newPlayer.name))
                {
                    LegendOfDrongoEngine.StartGame(newPlayer);
                    txtInput.Visible = true;
                    txtInput.Focus();
                    txtConsoleOutput.TextAlign = ContentAlignment.TopLeft;
                }
            }
        }

        public void LoadCampaign()
        {
            DataTypes.PlayerProfile newPlayer = LegendOfDrongoEngine.MainMenu(0);
            if (!string.IsNullOrEmpty(newPlayer.name))
            {
                txtConsoleOutput.TextAlign = ContentAlignment.TopLeft;
                lblSkipIntro.Visible = false;
                lblOptions.Visible = true;
                tkbVolume.Visible = true;
                lblVolume.Visible = true;
                LegendOfDrongoEngine.StartGame(newPlayer);
                txtInput.Visible = true;
                txtInput.Focus();
                txtConsoleOutput.TextAlign = ContentAlignment.TopLeft;
            }
        }

        public void ToggleMenuButtoms(bool Enabled)
        {
            if (Enabled == false)
            {
                lblCustom.Visible = false;
                lblLoadGame.Visible = false;
                lblNewGame.Visible = false;
                lblQuit.Visible = false;
                lblTutorial.Visible = false;
                pnlMainMenu.Visible = false;
            }
            else
            {
                pnlMainMenu.Visible = true;
                lblCustom.Visible = true;
                lblLoadGame.Visible = true;
                lblNewGame.Visible = true;
                lblQuit.Visible = true;
                lblTutorial.Visible = true;
            }
        }

        private void lblNewGame_Click(object sender, EventArgs e)
        {
            MainMenuChoice(0);
        }

        private void lblTutorial_Click(object sender, EventArgs e)
        {
            MainMenuChoice(1);
        }

        private void lblLoadGame_Click(object sender, EventArgs e)
        {
            MainMenuChoice(2);
        }

        private void lblCustom_Click(object sender, EventArgs e)
        {
            MainMenuChoice(3);
        }

        private void lblQuit_Click(object sender, EventArgs e)
        {
            MainMenuChoice(4);
        }

        public string FindFile(string StartDirectory)
        {
            string FilePath = string.Empty;

            OpenFile.InitialDirectory = Directory.GetCurrentDirectory()  + StartDirectory;
            OpenFile.FileName = string.Empty;
            OpenFile.DefaultExt = "dsg";
            DialogResult result = OpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath = OpenFile.FileName;
                return FilePath;
            }
            else return ("!FAIL!");
        }

        public string SaveFile(string StartDirectory)
        {
            string FilePath = string.Empty;

            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + StartDirectory;
            saveFileDialog.DefaultExt = "dsg";
            saveFileDialog.FileName = string.Empty;
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath = saveFileDialog.FileName;
                return FilePath;
            }
            else return ("!FAIL!");
        }

        private void lblOkay_Click(object sender, EventArgs e)
        {
            pnlWarning.Visible = false;
            //pnlOutputWindow.Visible = false;
            pnlMainMenu.Visible = true;
            txtConsoleOutput.TextAlign = ContentAlignment.MiddleCenter;
            LegendOfDrongoEngine.DrawMainMenu();
        }

        private void tkbVolume_ValueChanged(object sender, EventArgs e)
        {
            int trackBarValue = tkbVolume.Value;
            double percentage = Math.Round((double)trackBarValue * 10,0);

            LegendOfDrongoEngine.MusicVolume(percentage);

            lblVolume.Text = "Game Volume " + percentage.ToString() + "%";
        }
                
        public void DrawEnvironment(DataTypes.roomInfo ThisRoom)
        {
            //Clear existing controls that have been added. Continue to use previous background image if no new one is available
            MainBackgroundImage.Controls.Clear();

            #region Background
            //Draw the Background Image
            ThisRoom.ImagePath = Path.Combine(Directory.GetCurrentDirectory() + ThisRoom.ImagePath);
            if (!string.IsNullOrEmpty(ThisRoom.ImagePath) && File.Exists(ThisRoom.ImagePath))
            {
                MainBackgroundImage.Image = Image.FromFile(ThisRoom.ImagePath);
                MainBackgroundImage.Refresh();
            }
            #endregion

            //Draw Enemies
            #region Enemy Drawing

            //Create locations where images can be placed and indexes to point to next available image location
            List<Point> EnemyLocations = new List<Point>();
            EnemyLocations.Add(new Point(381, 352));
            EnemyLocations.Add(new Point(633, 352));
            EnemyLocations.Add(new Point(87, 352));
                        
            int EnemyLocationIndex = 0;
            if (ThisRoom.Enemy != null)
            {
                foreach (DataTypes.EnemyProfile Enemy in ThisRoom.Enemy)
                {
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Enemy.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath) && EnemyLocationIndex < EnemyLocations.Count)
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "img" + Enemy.name,
                            BackColor = Color.Transparent,
                            Size = new Size(200, 200),
                            Location = EnemyLocations[EnemyLocationIndex],
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        MainBackgroundImage.Controls.Add(NewPicBox);
                        EnemyLocationIndex++;
                    }

                }

            }

            #endregion

            //Draw items;
            #region Item Drawing

            //Create locations where images can be placed and indexes to point to next available image location
            List<Point> ItemLocations = new List<Point>();
            ItemLocations.Add(new Point(698, 294));
            ItemLocations.Add(new Point(14, 17));
            ItemLocations.Add(new Point(200, 90));
            int ItemLocationIndex = 0;
            if (ThisRoom.items != null)
            {
                foreach (DataTypes.itemInfo Item in ThisRoom.items)
                {
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Item.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath) && ItemLocationIndex < ItemLocations.Count)
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "img" + Item.Name,
                            BackColor = Color.Transparent,
                            Size = new Size(150, 150),
                            Location = ItemLocations[ItemLocationIndex],
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        MainBackgroundImage.Controls.Add(NewPicBox);
                        ItemLocationIndex++;
                    }

                }

            }

            #endregion

            //Draw NPCs
            #region NPC Drawing
            List<Point> NPCLocations = new List<Point>();
            NPCLocations.Add(new Point(300, 150));
            int NPCLocationIndex = 0;
            if (ThisRoom.Civilians != null)
            {
                foreach (DataTypes.CivilianProfile NPC in ThisRoom.Civilians)
                {
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + NPC.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath) && NPCLocationIndex < NPCLocations.Count)
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "img" + NPC.name,
                            BackColor = Color.Transparent,
                            Size = new Size(150, 150),
                            Location = NPCLocations[NPCLocationIndex],
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        MainBackgroundImage.Controls.Add(NewPicBox);
                        NPCLocationIndex++;
                    }

                }
            }

            #endregion
        }

        private void lblOptions_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc = Process.Start(Directory.GetCurrentDirectory() + "\\Options.txt");
            while (proc.HasExited == false) { }
            LegendOfDrongoEngine.ParseOptions();
            
        }

        private void lblSkipIntro_Click(object sender, EventArgs e)
        {
            LegendOfDrongoEngine.SkipIntro();
            WriteLine("Skipping Intro");
            thr.Join();
            pnlWarning.Visible = false;
            LoadCampaign();
        }

        public void DrawBorders(int BorderStyle)
        {
            bool Found = false;
            string[] FileNames = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Resources\\Borders");
            int index = 0;

            while (index < FileNames.Length && !Found)
            {
                string ThisFile = FileNames[index].Split('\\')[FileNames[index].Split('\\').Length -1];
                if (ThisFile.Split('.')[0] == BorderStyle.ToString())
                {
                    pnlGraphicWindow.BackgroundImage = Image.FromFile(FileNames[index]);
                    pnlGraphicWindow.BackgroundImageLayout = ImageLayout.Stretch;
                    pnlOutputWindow.BackgroundImage = Image.FromFile(FileNames[index]);
                    pnlOutputWindow.BackgroundImageLayout = ImageLayout.Stretch;
                    Found = true;
                }
                index++;
            }            
        }
    }
}
