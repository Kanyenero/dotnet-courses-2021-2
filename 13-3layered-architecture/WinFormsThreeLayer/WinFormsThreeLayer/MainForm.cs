using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PersonsAndRewards.BL;
using Entities;

namespace WinFormsThreeLayer
{
    public partial class MainForm : Form
    {
        private IPersonBL persons;
        private IRewardBL rewards;

        public MainForm(IPersonBL persons, IRewardBL rewards)
        {
            InitializeComponent();

            personsToolStripMenuItem.Enabled = true;
            rewardsToolStripMenuItem.Enabled = false;

            this.persons = persons;
            this.rewards = rewards;

            string[] dgvPersons_cols = Person.GetFieldsNames();
            string[] dgvRewards_cols = Reward.GetFieldsNames();

            InitDataGridView(
                dgvPersons,
                dgvPersons_cols,
                new int[] { 40, 80, 120, 120, 50, 400, 100 });

            InitDataGridView(
                dgvRewards,
                dgvRewards_cols,
                new int[] { 40, 200, 600 });

            foreach (Person p in persons.GetList())
            {
                dgvPersons.Rows.Add(p.GetFieldsValues());
            }

            foreach (Reward r in rewards.GetList())
            {
                dgvRewards.Rows.Add(r.GetFieldsValues());
            }
        }

