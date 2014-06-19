namespace Legend_Of_Drongo
{
    partial class frmWorldPicker
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmdLoadWorld = new System.Windows.Forms.Button();
            this.lstWorlds = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdLoadWorld
            // 
            this.cmdLoadWorld.Location = new System.Drawing.Point(186, 364);
            this.cmdLoadWorld.Name = "cmdLoadWorld";
            this.cmdLoadWorld.Size = new System.Drawing.Size(168, 34);
            this.cmdLoadWorld.TabIndex = 1;
            this.cmdLoadWorld.Text = "Load World";
            this.cmdLoadWorld.UseVisualStyleBackColor = true;
            this.cmdLoadWorld.Click += new System.EventHandler(this.cmdLoadWorld_Click);
            // 
            // lstWorlds
            // 
            this.lstWorlds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWorlds.FormattingEnabled = true;
            this.lstWorlds.ItemHeight = 16;
            this.lstWorlds.Location = new System.Drawing.Point(12, 15);
            this.lstWorlds.Name = "lstWorlds";
            this.lstWorlds.Size = new System.Drawing.Size(341, 324);
            this.lstWorlds.TabIndex = 2;
            this.lstWorlds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstWorlds_MouseDoubleClick);
            // 
            // frmWorldPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 410);
            this.Controls.Add(this.lstWorlds);
            this.Controls.Add(this.cmdLoadWorld);
            this.Controls.Add(this.button1);
            this.Name = "frmWorldPicker";
            this.Text = "Choose A World";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdLoadWorld;
        private System.Windows.Forms.ListBox lstWorlds;
    }
}