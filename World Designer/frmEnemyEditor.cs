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
    public partial class frmEnemyEditor : Form
    {
        public DataTypes.EnemyProfile Enemy;
        public bool ChangeMade;
        public struct Behaviour
        {
            public string ShortDesc;
            public string LongDesc;
        }
        List<Behaviour> EnemyBehaviour = new List<Behaviour>();

        public frmEnemyEditor(DataTypes.EnemyProfile ThisEnemy)
        {
            InitializeComponent();
            ChangeMade = false;

            Behaviour Behaviour = new Behaviour();
            Behaviour.ShortDesc = "AttackPlayer";
            Behaviour.LongDesc = "Always Attack Player";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackBestDamage";
            Behaviour.LongDesc = "Attack Enemy who deals most Damage";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackWorstDamage";
            Behaviour.LongDesc = "Attack Enemy who deals least Damage";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackStrongDefense";
            Behaviour.LongDesc = "Attack Enemy who has most Armor";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackWeakDefense";
            Behaviour.LongDesc = "Attack Enemy who has least Armor";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackMostHP";
            Behaviour.LongDesc = "Attack Enemy who has most HP";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackLeastHP";
            Behaviour.LongDesc = "Attack Enemy who has least HP";
            EnemyBehaviour.Add(Behaviour);
            Behaviour.ShortDesc = "AttackRandom";
            Behaviour.LongDesc = "Attack and Enemy at Random";
            EnemyBehaviour.Add(Behaviour);

            Enemy = ThisEnemy;
            PopulateEnemy();
        }

        public void PopulateEnemy()
        {
            if (Enemy.name != null) txtName.Text = Enemy.name;
            if (Enemy.Weapon.Name != null) txtWeapon.Text = Enemy.Weapon.Name;

            txtHP.Text = Enemy.HPBonus.ToString();
            txtArmor.Text = Enemy.armor.ToString();
            txtMoney.Text = Enemy.Money.ToString();
            txtXP.Text = Enemy.XP.ToString();
            txtTeam.Text = Enemy.Team.ToString();

            string LongDesc = string.Empty;

            foreach (Behaviour item in EnemyBehaviour) 
            { 
                cmbBehaviour.Items.Add(item.LongDesc);
                if (Enemy.Behaviour != null && Enemy.Behaviour == item.ShortDesc) LongDesc = item.LongDesc;
            }

            if (LongDesc != string.Empty) cmbBehaviour.SelectedIndex = cmbBehaviour.FindString(LongDesc);
            else cmbBehaviour.SelectedIndex = 0;

            if (Enemy.KillMessage != null) txtKill.Text = Enemy.KillMessage;
            if (Enemy.DeathMessage != null) txtDeath.Text = Enemy.DeathMessage;
            

            txtPayOff.Text = Enemy.PayOff.ToString();
            if (Enemy.PayOffResponse != null) txtPayOffResponse.Text = Enemy.PayOffResponse;

            if (!string.IsNullOrEmpty(Enemy.ImagePath)) txtImagePath.Text = Enemy.ImagePath;
            txtImageLocation.Text = Enemy.ImageLocation.ToString();
        }

        public bool SaveEnemy()
        {
            if (txtName.Text != string.Empty) Enemy.name = txtName.Text;
            else return false;
            if (txtKill.Text != string.Empty) Enemy.KillMessage = txtKill.Text;
            if (txtDeath.Text != string.Empty) Enemy.DeathMessage = txtDeath.Text;
            else return false;
            if (txtPayOffResponse.Text != string.Empty) Enemy.PayOffResponse = txtPayOffResponse.Text;

            if (cmbBehaviour.SelectedIndex > -1) Enemy.Behaviour = EnemyBehaviour[cmbBehaviour.SelectedIndex].ShortDesc;
            else return false;

            int n;
            double d;
            if (double.TryParse(txtHP.Text, out d)) Enemy.HPBonus = d;
            else return false;
            if (int.TryParse(txtArmor.Text, out n)) Enemy.armor= n;
            else return false;
            if (int.TryParse(txtMoney.Text, out n)) Enemy.Money = n;
            else return false;
            if (int.TryParse(txtXP.Text, out n)) Enemy.XP = n;
            else return false;
            if (int.TryParse(txtPayOff.Text, out n)) Enemy.PayOff = n;
            else return false;
            if (int.TryParse(txtTeam.Text, out n)) Enemy.Team = n;

            if (!string.IsNullOrEmpty(txtImagePath.Text)) Enemy.ImagePath = txtImagePath.Text;

            return true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
        }

        private void cmdItemInspect_Click(object sender, EventArgs e)
        {
            DataTypes.itemInfo NewItem = new DataTypes.itemInfo();
            NewItem = Enemy.Weapon;
            frmItemEditor NewForm = new frmItemEditor(NewItem, "Weapon");

            NewForm.ShowDialog();
            NewItem = NewForm.Item;

            if (NewForm.ChangeMade == true)
            {
                if (Enemy.Weapon.Name != null) Enemy.Weapon = new DataTypes.itemInfo();
                Enemy.Weapon = NewItem;
                txtWeapon.Text = Enemy.Weapon.Name;
            }
        }

        private void cmdSaveEnemy_Click(object sender, EventArgs e)
        {
            if (SaveEnemy())
            {
                ChangeMade = true;
                this.Hide();
            }
            else MessageBox.Show("There is a problem saving the enemy. Check fields");
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            frmHelp NewForm = new frmHelp();
            NewForm.Show();
        }

        private void cmdImagePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "\\Resources\\Enemies");
            OpenFile.FileName = string.Empty;

            DialogResult result = OpenFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                string Test = OpenFile.FileName.Replace(Directory.GetCurrentDirectory(), string.Empty);
                txtImagePath.Text = Test;
            }
        }
    }
}
