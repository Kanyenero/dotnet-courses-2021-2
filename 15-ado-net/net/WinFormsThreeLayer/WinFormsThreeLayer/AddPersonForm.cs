using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Entities;
using Persons.BL;
using Awards.BL;

namespace WinFormsThreeLayer
{
    public partial class AddPersonForm : Form
    {
        public enum FormTask { Add, Edit }
        public int PersonID { get { return personID; } }

        private FormTask task;

        private string bday_day;
        private string bday_month;
        private string bday_year;

        private int personID;
        private IPersonBL personsService;
        private IAwardBL awardsService;

        private Dictionary<string, int> personAwards;
        private Dictionary<string, int> allAwards;

        public AddPersonForm()
        {
            InitializeComponent();

            personAwards = new Dictionary<string, int>();
            allAwards = new Dictionary<string, int>();
        }
        public AddPersonForm(FormTask task, IPersonBL personsService, IAwardBL awardsService, int personID = 0) : this()
        {
            this.task = task;
            this.personsService = personsService;
            this.awardsService = awardsService;
            this.personID = personID;

            if (this.task == FormTask.Edit)
            {
                foreach (Award a in this.personsService.GetListItem(this.personID).Awards)
                {
                    personAwards.Add(a.Title, a.ID);
                }
            }

            foreach (Award a in this.awardsService.GetList())
            {
                allAwards.Add(a.Title, a.ID);
            }

            InitializeUI(this.task, personsService, personID, personAwards, allAwards);
        }

        private void InitializeUI(FormTask task, IPersonBL personsService, int personID,
            Dictionary<string, int> personAwards, 
            Dictionary<string, int> allAwards)
        {
            if (task == FormTask.Add)
            {
                Text = "Add Person";
                labelInfo.Text = "Fill in all the fields!";

                EnableUI(false);

                InitializeAwardTextBoxes(personAwards, allAwards);
                InitializeAwardButtons();
            }
            if (task == FormTask.Edit)
            {
                Text = "Edit Person";
                labelInfo.Text = "Everything is fine :)";

                EnableUI(true);

                InitializePersonTextBoxes(personsService, personID);
                InitializeAwardTextBoxes(personAwards, allAwards);
                InitializeAwardButtons();
            }
        }
        private void InitializePersonTextBoxes(IPersonBL persons, int personID)
        {
            Person p = persons.GetListItem(personID);

            textBoxName.Text = p.Name;
            textBoxLastName.Text = p.LastName;
            textBoxBirthdateYear.Text = p.Birthdate.Year.ToString();
            textBoxBirthdateMonth.Text = p.Birthdate.Month.ToString();
            textBoxBirthdateDay.Text = p.Birthdate.Day.ToString();
        }
        private void InitializeAwardTextBoxes(Dictionary<string, int> personAwards, Dictionary<string, int> allAwards)
        {
            // Добавить все имеющиеся награды у Person в правое меню
            foreach (KeyValuePair<string, int> kvp in personAwards)
            {
                listBoxChoosedAwardsList.Items.Add(kvp.Key);
            }

            // Добавить все награды, которых нет у Person в левое меню
            foreach (KeyValuePair<string, int> kvp in allAwards)
            {
                if (!listBoxChoosedAwardsList.Items.Contains(kvp.Key))
                {
                    listBoxAwardsList.Items.Add(kvp.Key);
                }
            }
        }
        private void InitializeAwardButtons()
        {
            if (listBoxChoosedAwardsList.Items.Count == 0)
                buttonRemoveListBoxItem.Enabled = false;
            else
                buttonRemoveListBoxItem.Enabled = true;

            if (listBoxAwardsList.Items.Count == 0)
                buttonAddListBoxItem.Enabled = false;
            else
                buttonAddListBoxItem.Enabled = true;
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
            listBoxAwardsList.Enabled = state;
            listBoxChoosedAwardsList.Enabled = state;
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (task == FormTask.Add)
            {
                // Создать персону и получить ее ID в хранилище
                personID = personsService.Add(
                    textBoxName.Text,
                    textBoxLastName.Text,
                    bday_year + "/" + bday_month + "/" + bday_day);

                // Добавить персоне выбранные в интерфейсе награды
                foreach (KeyValuePair<string, int> kvp in personAwards)
                {
                    personsService.AddAward(personID, awardsService.GetListItem(kvp.Value));
                }
            }

            if (task == FormTask.Edit)
            {
                // Добавить основную информацию
                personsService.SetData(personID, new string[] {
                    textBoxName.Text,
                    textBoxLastName.Text,
                    bday_year + "/" + bday_month + "/" + bday_day });

                // Очистить все предыдущие награды персоны
                personsService.ResetAwards(personID);

                // Добавить персоне выбранные в интерфейсе награды
                foreach (KeyValuePair<string, int> kvp in personAwards)
                {
                    personsService.AddAward(personID, awardsService.GetListItem(kvp.Value));
                }
            }

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
            if (listBoxChoosedAwardsList.SelectedIndex == -1)
            {
                labelInfo.Text = "Please select an item first!";
                return;
            }

            labelInfo.Text = "Everything is fine :)";

            personAwards.Remove(listBoxChoosedAwardsList.SelectedItem.ToString());

            listBoxAwardsList.Items.Add(listBoxChoosedAwardsList.SelectedItem);
            listBoxChoosedAwardsList.Items.Remove(listBoxChoosedAwardsList.SelectedItem);
        }
        private void buttonAddListBoxItem_Click(object sender, EventArgs e)
        {
            if (listBoxAwardsList.SelectedIndex == -1)
            {
                labelInfo.Text = "Please select an item first!";
                return;
            }

            labelInfo.Text = "Everything is fine :)";

            personAwards.Add(
                listBoxAwardsList.SelectedItem.ToString(),
                allAwards[listBoxAwardsList.SelectedItem.ToString()]);

            listBoxChoosedAwardsList.Items.Add(listBoxAwardsList.SelectedItem);
            listBoxAwardsList.Items.Remove(listBoxAwardsList.SelectedItem);
        }
    }
}
