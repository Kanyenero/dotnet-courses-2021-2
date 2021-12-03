using System;
using System.Collections.Generic;
using System.Linq;

using Entities;

namespace Awards.DAL
{
    public class AwardDAOCollections : IAwardDAO
    {
        private List<Award> awards = new List<Award>();

        public IEnumerable<Award> GetList()
        {
            return awards;
        }
        public Award GetListItem(int id)
        {
            return awards.FirstOrDefault(award => award.ID == id);
        }

        public int Add(Award item)
        {
            if (item == null) { throw new ArgumentNullException("Item was null"); }

            item.ID = awards.Count;
            awards.Add(item);

            return item.ID;
        }
        public void Remove(Award item)
        {
            CheckInput(item);
            Remove(item.ID);
        }
        public void Remove(int id)
        {
            int idx = awards.FindIndex(0, awards.Count, thisItem => thisItem.ID == id);
            awards.Remove(awards[idx]);
        }

        public void SetData(int awardID, string[] data)
        {
            int idx = awards.FindIndex(0, awards.Count, thisItem => thisItem.ID == awardID);

            awards[idx].Title = data[0];
            awards[idx].Description = data[1];
        }

        private void CheckInput(Award item)
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
    }
}
