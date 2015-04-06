namespace Legend_Of_Drongo
{
    partial class frmRoomEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomEditor));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEditing = new System.Windows.Forms.Label();
            this.cmdSaveClose = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAltDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCanMove = new System.Windows.Forms.CheckBox();
            this.cmdFormHelp = new System.Windows.Forms.Button();
            this.txtSuicide = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstEnemies = new System.Windows.Forms.ListBox();
            this.lstNPCs = new System.Windows.Forms.ListBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.cmdRemoveEvent = new System.Windows.Forms.Button();
            this.cmdAddEvent = new System.Windows.Forms.Button();
            this.cmdRemoveEnemy = new System.Windows.Forms.Button();
            this.cmdAddEnemy = new System.Windows.Forms.Button();
            this.cmdRemoveNPC = new System.Windows.Forms.Button();
            this.cmdAddNPC = new System.Windows.Forms.Button();
            this.cmdCloneEvent = new System.Windows.Forms.Button();
            this.cmdCloneItem = new System.Windows.Forms.Button();
            this.cmdCloneNPC = new System.Windows.Forms.Button();
            this.cmdCloneEnemy = new System.Windows.Forms.Button();
            this.lblRoomColour = new System.Windows.Forms.Label();
            this.lstColourPicker = new System.Windows.Forms.ComboBox();
            this.lblBuildingName = new System.Windows.Forms.Label();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBackgroundImage = new System.Windows.Forms.TextBox();
            this.cmdFindImage = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlGraphicWindow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(15, 486);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(161, 38);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Close Without Saving";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enemies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(787, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Items";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(787, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "NPCs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Primary Description";
            // 
            // lblEditing
            // 
            this.lblEditing.AutoSize = true;
            this.lblEditing.Location = new System.Drawing.Point(12, 9);
            this.lblEditing.Name = "lblEditing";
            this.lblEditing.Size = new System.Drawing.Size(48, 13);
            this.lblEditing.TabIndex = 6;
            this.lblEditing.Text = "Title Box";
            // 
            // cmdSaveClose
            // 
            this.cmdSaveClose.Location = new System.Drawing.Point(182, 486);
            this.cmdSaveClose.Name = "cmdSaveClose";
            this.cmdSaveClose.Size = new System.Drawing.Size(161, 38);
            this.cmdSaveClose.TabIndex = 5;
            this.cmdSaveClose.Text = "Save and Close";
            this.cmdSaveClose.UseVisualStyleBackColor = true;
            this.cmdSaveClose.Click += new System.EventHandler(this.cmdSaveClose_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 101);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(744, 121);
            this.txtDescription.TabIndex = 1;
            // 
            // txtAltDescription
            // 
            this.txtAltDescription.Location = new System.Drawing.Point(15, 268);
            this.txtAltDescription.Multiline = true;
            this.txtAltDescription.Name = "txtAltDescription";
            this.txtAltDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAltDescription.Size = new System.Drawing.Size(744, 121);
            this.txtAltDescription.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alt Description";
            // 
            // chkCanMove
            // 
            this.chkCanMove.AutoSize = true;
            this.chkCanMove.Location = new System.Drawing.Point(15, 44);
            this.chkCanMove.Name = "chkCanMove";
            this.chkCanMove.Size = new System.Drawing.Size(139, 17);
            this.chkCanMove.TabIndex = 0;
            this.chkCanMove.Text = "Player Can Move Here?";
            this.chkCanMove.UseVisualStyleBackColor = true;
            // 
            // cmdFormHelp
            // 
            this.cmdFormHelp.Location = new System.Drawing.Point(349, 486);
            this.cmdFormHelp.Name = "cmdFormHelp";
            this.cmdFormHelp.Size = new System.Drawing.Size(161, 38);
            this.cmdFormHelp.TabIndex = 7;
            this.cmdFormHelp.Text = "Help";
            this.cmdFormHelp.UseVisualStyleBackColor = true;
            this.cmdFormHelp.Click += new System.EventHandler(this.cmdFormHelp_Click);
            // 
            // txtSuicide
            // 
            this.txtSuicide.Location = new System.Drawing.Point(15, 440);
            this.txtSuicide.Name = "txtSuicide";
            this.txtSuicide.Size = new System.Drawing.Size(744, 20);
            this.txtSuicide.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Custom Suicide Message";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(787, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Events";
            // 
            // lstEnemies
            // 
            this.lstEnemies.FormattingEnabled = true;
            this.lstEnemies.Location = new System.Drawing.Point(790, 210);
            this.lstEnemies.Name = "lstEnemies";
            this.lstEnemies.Size = new System.Drawing.Size(238, 82);
            this.lstEnemies.TabIndex = 16;
            this.lstEnemies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstEnemies_MouseDoubleClick);
            // 
            // lstNPCs
            // 
            this.lstNPCs.FormattingEnabled = true;
            this.lstNPCs.Location = new System.Drawing.Point(790, 324);
            this.lstNPCs.Name = "lstNPCs";
            this.lstNPCs.Size = new System.Drawing.Size(238, 82);
            this.lstNPCs.TabIndex = 17;
            this.lstNPCs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstNPCs_MouseDoubleClick);
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(790, 438);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(238, 82);
            this.lstItems.TabIndex = 18;
            this.lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDoubleClick);
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.Location = new System.Drawing.Point(790, 101);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(238, 82);
            this.lstEvents.TabIndex = 19;
            this.lstEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstEvents_MouseDoubleClick);
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(765, 438);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(19, 22);
            this.cmdAddItem.TabIndex = 20;
            this.cmdAddItem.Text = "+";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(765, 494);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveItem.TabIndex = 21;
            this.cmdRemoveItem.Text = "-";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // cmdRemoveEvent
            // 
            this.cmdRemoveEvent.Location = new System.Drawing.Point(765, 156);
            this.cmdRemoveEvent.Name = "cmdRemoveEvent";
            this.cmdRemoveEvent.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveEvent.TabIndex = 23;
            this.cmdRemoveEvent.Text = "-";
            this.cmdRemoveEvent.UseVisualStyleBackColor = true;
            this.cmdRemoveEvent.Click += new System.EventHandler(this.cmdRemoveEvent_Click);
            // 
            // cmdAddEvent
            // 
            this.cmdAddEvent.Location = new System.Drawing.Point(765, 101);
            this.cmdAddEvent.Name = "cmdAddEvent";
            this.cmdAddEvent.Size = new System.Drawing.Size(19, 22);
            this.cmdAddEvent.TabIndex = 22;
            this.cmdAddEvent.Text = "+";
            this.cmdAddEvent.UseVisualStyleBackColor = true;
            this.cmdAddEvent.Click += new System.EventHandler(this.cmdAddEvent_Click);
            // 
            // cmdRemoveEnemy
            // 
            this.cmdRemoveEnemy.Location = new System.Drawing.Point(765, 268);
            this.cmdRemoveEnemy.Name = "cmdRemoveEnemy";
            this.cmdRemoveEnemy.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveEnemy.TabIndex = 25;
            this.cmdRemoveEnemy.Text = "-";
            this.cmdRemoveEnemy.UseVisualStyleBackColor = true;
            this.cmdRemoveEnemy.Click += new System.EventHandler(this.cmdRemoveEnemy_Click);
            // 
            // cmdAddEnemy
            // 
            this.cmdAddEnemy.Location = new System.Drawing.Point(765, 212);
            this.cmdAddEnemy.Name = "cmdAddEnemy";
            this.cmdAddEnemy.Size = new System.Drawing.Size(19, 22);
            this.cmdAddEnemy.TabIndex = 24;
            this.cmdAddEnemy.Text = "+";
            this.cmdAddEnemy.UseVisualStyleBackColor = true;
            this.cmdAddEnemy.Click += new System.EventHandler(this.cmdAddEnemy_Click);
            // 
            // cmdRemoveNPC
            // 
            this.cmdRemoveNPC.Location = new System.Drawing.Point(765, 380);
            this.cmdRemoveNPC.Name = "cmdRemoveNPC";
            this.cmdRemoveNPC.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveNPC.TabIndex = 27;
            this.cmdRemoveNPC.Text = "-";
            this.cmdRemoveNPC.UseVisualStyleBackColor = true;
            this.cmdRemoveNPC.Click += new System.EventHandler(this.cmdRemoveNPC_Click);
            // 
            // cmdAddNPC
            // 
            this.cmdAddNPC.Location = new System.Drawing.Point(765, 324);
            this.cmdAddNPC.Name = "cmdAddNPC";
            this.cmdAddNPC.Size = new System.Drawing.Size(19, 22);
            this.cmdAddNPC.TabIndex = 26;
            this.cmdAddNPC.Text = "+";
            this.cmdAddNPC.UseVisualStyleBackColor = true;
            this.cmdAddNPC.Click += new System.EventHandler(this.cmdAddNPC_Click);
            // 
            // cmdCloneEvent
            // 
            this.cmdCloneEvent.Location = new System.Drawing.Point(765, 128);
            this.cmdCloneEvent.Name = "cmdCloneEvent";
            this.cmdCloneEvent.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneEvent.TabIndex = 28;
            this.cmdCloneEvent.Text = "||";
            this.cmdCloneEvent.UseVisualStyleBackColor = true;
            this.cmdCloneEvent.Click += new System.EventHandler(this.cmdCloneEvent_Click);
            // 
            // cmdCloneItem
            // 
            this.cmdCloneItem.Location = new System.Drawing.Point(765, 466);
            this.cmdCloneItem.Name = "cmdCloneItem";
            this.cmdCloneItem.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneItem.TabIndex = 29;
            this.cmdCloneItem.Text = "||";
            this.cmdCloneItem.UseVisualStyleBackColor = true;
            this.cmdCloneItem.Click += new System.EventHandler(this.cmdCloneItem_Click);
            // 
            // cmdCloneNPC
            // 
            this.cmdCloneNPC.Location = new System.Drawing.Point(765, 352);
            this.cmdCloneNPC.Name = "cmdCloneNPC";
            this.cmdCloneNPC.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneNPC.TabIndex = 30;
            this.cmdCloneNPC.Text = "||";
            this.cmdCloneNPC.UseVisualStyleBackColor = true;
            this.cmdCloneNPC.Click += new System.EventHandler(this.cmdCloneNPC_Click);
            // 
            // cmdCloneEnemy
            // 
            this.cmdCloneEnemy.Location = new System.Drawing.Point(765, 240);
            this.cmdCloneEnemy.Name = "cmdCloneEnemy";
            this.cmdCloneEnemy.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneEnemy.TabIndex = 31;
            this.cmdCloneEnemy.Text = "||";
            this.cmdCloneEnemy.UseVisualStyleBackColor = true;
            this.cmdCloneEnemy.Click += new System.EventHandler(this.cmdCloneEnemy_Click);
            // 
            // lblRoomColour
            // 
            this.lblRoomColour.AutoSize = true;
            this.lblRoomColour.Location = new System.Drawing.Point(160, 46);
            this.lblRoomColour.Name = "lblRoomColour";
            this.lblRoomColour.Size = new System.Drawing.Size(68, 13);
            this.lblRoomColour.TabIndex = 32;
            this.lblRoomColour.Text = "Room Colour";
            // 
            // lstColourPicker
            // 
            this.lstColourPicker.FormattingEnabled = true;
            this.lstColourPicker.Items.AddRange(new object[] {
            "Black",
            "Blue",
            "Brown",
            "Green",
            "Light Blue",
            "Light Green",
            "Orange",
            "Pink",
            "Purple",
            "Red",
            "Silver",
            "White",
            "Yellow"});
            this.lstColourPicker.Location = new System.Drawing.Point(234, 43);
            this.lstColourPicker.Name = "lstColourPicker";
            this.lstColourPicker.Size = new System.Drawing.Size(128, 21);
            this.lstColourPicker.TabIndex = 33;
            // 
            // lblBuildingName
            // 
            this.lblBuildingName.AutoSize = true;
            this.lblBuildingName.Location = new System.Drawing.Point(153, 46);
            this.lblBuildingName.Name = "lblBuildingName";
            this.lblBuildingName.Size = new System.Drawing.Size(75, 13);
            this.lblBuildingName.TabIndex = 34;
            this.lblBuildingName.Text = "Building Name";
            this.lblBuildingName.Visible = false;
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.Location = new System.Drawing.Point(234, 44);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(128, 20);
            this.txtBuildingName.TabIndex = 35;
            this.txtBuildingName.Visible = false;
            // 
            // txtBuilding
            // 
            this.txtBuilding.Location = new System.Drawing.Point(443, 42);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.ReadOnly = true;
            this.txtBuilding.Size = new System.Drawing.Size(128, 20);
            this.txtBuilding.TabIndex = 37;
            this.txtBuilding.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtBuilding_MouseDoubleClick);
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(393, 45);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(44, 13);
            this.lblBuilding.TabIndex = 36;
            this.lblBuilding.Text = "Building";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(610, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Background Image";
            // 
            // txtBackgroundImage
            // 
            this.txtBackgroundImage.Location = new System.Drawing.Point(713, 43);
            this.txtBackgroundImage.Name = "txtBackgroundImage";
            this.txtBackgroundImage.ReadOnly = true;
            this.txtBackgroundImage.Size = new System.Drawing.Size(278, 20);
            this.txtBackgroundImage.TabIndex = 39;
            // 
            // cmdFindImage
            // 
            this.cmdFindImage.Location = new System.Drawing.Point(997, 41);
            this.cmdFindImage.Name = "cmdFindImage";
            this.cmdFindImage.Size = new System.Drawing.Size(31, 22);
            this.cmdFindImage.TabIndex = 40;
            this.cmdFindImage.Text = "...";
            this.cmdFindImage.UseVisualStyleBackColor = true;
            this.cmdFindImage.Click += new System.EventHandler(this.cmdFindImage_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // pnlGraphicWindow
            // 
            this.pnlGraphicWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGraphicWindow.Location = new System.Drawing.Point(1065, 101);
            this.pnlGraphicWindow.Name = "pnlGraphicWindow";
            this.pnlGraphicWindow.Size = new System.Drawing.Size(651, 322);
            this.pnlGraphicWindow.TabIndex = 41;
            // 
            // frmRoomEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 560);
            this.Controls.Add(this.pnlGraphicWindow);
            this.Controls.Add(this.cmdFindImage);
            this.Controls.Add(this.txtBackgroundImage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.lblBuilding);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.lblBuildingName);
            this.Controls.Add(this.lstColourPicker);
            this.Controls.Add(this.lblRoomColour);
            this.Controls.Add(this.cmdCloneEnemy);
            this.Controls.Add(this.cmdCloneNPC);
            this.Controls.Add(this.cmdCloneItem);
            this.Controls.Add(this.cmdCloneEvent);
            this.Controls.Add(this.cmdRemoveNPC);
            this.Controls.Add(this.cmdAddNPC);
            this.Controls.Add(this.cmdRemoveEnemy);
            this.Controls.Add(this.cmdAddEnemy);
            this.Controls.Add(this.cmdRemoveEvent);
            this.Controls.Add(this.cmdAddEvent);
            this.Controls.Add(this.cmdRemoveItem);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.lstNPCs);
            this.Controls.Add(this.lstEnemies);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSuicide);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdFormHelp);
            this.Controls.Add(this.chkCanMove);
            this.Controls.Add(this.txtAltDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmdSaveClose);
            this.Controls.Add(this.lblEditing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRoomEditor";
            this.Text = "Room Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEditing;
        private System.Windows.Forms.Button cmdSaveClose;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAltDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCanMove;
        private System.Windows.Forms.Button cmdFormHelp;
        private System.Windows.Forms.TextBox txtSuicide;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstEnemies;
        private System.Windows.Forms.ListBox lstNPCs;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.Button cmdRemoveEvent;
        private System.Windows.Forms.Button cmdAddEvent;
        private System.Windows.Forms.Button cmdRemoveEnemy;
        private System.Windows.Forms.Button cmdAddEnemy;
        private System.Windows.Forms.Button cmdRemoveNPC;
        private System.Windows.Forms.Button cmdAddNPC;
        private System.Windows.Forms.Button cmdCloneEvent;
        private System.Windows.Forms.Button cmdCloneItem;
        private System.Windows.Forms.Button cmdCloneNPC;
        private System.Windows.Forms.Button cmdCloneEnemy;
        private System.Windows.Forms.Label lblRoomColour;
        private System.Windows.Forms.ComboBox lstColourPicker;
        private System.Windows.Forms.Label lblBuildingName;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBackgroundImage;
        private System.Windows.Forms.Button cmdFindImage;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.Panel pnlGraphicWindow;
    }
}