using System;
using System.Collections.Generic;
using System.Linq;

using Entities;

namespace Awards.DAL.Collections
{
    public class AwardDAOCollections : IAwardDAOCollections
    {
        private List<Award> awards = new List<Award>();

        public void Add(Award item)
        {
            if (item == null) { throw new ArgumentNullException("Item was null"); }

            item.ID = awards.Count;
            awards.Add(item);
        }

        public void Copy(int idx, Award awardToCopy)
        {
            if (idx < 0 || idx > awards.Count) { throw new ArgumentOutOfRangeException("Incorrect idx"); }
            if (awardToCopy == null) { throw new ArgumentNullException("Item was null"); }

            awards[idx].Title = awardToCopy.Title;
            awards[idx].Description = awardToCopy.Description;
        }

        public void Remove(Award item)
        {
            CheckInput(item);

            int idx = awards.FindIndex(a => a.ID == item.ID);

            Remove(idx);
        }

        public void Remove(int idx)
        {
            foreach (Award item in awards)
            {
                if (item.ID > awards[idx].ID)
                {
                    item.ID--;
                }
            }

            awards.Remove(awards[idx]);
        }

        public void SetTitle(Award item, string newValue)
        {
            CheckInput(item);

            int idx = awards.FindIndex(item => item.ID == item.ID);
            awards[idx].Title = newValue;
        }
        public void SetDescription(Award item, string newValue)
        {
            CheckInput(item);

            int idx = awards.FindIndex(item => item.ID == item.ID);
            awards[idx].Description = newValue;
        }

        public IEnumerable<Award> GetList()
        {
            return awards;
        }

        public Award GetListItem(int idx)
        {
            if (idx < 0 || idx > awards.Count) throw new ArgumentOutOfRangeException("idx");

            return awards[idx];
        }

        public string[] GetTitles()
        {
            string[] s = { };

            for (int i = 0; i < awards.Count; i++)
            {
                s[i] = awards[i].Title;
            }

            return s;
        }

        public void CheckInput(Award item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item was null");
            }
            else if (!awards.Contains(item))
            {
                throw new ArgumentException($"Item '{nameof(item)}' doesn't exist");
            }
        }


        public void SortAwardsByIDAscOrder()
        {
            awards = (from s in GetList() orderby s.ID ascending select s).ToList();
        }
        public void SortAwardsByIDDescOrder()
        {
            awards = (from s in GetList() orderby s.ID descending select s).ToList();
        }

        public void SortAwardsByTitleAscOrder()
        {
            awards = (from s in GetList() orderby s.Title ascending select s).ToList();
        }
        public void SortAwardsByTitleDescOrder()
        {
            awards = (from s in GetList() orderby s.Title descending select s).ToList();
        }

        public void SortAwardsByDescriptionAscOrder()
        {
            awards = (from s in GetList() orderby s.Description ascending select s).ToList();
        }
        public void SortAwardsByDescriptionDescOrder()
        {
            awards = (from s in GetList() orderby s.Description descending select s).ToList();
        }
    }
}
