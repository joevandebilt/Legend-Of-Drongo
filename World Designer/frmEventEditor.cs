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
    public partial class frmEventEditor : Form
    {
        public DataTypes.Event Event;
        public bool ChangeMade;

        public struct EventTriggers
        {
            public string Trigger;
            public string TriggerDesc;
        }

        public struct EventActions
        {
            public string Action;
            public string ActionDesc;
        }

        EventTriggers[] Triggers = new EventTriggers[6];
        EventActions[] Actions = new EventActions[5];

        public frmEventEditor(DataTypes.Event thisEvent, int FloorCount)
        {
            InitializeComponent();
            ChangeMade = false;

            //Trigers
            Triggers[0].Trigger = "killallenemies";
            Triggers[0].TriggerDesc = "Player kills all enemies in the room";
            Triggers[1].Trigger = "moveinto";
            Triggers[1].TriggerDesc = "Player moves into the current room";
            Triggers[2].Trigger = "itempickup";
            Triggers[2].TriggerDesc = "Player picks up an item";
            Triggers[3].Trigger = "payoff";
            Triggers[3].TriggerDesc = "Player pays off an enemy";
            Triggers[4].Trigger = "iteminteraction";
            Triggers[4].TriggerDesc = "Player uses an interaction item correctly";
            Triggers[5].Trigger = "killenemy";
            Triggers[5].TriggerDesc = "Players kills 1 enemy in a room";

            //Actions
            Actions[0].Action = "unlock";
            Actions[0].ActionDesc = "unlock a locked cell at ";
            Actions[1].Action = "lock";
            Actions[1].ActionDesc = "lock a cell at ";
            Actions[2].Action = "kill all enemies";
            Actions[2].ActionDesc = "kill all enemies in the room";
            Actions[3].Action = "change description";
            Actions[3].ActionDesc = "change the room description to its alternative";
            Actions[4].Action = "change location";
            Actions[4].ActionDesc = "move player to these coodinates ";

            for (int i = 0; i < Triggers.Length; i++)
            {
                cmbTrigger.Items.Add(Triggers[i].TriggerDesc);
            }
            cmbTrigger.Items.Add("Unknown");

            for (int i = 0; i < Actions.Length; i++)
            {
                cmbAction.Items.Add(Actions[i].ActionDesc);
            }
            cmbAction.Items.Add("Unknown");

            Event = thisEvent;
            Event.Triggered = false;
            PopulateEvent(FloorCount);
        }

        private void PopulateEvent(int Count)
        {
            if (Event.Trigger == null) cmbTrigger.SelectedIndex = cmbTrigger.FindString("Unknown");
            else
            {
                for (int i = 0; i < Triggers.Length; i++)
                {
                    if (Triggers[i].Trigger == Event.Trigger) cmbTrigger.SelectedIndex = i;
                }
            }

            if (Event.Action == null) cmbAction.SelectedIndex = cmbAction.FindString("Unknown");
            else
            {
                for (int i = 0; i < Actions.Length; i++)
                {
                    if (Actions[i].Action == Event.Action) cmbAction.SelectedIndex = i;
                }
            }


            if (cmbAction.SelectedIndex == 0 || cmbAction.SelectedIndex == 1 || cmbAction.SelectedIndex == 3 || cmbAction.SelectedIndex == 4)
            {
                cmbRow.Enabled = true;
                cmbCol.Enabled = true;
                cmbFloor.Enabled = true;
            }

            cmbFloor.Items.Clear();
            for (int i = 0; i < Count; i++)
            {
                cmbFloor.Items.Add("Level " + (i + 1));
            }

            if (Event.Coodinates != null)
            {                
                cmbRow.SelectedIndex = Event.Coodinates[0];
                cmbCol.SelectedIndex = Event.Coodinates[1];
                cmbFloor.SelectedIndex = Event.Coodinates[2];
            }
        }

        private bool SaveEvent()
        {
            Event.Trigger = Triggers[cmbTrigger.FindString(cmbTrigger.Text)].Trigger;
            Event.Action = Actions[cmbAction.FindString(cmbAction.Text)].Action;

            if (cmbAction.SelectedIndex == 0 || cmbAction.SelectedIndex == 1 || cmbAction.SelectedIndex == 3 || cmbAction.SelectedIndex == 4)
            {
                if (Event.Coodinates == null) Event.Coodinates = new int[3];

                Event.Coodinates[0] = cmbRow.SelectedIndex;
                Event.Coodinates[1] = cmbCol.SelectedIndex;
                Event.Coodinates[2] = cmbFloor.SelectedIndex;
            }
            return true;
        }

        private void cmbAction_TextChanged(object sender, EventArgs e)
        {
            cmbRow.Enabled = false;
            cmbCol.Enabled = false;
            cmbFloor.Enabled = false;

           //Check if coodinate box should be enabled
            if (cmbAction.SelectedIndex == 0 || cmbAction.SelectedIndex == 1 || cmbAction.SelectedIndex == 3 || cmbAction.SelectedIndex == 4)
            {
                cmbRow.Enabled = true;
                cmbCol.Enabled = true;
                cmbFloor.Enabled = true;
            }
        }

        private void cmdSaveEvent_Click(object sender, EventArgs e)
        {
            if (SaveEvent())
            {
                ChangeMade = true;
                this.Hide();
            }
            else MessageBox.Show("There is an error on the form");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ChangeMade = false;
            this.Hide();
        }
    }
}
