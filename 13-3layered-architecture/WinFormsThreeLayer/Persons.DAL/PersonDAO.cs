using System;
using System.Collections.Generic;
using System.Linq;

using Entities;

namespace Persons.DAL
{
    public class PersonDAO : IPersonDAO
    {
        private List<Person> persons = new List<Person>();

        public void Add(Person p)
        {
            if (p == null) { throw new ArgumentNullException("Person was null"); }

            p.ID = persons.Count;
            persons.Add(p);
        }

        public void UpdateItem(int idx, Entities.Person p)
        {
            persons[idx].Name = p.Name;
            persons[idx].LastName = p.LastName;
            persons[idx].Birthdate = p.Birthdate;
            persons[idx].Rewards = p.Rewards;
        }

        public void EditInfo(Person p, Person.InfoField fieldToEdit, string newValue)
        {
            CheckInput(p);

            int idx = persons.FindIndex(person => person.ID == p.ID);

            if (fieldToEdit == Person.InfoField.Name)
            {
                persons[idx].Name = newValue;
            }

            if (fieldToEdit == Person.InfoField.LastName)
            {
                persons[idx].LastName = newValue;
            }

            if (fieldToEdit == Person.InfoField.Birthdate)
            {
                persons[idx].Birthdate = DateTime.ParseExact(newValue, "dd/MM/yyyy", null);
            }
        }

        public void EditRewards(Person p, List<Reward> rs)
        {
            CheckInput(p);

            int idx = persons.FindIndex(person => person.ID == p.ID);

            foreach (Reward r in persons[idx].Rewards)
            {
                if (!rs.Contains(r))
                {
                    persons[idx].Rewards.Remove(r);
                    break;
                }
            }
        }

        public void Remove(Person p)
        {
            CheckInput(p);

            int idx = persons.FindIndex(person => person.ID == p.ID);

            Remove(idx);
        }
        public void Remove(int idx)
        {
            foreach (Person person in persons)
            {
                if (person.ID > persons[idx].ID)
                {
                    person.ID--;
                }
            }

            persons.Remove(persons[idx]);
        }

        public IEnumerable<Person> GetList()
        {
            return persons;
        }

        public Person GetListItem(int idx)
        {
            if (idx < 0 || idx > persons.Count) throw new ArgumentOutOfRangeException("idx");

            return persons[idx];
        }

        public void CheckInput(Person p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("student");
            }
            else if (!persons.Contains(p))
            {
                throw new ArgumentException($"Person '{nameof(p)}' doesn't exist");
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
