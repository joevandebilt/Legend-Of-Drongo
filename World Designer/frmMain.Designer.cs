namespace Legend_Of_Drongo
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdLoadWorld = new System.Windows.Forms.Button();
            this.cmdNewWorld = new System.Windows.Forms.Button();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdLoadWorld
            // 
            this.cmdLoadWorld.Location = new System.Drawing.Point(287, 114);
            this.cmdLoadWorld.Name = "cmdLoadWorld";
            this.cmdLoadWorld.Size = new System.Drawing.Size(132, 60);
            this.cmdLoadWorld.TabIndex = 0;
            this.cmdLoadWorld.Text = "Load World";
            this.cmdLoadWorld.UseVisualStyleBackColor = true;
            this.cmdLoadWorld.Click += new System.EventHandler(this.cmdLoadWorld_Click);
            // 
            // cmdNewWorld
            // 
            this.cmdNewWorld.Location = new System.Drawing.Point(287, 12);
            this.cmdNewWorld.Name = "cmdNewWorld";
            this.cmdNewWorld.Size = new System.Drawing.Size(132, 60);
            this.cmdNewWorld.TabIndex = 1;
            this.cmdNewWorld.Text = "New World";
            this.cmdNewWorld.UseVisualStyleBackColor = true;
            this.cmdNewWorld.Click += new System.EventHandler(this.cmdNewWorld_Click);
            // 
            // cmdQuit
            // 
            this.cmdQuit.Location = new System.Drawing.Point(287, 208);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(132, 60);
            this.cmdQuit.TabIndex = 2;
            this.cmdQuit.Text = "Quit";
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(444, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 250);
            this.label1.TabIndex = 4;
            this.label1.Text = "The Legend of Drongo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 303);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdQuit);
            this.Controls.Add(this.cmdNewWorld);
            this.Controls.Add(this.cmdLoadWorld);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "LoD World Designer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdLoadWorld;
        private System.Windows.Forms.Button cmdNewWorld;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

