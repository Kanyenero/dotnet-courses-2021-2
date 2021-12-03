using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Entities;
using Awards.BL;


namespace WinFormsThreeLayer
{
    public partial class AddAwardForm : Form
    {
        public enum FormTask { Add, Edit }
        private FormTask task;

        public int AwardID { get { return awardID; } }
        private int awardID;
        private IAwardBL awardsService;

        public AddAwardForm()
        {
            InitializeComponent();
        }
        public AddAwardForm(FormTask task, IAwardBL awardsService, int awardID = 0) : this()
        {
            this.task = task;
            this.awardsService = awardsService;
            this.awardID = awardID;

            InitializeUI(task, this.awardsService, this.awardID);
        }

        private void InitializeUI(FormTask task, IAwardBL awardsService, int awardID)
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
                labelInfo.Text = "Everything is fine :)";

                InitializeRewardTextBoxes(awardsService, awardID);
            }
        }
        private void InitializeRewardTextBoxes(IAwardBL awardsService, int awardID)
        {
            Award a = awardsService.GetListItem(awardID);

            textBoxTitle.Text = a.Title;
            richTextBoxDescription.Text = a.Description;
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
            if (task == FormTask.Add)
            {
                awardID = awardsService.Add(textBoxTitle.Text, richTextBoxDescription.Text);
            }

            if (task == FormTask.Edit)
            {
                awardsService.SetData(awardID, new string[] {
                    textBoxTitle.Text,
                    richTextBoxDescription.Text });
            }

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
