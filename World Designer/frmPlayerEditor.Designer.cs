using System;
using System.Windows.Forms;
namespace Legend_Of_Drongo
{
    partial class frmPlayerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayerEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.lblInv = new System.Windows.Forms.Label();
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
            this.txtDefaultName = new SpellBox();
            this.lstInventory = new System.Windows.Forms.ListBox();
            this.txtObjective = new SpellBox();
            this.txtMoney = new SpellBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSpeed = new SpellBox();
            this.txtStrength = new SpellBox();
            this.txtResist = new SpellBox();
            this.txtHP = new SpellBox();
            this.txtMaxHP = new SpellBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtWeapon = new SpellBox();
            this.txtHelm = new SpellBox();
            this.txtChest = new SpellBox();
            this.txtFeet = new SpellBox();
            this.txtHands = new SpellBox();
            this.txtLegs = new SpellBox();
            this.cmdSaveChanges = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdCloneItem = new System.Windows.Forms.Button();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.cmbCol = new System.Windows.Forms.ComboBox();
            this.cmbRow = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMaxItems = new SpellBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default Name";
            // 
            // lblInv
            // 
            this.lblInv.AutoSize = true;
            this.lblInv.Location = new System.Drawing.Point(12, 32);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(65, 13);
            this.lblInv.TabIndex = 1;
            this.lblInv.Text = "Inventory 0/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Starting HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Starting Weapon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Helmet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hands";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Legs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Feet";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Chest";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Starting Objective";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(296, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Starting Money";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(55, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Speed";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(158, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Strength";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Max HP";
            // 
            // txtDefaultName
            // 
            this.txtDefaultName.Location = new System.Drawing.Point(90, 6);
            this.txtDefaultName.Name = "txtDefaultName";
            this.txtDefaultName.Size = new System.Drawing.Size(295, 20);
            this.txtDefaultName.TabIndex = 14;
            // 
            // lstInventory
            // 
            this.lstInventory.FormattingEnabled = true;
            this.lstInventory.Location = new System.Drawing.Point(15, 48);
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(345, 82);
            this.lstInventory.TabIndex = 15;
            this.lstInventory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstInventory_MouseDoubleClick);
            // 
            // txtObjective
            // 
            this.txtObjective.Location = new System.Drawing.Point(111, 152);
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.Size = new System.Drawing.Size(159, 20);
            this.txtObjective.TabIndex = 16;
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(380, 152);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(30, 20);
            this.txtMoney.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(264, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Resistence";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(99, 205);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(30, 20);
            this.txtSpeed.TabIndex = 19;
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(211, 205);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(30, 20);
            this.txtStrength.TabIndex = 20;
            // 
            // txtResist
            // 
            this.txtResist.Location = new System.Drawing.Point(330, 205);
            this.txtResist.Name = "txtResist";
            this.txtResist.Size = new System.Drawing.Size(30, 20);
            this.txtResist.TabIndex = 21;
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(175, 238);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(30, 20);
            this.txtHP.TabIndex = 22;
            // 
            // txtMaxHP
            // 
            this.txtMaxHP.Location = new System.Drawing.Point(275, 238);
            this.txtMaxHP.Name = "txtMaxHP";
            this.txtMaxHP.Size = new System.Drawing.Size(30, 20);
            this.txtMaxHP.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(122, 279);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // txtWeapon
            // 
            this.txtWeapon.BackColor = System.Drawing.Color.White;
            this.txtWeapon.Location = new System.Drawing.Point(314, 364);
            this.txtWeapon.Name = "txtWeapon";
            this.txtWeapon.Enabled = true;
            this.txtWeapon.ReadOnly = true;
            this.txtWeapon.Size = new System.Drawing.Size(111, 20);
            this.txtWeapon.TabIndex = 25;
            this.txtWeapon.MouseDoubleClickHandler += new MouseEventHandler(this.txtWeapon_MouseDoubleClick);
            // 
            // txtHelm
            // 
            this.txtHelm.BackColor = System.Drawing.Color.White;
            this.txtHelm.Location = new System.Drawing.Point(5, 313);
            this.txtHelm.Name = "txtHelm";
            this.txtHelm.Enabled = true;
            this.txtHelm.ReadOnly = true;
            this.txtHelm.Size = new System.Drawing.Size(111, 20);
            this.txtHelm.TabIndex = 27;
            this.txtHelm.MouseDoubleClickHandler += new MouseEventHandler(this.txtHelm_MouseDoubleClick);
            // 
            // txtChest
            // 
            this.txtChest.BackColor = System.Drawing.Color.White;
            this.txtChest.Location = new System.Drawing.Point(5, 376);
            this.txtChest.Name = "txtChest";
            this.txtChest.Enabled = true;
            this.txtChest.ReadOnly = true;
            this.txtChest.Size = new System.Drawing.Size(111, 20);
            this.txtChest.TabIndex = 28;
            this.txtChest.MouseDoubleClickHandler += new MouseEventHandler(this.txtChest_MouseDoubleClick);
            // 
            // txtFeet
            // 
            this.txtFeet.BackColor = System.Drawing.Color.White;
            this.txtFeet.Location = new System.Drawing.Point(5, 444);
            this.txtFeet.Name = "txtFeet";
            this.txtFeet.Enabled = true;
            this.txtFeet.ReadOnly = true;
            this.txtFeet.Size = new System.Drawing.Size(111, 20);
            this.txtFeet.TabIndex = 29;
            this.txtFeet.MouseDoubleClickHandler += new MouseEventHandler(this.txtFeet_MouseDoubleClick);
            // 
            // txtHands
            // 
            this.txtHands.BackColor = System.Drawing.Color.White;
            this.txtHands.Location = new System.Drawing.Point(311, 297);
            this.txtHands.Name = "txtHands";
            this.txtHands.Enabled = true;
            this.txtHands.ReadOnly = true;
            this.txtHands.Size = new System.Drawing.Size(111, 20);
            this.txtHands.TabIndex = 30;
            this.txtHands.MouseDoubleClickHandler += new MouseEventHandler(this.txtHands_MouseDoubleClick);
            // 
            // txtLegs
            // 
            this.txtLegs.BackColor = System.Drawing.Color.White;
            this.txtLegs.Location = new System.Drawing.Point(314, 431);
            this.txtLegs.Name = "txtLegs";
            this.txtLegs.Enabled = true;
            this.txtLegs.ReadOnly = true;
            this.txtLegs.Size = new System.Drawing.Size(111, 20);
            this.txtLegs.TabIndex = 31;
            this.txtLegs.MouseDoubleClickHandler += new MouseEventHandler(this.txtLegs_MouseDoubleClick);
            // 
            // cmdSaveChanges
            // 
            this.cmdSaveChanges.Location = new System.Drawing.Point(62, 489);
            this.cmdSaveChanges.Name = "cmdSaveChanges";
            this.cmdSaveChanges.Size = new System.Drawing.Size(107, 27);
            this.cmdSaveChanges.TabIndex = 32;
            this.cmdSaveChanges.Text = "Save Player";
            this.cmdSaveChanges.UseVisualStyleBackColor = true;
            this.cmdSaveChanges.Click += new System.EventHandler(this.cmdSaveChanges_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(175, 489);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(110, 27);
            this.cmdReset.TabIndex = 33;
            this.cmdReset.Text = "Reset to Default";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdCloneItem
            // 
            this.cmdCloneItem.Location = new System.Drawing.Point(366, 76);
            this.cmdCloneItem.Name = "cmdCloneItem";
            this.cmdCloneItem.Size = new System.Drawing.Size(19, 22);
            this.cmdCloneItem.TabIndex = 36;
            this.cmdCloneItem.Text = "||";
            this.cmdCloneItem.UseVisualStyleBackColor = true;
            this.cmdCloneItem.Click += new System.EventHandler(this.cmdCloneItem_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(366, 104);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(19, 22);
            this.cmdRemoveItem.TabIndex = 35;
            this.cmdRemoveItem.Text = "-";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(366, 48);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(19, 22);
            this.cmdAddItem.TabIndex = 34;
            this.cmdAddItem.Text = "+";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(291, 489);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(119, 27);
            this.cmdClose.TabIndex = 33;
            this.cmdClose.Text = "Close Without Saving";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmbFloor
            // 
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(263, 177);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(69, 21);
            this.cmbFloor.TabIndex = 39;
            this.cmbFloor.Text = "Level 1";
            // 
            // cmbCol
            // 
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
            this.cmbCol.Location = new System.Drawing.Point(188, 177);
            this.cmbCol.Name = "cmbCol";
            this.cmbCol.Size = new System.Drawing.Size(69, 21);
            this.cmbCol.TabIndex = 38;
            this.cmbCol.Text = "Col";
            // 
            // cmbRow
            // 
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
            this.cmbRow.Location = new System.Drawing.Point(111, 177);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Size = new System.Drawing.Size(69, 21);
            this.cmbRow.TabIndex = 37;
            this.cmbRow.Text = "Row";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Starting Position";
            // 
            // txtMaxItems
            // 
            this.txtMaxItems.Location = new System.Drawing.Point(76, 32);
            this.txtMaxItems.Multiline = true;
            this.txtMaxItems.Name = "txtMaxItems";
            this.txtMaxItems.Size = new System.Drawing.Size(22, 13);
            this.txtMaxItems.TabIndex = 42;
            this.txtMaxItems.Text = "20";
            // 
            // frmPlayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 528);
            this.Controls.Add(this.txtMaxItems);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbFloor);
            this.Controls.Add(this.cmbCol);
            this.Controls.Add(this.cmbRow);
            this.Controls.Add(this.cmdCloneItem);
            this.Controls.Add(this.cmdRemoveItem);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSaveChanges);
            this.Controls.Add(this.txtLegs);
            this.Controls.Add(this.txtHands);
            this.Controls.Add(this.txtFeet);
            this.Controls.Add(this.txtChest);
            this.Controls.Add(this.txtHelm);
            this.Controls.Add(this.txtWeapon);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtMaxHP);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtResist);
            this.Controls.Add(this.txtStrength);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.txtObjective);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.txtDefaultName);
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
            this.Controls.Add(this.lblInv);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlayerEditor";
            this.Text = "Player Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInv;
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
        private SpellBox txtDefaultName;
        private System.Windows.Forms.ListBox lstInventory;
        private SpellBox txtObjective;
        private SpellBox txtMoney;
        private System.Windows.Forms.Label label15;
        private SpellBox txtSpeed;
        private SpellBox txtStrength;
        private SpellBox txtResist;
        private SpellBox txtHP;
        private SpellBox txtMaxHP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private SpellBox txtWeapon;
        private SpellBox txtHelm;
        private SpellBox txtChest;
        private SpellBox txtFeet;
        private SpellBox txtHands;
        private SpellBox txtLegs;
        private System.Windows.Forms.Button cmdSaveChanges;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdCloneItem;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.ComboBox cmbCol;
        private System.Windows.Forms.ComboBox cmbRow;
        private System.Windows.Forms.Label label16;
        private SpellBox txtMaxItems;
    }
}