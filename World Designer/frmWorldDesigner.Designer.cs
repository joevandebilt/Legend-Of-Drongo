using System.Windows.Forms;
namespace Legend_Of_Drongo
{
    partial class frmWorldDesigner
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
            this.cmdMainMenu = new System.Windows.Forms.Button();
            this.cmdSaveWorld = new System.Windows.Forms.Button();
            this.cmbLevelSelect = new System.Windows.Forms.ComboBox();
            this.cmdTestWorld = new System.Windows.Forms.Button();
            this.tblWorldLevel = new System.Windows.Forms.TableLayoutPanel();
            this.lblEditor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdDeleteLevel = new System.Windows.Forms.Button();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFloorName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtMusicPath = new System.Windows.Forms.TextBox();
            this.cmdPickMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdMainMenu
            // 
            this.cmdMainMenu.Location = new System.Drawing.Point(504, 505);
            this.cmdMainMenu.Name = "cmdMainMenu";
            this.cmdMainMenu.Size = new System.Drawing.Size(150, 33);
            this.cmdMainMenu.TabIndex = 8;
            this.cmdMainMenu.Text = "Main Menu";
            this.cmdMainMenu.UseVisualStyleBackColor = true;
            this.cmdMainMenu.Click += new System.EventHandler(this.cmdMainMenu_Click);
            // 
            // cmdSaveWorld
            // 
            this.cmdSaveWorld.Location = new System.Drawing.Point(36, 505);
            this.cmdSaveWorld.Name = "cmdSaveWorld";
            this.cmdSaveWorld.Size = new System.Drawing.Size(150, 33);
            this.cmdSaveWorld.TabIndex = 5;
            this.cmdSaveWorld.Text = "Save World";
            this.cmdSaveWorld.UseVisualStyleBackColor = true;
            this.cmdSaveWorld.Click += new System.EventHandler(this.cmdSaveWorld_Click);
            // 
            // cmbLevelSelect
            // 
            this.cmbLevelSelect.FormattingEnabled = true;
            this.cmbLevelSelect.Items.AddRange(new object[] {
            "Level 1",
            "Add New Level..."});
            this.cmbLevelSelect.Location = new System.Drawing.Point(279, 12);
            this.cmbLevelSelect.Name = "cmbLevelSelect";
            this.cmbLevelSelect.Size = new System.Drawing.Size(150, 21);
            this.cmbLevelSelect.TabIndex = 9;
            this.cmbLevelSelect.Text = "Level 1";
            this.cmbLevelSelect.SelectionChangeCommitted += new System.EventHandler(this.cmbLevelSelect_SelectionChangeCommitted);
            // 
            // cmdTestWorld
            // 
            this.cmdTestWorld.Location = new System.Drawing.Point(192, 505);
            this.cmdTestWorld.Name = "cmdTestWorld";
            this.cmdTestWorld.Size = new System.Drawing.Size(150, 33);
            this.cmdTestWorld.TabIndex = 10;
            this.cmdTestWorld.Text = "Test World";
            this.cmdTestWorld.UseVisualStyleBackColor = true;
            this.cmdTestWorld.Click += new System.EventHandler(this.cmdTestWorld_Click);
            // 
            // tblWorldLevel
            // 
            this.tblWorldLevel.AllowDrop = true;
            this.tblWorldLevel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblWorldLevel.ColumnCount = 10;
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblWorldLevel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tblWorldLevel.Location = new System.Drawing.Point(36, 91);
            this.tblWorldLevel.Name = "tblWorldLevel";
            this.tblWorldLevel.RowCount = 10;
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblWorldLevel.Size = new System.Drawing.Size(618, 393);
            this.tblWorldLevel.TabIndex = 4;
            this.tblWorldLevel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tblWorldLevel_CellPaint);
            this.tblWorldLevel.Click += new System.EventHandler(this.tblWorldLevel_Click);
            // 
            // lblEditor
            // 
            this.lblEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditor.Location = new System.Drawing.Point(33, 42);
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Size = new System.Drawing.Size(396, 20);
            this.lblEditor.TabIndex = 11;
            this.lblEditor.Text = "Editing Cell 1,A";
            this.lblEditor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(426, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "7";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(489, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(550, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "9";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(614, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "A";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "B";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "C";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 227);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "D";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 265);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "E";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 304);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "F";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 344);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "G";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 384);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "H";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 421);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(10, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "I";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 464);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(12, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "J";
            // 
            // cmdDeleteLevel
            // 
            this.cmdDeleteLevel.Location = new System.Drawing.Point(348, 505);
            this.cmdDeleteLevel.Name = "cmdDeleteLevel";
            this.cmdDeleteLevel.Size = new System.Drawing.Size(150, 33);
            this.cmdDeleteLevel.TabIndex = 32;
            this.cmdDeleteLevel.Text = "Delete Level";
            this.cmdDeleteLevel.UseVisualStyleBackColor = true;
            this.cmdDeleteLevel.Click += new System.EventHandler(this.cmdDeleteLevel_Click);
            // 
            // txtWorldName
            // 
            this.txtWorldName.Location = new System.Drawing.Point(85, 12);
            this.txtWorldName.Name = "txtWorldName";
            this.txtWorldName.Size = new System.Drawing.Size(186, 20);
            this.txtWorldName.TabIndex = 33;
            this.txtWorldName.Text = "LoDWorld";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "World Name";
            // 
            // txtFloorName
            // 
            this.txtFloorName.Location = new System.Drawing.Point(516, 11);
            this.txtFloorName.Name = "txtFloorName";
            this.txtFloorName.Size = new System.Drawing.Size(149, 20);
            this.txtFloorName.TabIndex = 35;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(446, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 36;
            this.label22.Text = "Level Name";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(446, 45);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "Level Music";
            // 
            // txtMusicPath
            // 
            this.txtMusicPath.Location = new System.Drawing.Point(516, 42);
            this.txtMusicPath.Name = "txtMusicPath";
            this.txtMusicPath.ReadOnly = true;
            this.txtMusicPath.Size = new System.Drawing.Size(131, 20);
            this.txtMusicPath.TabIndex = 37;
            // 
            // cmdPickMusic
            // 
            this.cmdPickMusic.Location = new System.Drawing.Point(649, 42);
            this.cmdPickMusic.Name = "cmdPickMusic";
            this.cmdPickMusic.Size = new System.Drawing.Size(25, 20);
            this.cmdPickMusic.TabIndex = 39;
            this.cmdPickMusic.Text = "...";
            this.cmdPickMusic.UseVisualStyleBackColor = true;
            this.cmdPickMusic.Click += new System.EventHandler(this.cmdPickMusic_Click);
            // 
            // frmWorldDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 548);
            this.Controls.Add(this.cmdPickMusic);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtMusicPath);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtFloorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWorldName);
            this.Controls.Add(this.cmdDeleteLevel);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEditor);
            this.Controls.Add(this.cmdTestWorld);
            this.Controls.Add(this.cmbLevelSelect);
            this.Controls.Add(this.cmdMainMenu);
            this.Controls.Add(this.cmdSaveWorld);
            this.Controls.Add(this.tblWorldLevel);
            this.Name = "frmWorldDesigner";
            this.Text = "LoD World Designer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMainMenu;
        private System.Windows.Forms.Button cmdSaveWorld;
        private System.Windows.Forms.ComboBox cmbLevelSelect;
        private System.Windows.Forms.Button cmdTestWorld;
        private System.Windows.Forms.TableLayoutPanel tblWorldLevel;
        private System.Windows.Forms.Label lblEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button cmdDeleteLevel;
        private System.Windows.Forms.TextBox txtWorldName;
        private System.Windows.Forms.Label label1;
        private TextBox txtFloorName;
        private Label label22;
        private Label label23;
        private TextBox txtMusicPath;
        private Button cmdPickMusic;
    }
}