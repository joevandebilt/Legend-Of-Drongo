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

        public frmItemEditor(DataTypes.itemInfo ThisItem)
        {
            InitializeComponent();
            ChangeMade = false;

            if (ThisItem.Name != null) 
            {
                Item = ThisItem;
                PopulateItem(Item);
            }
            else cmbItemClass.SelectedIndex = cmbItemClass.FindString("Object");
        }

        public void PopulateItem(DataTypes.itemInfo ThisItem)
        {
            if (ThisItem.Name != null) txtName.Text = ThisItem.Name;
            if (ThisItem.Examine != null) txtDescription.Text = ThisItem.Examine;

            if (ThisItem.CanPickUp == false) chkPickup.Checked = false;
            else chkPickup.Checked = true;

            if (ThisItem.InteractionName != null)
            {
                txtInteraction.Clear();
                txtInteraction.Text = ThisItem.InteractionName[0];
                for (int i = 1; i < ThisItem.InteractionName.Count; i++)
                {
                    txtInteraction.Text = string.Concat(txtInteraction.Text, ", ", ThisItem.InteractionName[i]);
                }
            }

            if (ThisItem.Class != null) cmbItemClass.SelectedIndex = cmbItemClass.FindString(ThisItem.Class);
            else cmbItemClass.SelectedIndex = cmbItemClass.FindString("Unknown");

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
            else if (cmbItemClass.Text.Contains("Armor")) txtProtection.Enabled = true;
            else if (cmbItemClass.Text == "Food") txtHP.Enabled = true;
            
            txtValue.Text = ThisItem.Value.ToString();
            txtHP.Text = ThisItem.HPmod.ToString();
            txtDamage.Text = ThisItem.AttackMod.ToString();
            txtProtection.Text = ThisItem.DefenseMod.ToString();

            if (ThisItem.GoodHit != null) txtGoodHit.Text = ThisItem.GoodHit;
            if (ThisItem.MedHit != null) txtMedHit.Text = ThisItem.MedHit;
            if (ThisItem.BadHit != null) txtBadHit.Text = ThisItem.BadHit;

            if (ThisItem.ItemNeeded != null) txtItemNeeded.Text = ThisItem.ItemNeeded;
            if (ThisItem.interactionResponse != null) txtInteractionMessage.Text = ThisItem.interactionResponse;
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
            }
            else return false;

            Item.Class = cmbItemClass.Text;
            int n;
            if (int.TryParse(txtValue.Text, out n)) Item.Value = n;
            else if (txtValue.Enabled == true) return false;

            if (int.TryParse(txtHP.Text, out n)) Item.HPmod = n;
            else if (txtHP.Enabled == true) return false;

            if (int.TryParse(txtDamage.Text, out n)) Item.AttackMod = n;
            else if (txtDamage.Enabled == true) return false;

            if (int.TryParse(txtProtection.Text, out n)) Item.DefenseMod = n;
            else if (txtProtection.Enabled == true) return false;

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
            txtDamage.Enabled = false;
            txtProtection.Enabled = false;
            txtGoodHit.Enabled = false;
            txtMedHit.Enabled = false;
            txtBadHit.Enabled = false;
            txtItemNeeded.Enabled = false;
            txtInteractionMessage.Enabled = false;
            txtHP.Enabled = false;

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
            else if (cmbItemClass.Text.Contains("Armor")) txtProtection.Enabled = true;
            else if (cmbItemClass.Text == "Food") txtHP.Enabled = true;
        }
    }
}
