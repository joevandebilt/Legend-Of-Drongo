using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Legend_Of_Drongo
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();

            using (StreamReader file = new System.IO.StreamReader(@".\System Files\WorldEditHelp.sys", true))
            {
                rtbHelp.Text = file.ReadToEnd();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
