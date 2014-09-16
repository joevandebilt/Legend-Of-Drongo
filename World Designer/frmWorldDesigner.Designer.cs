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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorldDesigner));
            this.cmdMainMenu = new System.Windows.Forms.Button();
            this.cmdSaveWorld = new System.Windows.Forms.Button();
            this.cmbLevelSelect = new System.Windows.Forms.ComboBox();
            this.cmdTestWorld = new System.Windows.Forms.Button();
            this.tblWorldLevel = new System.Windows.Forms.TableLayoutPanel();
            this.lblEditor = new System.Windows.Forms.Label();
            this.cmdDeleteLevel = new System.Windows.Forms.Button();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFloorName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtMusicPath = new System.Windows.Forms.TextBox();
            this.cmdPickMusic = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.cmdEndCredits = new System.Windows.Forms.Button();
            this.cmdDefaultPlayer = new System.Windows.Forms.Button();
            this.cmdAddCol = new System.Windows.Forms.Button();
            this.cmdAddRow = new System.Windows.Forms.Button();
            this.cmdRemoveCol = new System.Windows.Forms.Button();
            this.cmdRemoveRow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdMainMenu
            // 
            this.cmdMainMenu.Location = new System.Drawing.Point(548, 559);
            this.cmdMainMenu.Name = "cmdMainMenu";
            this.cmdMainMenu.Size = new System.Drawing.Size(103, 33);
            this.cmdMainMenu.TabIndex = 8;
            this.cmdMainMenu.Text = "Main Menu";
            this.cmdMainMenu.UseVisualStyleBackColor = true;
            this.cmdMainMenu.Click += new System.EventHandler(this.cmdMainMenu_Click);
            // 
            // cmdSaveWorld
            // 
            this.cmdSaveWorld.Location = new System.Drawing.Point(33, 559);
            this.cmdSaveWorld.Name = "cmdSaveWorld";
            this.cmdSaveWorld.Size = new System.Drawing.Size(103, 33);
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
            this.cmbLevelSelect.Location = new System.Drawing.Point(278, 14);
            this.cmbLevelSelect.Name = "cmbLevelSelect";
            this.cmbLevelSelect.Size = new System.Drawing.Size(150, 21);
            this.cmbLevelSelect.TabIndex = 9;
            this.cmbLevelSelect.Text = "Level 1";
            this.cmbLevelSelect.SelectionChangeCommitted += new System.EventHandler(this.cmbLevelSelect_SelectionChangeCommitted);
            // 
            // cmdTestWorld
            // 
            this.cmdTestWorld.Location = new System.Drawing.Point(142, 559);
            this.cmdTestWorld.Name = "cmdTestWorld";
            this.cmdTestWorld.Size = new System.Drawing.Size(103, 33);
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
            this.tblWorldLevel.Location = new System.Drawing.Point(33, 132);
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
            this.lblEditor.Location = new System.Drawing.Point(33, 78);
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Size = new System.Drawing.Size(618, 20);
            this.lblEditor.TabIndex = 11;
            this.lblEditor.Text = "Editing Cell 1,A";
            this.lblEditor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdDeleteLevel
            // 
            this.cmdDeleteLevel.Location = new System.Drawing.Point(251, 559);
            this.cmdDeleteLevel.Name = "cmdDeleteLevel";
            this.cmdDeleteLevel.Size = new System.Drawing.Size(103, 33);
            this.cmdDeleteLevel.TabIndex = 32;
            this.cmdDeleteLevel.Text = "Delete Level";
            this.cmdDeleteLevel.UseVisualStyleBackColor = true;
            this.cmdDeleteLevel.Click += new System.EventHandler(this.cmdDeleteLevel_Click);
            // 
            // txtWorldName
            // 
            this.txtWorldName.Location = new System.Drawing.Point(84, 14);
            this.txtWorldName.Name = "txtWorldName";
            this.txtWorldName.Size = new System.Drawing.Size(186, 20);
            this.txtWorldName.TabIndex = 33;
            this.txtWorldName.Text = "LoDWorld";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "World Name";
            // 
            // txtFloorName
            // 
            this.txtFloorName.Location = new System.Drawing.Point(515, 13);
            this.txtFloorName.Name = "txtFloorName";
            this.txtFloorName.Size = new System.Drawing.Size(149, 20);
            this.txtFloorName.TabIndex = 35;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(445, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 36;
            this.label22.Text = "Level Name";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(445, 47);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "Level Music";
            // 
            // txtMusicPath
            // 
            this.txtMusicPath.Location = new System.Drawing.Point(515, 44);
            this.txtMusicPath.Name = "txtMusicPath";
            this.txtMusicPath.ReadOnly = true;
            this.txtMusicPath.Size = new System.Drawing.Size(131, 20);
            this.txtMusicPath.TabIndex = 37;
            // 
            // cmdPickMusic
            // 
            this.cmdPickMusic.Location = new System.Drawing.Point(648, 44);
            this.cmdPickMusic.Name = "cmdPickMusic";
            this.cmdPickMusic.Size = new System.Drawing.Size(25, 20);
            this.cmdPickMusic.TabIndex = 39;
            this.cmdPickMusic.Text = "...";
            this.cmdPickMusic.UseVisualStyleBackColor = true;
            this.cmdPickMusic.Click += new System.EventHandler(this.cmdPickMusic_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Location = new System.Drawing.Point(439, 559);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(103, 33);
            this.cmdHelp.TabIndex = 40;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 44);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "Created By";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(84, 41);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(148, 20);
            this.txtAuthor.TabIndex = 42;
            // 
            // cmdEndCredits
            // 
            this.cmdEndCredits.Location = new System.Drawing.Point(336, 38);
            this.cmdEndCredits.Name = "cmdEndCredits";
            this.cmdEndCredits.Size = new System.Drawing.Size(92, 23);
            this.cmdEndCredits.TabIndex = 43;
            this.cmdEndCredits.Text = "Edit End Credits";
            this.cmdEndCredits.UseVisualStyleBackColor = true;
            this.cmdEndCredits.Click += new System.EventHandler(this.cmdEndCredits_Click);
            // 
            // cmdDefaultPlayer
            // 
            this.cmdDefaultPlayer.Location = new System.Drawing.Point(238, 39);
            this.cmdDefaultPlayer.Name = "cmdDefaultPlayer";
            this.cmdDefaultPlayer.Size = new System.Drawing.Size(92, 23);
            this.cmdDefaultPlayer.TabIndex = 44;
            this.cmdDefaultPlayer.Text = "Default Player";
            this.cmdDefaultPlayer.UseVisualStyleBackColor = true;
            this.cmdDefaultPlayer.Click += new System.EventHandler(this.cmdDefaultPlayer_Click);
            // 
            // cmdAddCol
            // 
            this.cmdAddCol.Location = new System.Drawing.Point(463, 102);
            this.cmdAddCol.Name = "cmdAddCol";
            this.cmdAddCol.Size = new System.Drawing.Size(27, 24);
            this.cmdAddCol.TabIndex = 45;
            this.cmdAddCol.Text = "+";
            this.cmdAddCol.UseVisualStyleBackColor = true;
            this.cmdAddCol.Click += new System.EventHandler(this.cmdAddCol_Click);
            // 
            // cmdAddRow
            // 
            this.cmdAddRow.Location = new System.Drawing.Point(205, 101);
            this.cmdAddRow.Name = "cmdAddRow";
            this.cmdAddRow.Size = new System.Drawing.Size(27, 25);
            this.cmdAddRow.TabIndex = 46;
            this.cmdAddRow.Text = "+";
            this.cmdAddRow.UseVisualStyleBackColor = true;
            this.cmdAddRow.Click += new System.EventHandler(this.cmdAddRow_Click);
            // 
            // cmdRemoveCol
            // 
            this.cmdRemoveCol.Location = new System.Drawing.Point(496, 102);
            this.cmdRemoveCol.Name = "cmdRemoveCol";
            this.cmdRemoveCol.Size = new System.Drawing.Size(27, 24);
            this.cmdRemoveCol.TabIndex = 47;
            this.cmdRemoveCol.Text = "-";
            this.cmdRemoveCol.UseVisualStyleBackColor = true;
            this.cmdRemoveCol.Click += new System.EventHandler(this.cmdRemoveCol_Click);
            // 
            // cmdRemoveRow
            // 
            this.cmdRemoveRow.Location = new System.Drawing.Point(236, 101);
            this.cmdRemoveRow.Name = "cmdRemoveRow";
            this.cmdRemoveRow.Size = new System.Drawing.Size(27, 25);
            this.cmdRemoveRow.TabIndex = 48;
            this.cmdRemoveRow.Text = "-";
            this.cmdRemoveRow.UseVisualStyleBackColor = true;
            this.cmdRemoveRow.Click += new System.EventHandler(this.cmdRemoveRow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Columns";
            // 
            // frmWorldDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 606);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdRemoveRow);
            this.Controls.Add(this.cmdRemoveCol);
            this.Controls.Add(this.cmdAddRow);
            this.Controls.Add(this.cmdAddCol);
            this.Controls.Add(this.cmdDefaultPlayer);
            this.Controls.Add(this.cmdEndCredits);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdPickMusic);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtMusicPath);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtFloorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWorldName);
            this.Controls.Add(this.cmdDeleteLevel);
            this.Controls.Add(this.lblEditor);
            this.Controls.Add(this.cmdTestWorld);
            this.Controls.Add(this.cmbLevelSelect);
            this.Controls.Add(this.cmdMainMenu);
            this.Controls.Add(this.cmdSaveWorld);
            this.Controls.Add(this.tblWorldLevel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button cmdDeleteLevel;
        private System.Windows.Forms.TextBox txtWorldName;
        private System.Windows.Forms.Label label1;
        private TextBox txtFloorName;
        private Label label22;
        private Label label23;
        private TextBox txtMusicPath;
        private Button cmdPickMusic;
        private Button cmdHelp;
        private Label label24;
        private TextBox txtAuthor;
        private Button cmdEndCredits;
        private Button cmdDefaultPlayer;
        private Button cmdAddCol;
        private Button cmdAddRow;
        private Button cmdRemoveCol;
        private Button cmdRemoveRow;
        private Label label2;
        private Label label3;
    }
}