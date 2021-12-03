using System;
using System.Collections.Generic;


using Entities;
using Awards.DAL;

namespace Awards.BL
{
    public class AwardBLSql : IAwardBL
    {
        private readonly IAwardDAO awardsDAO;


        public AwardBLSql(IAwardDAO awardsDAO)
        {
            this.awardsDAO = awardsDAO;
        }


        public IEnumerable<Award> GetList()
        {
            return awardsDAO.GetList();
        }
        public Award GetListItem(int id)
        {
            return awardsDAO.GetListItem(id);
        }

        public void InitTable()
        {
            Add("Oscar", "Very high cinema award!");
            Add("Medal of Honor", "Very high wartime award!");
            Add("Nobel Prize", "Very high science award!");
        }

        public int Add(string title, string description)
        {
            Award item = new Award(title, description);

            return Add(item);
        }
        public int Add(Award item)
        {
            return awardsDAO.Add(item);
        }
        public void Remove(int itemID)
        {
            awardsDAO.Remove(itemID);
        }
        public void Remove(Award item)
        {
            awardsDAO.Remove(item);
        }

        public void SetData(int awardID, string[] data)
        {
            awardsDAO.SetData(awardID, data);
        }

        //public int GetAwardIDByTitle(string title)
        //{
        //    return awardsDAO.GetAwardIDByTitle(title);
        //}
    }
}
