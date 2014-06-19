namespace Legend_Of_Drongo
{
    partial class frmNPCEditor
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSaveNPC = new System.Windows.Forms.Button();
            this.txtTalkTo = new System.Windows.Forms.TextBox();
            this.txtArmor = new System.Windows.Forms.TextBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWillBuy = new System.Windows.Forms.CheckBox();
            this.chkWillSell = new System.Windows.Forms.CheckBox();
            this.chkPlot = new System.Windows.Forms.CheckBox();
            this.cmbMerchType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstInventory = new System.Windows.Forms.ListBox();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.cmdRemoveKnowledge = new System.Windows.Forms.Button();
            this.cmdAddKnowledge = new System.Windows.Forms.Button();
            this.lstKnowledge = new System.Windows.Forms.ListBox();
            this.txtKnowledge = new System.Windows.Forms.TextBox();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSaveKnowledge = new System.Windows.Forms.Button();
            this.cmdCloneItem = new System.Windows.Forms.Button();
            this.cmdCloneKnowledge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(169, 312);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(121, 27);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "Close Without Saving";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSaveNPC
            // 
            this.cmdSaveNPC.Location = new System.Drawing.Point(34, 312);
            this.cmdSaveNPC.Name = "cmdSaveNPC";
            this.cmdSaveNPC.Size = new System.Drawing.Size(121, 27);
            this.cmdSaveNPC.TabIndex = 18;
            this.cmdSaveNPC.Text = "Save NPC";
            this.cmdSaveNPC.UseVisualStyleBackColor = true;
            this.cmdSaveNPC.Click += new System.EventHandler(this.cmdSaveNPC_Click);
            // 
            // txtTalkTo
            // 
            this.txtTalkTo.Location = new System.Drawing.Point(12, 74);
            this.txtTalkTo.Multiline = true;
            this.txtTalkTo.Name = "txtTalkTo";
            this.txtTalkTo.Size = new System.Drawing.Size(271, 50);
            this.txtTalkTo.TabIndex = 5;
            // 
            // txtArmor
            // 
            this.txtArmor.Location = new System.Drawing.Point(558, 18);
            this.txtArmor.Name = "txtArmor";
            this.txtArmor.Size = new System.Drawing.Size(38, 20);
            this.txtArmor.TabIndex = 3;
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(425, 58);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(39, 20);
            this.txtMoney.TabIndex = 4;
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(425, 22);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(38, 20);
            this.txtHP.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 20);
            this.txtName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Talk To Response";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Armor %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Money";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "HP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            // 
            // chkWillBuy
            // 
            this.chkWillBuy.AutoSize = true;
            this.chkWillBuy.Location = new System.Drawing.Point(16, 166);
            this.chkWillBuy.Name = "chkWillBuy";
            this.chkWillBuy.Size = new System.Drawing.Size(150, 17);
            this.chkWillBuy.TabIndex = 7;
            this.chkWillBuy.Text = "Will Buy Items From Player";
            this.chkWillBuy.UseVisualStyleBackColor = true;
            // 
            // chkWillSell
            // 
            this.chkWillSell.AutoSize = true;
            this.chkWillSell.Location = new System.Drawing.Point(16, 189);
            this.chkWillSell.Name = "chkWillSell";
            this.chkWillSell.Size = new System.Drawing.Size(139, 17);
            this.chkWillSell.TabIndex = 8;
            this.chkWillSell.Text = "Will Sell Items To Player";
            this.chkWillSell.UseVisualStyleBackColor = true;
            // 
            // chkPlot
            // 
            this.chkPlot.AutoSize = true;
            this.chkPlot.Location = new System.Drawing.Point(248, 25);
            this.chkPlot.Name = "chkPlot";
            this.chkPlot.Size = new System.Drawing.Size(93, 17);
            this.chkPlot.TabIndex = 1;
            this.chkPlot.Text = "Plot Character";
            this.chkPlot.UseVisualStyleBackColor = true;
            // 
            // cmbMerchType
            // 
            this.cmbMerchType.FormattingEnabled = true;
            this.cmbMerchType.Items.AddRange(new object[] {
            "All",
            "Armor",
            "Food",
            "None",
            "Object",
            "Readable",
            "Weapons"});
            this.cmbMerchType.Location = new System.Drawing.Point(98, 136);
            this.cmbMerchType.Name = "cmbMerchType";
            this.cmbMerchType.Size = new System.Drawing.Size(138, 21);
            this.cmbMerchType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Merchant Type";
            // 
            // lstInventory
            // 
            this.lstInventory.FormattingEnabled = true;
            this.lstInventory.Location = new System.Drawing.Point(16, 211);
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(287, 82);
            this.lstInventory.TabIndex = 9;
            this.lstInventory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstInventory_MouseDoubleClick);
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(309, 211);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(36, 24);
            this.cmdAddItem.TabIndex = 10;
            this.cmdAddItem.Text = "+";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(309, 269);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(36, 24);
            this.cmdRemoveItem.TabIndex = 11;
            this.cmdRemoveItem.Text = "-";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // cmdRemoveKnowledge
            // 
            this.cmdRemoveKnowledge.Location = new System.Drawing.Point(641, 269);
            this.cmdRemoveKnowledge.Name = "cmdRemoveKnowledge";
            this.cmdRemoveKnowledge.Size = new System.Drawing.Size(41, 24);
            this.cmdRemoveKnowledge.TabIndex = 13;
            this.cmdRemoveKnowledge.Text = "-";
            this.cmdRemoveKnowledge.UseVisualStyleBackColor = true;
            this.cmdRemoveKnowledge.Click += new System.EventHandler(this.cmdRemoveKnowledge_Click);
            // 
            // cmdAddKnowledge
            // 
            this.cmdAddKnowledge.Location = new System.Drawing.Point(641, 211);
            this.cmdAddKnowledge.Name = "cmdAddKnowledge";
            this.cmdAddKnowledge.Size = new System.Drawing.Size(41, 24);
            this.cmdAddKnowledge.TabIndex = 12;
            this.cmdAddKnowledge.Text = "+";
            this.cmdAddKnowledge.UseVisualStyleBackColor = true;
            this.cmdAddKnowledge.Click += new System.EventHandler(this.cmdAddKnowledge_Click);
            // 
            // lstKnowledge
            // 
            this.lstKnowledge.FormattingEnabled = true;
            this.lstKnowledge.Location = new System.Drawing.Point(351, 211);
            this.lstKnowledge.Name = "lstKnowledge";
            this.lstKnowledge.Size = new System.Drawing.Size(287, 82);
            this.lstKnowledge.TabIndex = 14;
            this.lstKnowledge.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstKnowledge_MouseClick);
            // 
            // txtKnowledge
            // 
            this.txtKnowledge.Enabled = false;
            this.txtKnowledge.Location = new System.Drawing.Point(352, 169);
            this.txtKnowledge.Multiline = true;
            this.txtKnowledge.Name = "txtKnowledge";
            this.txtKnowledge.Size = new System.Drawing.Size(286, 36);
            this.txtKnowledge.TabIndex = 16;
            // 
            // txtTopic
            // 
            this.txtTopic.Enabled = false;
            this.txtTopic.Location = new System.Drawing.Point(352, 126);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(286, 20);
            this.txtTopic.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Topic";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Knowledge";
            // 
            // cmdSaveKnowledge
            // 
            this.cmdSaveKnowledge.Location = new System.Drawing.Point(641, 166);
            this.cmdSaveKnowledge.Name = "cmdSaveKnowledge";
            this.cmdSaveKnowledge.Size = new System.Drawing.Size(41, 39);
            this.cmdSaveKnowledge.TabIndex = 17;
            this.cmdSaveKnowledge.Text = "Save";
            this.cmdSaveKnowledge.UseVisualStyleBackColor = true;
            this.cmdSaveKnowledge.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmdCloneItem
            // 
            this.cmdCloneItem.Location = new System.Drawing.Point(309, 240);
            this.cmdCloneItem.Name = "cmdCloneItem";
            this.cmdCloneItem.Size = new System.Drawing.Size(36, 24);
            this.cmdCloneItem.TabIndex = 57;
            this.cmdCloneItem.Text = "||";
            this.cmdCloneItem.UseVisualStyleBackColor = true;
            this.cmdCloneItem.Click += new System.EventHandler(this.cmdCloneItem_Click);
            // 
            // cmdCloneKnowledge
            // 
            this.cmdCloneKnowledge.Location = new System.Drawing.Point(641, 241);
            this.cmdCloneKnowledge.Name = "cmdCloneKnowledge";
            this.cmdCloneKnowledge.Size = new System.Drawing.Size(41, 24);
            this.cmdCloneKnowledge.TabIndex = 58;
            this.cmdCloneKnowledge.Text = "||";
            this.cmdCloneKnowledge.UseVisualStyleBackColor = true;
            this.cmdCloneKnowledge.Click += new System.EventHandler(this.cmdCloneKnowledge_Click);
            // 
            // frmNPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 363);
            this.Controls.Add(this.cmdCloneKnowledge);
            this.Controls.Add(this.cmdCloneItem);
            this.Controls.Add(this.cmdSaveKnowledge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTopic);
            this.Controls.Add(this.txtKnowledge);
            this.Controls.Add(this.cmdRemoveKnowledge);
            this.Controls.Add(this.cmdAddKnowledge);
            this.Controls.Add(this.lstKnowledge);
            this.Controls.Add(this.cmdRemoveItem);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMerchType);
            this.Controls.Add(this.chkPlot);
            this.Controls.Add(this.chkWillSell);
            this.Controls.Add(this.chkWillBuy);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSaveNPC);
            this.Controls.Add(this.txtTalkTo);
            this.Controls.Add(this.txtArmor);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmNPCEditor";
            this.Text = "NPC Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSaveNPC;
        private System.Windows.Forms.TextBox txtTalkTo;
        private System.Windows.Forms.TextBox txtArmor;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWillBuy;
        private System.Windows.Forms.CheckBox chkWillSell;
        private System.Windows.Forms.CheckBox chkPlot;
        private System.Windows.Forms.ComboBox cmbMerchType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstInventory;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.Button cmdRemoveKnowledge;
        private System.Windows.Forms.Button cmdAddKnowledge;
        private System.Windows.Forms.ListBox lstKnowledge;
        private System.Windows.Forms.TextBox txtKnowledge;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdSaveKnowledge;
        private System.Windows.Forms.Button cmdCloneItem;
        private System.Windows.Forms.Button cmdCloneKnowledge;
    }
}