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
    public partial class frmMusicPicker : Form
    {
        public string MusicPath;

        public frmMusicPicker()
        {
            InitializeComponent();
            label1.Text = "This form will allow you to select custom music for a floor. Music must be stored in the Music folder and must be .wav format.\n\nIf no music is specified the game will continue playing the last song";
            PopulateMusic();
        }

        public void PopulateMusic()
        {
            if (Directory.Exists(".\\Music"))
            {
                DirectoryInfo dir = new DirectoryInfo(".\\Music");
                int NumOfFiles = (dir.GetFiles().Length);

                int index = 0;
                lstMusicBox.Items.Clear();
                if (NumOfFiles > 0)
                {
                    foreach (FileInfo file in dir.GetFiles())    //Find games in saves directory
                    {
                        if (file.Name.Split('.')[(file.Name.Split('.').Length -1)].ToLower() == "wav") lstMusicBox.Items.Add(string.Concat((file.Name.Split('.')[0])));
                        index++;
                    }
                    if (index == 0) lstMusicBox.Items.Add("No .Wav files found");
                }
                else lstMusicBox.Items.Add("No files found, does Music folder contain files?");
            }
            else lstMusicBox.Items.Add("No files found, does Music folder exist?");
        }

        public bool SaveMusicItem()
        {
            if (lstMusicBox.SelectedIndex > -1)
            {
                DirectoryInfo dir = new DirectoryInfo(".\\Music");
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (file.Name.Split('.')[0] == lstMusicBox.Text) MusicPath = MusicPath = ".\\Music\\" + file.Name;
                }

                
                return true;
            }
            else MessageBox.Show("Please select a valid file first");
            return false;
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            if (SaveMusicItem()) this.Hide();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            PopulateMusic();
        }

        private void lstMusicBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SaveMusicItem()) this.Hide();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            MusicPath = string.Empty;
            this.Hide();
        }

    }
}
