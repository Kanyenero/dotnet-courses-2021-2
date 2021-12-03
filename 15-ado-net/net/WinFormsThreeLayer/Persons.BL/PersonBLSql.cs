using System;
using System.Collections.Generic;
using System.Linq;

using Entities;
using Persons.DAL.SQL;

namespace Persons.BL.SQL
{
    public class PersonBLSql
    {
        private readonly IPersonDAOSql personDAOSql;

        public PersonBLSql(string connection)
        {
            personDAOSql = new PersonDAOSql(connection);
        }

        public void InitDB()
        {
            Add("Ilya", "Varlamov", "1984/01/07");
            Add("Max", "Katz", "1984/12/23");
            Add("Darya", "Besedina", "1988/07/22");
            Add("Leonid", "Volkov", "1980/11/10");
            Add("Kira", "Yarmish", "1989/10/11");
        }

        public int Add(string name, string lastname, string birthdate)
        {
            Person item = new Person(name, lastname, DateTime.ParseExact(birthdate, "yyyy/MM/dd", null));

            return personDAOSql.Add(item);
        }

        public void Remove(int itemID)
        {
            personDAOSql.Remove(itemID);
        }

        public void SetName(int itemID, string newValue)
        {
            personDAOSql.SetName(itemID, newValue);
        }
        public void SetLastName(int itemID, string newValue)
        {
            personDAOSql.SetLastName(itemID, newValue);
        }
        public void SetBirthdate(int itemID, string newValue)
        {
            personDAOSql.SetBirthdate(itemID, newValue);
        }

        public void AddAward(int personID, int awardID)
        {
            personDAOSql.AddAward(personID, awardID);
        }
        public void RemoveAward(int personID, int awardID)
        {
            personDAOSql.RemoveAward(personID, awardID);
        }

        public IEnumerable<Person> GetList()
        {
            return personDAOSql.GetList();
        }
        public Person GetListItem(int itemID)
        {
            return personDAOSql.GetListItem(itemID);
        }
    }
}
