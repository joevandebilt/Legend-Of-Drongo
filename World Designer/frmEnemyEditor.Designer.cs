﻿namespace Legend_Of_Drongo
{
    partial class frmEnemyEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnemyEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWeapon = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtArmor = new System.Windows.Forms.TextBox();
            this.txtKill = new System.Windows.Forms.TextBox();
            this.txtDeath = new System.Windows.Forms.TextBox();
            this.txtPayOff = new System.Windows.Forms.TextBox();
            this.txtPayOffResponse = new System.Windows.Forms.TextBox();
            this.cmdItemInspect = new System.Windows.Forms.Button();
            this.cmdSaveEnemy = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtXP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.txtTeam = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBehaviour = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Weapon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Armor %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Pay Off Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kill Message";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Death Message";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Pay Off Response";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(67, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtWeapon
            // 
            this.txtWeapon.Location = new System.Drawing.Point(67, 34);
            this.txtWeapon.Name = "txtWeapon";
            this.txtWeapon.ReadOnly = true;
            this.txtWeapon.Size = new System.Drawing.Size(189, 20);
            this.txtWeapon.TabIndex = 1;
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(56, 60);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(38, 20);
            this.txtHP.TabIndex = 3;
            // 
            // txtArmor
            // 
            this.txtArmor.Location = new System.Drawing.Point(164, 60);
            this.txtArmor.Name = "txtArmor";
            this.txtArmor.Size = new System.Drawing.Size(38, 20);
            this.txtArmor.TabIndex = 4;
            // 
            // txtKill
            // 
            this.txtKill.Location = new System.Drawing.Point(12, 164);
            this.txtKill.Multiline = true;
            this.txtKill.Name = "txtKill";
            this.txtKill.Size = new System.Drawing.Size(271, 50);
            this.txtKill.TabIndex = 7;
            // 
            // txtDeath
            // 
            this.txtDeath.Location = new System.Drawing.Point(12, 252);
            this.txtDeath.Multiline = true;
            this.txtDeath.Name = "txtDeath";
            this.txtDeath.Size = new System.Drawing.Size(271, 50);
            this.txtDeath.TabIndex = 8;
            // 
            // txtPayOff
            // 
            this.txtPayOff.Location = new System.Drawing.Point(87, 333);
            this.txtPayOff.Name = "txtPayOff";
            this.txtPayOff.Size = new System.Drawing.Size(38, 20);
            this.txtPayOff.TabIndex = 9;
            // 
            // txtPayOffResponse
            // 
            this.txtPayOffResponse.Location = new System.Drawing.Point(108, 361);
            this.txtPayOffResponse.Name = "txtPayOffResponse";
            this.txtPayOffResponse.Size = new System.Drawing.Size(175, 20);
            this.txtPayOffResponse.TabIndex = 10;
            // 
            // cmdItemInspect
            // 
            this.cmdItemInspect.Location = new System.Drawing.Point(262, 32);
            this.cmdItemInspect.Name = "cmdItemInspect";
            this.cmdItemInspect.Size = new System.Drawing.Size(25, 22);
            this.cmdItemInspect.TabIndex = 2;
            this.cmdItemInspect.Text = "...";
            this.cmdItemInspect.UseVisualStyleBackColor = true;
            this.cmdItemInspect.Click += new System.EventHandler(this.cmdItemInspect_Click);
            // 
            // cmdSaveEnemy
            // 
            this.cmdSaveEnemy.Location = new System.Drawing.Point(12, 402);
            this.cmdSaveEnemy.Name = "cmdSaveEnemy";
            this.cmdSaveEnemy.Size = new System.Drawing.Size(101, 27);
            this.cmdSaveEnemy.TabIndex = 11;
            this.cmdSaveEnemy.Text = "Save Enemy";
            this.cmdSaveEnemy.UseVisualStyleBackColor = true;
            this.cmdSaveEnemy.Click += new System.EventHandler(this.cmdSaveEnemy_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(162, 402);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(121, 27);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Close Without Saving";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Money";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(249, 86);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(38, 20);
            this.txtMoney.TabIndex = 5;
            // 
            // txtXP
            // 
            this.txtXP.Location = new System.Drawing.Point(249, 60);
            this.txtXP.Name = "txtXP";
            this.txtXP.Size = new System.Drawing.Size(38, 20);
            this.txtXP.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "XP";
            // 
            // cmdHelp
            // 
            this.cmdHelp.Location = new System.Drawing.Point(119, 401);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(37, 28);
            this.cmdHelp.TabIndex = 42;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // txtTeam
            // 
            this.txtTeam.Location = new System.Drawing.Point(56, 86);
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.Size = new System.Drawing.Size(38, 20);
            this.txtTeam.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Team";
            // 
            // cmbBehaviour
            // 
            this.cmbBehaviour.FormattingEnabled = true;
            this.cmbBehaviour.Location = new System.Drawing.Point(67, 112);
            this.cmbBehaviour.Name = "cmbBehaviour";
            this.cmbBehaviour.Size = new System.Drawing.Size(220, 21);
            this.cmbBehaviour.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Behaviour";
            // 
            // frmEnemyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 441);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbBehaviour);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.txtXP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSaveEnemy);
            this.Controls.Add(this.cmdItemInspect);
            this.Controls.Add(this.txtPayOffResponse);
            this.Controls.Add(this.txtPayOff);
            this.Controls.Add(this.txtDeath);
            this.Controls.Add(this.txtKill);
            this.Controls.Add(this.txtArmor);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtWeapon);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEnemyEditor";
            this.Text = "Enemy Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtWeapon;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.TextBox txtArmor;
        private System.Windows.Forms.TextBox txtKill;
        private System.Windows.Forms.TextBox txtDeath;
        private System.Windows.Forms.TextBox txtPayOff;
        private System.Windows.Forms.TextBox txtPayOffResponse;
        private System.Windows.Forms.Button cmdItemInspect;
        private System.Windows.Forms.Button cmdSaveEnemy;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtXP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.TextBox txtTeam;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBehaviour;
        private System.Windows.Forms.Label label12;
    }
}