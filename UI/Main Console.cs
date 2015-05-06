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
        #region Public Data Objects
        List<string> CommandHistory = new List<string>();
        int cmdHistory = -1;
        Thread thr = new Thread(LegendOfDrongoEngine.Introduction);
        #endregion

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
        
        #region Init and Closing

        public frmMainConsole()
        {
            InitializeComponent();
            tkbVolume.Value = 10;
            Clear();
            tmrStartGame.Enabled = true;
            string MainMenuImage = ".\\Resources\\Backgrounds\\MainMenu\\MainMenu.png";
            if (File.Exists(MainMenuImage))
            {
                pnlOutputWindow.BackgroundImage = Image.FromFile(MainMenuImage);
                pnlOutputWindow.Refresh();
            }
            SetFonts();
        }
        
        public void SetFonts ()
        {
            Font DefaultFont = new Font("Bookman Old Style",12F,FontStyle.Regular);
            txtConsoleOutput.Font = DefaultFont;
            lblSkipIntro.Font = DefaultFont;
            txtInput.Font = DefaultFont;
            lblNewGame.Font = DefaultFont;
            lblLoadGame.Font = DefaultFont;
            lblTutorial.Font = DefaultFont;
            lblCustom.Font = DefaultFont;
            lblQuit.Font = DefaultFont;
            lblOptions.Font = DefaultFont;
            lblOkay.Font = DefaultFont;
            lblVolume.Font = DefaultFont;
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

        #endregion

        #region Game Setup

        public void SetupGame()
        {
            LegendOfDrongoEngine GameEngine = new LegendOfDrongoEngine(this);
            LegendOfDrongoEngine.ParseOptions();
            LegendOfDrongoEngine.Warning();
            pnlWarning.Visible = true;
            
        }
        
        private void MainMenuChoice(int Choice)
        {
            if (Choice == 0)
            {
                txtConsoleOutput.TextAlign = HorizontalAlignment.Left;
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
                    txtConsoleOutput.TextAlign = HorizontalAlignment.Left;
                }
            }
        }
        
        delegate void BeginCampaign();
        public void LoadCampaign()
        {
            if (!this.InvokeRequired)
            {
                DataTypes.PlayerProfile newPlayer = LegendOfDrongoEngine.MainMenu(0);
                if (!string.IsNullOrEmpty(newPlayer.name))
                {
                    pnlWarning.Visible = false;
                    txtConsoleOutput.TextAlign = HorizontalAlignment.Left;
                    lblSkipIntro.Visible = false;
                    lblOptions.Visible = true;
                    tkbVolume.Visible = true;
                    lblVolume.Visible = true;
                    LegendOfDrongoEngine.StartGame(newPlayer);
                    txtInput.Visible = true;
                    txtInput.Focus();
                    txtConsoleOutput.TextAlign = HorizontalAlignment.Left;
                }
            }
            else
            {
                BeginCampaign d = new BeginCampaign(LoadCampaign);
                this.Invoke(d);
            }
        }

        #endregion
      
        #region Form Events

        public void ToggleMenuButtons(bool Enabled)
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

        private void lblOkay_Click(object sender, EventArgs e)
        {
            pnlWarning.Visible = false;
            //pnlOutputWindow.Visible = false;
            pnlMainMenu.Visible = true;
            txtConsoleOutput.TextAlign = HorizontalAlignment.Center;
            LegendOfDrongoEngine.DrawMainMenu();
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
                    if (cmdHistory < (CommandHistory.Count - 1))
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

        private void txtConsoleOutput_TextChanged(object sender, EventArgs e)
        {
            if (txtConsoleOutput.Text.Length > 300) txtConsoleOutput.ScrollBars = ScrollBars.Vertical;
            else txtConsoleOutput.ScrollBars = ScrollBars.None;
        }    

        #endregion

        #region File Control
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
        #endregion

        #region Music Control
        private void tkbVolume_ValueChanged(object sender, EventArgs e)
        {
            int trackBarValue = tkbVolume.Value;
            double percentage = Math.Round((double)trackBarValue * 10,0);

            LegendOfDrongoEngine.MusicVolume(percentage);

            lblVolume.Text = "Game Volume " + percentage.ToString() + "%";
        }
        #endregion
        
        #region Drawing
        /*
        public void DrawEnvironment(DataTypes.roomInfo ThisRoom)
        {
            //Clear existing controls that have been added. Continue to use previous background image if no new one is available
            pnlOutputWindow.Controls.Clear();

            #region Background
            //Draw the Background Image
            ThisRoom.ImagePath = Path.Combine(Directory.GetCurrentDirectory() + ThisRoom.ImagePath);
            if (!string.IsNullOrEmpty(ThisRoom.ImagePath) && File.Exists(ThisRoom.ImagePath))
            {
                pnlOutputWindow.BackgroundImage = Image.FromFile(ThisRoom.ImagePath);
                pnlOutputWindow.Refresh();
            }
            #endregion

            //Draw Enemies
            #region Enemy Drawing
            if (ThisRoom.Enemy != null)
            {
                foreach (DataTypes.EnemyProfile Enemy in ThisRoom.Enemy)
                {
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Enemy.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "img" + Enemy.name,
                            BackColor = Color.Transparent,
                            Size = new Size(200, 200),
                            Location = Enemy.ImageLocation,
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        pnlOutputWindow.Controls.Add(NewPicBox);
                    }
                }
            }

            #endregion

            //Draw items;
            #region Item Drawing
            if (ThisRoom.items != null)
            {
                foreach (DataTypes.itemInfo Item in ThisRoom.items)
                {
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + Item.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "img" + Item.Name,
                            BackColor = Color.Transparent,
                            Size = new Size(50, 50),
                            Location = Item.ImageLocation,
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        pnlOutputWindow.Controls.Add(NewPicBox);
                    }
                }
            }
            #endregion

            //Draw NPCs
            #region NPC Drawing
            if (ThisRoom.Civilians != null)
            {
                foreach (DataTypes.CivilianProfile NPC in ThisRoom.Civilians)
                {
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory() + NPC.ImagePath);
                    if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        PictureBox NewPicBox = new PictureBox
                        {
                            Name = "img" + NPC.name,
                            BackColor = Color.Transparent,
                            Size = new Size(150, 150),
                            Location = NPC.ImageLocation,
                            Visible = true,
                            ImageLocation = ImagePath,
                            Image = Image.FromFile(ImagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        pnlOutputWindow.Controls.Add(NewPicBox);
                    }

                }
            }
            #endregion
        }
                
        public void DrawBorders(int BorderStyle)
        {
            bool Found = false;
            string[] FileNames = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Resources\\Borders");
            int index = 0;

            if (BorderStyle > 0)
            {
                while (index < FileNames.Length && !Found)
                {
                    string ThisFile = FileNames[index].Split('\\')[FileNames[index].Split('\\').Length - 1];
                    if (ThisFile.Split('.')[0] == BorderStyle.ToString())
                    {
                        pnlOutputWindow.BackgroundImage = Image.FromFile(FileNames[index]);
                        pnlOutputWindow.BackgroundImageLayout = ImageLayout.Stretch;
                        pnlOutputWindow.BackgroundImage = Image.FromFile(FileNames[index]);
                        pnlOutputWindow.BackgroundImageLayout = ImageLayout.Stretch;
                        Found = true;
                    }
                    index++;
                }
            }
            else
            {
                pnlOutputWindow.BackgroundImage = null;
                pnlOutputWindow.BackgroundImage = null;
                Found = true;
            }
        }
        */
        #endregion

    }
}
