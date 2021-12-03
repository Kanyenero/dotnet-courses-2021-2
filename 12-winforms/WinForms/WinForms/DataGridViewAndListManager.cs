using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace WinForms
{
    public static class DataGridViewAndListManager
    {
        /* DataGridView Person */


        public static void AddRow(DataGridView dgv, List<Person> list)
        {
            if (dgv.Equals(null) || list.Equals(null))
                throw new ArgumentNullException();

            dgv.Rows.Add(new string[] { list.Last().ID.ToString(),
                                            list.Last().Name,
                                            list.Last().LastName,
                                            list.Last().Birthdate,
                                            list.Last().Age.ToString(),
                                            list.Last().RewardsString});
        }
        public static void UpdateRow(DataGridView dgv, List<Person> list, int id)
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
        }
        public static int RemoveRow(DataGridView dgv)
        {
            int id = -1;

            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                int col = Convert.ToInt32(MainForm.PersonsGridColumns.ID);
                id = Convert.ToInt32(item.Cells[col].Value);
                dgv.Rows.RemoveAt(item.Index);
            }

            return id; // Возвращаемое значение - id, а не номер строки в таблице
        }
        public static void UpdateRowsIndexes(DataGridView dgv, List<Person> list, int id)
        {
            if (dgv.Equals(null) || list.Equals(null))
                throw new ArgumentNullException();

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
        }
        public static void UpdateRowsRewards(DataGridView dgv, List<Person> list)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                int id_col = Convert.ToInt32(MainForm.PersonsGridColumns.ID);
                int curr_id = Convert.ToInt32(item.Cells[id_col].Value);

                int reward_col = Convert.ToInt32(MainForm.PersonsGridColumns.Rewards);

                string s = list[curr_id].RewardsString;
                object t = item.Cells[reward_col].Value;


                item.Cells[reward_col].Value = list[curr_id].RewardsString;
            }
        }



        /* DataGridView Rewards */



        public static void AddRow(DataGridView dgv, List<Reward> list)
        {
            if (dgv.Equals(null) || list.Equals(null))
                throw new ArgumentNullException();

            dgv.Rows.Add(new string[] { list.Last().ID.ToString(),
                                            list.Last().Title,
                                            list.Last().Description });
        }
        public static void UpdateRow(DataGridView dgv, List<Reward> list, int id)
        {
            if (dgv.Equals(null) || list.Equals(null))
                throw new ArgumentNullException();

            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                item.Cells[Convert.ToInt32(MainForm.RewardsGridColumns.Title)].Value = list[id].Title;
                item.Cells[Convert.ToInt32(MainForm.RewardsGridColumns.Description)].Value = list[id].Description;
            }
        }
        public static void UpdateRowsIndexes(DataGridView dgv, List<Reward> list, int id)
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
        }



        /* Person */



        public static void AddPerson(List<Person> ps, Person item)
        {
            if (ps.Equals(null) || item.Equals(null))
                throw new ArgumentNullException();

            item.ID = ps.Count;
            ps.Add(item);
        }
        public static void CopyPerson(List<Person> ps, Person item, int id)
        {
            if (ps.Equals(null) || item.Equals(null))
                throw new ArgumentNullException();

            ps[id].Name = item.Name;
            ps[id].LastName = item.LastName;
            ps[id].Birthdate = item.Birthdate;
            ps[id].ResetRewards();
            ps[id].AddReward(item.Rewards);
        }
        public static void DeletePerson(List<Person> ps, int id)
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
        }
        public static void UpdatePersonRewardsOnRemove(List<Person> ps, List<Reward> rs, int id)
        {
            foreach (Person p in ps)
            {
                if (p.Rewards.Contains(rs[id]))
                {
                    p.RemoveReward(rs[id]);
                }
            }
        }
        public static void UpdatePersonRewardsOnEdit(List<Person> ps, Reward oldReward, Reward updatedReward)
        {
            foreach (Person p in ps)
            {
                for (int i = 0; i < p.Rewards.Count; i++)
                {
                    if (p.Rewards[i] == oldReward)
                    {
                        p.Rewards[i] = updatedReward;
                    }
                }
            }
        }



        /* Reward */



        public static void AddReward(List<Reward> rs, Reward item)
        {
            if (rs.Equals(null) || item.Equals(null))
                throw new ArgumentNullException();

            item.ID = rs.Count;
            rs.Add(item);
        }
        public static void DeleteReward(List<Reward> rs, int id)
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
        }
        public static void CopyReward(List<Reward> rs, Reward item, int id)
        {
            if (rs.Equals(null) || item.Equals(null))
                throw new ArgumentNullException();

            rs[id].Title = item.Title;
            rs[id].Description = item.Description;
        }
    }
}
