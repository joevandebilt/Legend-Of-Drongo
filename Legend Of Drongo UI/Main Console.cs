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
            }
            else
            {
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
            //Draw the Background Image
            ThisRoom.ImagePath = Path.Combine(Directory.GetCurrentDirectory() + ThisRoom.ImagePath);
            if (!string.IsNullOrEmpty(ThisRoom.ImagePath) && File.Exists(ThisRoom.ImagePath))
            {
                MainBackgroundImage.Image = Image.FromFile(ThisRoom.ImagePath);
                MainBackgroundImage.Refresh();
            }

            //Draw Enemies

            //Draw items
        
            //Draw NPCs
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
            thr.Join();
            LoadCampaign();
        }
    }
}
