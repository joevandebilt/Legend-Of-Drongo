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
    public partial class frmNPCEditor : Form
    {
        public DataTypes.CivilianProfile NPC;
        public bool ChangeMade;

        public frmNPCEditor(DataTypes.CivilianProfile ThisNPC)
        {
            InitializeComponent();
            ChangeMade = false;

            NPC = ThisNPC;
            PopulateFields();
        }

        public void PopulateFields()
        {
            if (NPC.name != null) txtName.Text = NPC.name;
            if (NPC.TalkToResponse != null) txtTalkTo.Text = NPC.TalkToResponse;
            if (NPC.QuestCharacter == true) chkPlot.Checked = true;
            else chkPlot.Checked = false;

            txtHP.Text = NPC.HPBonus.ToString();
            txtArmor.Text = NPC.armor.ToString();
            txtMoney.Text = NPC.Money.ToString();
        
            if (NPC.MerchantType != null) cmbMerchType.SelectedIndex = cmbMerchType.FindString(NPC.MerchantType);
            else cmbMerchType.SelectedIndex = cmbMerchType.FindString("None");

            if (NPC.willBuy == true) chkWillBuy.Checked = true;
            else chkWillBuy.Checked = false;

            if (NPC.willSell == true) chkWillSell.Checked = true;
            else chkWillSell.Checked = false;

            if (NPC.inventory != null) GetAllItems();
            if (NPC.Knowledge != null) GetAllKnowledge();

        }

        public bool  SaveNPC()
        {
            if (txtName.Text != string.Empty) NPC.name = txtName.Text;
            else return false;

            if (txtTalkTo.Text != string.Empty) NPC.TalkToResponse = txtTalkTo.Text;
            else return false;

            if (chkPlot.Checked == true) NPC.QuestCharacter = true;
            else NPC.QuestCharacter = false;

            int n;
            if (int.TryParse(txtHP.Text, out n)) NPC.HPBonus = n;
            else return false;
            if (int.TryParse(txtArmor.Text, out n)) NPC.armor = n;
            else return false;
            if (int.TryParse(txtMoney.Text, out n)) NPC.Money = n;
            else return false;

            NPC.MerchantType = cmbMerchType.Text;

            if (chkWillBuy.Checked == true) NPC.willBuy = true;
            else NPC.willBuy = false;

            if (chkWillSell.Checked == true) NPC.willSell = true;
            else NPC.willSell = false;

            return true;

            //Inventory Saves in another function
        }


        public void GetAllItems()
        {
            lstInventory.Items.Clear();
            foreach (DataTypes.itemInfo Item in NPC.inventory)
            {
                lstInventory.Items.Add(Item.Name + " - " + Item.Class + "  " + Item.Value);
            }
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            DataTypes.itemInfo NewItem = new DataTypes.itemInfo();
            frmItemEditor NewForm = new frmItemEditor(NewItem);
            NewForm.ShowDialog();

            if (NewForm.ChangeMade == true)
            {
                NewItem = NewForm.Item;
                if (NPC.inventory == null) NPC.inventory = new List<DataTypes.itemInfo>();
                NPC.inventory.Add(NewItem);
            }
            GetAllItems();
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            NPC.inventory.RemoveAt(lstInventory.SelectedIndex);
            GetAllItems();
        }

        private void lstInventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstInventory.SelectedIndex > -1)
            {
                DataTypes.itemInfo EditItem = new DataTypes.itemInfo();
                EditItem = NPC.inventory[lstInventory.SelectedIndex];
                frmItemEditor NewForm = new frmItemEditor(EditItem);
                NewForm.ShowDialog();

                if (NewForm.ChangeMade == true)
                {
                    EditItem = NewForm.Item;
                    NPC.inventory[lstInventory.SelectedIndex] = EditItem;
                    GetAllItems();
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
        }

        private void cmdSaveNPC_Click(object sender, EventArgs e)
        {
            if (SaveNPC())
            {
                ChangeMade = true;
                this.Hide();
            }
            else MessageBox.Show("There was a problem with saving the NPC. Check fields.");
        }

        private void cmdAddKnowledge_Click(object sender, EventArgs e)
        {
            if (NPC.Knowledge == null) NPC.Knowledge = new List<DataTypes.Facts>();

            DataTypes.Facts thisFact = new DataTypes.Facts();
            thisFact.Knowledge = "I know these facts...";
            thisFact.Topic = "Ask About <Topic>";

            NPC.Knowledge.Add(thisFact);

            GetAllKnowledge();
        }

        private void cmdRemoveKnowledge_Click(object sender, EventArgs e)
        {
            if (lstKnowledge.SelectedIndex > -1)
            {
                NPC.Knowledge.RemoveAt(lstKnowledge.SelectedIndex);
                GetAllKnowledge();
            }
            else MessageBox.Show("Please select and item to remove");
        }

        public void GetAllKnowledge()
        {
            lstKnowledge.Items.Clear();
            int StringLength;


            foreach (DataTypes.Facts fact in NPC.Knowledge)
            {
                if (fact.Knowledge.Length > 23) StringLength = 23;
                else StringLength = fact.Knowledge.Length;
                lstKnowledge.Items.Add(fact.Topic + " - " + fact.Knowledge.Substring(0,StringLength) + "...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTypes.Facts thisFact = new DataTypes.Facts();
            thisFact = NPC.Knowledge[lstKnowledge.SelectedIndex];

            thisFact.Topic = txtTopic.Text;
            thisFact.Knowledge = txtKnowledge.Text;

            txtTopic.Clear();
            txtKnowledge.Clear();

            txtTopic.Enabled = false;
            txtKnowledge.Enabled = false;

            NPC.Knowledge[lstKnowledge.SelectedIndex] = thisFact;

            GetAllKnowledge();
        }

        private void lstKnowledge_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstKnowledge.SelectedIndex > -1)
            {
                txtTopic.Clear();
                txtKnowledge.Clear();

                txtTopic.Enabled = true;
                txtKnowledge.Enabled = true;

                txtTopic.Text = NPC.Knowledge[lstKnowledge.SelectedIndex].Topic;
                txtKnowledge.Text = NPC.Knowledge[lstKnowledge.SelectedIndex].Knowledge;
            }
        }
    }
}
