using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Linq;
using Entities;
using PersonsAndRewards.BL;

namespace WinFormsThreeLayer
{
    public partial class AddUserForm : Form
    {
        public enum FormTask { Add, Edit }

        private Person person;
        private readonly IRewardBL allAvailableRewards;

        // Возвращает результирующее значение формы
        public Person Person { get { return person; } }

        private string bday_day;
        private string bday_month;
        private string bday_year;

        public AddUserForm(FormTask task, Person person, IRewardBL allAvailableRewards)
        {
            InitializeComponent();

            this.allAvailableRewards = allAvailableRewards;

            InitializeVariables(person, allAvailableRewards);
            InitializeUI(task);
        }

        private void InitializeVariables(Person p, IRewardBL rs)
        {
            if (p == null)
                person = new Person();
            else
                person = new Person(p);


            if (rs == null)
                throw new ArgumentNullException("Input value of type 'Reward' must not be null");
        }
        private void InitializeUI(FormTask task)
        {
            if (task == FormTask.Add)
            {
                Text = "Add Person";
                labelInfo.Text = "Fill in all the fields!";

                EnableUI(false);

                if (listBoxChoosedRewardsList.Items.Count == 0)
                    buttonRemoveListBoxItem.Enabled = false;
                else
                    buttonRemoveListBoxItem.Enabled = true;
            }

            if (task == FormTask.Edit)
            {
                Text = "Edit Person";
                labelInfo.Text = "Everything is fine :)";

                EnableUI(true);

                InitializeRewardButtons();
                InitializeRewardTextBoxes(person, allAvailableRewards);

                InitializePersonTextBoxes(person);
            }
        }
        private void InitializePersonTextBoxes(Person p)
        {
            textBoxName.Text = p.Name;
            textBoxLastName.Text = p.LastName;
            textBoxBirthdateDay.Text = p.Birthdate.Day.ToString();
            textBoxBirthdateMonth.Text = p.Birthdate.Month.ToString();
            textBoxBirthdateYear.Text = p.Birthdate.Year.ToString();
        }
        private void InitializeRewardTextBoxes(Person p, IRewardBL rs)
        {
            // Добавить все имеющиеся награды у Person в правое меню
            foreach (Reward r in p.Rewards)
            {
                listBoxChoosedRewardsList.Items.Add(r.Title);
            }

            // Добавить все награды, которых нет у Person в левое меню
            foreach (Reward r in rs.GetList())
            {
                if (!listBoxChoosedRewardsList.Items.Contains(r.Title))
                {
                    listBoxRewardsList.Items.Add(r.Title);
                }
            }
        }
        private void InitializeRewardButtons()
        {
            if (listBoxChoosedRewardsList.Items.Count == 0)
                buttonRemoveListBoxItem.Enabled = false;
            else
                buttonRemoveListBoxItem.Enabled = true;

            if (listBoxRewardsList.Items.Count == 0)
                buttonAddListBoxItem.Enabled = false;
            else
                buttonAddListBoxItem.Enabled = true;
        }
        private void UpdatePersonData(Person p)
        {
            p.Name = textBoxName.Text;
            p.LastName = textBoxLastName.Text;
            p.Birthdate = DateTime.ParseExact(bday_day + "/" + bday_month + "/" + bday_year, "dd/MM/yyyy", null);
        }


