namespace Legend_Of_Drongo
{
    partial class frmMainConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.tmrStartGame = new System.Windows.Forms.Timer(this.components);
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tkbVolume = new System.Windows.Forms.TrackBar();
            this.lblOptions = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblOkay = new System.Windows.Forms.Label();
            this.lblSkipIntro = new System.Windows.Forms.Label();
            this.pnlOutputWindow = new System.Windows.Forms.Panel();
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.lblTutorial = new System.Windows.Forms.Label();
            this.lblCustom = new System.Windows.Forms.Label();
            this.lblQuit = new System.Windows.Forms.Label();
            this.lblLoadGame = new System.Windows.Forms.Label();
            this.lblNewGame = new System.Windows.Forms.Label();
            this.txtConsoleOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tkbVolume)).BeginInit();
            this.pnlWarning.SuspendLayout();
            this.pnlMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(196, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ">";
            this.label1.Visible = false;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.Black;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(215, 423);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(751, 26);
            this.txtInput.TabIndex = 2;
            this.txtInput.Visible = false;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // tmrStartGame
            // 
            this.tmrStartGame.Interval = 500;
            this.tmrStartGame.Tick += new System.EventHandler(this.tmrStartGame_Tick);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.BackColor = System.Drawing.Color.Black;
            this.lblVolume.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.ForeColor = System.Drawing.Color.White;
            this.lblVolume.Location = new System.Drawing.Point(972, 428);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(125, 18);
            this.lblVolume.TabIndex = 9;
            this.lblVolume.Text = "Game Volume 0%";
            // 
            // tkbVolume
            // 
            this.tkbVolume.BackColor = System.Drawing.Color.Black;
            this.tkbVolume.Location = new System.Drawing.Point(1068, 423);
            this.tkbVolume.Name = "tkbVolume";
            this.tkbVolume.Size = new System.Drawing.Size(104, 45);
            this.tkbVolume.TabIndex = 10;
            this.tkbVolume.ValueChanged += new System.EventHandler(this.tkbVolume_ValueChanged);
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.ForeColor = System.Drawing.Color.White;
            this.lblOptions.Location = new System.Drawing.Point(23, 423);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(71, 20);
            this.lblOptions.TabIndex = 11;
            this.lblOptions.Text = "Options";
            this.lblOptions.Click += new System.EventHandler(this.lblOptions_Click);
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.Transparent;
            this.pnlWarning.Controls.Add(this.lblOkay);
            this.pnlWarning.Controls.Add(this.lblSkipIntro);
            this.pnlWarning.Location = new System.Drawing.Point(335, 402);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(423, 48);
            this.pnlWarning.TabIndex = 17;
            this.pnlWarning.Visible = false;
            // 
            // lblOkay
            // 
            this.lblOkay.AutoSize = true;
            this.lblOkay.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkay.ForeColor = System.Drawing.Color.White;
            this.lblOkay.Location = new System.Drawing.Point(197, 12);
            this.lblOkay.Name = "lblOkay";
            this.lblOkay.Size = new System.Drawing.Size(32, 20);
            this.lblOkay.TabIndex = 10;
            this.lblOkay.Text = "Ok";
            this.lblOkay.Click += new System.EventHandler(this.lblOkay_Click);
            // 
            // lblSkipIntro
            // 
            this.lblSkipIntro.AutoSize = true;
            this.lblSkipIntro.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipIntro.ForeColor = System.Drawing.Color.White;
            this.lblSkipIntro.Location = new System.Drawing.Point(173, 12);
            this.lblSkipIntro.Name = "lblSkipIntro";
            this.lblSkipIntro.Size = new System.Drawing.Size(88, 20);
            this.lblSkipIntro.TabIndex = 13;
            this.lblSkipIntro.Text = "Skip Intro";
            this.lblSkipIntro.Visible = false;
            this.lblSkipIntro.Click += new System.EventHandler(this.lblSkipIntro_Click);
            // 
            // pnlOutputWindow
            // 
            this.pnlOutputWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlOutputWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOutputWindow.Location = new System.Drawing.Point(442, 12);
            this.pnlOutputWindow.Name = "pnlOutputWindow";
            this.pnlOutputWindow.Size = new System.Drawing.Size(730, 384);
            this.pnlOutputWindow.TabIndex = 18;
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.AllowDrop = true;
            this.pnlMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainMenu.Controls.Add(this.lblTutorial);
            this.pnlMainMenu.Controls.Add(this.lblCustom);
            this.pnlMainMenu.Controls.Add(this.lblQuit);
            this.pnlMainMenu.Controls.Add(this.lblLoadGame);
            this.pnlMainMenu.Controls.Add(this.lblNewGame);
            this.pnlMainMenu.Location = new System.Drawing.Point(27, 82);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(392, 189);
            this.pnlMainMenu.TabIndex = 19;
            this.pnlMainMenu.Visible = false;
            // 
            // lblTutorial
            // 
            this.lblTutorial.AutoSize = true;
            this.lblTutorial.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutorial.ForeColor = System.Drawing.Color.White;
            this.lblTutorial.Location = new System.Drawing.Point(154, 86);
            this.lblTutorial.Name = "lblTutorial";
            this.lblTutorial.Size = new System.Drawing.Size(70, 20);
            this.lblTutorial.TabIndex = 13;
            this.lblTutorial.Text = "Tutorial";
            this.lblTutorial.Visible = false;
            this.lblTutorial.Click += new System.EventHandler(this.lblTutorial_Click);
            // 
            // lblCustom
            // 
            this.lblCustom.AutoSize = true;
            this.lblCustom.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustom.ForeColor = System.Drawing.Color.White;
            this.lblCustom.Location = new System.Drawing.Point(133, 117);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(121, 20);
            this.lblCustom.TabIndex = 12;
            this.lblCustom.Text = "Custom Game";
            this.lblCustom.Click += new System.EventHandler(this.lblCustom_Click);
            // 
            // lblQuit
            // 
            this.lblQuit.AutoSize = true;
            this.lblQuit.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuit.ForeColor = System.Drawing.Color.White;
            this.lblQuit.Location = new System.Drawing.Point(170, 144);
            this.lblQuit.Name = "lblQuit";
            this.lblQuit.Size = new System.Drawing.Size(44, 20);
            this.lblQuit.TabIndex = 11;
            this.lblQuit.Text = "Quit";
            this.lblQuit.Click += new System.EventHandler(this.lblQuit_Click);
            // 
            // lblLoadGame
            // 
            this.lblLoadGame.AutoSize = true;
            this.lblLoadGame.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadGame.ForeColor = System.Drawing.Color.White;
            this.lblLoadGame.Location = new System.Drawing.Point(142, 54);
            this.lblLoadGame.Name = "lblLoadGame";
            this.lblLoadGame.Size = new System.Drawing.Size(98, 20);
            this.lblLoadGame.TabIndex = 10;
            this.lblLoadGame.Text = "Load Game";
            this.lblLoadGame.Click += new System.EventHandler(this.lblLoadGame_Click);
            // 
            // lblNewGame
            // 
            this.lblNewGame.AutoSize = true;
            this.lblNewGame.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewGame.ForeColor = System.Drawing.Color.White;
            this.lblNewGame.Location = new System.Drawing.Point(144, 23);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(93, 20);
            this.lblNewGame.TabIndex = 9;
            this.lblNewGame.Text = "New Game";
            this.lblNewGame.Click += new System.EventHandler(this.lblNewGame_Click);
            // 
            // txtConsoleOutput
            // 
            this.txtConsoleOutput.BackColor = System.Drawing.Color.Black;
            this.txtConsoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsoleOutput.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsoleOutput.ForeColor = System.Drawing.Color.White;
            this.txtConsoleOutput.Location = new System.Drawing.Point(12, 11);
            this.txtConsoleOutput.Multiline = true;
            this.txtConsoleOutput.Name = "txtConsoleOutput";
            this.txtConsoleOutput.ReadOnly = true;
            this.txtConsoleOutput.Size = new System.Drawing.Size(424, 385);
            this.txtConsoleOutput.TabIndex = 20;
            // 
            // frmMainConsole
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1184, 542);
            this.Controls.Add(this.pnlMainMenu);
            this.Controls.Add(this.txtConsoleOutput);
            this.Controls.Add(this.pnlOutputWindow);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tkbVolume);
            this.Controls.Add(this.lblVolume);
            this.Name = "frmMainConsole";
            this.Text = "Legend Of Drongo";
            ((System.ComponentModel.ISupportInitialize)(this.tkbVolume)).EndInit();
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Timer tmrStartGame;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar tkbVolume;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblOkay;
        private System.Windows.Forms.Label lblSkipIntro;
        private System.Windows.Forms.Panel pnlOutputWindow;
        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Label lblTutorial;
        private System.Windows.Forms.Label lblCustom;
        private System.Windows.Forms.Label lblQuit;
        private System.Windows.Forms.Label lblLoadGame;
        private System.Windows.Forms.Label lblNewGame;
        private System.Windows.Forms.TextBox txtConsoleOutput;
    }
}

