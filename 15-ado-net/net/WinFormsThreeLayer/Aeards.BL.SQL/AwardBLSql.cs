using System;
using System.Collections.Generic;
using System.Linq;

using Entities;
using Awards.DAL.SQL;

namespace Awards.BL.SQL
{
    public class AwardBLSql
    {
        private readonly IAwardDAOSql awardDAOSql;

        public AwardBLSql(string connection)
        {
            awardDAOSql = new AwardDAOSql(connection);
        }

        public void InitDB()
        {
            Add("Oscar", "Very high cinema award!");
            Add("Medal of Honor", "Very high wartime award!");
            Add("Nobel Prize", "Very high science award!");
        }

        public void Add(string title, string description)
        {
            Award item = new Award(title, description);

            awardDAOSql.Add(item);
        }
        public void Remove(int itemID)
        {
            awardDAOSql.Remove(itemID);
        }

        public void SetTitle(int itemID, string newValue)
        {
            awardDAOSql.SetTitle(itemID, newValue);
        }
        public void SetDescription(int itemID, string newValue)
        {
            awardDAOSql.SetDescription(itemID, newValue);
        }

        public IEnumerable<Award> GetList()
        {
            return awardDAOSql.GetList();
        }
        public Award GetListItem(int itemID)
        {
            return awardDAOSql.GetListItem(itemID);
        }
        public int GetAwardIDByTitle(string title)
        {
            return awardDAOSql.GetAwardIDByTitle(title);
        }
    }
}
