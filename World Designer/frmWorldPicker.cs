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
    public partial class frmWorldPicker : Form
    {
        string[] SavesList;

        public frmWorldPicker()
        {
            InitializeComponent();
            
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(".\\Worlds");
            int NumOfSaves = (dir.GetFiles().Length);

            SavesList = new string[NumOfSaves];
            int index = 0;

            if (NumOfSaves != 0)
            {
                foreach (FileInfo file in dir.GetFiles())    //Find games in saves directory
                {
                    string FileName = file.Name;
                    lstWorlds.Items.Add(string.Concat((FileName.Split('.')[0])));
                    SavesList[index] = FileName;
                    index++;
                }
            }
            else 
            {   
                lstWorlds.Items.Add("There are currentlty no Worlds to load");
                cmdLoadWorld.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain NewForm = new frmMain();
            NewForm.Show();
            this.Hide();
        }

        private void LoadWorld(int SelectedIndex)
        {
            frmWorldDesigner NewForm = new frmWorldDesigner(true, SavesList[SelectedIndex]);
            NewForm.Show();
            this.Hide();
        }

        private void cmdLoadWorld_Click(object sender, EventArgs e)
        {
            LoadWorld(lstWorlds.SelectedIndex);
        }

        private void lstWorlds_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstWorlds.SelectedIndex > -1)
            {
                LoadWorld(lstWorlds.SelectedIndex);
            }
        }
    }
}
