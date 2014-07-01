using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legend_Of_Drongo
{
    public partial class frmEndCredits : Form
    {
        public List<string> EndCredits = new List<string>();
        
        public frmEndCredits(string Author, List<string> ExistingCredits)
        {
            InitializeComponent();
            label2.Text = "World Designed by " + Author;

            rtbCredits.Clear();
            if (ExistingCredits != null && ExistingCredits.Count != 0)
            {
                foreach (string Credit in ExistingCredits)
                {
                    rtbCredits.AppendText(Credit);
                    rtbCredits.AppendText("\n");
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (rtbCredits.Text != string.Empty)
            {
                foreach (string Credit in rtbCredits.Lines)
                {
                    EndCredits.Add(Credit);
                }
            }
            this.Hide();
        }
    }
}
