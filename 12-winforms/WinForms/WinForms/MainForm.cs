using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




// TODO: Удаление элементов при сортировке работает неправильно
// TODO: Прикрутить к таблице с пользователями возможность награждать их




namespace WinForms
{
    public partial class MainForm : Form
    {
        public enum PersonsGridColumns
        {
            ID,
            Name,
            LastName,
            Birthdate,
            Age,
            Rewards
        }
        public enum RewardsGridColumns
        {
            ID,
            Title,
            Description
        }

        public MainForm()
        {
            InitializeComponent();

            personsToolStripMenuItem.Enabled = true;
            rewardsToolStripMenuItem.Enabled = false;

            string[] dgvPersons_cols = Enum.GetNames(typeof(PersonsGridColumns));
            string[] dgvRewards_cols = Enum.GetNames(typeof(RewardsGridColumns));

            InitializeDataGridView(
                dgvPersons,
                dgvPersons_cols,
                new int[] { 40, 80, 120, 120, 50, 400, 100 });

            InitializeDataGridView(
                dgvRewards,
                dgvRewards_cols,
                new int[] { 40, 200, 600 });

            persons = new List<Person>();
            rewards = new List<Reward>();

            AddTestRowsToDataGridView(dgvRewards);
            AddTestRowsToDataGridView(dgvPersons);
        }

