namespace Legend_Of_Drongo
{
    partial class frmItemEditor
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
            this.cmdAddItems = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkPickup = new System.Windows.Forms.CheckBox();
            this.cmbItemClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInteraction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDamage = new System.Windows.Forms.TextBox();
            this.txtProtection = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGoodHit = new System.Windows.Forms.TextBox();
            this.txtMedHit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBadHit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItemNeeded = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtInteractionMessage = new System.Windows.Forms.TextBox();
            this.cmdCancelEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdAddItems
            // 
            this.cmdAddItems.Location = new System.Drawing.Point(104, 357);
            this.cmdAddItems.Name = "cmdAddItems";
            this.cmdAddItems.Size = new System.Drawing.Size(160, 28);
            this.cmdAddItems.TabIndex = 14;
            this.cmdAddItems.Text = "Save Item";
            this.cmdAddItems.UseVisualStyleBackColor = true;
            this.cmdAddItems.Click += new System.EventHandler(this.cmdAddItems_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Item Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Item Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 77);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(160, 74);
            this.txtDescription.TabIndex = 2;
            // 
            // chkPickup
            // 
            this.chkPickup.AutoSize = true;
            this.chkPickup.Location = new System.Drawing.Point(201, 24);
            this.chkPickup.Name = "chkPickup";
            this.chkPickup.Size = new System.Drawing.Size(140, 17);
            this.chkPickup.TabIndex = 1;
            this.chkPickup.Text = "Can Item be Picked up?";
            this.chkPickup.UseVisualStyleBackColor = true;
            // 
            // cmbItemClass
            // 
            this.cmbItemClass.FormattingEnabled = true;
            this.cmbItemClass.Items.AddRange(new object[] {
            "Armor-Helmet",
            "Armor-Chest",
            "Armor-Gloves",
            "Armor-Legs",
            "Armor-Boots",
            "Bed",
            "Drink",
            "Food",
            "Interaction Object",
            "Interactive Item",
            "Object",
            "Readable",
            "Weapon",
            "Unknown"});
            this.cmbItemClass.Location = new System.Drawing.Point(199, 77);
            this.cmbItemClass.Name = "cmbItemClass";
            this.cmbItemClass.Size = new System.Drawing.Size(160, 21);
            this.cmbItemClass.TabIndex = 3;
            this.cmbItemClass.TextChanged += new System.EventHandler(this.cmbItemClass_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Item Class";
            // 
            // txtInteraction
            // 
            this.txtInteraction.Location = new System.Drawing.Point(370, 21);
            this.txtInteraction.Multiline = true;
            this.txtInteraction.Name = "txtInteraction";
            this.txtInteraction.Size = new System.Drawing.Size(160, 130);
            this.txtInteraction.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Interaction Names";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(199, 131);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(160, 20);
            this.txtValue.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Damage";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Protection";
            // 
            // txtDamage
            // 
            this.txtDamage.Enabled = false;
            this.txtDamage.Location = new System.Drawing.Point(119, 161);
            this.txtDamage.Name = "txtDamage";
            this.txtDamage.Size = new System.Drawing.Size(28, 20);
            this.txtDamage.TabIndex = 6;
            // 
            // txtProtection
            // 
            this.txtProtection.Enabled = false;
            this.txtProtection.Location = new System.Drawing.Point(313, 161);
            this.txtProtection.Name = "txtProtection";
            this.txtProtection.Size = new System.Drawing.Size(28, 20);
            this.txtProtection.TabIndex = 7;
            // 
            // txtHP
            // 
            this.txtHP.Enabled = false;
            this.txtHP.Location = new System.Drawing.Point(502, 161);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(28, 20);
            this.txtHP.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "HP Recovery";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Good Hit";
            // 
            // txtGoodHit
            // 
            this.txtGoodHit.Enabled = false;
            this.txtGoodHit.Location = new System.Drawing.Point(67, 190);
            this.txtGoodHit.Name = "txtGoodHit";
            this.txtGoodHit.Size = new System.Drawing.Size(463, 20);
            this.txtGoodHit.TabIndex = 9;
            this.txtGoodHit.Text = "Hitting the enemy the weapon deals a good amount of damage";
            // 
            // txtMedHit
            // 
            this.txtMedHit.Enabled = false;
            this.txtMedHit.Location = new System.Drawing.Point(67, 216);
            this.txtMedHit.Name = "txtMedHit";
            this.txtMedHit.Size = new System.Drawing.Size(463, 20);
            this.txtMedHit.TabIndex = 10;
            this.txtMedHit.Text = "Hitting the enemy the weapon deals a medium amount of damage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Medium Hit";
            // 
            // txtBadHit
            // 
            this.txtBadHit.Enabled = false;
            this.txtBadHit.Location = new System.Drawing.Point(67, 242);
            this.txtBadHit.Name = "txtBadHit";
            this.txtBadHit.Size = new System.Drawing.Size(463, 20);
            this.txtBadHit.TabIndex = 11;
            this.txtBadHit.Text = "Barely hitting the enemy the weapon deals a bad amount of damage";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Bad Hit";
            // 
            // txtItemNeeded
            // 
            this.txtItemNeeded.Enabled = false;
            this.txtItemNeeded.Location = new System.Drawing.Point(166, 282);
            this.txtItemNeeded.Name = "txtItemNeeded";
            this.txtItemNeeded.Size = new System.Drawing.Size(175, 20);
            this.txtItemNeeded.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Item Needed To Interact";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Message When Interacted with";
            // 
            // txtInteractionMessage
            // 
            this.txtInteractionMessage.Enabled = false;
            this.txtInteractionMessage.Location = new System.Drawing.Point(166, 308);
            this.txtInteractionMessage.Name = "txtInteractionMessage";
            this.txtInteractionMessage.Size = new System.Drawing.Size(360, 20);
            this.txtInteractionMessage.TabIndex = 13;
            // 
            // cmdCancelEdit
            // 
            this.cmdCancelEdit.Location = new System.Drawing.Point(270, 357);
            this.cmdCancelEdit.Name = "cmdCancelEdit";
            this.cmdCancelEdit.Size = new System.Drawing.Size(160, 28);
            this.cmdCancelEdit.TabIndex = 15;
            this.cmdCancelEdit.Text = "Close Without Saving";
            this.cmdCancelEdit.UseVisualStyleBackColor = true;
            this.cmdCancelEdit.Click += new System.EventHandler(this.cmdCancelEdit_Click);
            // 
            // frmItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 397);
            this.Controls.Add(this.cmdCancelEdit);
            this.Controls.Add(this.txtInteractionMessage);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtItemNeeded);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBadHit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtMedHit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGoodHit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProtection);
            this.Controls.Add(this.txtDamage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInteraction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbItemClass);
            this.Controls.Add(this.chkPickup);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdAddItems);
            this.Name = "frmItemEditor";
            this.Text = "Item Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAddItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkPickup;
        private System.Windows.Forms.ComboBox cmbItemClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInteraction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDamage;
        private System.Windows.Forms.TextBox txtProtection;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGoodHit;
        private System.Windows.Forms.TextBox txtMedHit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBadHit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtItemNeeded;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtInteractionMessage;
        private System.Windows.Forms.Button cmdCancelEdit;
    }
}