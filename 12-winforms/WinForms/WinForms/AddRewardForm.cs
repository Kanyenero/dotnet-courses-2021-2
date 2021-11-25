using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AddRewardForm : Form
    {
        public enum FormTask { Add, Edit }

        public AddRewardForm(FormTask task, Reward r)
        {
            InitializeComponent();

            InitializePrivateVariables(r);
            InitializeUI(task);
        }

        private Reward reward;
        public Reward Reward { get { return reward; } }

        private void InitializePrivateVariables(Reward r)
        {
            if (r == null)
                reward = new Reward();
            else
                reward = new Reward(r.Title, r.Description);
        }
        private void InitializeUI(FormTask task)
        {
            if (task == FormTask.Add)
            {
                Text = "Add Reward";
                buttonAccept.Enabled = false;
                labelInfo.Text = "Fill in all the fields!";
            }
            if (task == FormTask.Edit)
            {
                Text = "Edit Reward";
                buttonAccept.Enabled = true;
                InitializeRewardTextBoxes(reward);
                labelInfo.Text = "Everything is fine :)";
            }
        }
        private void InitializeRewardTextBoxes(Reward r)
        {
            textBoxTitle.Text = r.Title;
            richTextBoxDescription.Text = r.Description;
        }


        private void CheckInputAndUpdateUI()
        {
            if (!string.IsNullOrWhiteSpace(textBoxTitle.Text) &&
                !string.IsNullOrWhiteSpace(richTextBoxDescription.Text))
            {
                buttonAccept.Enabled = true;
                labelInfo.Text = "Everything is fine :)";
            }
            else
            {
                buttonAccept.Enabled = false;
                labelInfo.Text = "Fill in all the fields!";
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            reward = new Reward(textBoxTitle.Text, richTextBoxDescription.Text);

            DialogResult = DialogResult.OK;
            Close();
        }


        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndUpdateUI();
        }
        private void richTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndUpdateUI();
        }
    }
}