        private void InitDataGridView(DataGridView dgv, string[] cols, int[] cols_width)
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
                dgv.Columns[i].Width = cols_width[i];
            }

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

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
                    persons.Add(form.Person);
                    dgvPersons.Rows.Add(form.Person.GetFieldsValues());
                }
            }
        }
        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idx = 0;
            foreach (DataGridViewRow item in dgvPersons.SelectedRows)
            {
                idx = item.Index;
            }

            using (var form = new AddUserForm(AddUserForm.FormTask.Edit, persons.GetListItem(idx), rewards))
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    persons.Update(idx, form.Person);
                    DataGridViewUpdateSelectedRows(dgvPersons, persons);
                }
            }
        }
        private void removePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idx = 0;
            foreach (DataGridViewRow item in dgvPersons.SelectedRows)
            {
                idx = item.Index;
            }

            using (var form = new DeleteAlarmForm())
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    persons.Remove(idx);

                    DataGridViewRemoveSelectedRows(dgvPersons);
                    DataGridViewUpdateRows(dgvPersons, persons);
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
                    rewards.Add(form.Reward);
                    dgvRewards.Rows.Add(form.Reward.GetFieldsValues());
                }
            }
        }
        private void editRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idx = 0;
            foreach (DataGridViewRow item in dgvRewards.SelectedRows)
            {
                idx = item.Index;
            }

            using (var form = new AddRewardForm(AddRewardForm.FormTask.Edit, rewards.GetListItem(idx)))
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    rewards.Update(idx, form.Reward);
                    DataGridViewUpdateSelectedRows(dgvRewards, rewards);
                }
            }
        }
        private void removeRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idx = 0;
            foreach (DataGridViewRow item in dgvRewards.SelectedRows)
            {
                idx = item.Index;
            }

            using (var form = new DeleteAlarmForm())
            {
                // Вывести форму
                var result = form.ShowDialog();

                // Обработать результат
                if (result == DialogResult.OK)
                {
                    rewards.Remove(idx);

                    DataGridViewRemoveSelectedRows(dgvRewards);
                    DataGridViewUpdateRows(dgvRewards, rewards);

                    // Обновить списки наград у персон
                    foreach (Person p in persons.GetList())
                    {
                        persons.UpdateRewards(p, rewards);
                    }

                    DataGridViewUpdateRows(dgvPersons, persons);
                }
            }
        }

        private void DataGridViewUpdateSelectedRows(DataGridView dgv, IPersonBL ps)
        {
            foreach (DataGridViewRow r in dgv.SelectedRows)
            {
                for (int i = 0; i < ps.GetListItem(r.Index).GetFieldsValues().Length; i++)
                {
                    r.Cells[i].Value = ps.GetListItem(r.Index).GetFieldsValues()[i];
                }
            }
        }
        private void DataGridViewUpdateSelectedRows(DataGridView dgv, IRewardBL rs)
        {
            foreach (DataGridViewRow r in dgv.SelectedRows)
            {
                for (int i = 0; i < rs.GetListItem(r.Index).GetFieldsValues().Length; i++)
                {
                    r.Cells[i].Value = rs.GetListItem(r.Index).GetFieldsValues()[i];
                }
            }
        }
        private void DataGridViewUpdateRows(DataGridView dgv, IPersonBL ps)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                for (int i = 0; i < ps.GetListItem(r.Index).GetFieldsValues().Length; i++)
                {
                    r.Cells[i].Value = ps.GetListItem(r.Index).GetFieldsValues()[i];
                }
            }
        }
        private void DataGridViewUpdateRows(DataGridView dgv, IRewardBL rs)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                for (int i = 0; i < rs.GetListItem(r.Index).GetFieldsValues().Length; i++)
                {
                    r.Cells[i].Value = rs.GetListItem(r.Index).GetFieldsValues()[i];
                }
            }
        }
        private void DataGridViewRemoveSelectedRows(DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                dgv.Rows.RemoveAt(item.Index);
            }
        }


        private void dgvPersons_Sorted(object sender, EventArgs e)
        {
            if(dgvPersons.SortOrder == SortOrder.Ascending)
            {
                if (dgvPersons.SortedColumn.Index == 0)
                {
                    persons.SetList(from s in persons.GetList() orderby s.ID ascending select s);
                }

                if (dgvPersons.SortedColumn.Index == 1)
                {
                    persons.SetList(from s in persons.GetList() orderby s.Name ascending select s);
                }

                if (dgvPersons.SortedColumn.Index == 2)
                {
                    persons.SetList(from s in persons.GetList() orderby s.LastName ascending select s);
                }

                if (dgvPersons.SortedColumn.Index == 3)
                {
                    persons.SetList(from s in persons.GetList() orderby s.Birthdate ascending select s);
                }

                if (dgvPersons.SortedColumn.Index == 4)
                {
                    persons.SetList(from s in persons.GetList() orderby s.Age ascending select s);
                }
            }

            if (dgvPersons.SortOrder == SortOrder.Descending)
            {
                if (dgvPersons.SortedColumn.Index == 0)
                {
                    persons.SetList(from s in persons.GetList() orderby s.ID descending select s);
                }

                if (dgvPersons.SortedColumn.Index == 1)
                {
                    persons.SetList(from s in persons.GetList() orderby s.Name descending select s);
                }

                if (dgvPersons.SortedColumn.Index == 2)
                {
                    persons.SetList(from s in persons.GetList() orderby s.LastName descending select s);
                }

                if (dgvPersons.SortedColumn.Index == 3)
                {
                    persons.SetList(from s in persons.GetList() orderby s.Birthdate descending select s);
                }

                if (dgvPersons.SortedColumn.Index == 4)
                {
                    persons.SetList(from s in persons.GetList() orderby s.Age descending select s);
                }
            }
        }
        private void dgvRewards_Sorted(object sender, EventArgs e)
        {
            if (dgvRewards.SortOrder == SortOrder.Ascending)
            {
                if (dgvRewards.SortedColumn.Index == 0)
                {
                    rewards.SetList(from s in rewards.GetList() orderby s.ID ascending select s);
                }

                if (dgvRewards.SortedColumn.Index == 1)
                {
                    rewards.SetList(from s in rewards.GetList() orderby s.Title ascending select s);
                }

                if (dgvRewards.SortedColumn.Index == 2)
                {
                    rewards.SetList(from s in rewards.GetList() orderby s.Description ascending select s);
                }
            }

            if (dgvRewards.SortOrder == SortOrder.Descending)
            {
                if (dgvRewards.SortedColumn.Index == 0)
                {
                    rewards.SetList(from s in rewards.GetList() orderby s.ID descending select s);
                }

                if (dgvRewards.SortedColumn.Index == 1)
                {
                    rewards.SetList(from s in rewards.GetList() orderby s.Title descending select s);
                }

                if (dgvRewards.SortedColumn.Index == 2)
                {
                    rewards.SetList(from s in rewards.GetList() orderby s.Description descending select s);
                }
            }
        }
    }
}
