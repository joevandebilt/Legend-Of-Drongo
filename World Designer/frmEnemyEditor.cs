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
    public partial class frmEnemyEditor : Form
    {
        public DataTypes.EnemyProfile Enemy;
        public bool ChangeMade;

        public frmEnemyEditor(DataTypes.EnemyProfile ThisEnemy)
        {
            InitializeComponent();
            ChangeMade = false;

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

            if (Enemy.KillMessage != null) txtKill.Text = Enemy.KillMessage;
            if (Enemy.DeathMessage != null) txtDeath.Text = Enemy.DeathMessage;

            txtPayOff.Text = Enemy.PayOff.ToString();
            if (Enemy.PayOffResponse != null) txtPayOffResponse.Text = Enemy.PayOffResponse;
        }

        public bool SaveEnemy()
        {
            if (txtName.Text != string.Empty) Enemy.name = txtName.Text;
            else return false;
            if (txtKill.Text != string.Empty) Enemy.KillMessage = txtKill.Text;
            if (txtDeath.Text != string.Empty) Enemy.DeathMessage = txtDeath.Text;
            else return false;
            if (txtPayOffResponse.Text != string.Empty) Enemy.PayOffResponse = txtPayOffResponse.Text;
            
            int n;
            double d;
            if (double.TryParse(txtHP.Text, out d)) Enemy.HPBonus = d;
            else return false;
            if (int.TryParse(txtArmor.Text, out n)) Enemy.armor= n;
            else return false;
            if (int.TryParse(txtMoney.Text, out n)) Enemy.Money = n;
            else return false;
            if (int.TryParse(txtPayOff.Text, out n)) Enemy.PayOff = n;
            else return false;

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
            frmItemEditor NewForm = new frmItemEditor(NewItem);

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
    }
}
