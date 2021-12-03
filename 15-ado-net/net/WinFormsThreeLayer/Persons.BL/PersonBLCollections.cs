using System;
using System.Collections.Generic;
using System.Linq;

using Entities;
using Persons.DAL;

namespace Persons.BL
{
    public class PersonBLCollections : IPersonBL
    {
        private readonly IPersonDAO personsDAO;


        public PersonBLCollections(IPersonDAO personsDAO)
        {
            this.personsDAO = personsDAO;
        }


        public IEnumerable<Person> InitList()
        {
            Add("Ilya", "Varlamov", "1984/01/07");
            Add("Max", "Katz", "1984/12/23");
            Add("Darya", "Besedina", "1988/07/22");
            Add("Leonid", "Volkov", "1980/11/10");
            Add("Kira", "Yarmish", "1989/10/11");

            return GetList();
        }

        public IEnumerable<Person> GetList()
        {
            return personsDAO.GetList();
        }
        public Person GetListItem(int id)
        {
            return personsDAO.GetListItem(id);
        }

        public int Add(string name, string lastname, string birthdate)
        {
            Person p = new Person(name, lastname, DateTime.ParseExact(birthdate, "yyyy/MM/dd", null));

            return Add(p);
        }
        public int Add(Person p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            return personsDAO.Add(p);
        }

        public void Remove(Person p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            personsDAO.Remove(p);
        }
        public void Remove(int id)
        {
            personsDAO.Remove(id);
        }

        public void SetData(int personID, string[] data)
        {
            personsDAO.SetData(personID, data);
        }

        public void AddAward(Person person, Award award)
        {
            personsDAO.AddAward(person, award);
        }
        public void AddAward(int personID, Award award)
        {
            personsDAO.AddAward(personID, award);
        }

        public void RemoveAward(Person person, Award award)
        {
            personsDAO.RemoveAward(person, award);
        }
        public void RemoveAward(int personID, int awardID)
        {
            personsDAO.RemoveAward(personID, awardID);
        }

        public void GetAwards(List<Person> persons)
        {
            personsDAO.GetAwards(persons);
        }
        public void GetAwards(Person person)
        {
            personsDAO.GetAwards(person);
        }

        public void ResetAwards(int personID)
        {
            personsDAO.ResetAwards(personID);
        }
    }
}
