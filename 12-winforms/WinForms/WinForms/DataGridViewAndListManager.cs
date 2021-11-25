using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace WinForms
{
    public static class DataGridViewAndListManager
    {
        public enum ListAction
        {
            AddItem,
            UpdateItem,
            DeleteItem,
            UpdateRewards
        }
        public enum DataGridViewAction
        {
            AddRow,
            UpdateRowsIndexes,
            UpdateRow,
            DeleteRow,
            UpdateRowsRewards
        }

        public static int ManageDataGridView(DataGridView dgv, List<Person> list, DataGridViewAction key, int id = 0)
        {
            if (key == DataGridViewAction.AddRow)
            {
                if (dgv.Equals(null) || list.Equals(null))
                    throw new ArgumentNullException();

                dgv.Rows.Add(new string[] { list.Last().ID.ToString(),
                                            list.Last().Name,
                                            list.Last().LastName,
                                            list.Last().Birthdate,
                                            list.Last().Age.ToString(),
                                            list.Last().RewardsString});

                return 0;
            }

            if (key == DataGridViewAction.UpdateRow)
            {
                if (dgv.Equals(null) || list.Equals(null))
                    throw new ArgumentNullException();

                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    item.Cells[Convert.ToInt32(MainForm.PersonsGridColumns.Name)].Value = list[id].Name;
                    item.Cells[Convert.ToInt32(MainForm.PersonsGridColumns.LastName)].Value = list[id].LastName;
                    item.Cells[Convert.ToInt32(MainForm.PersonsGridColumns.Birthdate)].Value = list[id].Birthdate;
                    item.Cells[Convert.ToInt32(MainForm.PersonsGridColumns.Age)].Value = list[id].Age;
                    item.Cells[Convert.ToInt32(MainForm.PersonsGridColumns.Rewards)].Value = list[id].RewardsString;
                }

                return 0;
            }

            if (key == DataGridViewAction.DeleteRow)
            {
                id = -1;

                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    int col = Convert.ToInt32(MainForm.PersonsGridColumns.ID);
                    id = Convert.ToInt32(item.Cells[col].Value);
                    dgv.Rows.RemoveAt(item.Index);
                }

                return id; // Возвращаемое значение - id, а не номер строки в таблице
            }

            if (key == DataGridViewAction.UpdateRowsIndexes)
            {
                if (dgv.Equals(null) || list.Equals(null))
                    throw new ArgumentNullException();

                // К примеру:
                // удалили объект p с id = 2

                // Если отсортированно по id:
                // p1 0     l1 0
                // p2 1     l2 1
                // p3 3     l3 2
                // p4 4     l4 3

                // Если отсортированно иначе:
                // p1 3     l1 0
                // p2 1     l2 1
                // p3 4     l3 2
                // p4 0     l4 3

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int id_col = Convert.ToInt32(MainForm.PersonsGridColumns.ID);
                    int curr_id = Convert.ToInt32(item.Cells[id_col].Value);

                    if (curr_id > id)
                    {
                        curr_id--;
                        item.Cells[id_col].Value = list[curr_id].ID;
                    }
                    else
                    {
                        item.Cells[id_col].Value = list[curr_id].ID;
                    }
                }

                return 0;
            }

            if (key == DataGridViewAction.UpdateRowsRewards)
            {
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int id_col = Convert.ToInt32(MainForm.PersonsGridColumns.ID);
                    int curr_id = Convert.ToInt32(item.Cells[id_col].Value);

                    int reward_col = Convert.ToInt32(MainForm.PersonsGridColumns.Rewards);

                    item.Cells[reward_col].Value = list[curr_id].RewardsString;
                }
            }

            return -1;
        }
        public static int ManageDataGridView(DataGridView dgv, List<Reward> list, DataGridViewAction key, int id = 0)
        {
            if (key == DataGridViewAction.AddRow)
            {
                if (dgv.Equals(null) || list.Equals(null))
                    throw new ArgumentNullException();

                dgv.Rows.Add(new string[] { list.Last().ID.ToString(),
                                            list.Last().Title,
                                            list.Last().Description });

                return 0;
            }

            if (key == DataGridViewAction.UpdateRow)
            {
                if (dgv.Equals(null) || list.Equals(null))
                    throw new ArgumentNullException();

                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    item.Cells[Convert.ToInt32(MainForm.RewardsGridColumns.Title)].Value = list[id].Title;
                    item.Cells[Convert.ToInt32(MainForm.RewardsGridColumns.Description)].Value = list[id].Description;
                }

                return 0;
            }

            if (key == DataGridViewAction.DeleteRow)
            {
                id = -1;

                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    int col = Convert.ToInt32(MainForm.RewardsGridColumns.ID);
                    id = Convert.ToInt32(item.Cells[col].Value);
                    dgv.Rows.RemoveAt(item.Index);
                }

                return id;
            }

            if (key == DataGridViewAction.UpdateRowsIndexes)
            {
                if (dgv.Equals(null) || list.Equals(null))
                    throw new ArgumentNullException();

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int id_col = Convert.ToInt32(MainForm.RewardsGridColumns.ID);
                    int curr_id = Convert.ToInt32(item.Cells[id_col].Value);

                    if (curr_id > id)
                    {
                        curr_id--;
                        item.Cells[id_col].Value = list[curr_id].ID;
                    }
                    else
                    {
                        item.Cells[id_col].Value = list[curr_id].ID;
                    }
                }

                return 0;
            }

            return -1;
        }

        public static int ManageList(List<Person> ps, List<Reward> rs, Person item, ListAction key, int id = 0)
        {
            if (key == ListAction.AddItem)
            {
                if (ps.Equals(null) || item.Equals(null))
                    throw new ArgumentNullException();

                item.ID = ps.Count;
                ps.Add(item);

                return 0;
            }

            if (key == ListAction.UpdateItem)
            {
                if (ps.Equals(null) || item.Equals(null))
                    throw new ArgumentNullException();

                ps[id].Name = item.Name;
                ps[id].LastName = item.LastName;
                ps[id].Birthdate = item.Birthdate;
                ps[id].ResetRewards();
                ps[id].AddReward(item.Rewards);

                return 0;
            }

            if (key == ListAction.DeleteItem)
            {
                foreach (Person p in ps)
                {
                    if (p.ID == id)
                    {
                        // Декремент id'шников у элементов, стоящих после удаляемого
                        for (int i = id + 1; i < ps.Count; i++) 
                            ps[i].ID--;

                        // Удалить элемент из коллекции
                        ps.RemoveAt(id);
                        break;
                    }
                }

                return 0;
            }

            if (key == ListAction.UpdateRewards)
            {
                foreach (Person p in ps)
                {
                    if (p.Rewards.Contains(rs[id]))
                    {
                        p.RemoveReward(rs[id]);
                    }
                }

                return 0;
            }

            return -1;
        }
        public static int ManageList(List<Reward> rs, Reward item, ListAction key, int id = 0)
        {
            if (key == ListAction.AddItem)
            {
                if (rs.Equals(null) || item.Equals(null))
                    throw new ArgumentNullException();

                item.ID = rs.Count;
                rs.Add(item);

                return 0;
            }

            if (key == ListAction.UpdateItem)
            {
                if (rs.Equals(null) || item.Equals(null))
                    throw new ArgumentNullException();

                rs[id].Title = item.Title;
                rs[id].Description = item.Description;

                return 0;
            }

            if (key == ListAction.DeleteItem)
            {
                foreach (Reward r in rs)
                {
                    if (r.ID == id)
                    {
                        // Декремент id'шников у элементов, стоящих за удаляемым
                        for (int i = r.ID + 1; i <= rs.Last().ID; i++) rs[i].ID--;
                        rs.RemoveAt(r.ID);
                        break;
                    }
                }

                return 0;
            }

            return -1;
        }
    }
}
