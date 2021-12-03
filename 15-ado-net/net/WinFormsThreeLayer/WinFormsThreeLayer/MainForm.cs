using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Persons.BL;
using Awards.BL;
using Entities;

namespace WinFormsThreeLayer
{
    public partial class MainForm : Form
    {
        private readonly IPersonBL personsService;
        private readonly IAwardBL awardsService;

        public MainForm()
        {
            InitializeComponent();

            InitDataGridView(
                dgvPersons,
                new string[] { "ID", "Name", "LastName", "Birthdate", "Age", "Awards" },
                new int[] { 40, 80, 120, 120, 50, 400, 100 });

            InitDataGridView(
                dgvAwards,
                new string[] { "ID", "Title", "Description" },
                new int[] { 40, 200, 600 });
        }
        public MainForm(IPersonBL personsService, IAwardBL awardsService) : this()
        {
            this.personsService = personsService;
            this.awardsService = awardsService;

            foreach (Person item in personsService.GetList())
            {
                dgvPersons.Rows.Add(item.GetData());
            }

            foreach (Award item in awardsService.GetList())
            {
                dgvAwards.Rows.Add(item.GetData());
            }
        }

        private void InitDataGridView(DataGridView dgv, string[] cols, int[] cols_width)
        {
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.DarkBlue;
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
                awardsToolStripMenuItem.Enabled = false;
            }
            if (tabControl.SelectedIndex == 1)
            {
                personsToolStripMenuItem.Enabled = false;
                awardsToolStripMenuItem.Enabled = true;
            }
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddPersonForm(AddPersonForm.FormTask.Add, personsService, awardsService))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dgvPersons.Rows.Add(personsService.GetListItem(form.PersonID).GetData());
                }
            }
        }
        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = 0;
            foreach (DataGridViewRow item in dgvPersons.SelectedRows)
            {
                personID = Convert.ToInt32(item.Cells[0].Value);
            }

            using (var form = new AddPersonForm(AddPersonForm.FormTask.Edit, personsService, awardsService, personID))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvPersons.SelectedRows)
                    {
                        for (int i = 0; i < personsService.GetListItem(personID).GetData().Length; i++)
                        {
                            item.Cells[i].Value = personsService.GetListItem(personID).GetData()[i];
                        }
                    }
                }
            }
        }
        private void removePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = 0;
            foreach (DataGridViewRow item in dgvPersons.SelectedRows)
            {
                personID = Convert.ToInt32(item.Cells[0].Value);
            }

            using (var form = new DeleteAlarmForm())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    personsService.Remove(personID);

                    foreach (DataGridViewRow item in dgvPersons.SelectedRows)
                    {
                        dgvPersons.Rows.RemoveAt(item.Index);
                    }
                }

            }
        }

        private void addAwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddAwardForm(AddAwardForm.FormTask.Add, awardsService))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dgvAwards.Rows.Add(awardsService.GetListItem(form.AwardID).GetData());
                }
            }
        }
        private void editAwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int awardID = 0;
            foreach (DataGridViewRow item in dgvAwards.SelectedRows)
            {
                awardID = Convert.ToInt32(item.Cells[0].Value);
            }  

            using (var form = new AddAwardForm(AddAwardForm.FormTask.Edit, awardsService, awardID))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Award updatedAward = awardsService.GetListItem(awardID);

                    // Обновить таблицу наград
                    foreach (DataGridViewRow item in dgvAwards.SelectedRows)
                    {
                        for (int i = 0; i < updatedAward.GetData().Length; i++)
                        {
                            item.Cells[i].Value = updatedAward.GetData()[i];
                        }
                    }

                    // Обновить награды персон
                    foreach (Person p in personsService.GetList())
                    {
                        int idx = p.Awards.FindIndex(0, p.Awards.Count, thisItem => thisItem.ID == awardID);
                        if (idx != -1)
                        {
                            p.Awards[idx].Title = updatedAward.Title;
                            p.Awards[idx].Description = updatedAward.Description;
                        }
                    }

                    // Обновить таблицу персон
                    foreach (DataGridViewRow item in dgvPersons.Rows)
                    {
                        int personID = Convert.ToInt32(item.Cells[0].Value);

                        Person p = personsService.GetListItem(personID);

                        for (int i = 0; i < p.GetData().Length; i++)
                        {
                            item.Cells[i].Value = p.GetData()[i];
                        }
                    }
                }
            }
        }
        private void removeAwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int awardID = 0;
            foreach (DataGridViewRow item in dgvAwards.SelectedRows)
            {
                awardID = Convert.ToInt32(item.Cells[0].Value);
            }

            using (var form = new DeleteAlarmForm())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Обновить таблицу наград
                    foreach (DataGridViewRow item in dgvAwards.SelectedRows)
                    {
                        dgvAwards.Rows.RemoveAt(item.Index);
                    }

                    // Обновить награды персон
                    foreach (Person p in personsService.GetList())
                    {
                        personsService.RemoveAward(p.ID, awardID);
                    }

                    // Обновить таблицу персон
                    foreach (DataGridViewRow item in dgvPersons.Rows)
                    {
                        int personID = Convert.ToInt32(item.Cells[0].Value);

                        Person p = personsService.GetListItem(personID);

                        for (int i = 0; i < p.GetData().Length; i++)
                        {
                            item.Cells[i].Value = p.GetData()[i];
                        }
                    }

                    // Обновить награды
                    awardsService.Remove(awardID);
                }
            }
        }


        private void dgvPersons_Sorted(object sender, EventArgs e)
        {
            //if (dgvPersons.SortOrder == SortOrder.Ascending)
            //{
            //    if (dgvPersons.SortedColumn.Index == 0)
            //    {
            //        personsService.SetList(from s in persons.GetList() orderby s.ID ascending select s);
            //    }

            //    if (dgvPersons.SortedColumn.Index == 1)
            //    {
            //        personsCollection.SortPersonsByNameAscOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 2)
            //    {
            //        personsCollection.SortPersonsByLastNameAscOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 3)
            //    {
            //        personsCollection.SortPersonsByBirthdateAscOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 4)
            //    {
            //        personsCollection.SortPersonsByAgeAscOrder();
            //    }
            //}

            //if (dgvPersons.SortOrder == SortOrder.Descending)
            //{
            //    if (dgvPersons.SortedColumn.Index == 0)
            //    {
            //        personsCollection.SortPersonsByIDDescOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 1)
            //    {
            //        personsCollection.SortPersonsByNameDescOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 2)
            //    {
            //        personsCollection.SortPersonsByLastNameDescOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 3)
            //    {
            //        personsCollection.SortPersonsByBirthdateDescOrder();
            //    }

            //    if (dgvPersons.SortedColumn.Index == 4)
            //    {
            //        personsCollection.SortPersonsByAgeDescOrder();
            //    }
            //}
        }
        private void dgvAwards_Sorted(object sender, EventArgs e)
        {
            //if (dgvAwards.SortOrder == SortOrder.Ascending)
            //{
            //    if (dgvAwards.SortedColumn.Index == 0)
            //    {
            //        awardsCollection.SortAwardsByIDAscOrder();
            //    }

            //    if (dgvAwards.SortedColumn.Index == 1)
            //    {
            //        awardsCollection.SortAwardsByTitleAscOrder();
            //    }

            //    if (dgvAwards.SortedColumn.Index == 2)
            //    {
            //        awardsCollection.SortAwardsByDescriptionAscOrder();
            //    }
            //}

            //if (dgvAwards.SortOrder == SortOrder.Descending)
            //{
            //    if (dgvAwards.SortedColumn.Index == 0)
            //    {
            //        awardsCollection.SortAwardsByIDDescOrder();
            //    }

            //    if (dgvAwards.SortedColumn.Index == 1)
            //    {
            //        awardsCollection.SortAwardsByTitleDescOrder();
            //    }

            //    if (dgvAwards.SortedColumn.Index == 2)
            //    {
            //        awardsCollection.SortAwardsByDescriptionDescOrder();
            //    }
            //}
        }
    }
}
