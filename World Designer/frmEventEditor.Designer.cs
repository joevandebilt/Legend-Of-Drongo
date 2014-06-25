namespace Legend_Of_Drongo
{
    partial class frmEventEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTrigger = new System.Windows.Forms.ComboBox();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.cmdSaveEvent = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmbRow = new System.Windows.Forms.ComboBox();
            this.cmbCol = new System.Windows.Forms.ComboBox();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.cmdRemoveNPC = new System.Windows.Forms.Button();
            this.cmdAddNPC = new System.Windows.Forms.Button();
            this.cmdRemoveEnemy = new System.Windows.Forms.Button();
            this.cmdAddEnemy = new System.Windows.Forms.Button();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lstNPCs = new System.Windows.Forms.ListBox();
            this.lstEnemies = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.cmdCloneEnemy = new System.Windows.Forms.Button();
            this.cmdCloneNPC = new System.Windows.Forms.Button();
            this.cmdCloneItem = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "When Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Then";
            // 
            // cmbTrigger
            // 
            this.cmbTrigger.FormattingEnabled = true;
            this.cmbTrigger.Location = new System.Drawing.Point(86, 23);
            this.cmbTrigger.Name = "cmbTrigger";
            this.cmbTrigger.Size = new System.Drawing.Size(299, 21);
            this.cmbTrigger.TabIndex = 1;
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(429, 23);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(267, 21);
            this.cmbAction.TabIndex = 3;
            this.cmbAction.TextChanged += new System.EventHandler(this.cmbAction_TextChanged);
            // 
            // cmdSaveEvent
            // 
            this.cmdSaveEvent.Location = new System.Drawing.Point(335, 288);
            this.cmdSaveEvent.Name = "cmdSaveEvent";
            this.cmdSaveEvent.Size = new System.Drawing.Size(108, 24);
            this.cmdSaveEvent.TabIndex = 7;
            this.cmdSaveEvent.Text = "Save";
            this.cmdSaveEvent.UseVisualStyleBackColor = true;
            this.cmdSaveEvent.Click += new System.EventHandler(this.cmdSaveEvent_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(449, 288);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(108, 24);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmbRow
            // 
            this.cmbRow.Enabled = false;
            this.cmbRow.FormattingEnabled = true;
            this.cmbRow.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J"});
            this.cmbRow.Location = new System.Drawing.Point(702, 22);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Size = new System.Drawing.Size(69, 21);
            this.cmbRow.TabIndex = 4;
            this.cmbRow.Text = "Row";
            // 
            // cmbCol
            // 
            this.cmbCol.Enabled = false;
            this.cmbCol.FormattingEnabled = true;
            this.cmbCol.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbCol.Location = new System.Drawing.Point(779, 22);
            this.cmbCol.Name = "cmbCol";
            this.cmbCol.Size = new System.Drawing.Size(69, 21);
            this.cmbCol.TabIndex = 5;
            this.cmbCol.Text = "Col";
            // 
            // cmbFloor
            // 
            this.cmbFloor.Enabled = false;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(854, 22);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(69, 21);
            this.cmbFloor.TabIndex = 6;
            this.cmbFloor.Text = "Level 1";
            // 
            // cmdRemoveNPC
            // 
            this.cmdRemoveNPC.Enabled = false;
            this.cmdRemoveNPC.Location = new System.Drawing.Point(340, 212);
            this.cmdRemoveNPC.Name = "cmdRemoveNPC";
            this.cmdRemoveNPC.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveNPC.TabIndex = 39;
            this.cmdRemoveNPC.Text = "-";
            this.cmdRemoveNPC.UseVisualStyleBackColor = true;
            this.cmdRemoveNPC.Click += new System.EventHandler(this.cmdRemoveNPC_Click);
            // 
            // cmdAddNPC
            // 
            this.cmdAddNPC.Enabled = false;
            this.cmdAddNPC.Location = new System.Drawing.Point(340, 152);
            this.cmdAddNPC.Name = "cmdAddNPC";
            this.cmdAddNPC.Size = new System.Drawing.Size(19, 22);
            this.cmdAddNPC.TabIndex = 38;
            this.cmdAddNPC.Text = "+";
            this.cmdAddNPC.UseVisualStyleBackColor = true;
            this.cmdAddNPC.Click += new System.EventHandler(this.cmdAddNPC_Click);
            // 
            // cmdRemoveEnemy
            // 
            this.cmdRemoveEnemy.Enabled = false;
            this.cmdRemoveEnemy.Location = new System.Drawing.Point(660, 212);
            this.cmdRemoveEnemy.Name = "cmdRemoveEnemy";
            this.cmdRemoveEnemy.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveEnemy.TabIndex = 37;
            this.cmdRemoveEnemy.Text = "-";
            this.cmdRemoveEnemy.UseVisualStyleBackColor = true;
            this.cmdRemoveEnemy.Click += new System.EventHandler(this.cmdRemoveEnemy_Click);
            // 
            // cmdAddEnemy
            // 
            this.cmdAddEnemy.Enabled = false;
            this.cmdAddEnemy.Location = new System.Drawing.Point(660, 154);
            this.cmdAddEnemy.Name = "cmdAddEnemy";
            this.cmdAddEnemy.Size = new System.Drawing.Size(19, 22);
            this.cmdAddEnemy.TabIndex = 36;
            this.cmdAddEnemy.Text = "+";
            this.cmdAddEnemy.UseVisualStyleBackColor = true;
            this.cmdAddEnemy.Click += new System.EventHandler(this.cmdAddEnemy_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Enabled = false;
            this.cmdRemoveItem.Location = new System.Drawing.Point(23, 212);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveItem.TabIndex = 35;
            this.cmdRemoveItem.Text = "-";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Enabled = false;
            this.cmdAddItem.Location = new System.Drawing.Point(23, 152);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(19, 22);
            this.cmdAddItem.TabIndex = 34;
            this.cmdAddItem.Text = "+";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // lstItems
            // 
            this.lstItems.Enabled = false;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(48, 152);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(238, 82);
            this.lstItems.TabIndex = 33;
            this.lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDoubleClick);
            // 
            // lstNPCs
            // 
            this.lstNPCs.Enabled = false;
            this.lstNPCs.FormattingEnabled = true;
            this.lstNPCs.Location = new System.Drawing.Point(365, 152);
            this.lstNPCs.Name = "lstNPCs";
            this.lstNPCs.Size = new System.Drawing.Size(238, 82);
            this.lstNPCs.TabIndex = 32;
            this.lstNPCs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstNPCs_MouseDoubleClick);
            // 
            // lstEnemies
            // 
            this.lstEnemies.Enabled = false;
            this.lstEnemies.FormattingEnabled = true;
            this.lstEnemies.Location = new System.Drawing.Point(685, 152);
            this.lstEnemies.Name = "lstEnemies";
            this.lstEnemies.Size = new System.Drawing.Size(238, 82);
            this.lstEnemies.TabIndex = 31;
            this.lstEnemies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstEnemies_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "NPCs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Items";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Enemies";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "New Value";
            // 
            // txtNewValue
            // 
            this.txtNewValue.Enabled = false;
            this.txtNewValue.Location = new System.Drawing.Point(86, 80);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(668, 20);
            this.txtNewValue.TabIndex = 41;
            // 
            // cmdCloneEnemy
            // 
            this.cmdCloneEnemy.Location = new System.Drawing.Point(660, 182);
            this.cmdCloneEnemy.Name = "cmdCloneEnemy";
            this.cmdCloneEnemy.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneEnemy.TabIndex = 44;
            this.cmdCloneEnemy.Text = "||";
            this.cmdCloneEnemy.UseVisualStyleBackColor = true;
            this.cmdCloneEnemy.Click += new System.EventHandler(this.cmdCloneEnemy_Click);
            // 
            // cmdCloneNPC
            // 
            this.cmdCloneNPC.Location = new System.Drawing.Point(340, 180);
            this.cmdCloneNPC.Name = "cmdCloneNPC";
            this.cmdCloneNPC.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneNPC.TabIndex = 43;
            this.cmdCloneNPC.Text = "||";
            this.cmdCloneNPC.UseVisualStyleBackColor = true;
            this.cmdCloneNPC.Click += new System.EventHandler(this.cmdCloneNPC_Click);
            // 
            // cmdCloneItem
            // 
            this.cmdCloneItem.Location = new System.Drawing.Point(23, 184);
            this.cmdCloneItem.Name = "cmdCloneItem";
            this.cmdCloneItem.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneItem.TabIndex = 42;
            this.cmdCloneItem.Text = "||";
            this.cmdCloneItem.UseVisualStyleBackColor = true;
            this.cmdCloneItem.Click += new System.EventHandler(this.cmdCloneItem_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Location = new System.Drawing.Point(563, 288);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(108, 24);
            this.cmdHelp.TabIndex = 45;
            this.cmdHelp.Text = "Cancel";
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // frmEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 324);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdCloneEnemy);
            this.Controls.Add(this.cmdCloneNPC);
            this.Controls.Add(this.cmdCloneItem);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdRemoveNPC);
            this.Controls.Add(this.cmdAddNPC);
            this.Controls.Add(this.cmdRemoveEnemy);
            this.Controls.Add(this.cmdAddEnemy);
            this.Controls.Add(this.cmdRemoveItem);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.lstNPCs);
            this.Controls.Add(this.lstEnemies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbFloor);
            this.Controls.Add(this.cmbCol);
            this.Controls.Add(this.cmbRow);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSaveEvent);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.cmbTrigger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEventEditor";
            this.Text = "frmEventEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTrigger;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Button cmdSaveEvent;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cmbRow;
        private System.Windows.Forms.ComboBox cmbCol;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Button cmdRemoveNPC;
        private System.Windows.Forms.Button cmdAddNPC;
        private System.Windows.Forms.Button cmdRemoveEnemy;
        private System.Windows.Forms.Button cmdAddEnemy;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.ListBox lstNPCs;
        private System.Windows.Forms.ListBox lstEnemies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.Button cmdCloneEnemy;
        private System.Windows.Forms.Button cmdCloneNPC;
        private System.Windows.Forms.Button cmdCloneItem;
        private System.Windows.Forms.Button cmdHelp;
    }
}