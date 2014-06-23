namespace Legend_Of_Drongo
{
    partial class frmMusicPicker
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
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lstMusicBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(12, 350);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(102, 22);
            this.cmdSelect.TabIndex = 0;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(120, 350);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(102, 22);
            this.cmdRefresh.TabIndex = 1;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(228, 350);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(102, 22);
            this.cmdBack.TabIndex = 2;
            this.cmdBack.Text = "Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lstMusicBox
            // 
            this.lstMusicBox.FormattingEnabled = true;
            this.lstMusicBox.Location = new System.Drawing.Point(12, 8);
            this.lstMusicBox.Name = "lstMusicBox";
            this.lstMusicBox.Size = new System.Drawing.Size(317, 251);
            this.lstMusicBox.TabIndex = 3;
            this.lstMusicBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMusicBox_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 75);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // frmMusicPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMusicBox);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdSelect);
            this.Name = "frmMusicPicker";
            this.Text = "Music Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.ListBox lstMusicBox;
        private System.Windows.Forms.Label label1;
    }
}