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
            this.label2.Location = new System.Drawing.Point(292, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Then";
            // 
            // cmbTrigger
            // 
            this.cmbTrigger.FormattingEnabled = true;
            this.cmbTrigger.Location = new System.Drawing.Point(86, 23);
            this.cmbTrigger.Name = "cmbTrigger";
            this.cmbTrigger.Size = new System.Drawing.Size(200, 21);
            this.cmbTrigger.TabIndex = 3;
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(330, 22);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(197, 21);
            this.cmbAction.TabIndex = 4;
            this.cmbAction.TextChanged += new System.EventHandler(this.cmbAction_TextChanged);
            // 
            // cmdSaveEvent
            // 
            this.cmdSaveEvent.Location = new System.Drawing.Point(86, 75);
            this.cmdSaveEvent.Name = "cmdSaveEvent";
            this.cmdSaveEvent.Size = new System.Drawing.Size(108, 24);
            this.cmdSaveEvent.TabIndex = 8;
            this.cmdSaveEvent.Text = "Save";
            this.cmdSaveEvent.UseVisualStyleBackColor = true;
            this.cmdSaveEvent.Click += new System.EventHandler(this.cmdSaveEvent_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(200, 75);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(108, 24);
            this.cmdCancel.TabIndex = 9;
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
            this.cmbRow.Location = new System.Drawing.Point(533, 22);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Size = new System.Drawing.Size(69, 21);
            this.cmbRow.TabIndex = 10;
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
            this.cmbCol.Location = new System.Drawing.Point(533, 49);
            this.cmbCol.Name = "cmbCol";
            this.cmbCol.Size = new System.Drawing.Size(69, 21);
            this.cmbCol.TabIndex = 11;
            this.cmbCol.Text = "Col";
            // 
            // cmbFloor
            // 
            this.cmbFloor.Enabled = false;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(533, 75);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(69, 21);
            this.cmbFloor.TabIndex = 12;
            this.cmbFloor.Text = "Level 1";
            // 
            // frmEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 113);
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
    }
}