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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void cmdNewWorld_Click(object sender, EventArgs e)
        {
            frmWorldDesigner NewForm = new frmWorldDesigner(false, string.Empty);
            NewForm.Show();
            this.Hide();

        }

        private void cmdLoadWorld_Click(object sender, EventArgs e)
        {
            frmWorldPicker NewForm = new frmWorldPicker();
            NewForm.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            label1.Text = "The Legend of Drongo has been built and designed by Joe van de Bilt\n\nThis world editor is free to use in conjunction with the World of Drongo game engine.\n\nThe Software can be distributed as you please but please remember to give credit to the creator wherever applicable.\n\nKind regards,\nJoe van de Bilt";
        }
    }
}
