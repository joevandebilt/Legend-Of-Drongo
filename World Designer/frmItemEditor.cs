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
    public partial class frmItemEditor : Form
    {
        public DataTypes.itemInfo Item;
        public bool ChangeMade;

        public frmItemEditor(DataTypes.itemInfo ThisItem, string ItemClass)
        {
            InitializeComponent();
            ChangeMade = false;
            Item = ThisItem;
            PopulateItem(ItemClass);
        }

        public void PopulateItem(string Class)
        {
            if (Item.Name != null) txtName.Text = Item.Name;
            if (Item.Examine != null) txtDescription.Text = Item.Examine;

            if (Item.CanPickUp == false) chkPickup.Checked = false;
            else chkPickup.Checked = true;

            if (Item.InteractionName != null)
            {
                txtInteraction.Clear();
                txtInteraction.Text = Item.InteractionName[0];
                for (int i = 1; i < Item.InteractionName.Count; i++)
                {
                    txtInteraction.Text = string.Concat(txtInteraction.Text, ", ", Item.InteractionName[i]);
                }
            }

            if (Item.Class != null) cmbItemClass.SelectedIndex = cmbItemClass.FindString(Item.Class);
            else if (Class != string.Empty)
            {
                cmbItemClass.SelectedIndex = cmbItemClass.FindString(Class);
                cmbItemClass.Enabled = false;
            }
            else cmbItemClass.SelectedIndex = cmbItemClass.FindString("Unknown");
            
            txtValue.Text = Item.Value.ToString();
            txtHP.Text = Item.HPmod.ToString();
            txtDamage.Text = Item.AttackMod.ToString();
            txtProtection.Text = Item.DefenseMod.ToString();
            txtXP.Text = Item.XP.ToString();
            EnableElements();

            if (Item.GoodHit != null) txtGoodHit.Text = Item.GoodHit;
            if (Item.MedHit != null) txtMedHit.Text = Item.MedHit;
            if (Item.BadHit != null) txtBadHit.Text = Item.BadHit;

            if (Item.ItemNeeded != null) txtItemNeeded.Text = Item.ItemNeeded;
            if (Item.interactionResponse != null) txtInteractionMessage.Text = Item.interactionResponse;
        }

        private bool SaveItem()
        {
            if (txtName.Text != string.Empty) Item.Name = txtName.Text;
            else return false;

            if (txtDescription.Text != string.Empty) Item.Examine = txtDescription.Text;
            else return false;

            if (chkPickup.Checked == false) Item.CanPickUp = false;
            else Item.CanPickUp = true;

            if (txtInteraction.Text != string.Empty)
            {
                string[] Names = txtInteraction.Text.Split(',');
                if (Item.InteractionName == null) Item.InteractionName = new List<string>();
                Item.InteractionName.Clear();
                foreach (string name in Names)
                {
                    Item.InteractionName.Add(name.Trim());
                }
                Array.Clear(Names,0,Names.Length);
            }
            else return false;

            Item.Class = cmbItemClass.Text;
            int n;
            double d;
            if (int.TryParse(txtValue.Text, out n)) Item.Value = n;
            else if (txtValue.Enabled == true) return false;

            if (int.TryParse(txtHP.Text, out n)) Item.HPmod = n;
            else if (txtHP.Enabled == true) return false;

            if (double.TryParse(txtDamage.Text, out d)) Item.AttackMod = d;
            else if (txtDamage.Enabled == true) return false;

            if (int.TryParse(txtProtection.Text, out n)) Item.DefenseMod = n;
            else if (txtProtection.Enabled == true) return false;

            if (int.TryParse(txtXP.Text, out n)) Item.XP = n;
            else if (txtXP.Enabled == true) return false;

            if (txtGoodHit.Text != string.Empty)Item.GoodHit = txtGoodHit.Text;
            else if (txtGoodHit.Enabled == true) return false;
            if (txtMedHit.Text != string.Empty) Item.MedHit = txtMedHit.Text;
            else if (txtMedHit.Enabled == true) return false;
            if (txtBadHit.Text != string.Empty) Item.BadHit = txtBadHit.Text;
            else if (txtBadHit.Enabled == true) return false;

            if (txtItemNeeded.Text != string.Empty) Item.ItemNeeded = txtItemNeeded.Text;
            else if (txtItemNeeded.Enabled == true) return false;

            if (txtInteractionMessage.Text != string.Empty) Item.interactionResponse = txtInteractionMessage.Text;
            else if (txtInteractionMessage.Enabled == true) return false;

            return true;
        }

        private void cmdAddItems_Click(object sender, EventArgs e)
        {
            if (SaveItem())
            {
                ChangeMade = true;
                this.Hide();
            }
            else MessageBox.Show("There was a problem saving the item. Check fields.");
        }

        private void cmdCancelEdit_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
        }

        private void cmbItemClass_TextChanged(object sender, EventArgs e)
        {
            EnableElements();
        }

        private void EnableElements()
        {
            txtDamage.Enabled = false;
            txtProtection.Enabled = false;
            txtGoodHit.Enabled = false;
            txtMedHit.Enabled = false;
            txtBadHit.Enabled = false;
            txtItemNeeded.Enabled = false;
            txtInteractionMessage.Enabled = false;
            txtHP.Enabled = false;
            txtXP.Enabled = false;

            if (cmbItemClass.Text == "Weapon")
            {
                txtDamage.Enabled = true;
                txtProtection.Enabled = true;
                txtGoodHit.Enabled = true;
                txtMedHit.Enabled = true;
                txtBadHit.Enabled = true;
            }
            else if (cmbItemClass.Text == "Interaction Object")
            {
                txtItemNeeded.Enabled = true;
                txtInteractionMessage.Enabled = true;
            }
            else if (cmbItemClass.Text == "Food" || cmbItemClass.Text == "Drink")
            {
                txtHP.Enabled = true;
                txtXP.Enabled = true;
            }
            else if (cmbItemClass.Text == "Interactive Item") txtXP.Enabled = true;
            else if (cmbItemClass.Text == "Readable") txtXP.Enabled = true;
            else if (cmbItemClass.Text.Contains("Armor")) txtProtection.Enabled = true;
            
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            frmHelp NewForm = new frmHelp();
            NewForm.Show();
        }
    }
}
