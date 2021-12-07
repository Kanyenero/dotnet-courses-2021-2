using System;
using System.Collections.Generic;
using System.Linq;

using Entities;
using Awards.DAL;

namespace Awards.BL
{
    public class AwardBLCollections : IAwardBL
    {
        private readonly IAwardDAO awardsDAO;

        public AwardBLCollections(IAwardDAO awardsDAO)
        {
            this.awardsDAO = awardsDAO;
        }

        public IEnumerable<Award> InitList()
        {
            Add("Nobel Prize", "Very high science award");
            Add("Medal of Honor", "Very high wartime award");
            Add("Darwin Award", "The most famous world anti-award");

            return GetList();
        }

        public IEnumerable<Award> GetList()
        {
            return awardsDAO.GetList();
        }

        public Award GetListItem(int id)
        {
            return awardsDAO.GetListItem(id);
        }

        public int Add(string title, string description)
        {
            Award r = new Award(title, description);

            return Add(r);
        }
        public int Add(Award r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            return awardsDAO.Add(r);
        }

        public void Remove(Award r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            awardsDAO.Remove(r);
        }
        public void Remove(int id)
        {
            awardsDAO.Remove(id);
        }

        public void SetData(int awardID, string[] data)
        {
            awardsDAO.SetData(awardID, data);
        }
    }
}
