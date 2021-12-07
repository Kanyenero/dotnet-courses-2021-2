using System;
using System.Collections.Generic;
using System.Linq;

using Entities;

namespace Persons.DAL
{
    public class PersonDAOCollections : IPersonDAO
    {
        private List<Person> persons = new List<Person>();

        public IEnumerable<Person> GetList()
        {
            return persons;
        }
        public Person GetListItem(int id)
        {
            return persons.FirstOrDefault(award => award.ID == id);
        }

        public int Add(Person item)
        {
            if (item == null) { throw new ArgumentNullException("Item was null"); }

            item.ID = persons.Count;
            persons.Add(item);

            return item.ID;
        }
        public void Remove(Person item)
        {
            CheckInput(item);
            Remove(item.ID);
        }
        public void Remove(int id)
        {
            int idx = persons.FindIndex(0, persons.Count, thisItem => thisItem.ID == id);
            persons.Remove(persons[idx]);
        }

        public void SetData(int personID, string[] data)
        {
            int idx = persons.FindIndex(0, persons.Count, thisItem => thisItem.ID == personID);

            persons[idx].Name = data[0];
            persons[idx].LastName = data[1];
            persons[idx].Birthdate = DateTime.ParseExact(data[2], "yyyy/MM/dd", null);
        }

        public void AddAward(Person person, Award award)
        {
            CheckInput(person);

            AddAward(person.ID, award);
        }
        public void AddAward(int personID, Award award)
        {
            CheckInput(award);

            int personIdx = persons.FindIndex(0, persons.Count, thisItem => thisItem.ID == personID);

            if (personIdx != -1 && !persons[personIdx].Awards.Exists(item => item.ID == award.ID))
            {
                persons[personIdx].Awards.Add(award);
            }
        }

        public void RemoveAward(Person person, Award award)
        {
            CheckInput(person);
            CheckInput(award);

            int idx = persons.FindIndex(0, persons.Count, thisItem => thisItem.ID == person.ID);

            if (idx != -1 && persons[idx].Awards.Exists(award => award.ID == award.ID))
            {
                persons[idx].Awards.Remove(award);
            }
        }
        public void RemoveAward(int personID, int awardID)
        {
            int personIdx = persons.FindIndex(0, persons.Count, thisItem => thisItem.ID == personID);
            int awardIdx = persons[personIdx].Awards.FindIndex(0, persons[personIdx].Awards.Count, thisItem => thisItem.ID == awardID);

            if (awardIdx != -1 && personIdx != -1)
                persons[personIdx].Awards.RemoveAt(awardIdx);
        }

        public void GetAwards(List<Person> persons)
        {
            throw new NotImplementedException();
        }
        public void GetAwards(Person person)
        {
            throw new NotImplementedException();
        }

        public void ResetAwards(int personID)
        {
            int personIdx = persons.FindIndex(0, persons.Count, thisItem => thisItem.ID == personID);

            if (personIdx != -1)
                persons[personIdx].Awards.Clear();
        }

        private void CheckInput(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item was null");
            }
            else if (!persons.Contains(item))
            {
                throw new ArgumentException("item doesn't exist");
            }
        }
        private void CheckInput(Award item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item was null");
            }
        }
    }
}