        private void CheckInputAndUpdateUI()
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text) &&
                !string.IsNullOrWhiteSpace(textBoxLastName.Text) &&
                !string.IsNullOrWhiteSpace(textBoxBirthdateYear.Text) &&
                !string.IsNullOrWhiteSpace(textBoxBirthdateMonth.Text) &&
                !string.IsNullOrWhiteSpace(textBoxBirthdateDay.Text))
            {
                if (int.Parse(bday_year) < DateTime.Now.AddYears(-150).Year)
                {
                    EnableUI(false);

                    labelInfo.Text = "Person cannot be older than 150 years";
                }
                else
                {
                    EnableUI(true);

                    labelInfo.Text = "Everything is fine :)";
                }
            }
            else
            {
                EnableUI(false);
                labelInfo.Text = "Fill in all the fields!";
            }
        }
        private void EnableUI(bool state)
        {
            buttonAccept.Enabled = state;
            buttonAddListBoxItem.Enabled = state;
            buttonRemoveListBoxItem.Enabled = state;
            listBoxRewardsList.Enabled = state;
            listBoxChoosedRewardsList.Enabled = state;
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            UpdatePersonData(person);

            DialogResult = DialogResult.OK;
            Close();
        }


        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndUpdateUI();
        }
        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndUpdateUI();
        }
        private void textBoxBirthdateDay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxBirthdateDay.Text))
            {
                if (int.Parse(textBoxBirthdateDay.Text) > 31 || int.Parse(textBoxBirthdateDay.Text) == 0)
                {
                    textBoxBirthdateDay.Text = "1";
                    bday_day = textBoxBirthdateDay.Text;

                    // set caret to right
                    textBoxBirthdateDay.SelectionStart = textBoxBirthdateDay.Text.Length;
                    textBoxBirthdateDay.SelectionLength = 0;
                }
                else
                {
                    bday_day = textBoxBirthdateDay.Text;

                    if (int.Parse(textBoxBirthdateDay.Text) < 10)
                    {
                        bday_day = "0" + textBoxBirthdateDay.Text;
                    }
                }
            }

            CheckInputAndUpdateUI();
        }
        private void textBoxBirthdateMonth_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxBirthdateMonth.Text))
            {
                if (int.Parse(textBoxBirthdateMonth.Text) > 12 || int.Parse(textBoxBirthdateMonth.Text) == 0)
                {
                    textBoxBirthdateMonth.Text = "12";
                    bday_month = textBoxBirthdateMonth.Text;

                    // set caret to right
                    textBoxBirthdateMonth.SelectionStart = textBoxBirthdateMonth.Text.Length;
                    textBoxBirthdateMonth.SelectionLength = 0;
                }
                else
                {
                    bday_month = textBoxBirthdateMonth.Text;

                    if (int.Parse(textBoxBirthdateMonth.Text) < 10)
                    {
                        bday_month = "0" + textBoxBirthdateMonth.Text;
                    }
                }
            }

            CheckInputAndUpdateUI();
        }
        private void textBoxBirthdateYear_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxBirthdateYear.Text))
            {
                if (int.Parse(textBoxBirthdateYear.Text) > DateTime.Now.Year)
                {
                    textBoxBirthdateYear.Text = DateTime.Now.Year.ToString();
                    bday_year = textBoxBirthdateYear.Text;

                    // set caret to right
                    textBoxBirthdateYear.SelectionStart = textBoxBirthdateYear.Text.Length;
                    textBoxBirthdateYear.SelectionLength = 0;
                }
                else
                {
                    bday_year = textBoxBirthdateYear.Text;
                }
            }

            CheckInputAndUpdateUI();
        }


        private void textBoxBirthdateDay_keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBoxBirthdateMonth_keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBoxBirthdateYear_keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void buttonRemoveListBoxItem_Click(object sender, EventArgs e)
        {
            if (listBoxChoosedRewardsList.SelectedIndex == -1)
            {
                labelInfo.Text = "Please select an item first!";
                return;
            }

            labelInfo.Text = "Everything is fine :)";

            string rewardToRemove = listBoxChoosedRewardsList.SelectedItem.ToString();

            person.Rewards.Remove(
                allAvailableRewards.GetList().FirstOrDefault(
                    reward => reward.Title == rewardToRemove));

            listBoxRewardsList.Items.Add(listBoxChoosedRewardsList.SelectedItem);
            listBoxChoosedRewardsList.Items.Remove(listBoxChoosedRewardsList.SelectedItem);
        }
        private void buttonAddListBoxItem_Click(object sender, EventArgs e)
        {
            if (listBoxRewardsList.SelectedIndex == -1)
            {
                labelInfo.Text = "Please select an item first!";
                return;
            }

            labelInfo.Text = "Everything is fine :)";

            Reward r = allAvailableRewards.GetList().FirstOrDefault(
                reward => reward.Title == listBoxRewardsList.SelectedItem.ToString());

            person.Rewards.Add(r);

            listBoxChoosedRewardsList.Items.Add(listBoxRewardsList.SelectedItem);
            listBoxRewardsList.Items.Remove(listBoxRewardsList.SelectedItem);
        }
    }
}