        private List<Person> persons;
        private List<Reward> rewards;

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                personsToolStripMenuItem.Enabled = true;
                rewardsToolStripMenuItem.Enabled = false;
            }
            if (tabControl.SelectedIndex == 1)
            {
                personsToolStripMenuItem.Enabled = false;
                rewardsToolStripMenuItem.Enabled = true;
            }
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddUserForm(AddUserForm.FormTask.Add, null, rewards))
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    DataGridViewAndListManager.ManageList(
                        persons, null, form.Person, DataGridViewAndListManager.ListAction.AddItem);

                    DataGridViewAndListManager.ManageDataGridView(
                        dgvPersons, persons, DataGridViewAndListManager.DataGridViewAction.AddRow);
                }
            }
        }
        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получить индекс выделенной строки
            int idx = 0;
            foreach (DataGridViewRow item in dgvPersons.SelectedRows)
                idx = int.Parse(item.Cells[0].Value.ToString());

            using (var form = new AddUserForm(AddUserForm.FormTask.Edit, persons[idx], rewards))
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    DataGridViewAndListManager.ManageList(
                        persons, null, form.Person, DataGridViewAndListManager.ListAction.UpdateItem, idx);

                    DataGridViewAndListManager.ManageDataGridView(
                        dgvPersons, persons, DataGridViewAndListManager.DataGridViewAction.UpdateRow, idx);
                }
            }
        }
        private void removePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new DeleteAlarmForm())
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    int id = DataGridViewAndListManager.ManageDataGridView(
                                dgvPersons, persons, DataGridViewAndListManager.DataGridViewAction.DeleteRow);

                    DataGridViewAndListManager.ManageList(
                        persons, null, null, DataGridViewAndListManager.ListAction.DeleteItem, id);

                    DataGridViewAndListManager.ManageDataGridView(
                        dgvPersons, persons, DataGridViewAndListManager.DataGridViewAction.UpdateRowsIndexes, id);
                }
            }
        }

        private void addRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddRewardForm(AddRewardForm.FormTask.Add, null))
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    DataGridViewAndListManager.ManageList(
                        rewards, form.Reward, DataGridViewAndListManager.ListAction.AddItem);

                    DataGridViewAndListManager.ManageDataGridView(
                        dgvRewards, rewards, DataGridViewAndListManager.DataGridViewAction.AddRow);
                }
            }
        }
        private void editRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получить индекс выделенной строки
            int idx = 0;
            foreach (DataGridViewRow item in dgvRewards.SelectedRows)
                idx = int.Parse(item.Cells[0].Value.ToString());

            using (var form = new AddRewardForm(AddRewardForm.FormTask.Edit, rewards[idx]))
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    DataGridViewAndListManager.ManageList(
                        rewards, form.Reward, DataGridViewAndListManager.ListAction.UpdateItem, idx);

                    DataGridViewAndListManager.ManageDataGridView(
                        dgvRewards, rewards, DataGridViewAndListManager.DataGridViewAction.UpdateRow, idx);
                }
            }
        }
        private void removeRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new DeleteAlarmForm())
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    int id = DataGridViewAndListManager.ManageDataGridView(
                                dgvRewards, rewards, DataGridViewAndListManager.DataGridViewAction.DeleteRow);

                    // Обновить списки наград пользователей
                    DataGridViewAndListManager.ManageList(
                        persons, rewards, null, DataGridViewAndListManager.ListAction.UpdateRewards, id);

                    // Обновить список наград
                    DataGridViewAndListManager.ManageList(
                        rewards, null, DataGridViewAndListManager.ListAction.DeleteItem, id);

                    // Обновить индексы в таблице наград
                    DataGridViewAndListManager.ManageDataGridView(
                        dgvRewards, rewards, DataGridViewAndListManager.DataGridViewAction.UpdateRowsIndexes, id);

                    // Обновить награды в таблице пользователей
                    DataGridViewAndListManager.ManageDataGridView(
                        dgvPersons, persons, DataGridViewAndListManager.DataGridViewAction.UpdateRowsRewards, id);
                }
            }
        }

        private void InitializeDataGridView(DataGridView dgv, string[] cols, int[] cols_w)
        {
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = true;

            dgv.ColumnCount = cols.Length;

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Name = cols[i];
                dgv.Columns[i].Width = cols_w[i];
            }

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }
        private void AddTestRowsToDataGridView(DataGridView dgv)
        {
            if(dgv.Name == "dgvPersons")
            {
                Person test_p1 = new Person("Ilya", "Varlamov", "07/01/1984");
                test_p1.ID = 0;
                test_p1.AddReward(rewards[0]);
                test_p1.AddReward(rewards[1]);
                test_p1.AddReward(rewards[2]);
                persons.Add(test_p1);
                dgvPersons.Rows.Add(
                    new string[] { 
                        test_p1.ID.ToString(), test_p1.Name, test_p1.LastName, test_p1.Birthdate, test_p1.Age.ToString(), 
                        test_p1.RewardsString
                    });

                Person test_p2 = new Person("Max", "Katz", "23/12/1984");
                test_p2.ID = 1;
                test_p2.AddReward(rewards[1]);
                persons.Add(test_p2);
                dgvPersons.Rows.Add(
                    new string[] { test_p2.ID.ToString(), test_p2.Name, test_p2.LastName, test_p2.Birthdate, test_p2.Age.ToString(), 
                        test_p2.RewardsString });

                Person test_p3 = new Person("Darya", "Besedina", "22/07/1988");
                test_p3.ID = 2;
                persons.Add(test_p3);
                dgvPersons.Rows.Add(
                    new string[] { test_p3.ID.ToString(), test_p3.Name, test_p3.LastName, test_p3.Birthdate, test_p3.Age.ToString(),
                    test_p3.RewardsString});

                Person test_p4 = new Person("Leonid", "Volkov", "10/11/1980");
                test_p4.ID = 3;
                test_p4.AddReward(rewards[2]);
                persons.Add(test_p4);
                dgvPersons.Rows.Add(
                    new string[] { test_p4.ID.ToString(), test_p4.Name, test_p4.LastName, test_p4.Birthdate, test_p4.Age.ToString(),
                    test_p4.RewardsString});

                Person test_p5 = new Person("Kira", "Yarmish", "11/10/1989");
                test_p5.ID = 4;
                test_p5.AddReward(rewards[0]);
                test_p5.AddReward(rewards[2]);
                persons.Add(test_p5);
                dgvPersons.Rows.Add(
                    new string[] { test_p5.ID.ToString(), test_p5.Name, test_p5.LastName, test_p5.Birthdate, test_p5.Age.ToString(),
                    test_p5.RewardsString});
            }
            if(dgv.Name == "dgvRewards")
            {
                Reward test_r1 = new Reward("Nobel Prize", "Very high science award");
                test_r1.ID = 0;
                rewards.Add(test_r1);
                dgvRewards.Rows.Add(new string[] { test_r1.ID.ToString(), test_r1.Title, test_r1.Description });

                Reward test_r2 = new Reward("Medal of Honor", "Very high wartime award");
                test_r2.ID = 1;
                rewards.Add(test_r2);
                dgvRewards.Rows.Add(new string[] { test_r2.ID.ToString(), test_r2.Title, test_r2.Description });

                Reward test_r3 = new Reward("International Dota2 Cup", "Very high gaming award");
                test_r3.ID = 2;
                rewards.Add(test_r3);
                dgvRewards.Rows.Add(new string[] { test_r3.ID.ToString(), test_r3.Title, test_r3.Description });
            }
        }
    }
}
