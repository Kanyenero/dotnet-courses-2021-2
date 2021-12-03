using System;
using System.Collections.Generic;
using System.Linq;

using Entities;

namespace Persons.DAL.Collections
{
    public class PersonDAOCollections : IPersonDAOCollections
    {
        private List<Person> persons = new List<Person>();

        public void Add(Person item)
        {
            if (item == null) { throw new ArgumentNullException("Item was null"); }

            item.ID = persons.Count;
            persons.Add(item);
        }
        public void Copy(int idx, Person personToCopy)
        {
            if (idx < 0 || idx > persons.Count) { throw new ArgumentOutOfRangeException("Incorrect idx"); }
            if (personToCopy == null) { throw new ArgumentNullException("Item was null"); }

            persons[idx].Name = personToCopy.Name;
            persons[idx].LastName = personToCopy.LastName;
            persons[idx].Birthdate = personToCopy.Birthdate;
            persons[idx].Awards = personToCopy.Awards;
        }
        public void Remove(Person item)
        {
            CheckInput(item);

            int idx = persons.FindIndex(person => person.ID == item.ID);

            Remove(idx);
        }
        public void Remove(int idx)
        {
            if (idx < 0 || idx > persons.Count) { throw new ArgumentOutOfRangeException("Incorrect idx"); }

            foreach (Person person in persons)
            {
                if (person.ID > persons[idx].ID)
                {
                    person.ID--;
                }
            }

            persons.Remove(persons[idx]);
        }

        public void SetName(Person item, string newValue)
        {
            CheckInput(item);

            int idx = persons.FindIndex(person => person.ID == item.ID);
            persons[idx].Name = newValue;
        }
        public void SetLastName(Person item, string newValue)
        {
            CheckInput(item);

            int idx = persons.FindIndex(person => person.ID == item.ID);
            persons[idx].LastName = newValue;
        }
        public void SetBirthdate(Person item, string newValue)
        {
            CheckInput(item);

            int idx = persons.FindIndex(person => person.ID == item.ID);
            persons[idx].Birthdate = DateTime.ParseExact(newValue, "yyyy/MM/dd", null);
        }

        public void UpdateAwards(Person item, List<Award> newAwardsList)
        {
            CheckInput(item);

            int idx = persons.FindIndex(person => person.ID == item.ID);

            foreach (Award award in persons[idx].Awards)
            {
                if (!newAwardsList.Contains(award))
                {
                    persons[idx].Awards.Remove(award);
                    break;
                }
            }
        }

        public IEnumerable<Person> GetList()
        {
            return persons;
        }
        public Person GetListItem(int idx)
        {
            if (idx < 0 || idx > persons.Count) { throw new ArgumentOutOfRangeException("Incorrect idx"); }

            return persons[idx];
        }

        public void CheckInput(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("person");
            }
            else if (!persons.Contains(item))
            {
                throw new ArgumentException($"Item '{nameof(item)}' doesn't exist");
            }
        }





        public void SortPersonsByIDAscOrder()
        {
            persons = (from s in GetList() orderby s.ID ascending select s).ToList();
        }
        public void SortPersonsByIDDescOrder()
        {
            persons = (from s in GetList() orderby s.ID descending select s).ToList();
        }

        public void SortPersonsByNameAscOrder()
        {
            persons = (from s in GetList() orderby s.Name ascending select s).ToList();
        }
        public void SortPersonsByNameDescOrder()
        {
            persons = (from s in GetList() orderby s.Name descending select s).ToList();
        }

        public void SortPersonsByLastNameAscOrder()
        {
            persons = (from s in GetList() orderby s.LastName ascending select s).ToList();
        }
        public void SortPersonsByLastNameDescOrder()
        {
            persons = (from s in GetList() orderby s.LastName descending select s).ToList();
        }

        public void SortPersonsByBirthdateAscOrder()
        {
            persons = (from s in GetList() orderby s.Birthdate ascending select s).ToList();
        }
        public void SortPersonsByBirthdateDescOrder()
        {
            persons = (from s in GetList() orderby s.Birthdate descending select s).ToList();
        }

        public void SortPersonsByAgeAscOrder()
        {
            persons = (from s in GetList() orderby s.Age ascending select s).ToList();
        }
        public void SortPersonsByAgeDescOrder()
        {
            persons = (from s in GetList() orderby s.Age descending select s).ToList();
        }
    }
}
