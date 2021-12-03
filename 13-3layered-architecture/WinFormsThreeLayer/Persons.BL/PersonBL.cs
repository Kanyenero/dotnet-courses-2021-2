using System;
using System.Collections.Generic;
using System.Linq;

using Entities;
using Persons.DAL;

namespace PersonsAndRewards.BL
{
    public class PersonBL : IPersonBL
    {
        private readonly IPersonDAO personsDAO;

        public PersonBL(IPersonDAO personsDAO)
        {
            this.personsDAO = personsDAO;
        }

        public IEnumerable<Person> InitList()
        {
            Add("Ilya", "Varlamov", "07/01/1984");
            Add("Max", "Katz", "23/12/1984");
            Add("Darya", "Besedina", "22/07/1988");
            Add("Leonid", "Volkov", "10/11/1980");
            Add("Kira", "Yarmish", "11/10/1989");

            return GetList();
        }

        public IEnumerable<Person> GetList()
        {
            return personsDAO.GetList();
        }

        public Person GetListItem(int idx)
        {
            return personsDAO.GetListItem(idx);
        }

        public void SetList(IEnumerable<Person> list)
        {
            personsDAO.SetList(list);
        }

        public void Add(string name, string lastname, string birthdate)
        {
            Person p = new Person(name, lastname, DateTime.ParseExact(birthdate, "dd/MM/yyyy", null));

            Add(p);
        }

        public void Add(Person p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            personsDAO.Add(p);
        }

        public void Update(int onIndex, Person toCopy)
        {
            if (toCopy == null) throw new ArgumentNullException(nameof(toCopy));

            personsDAO.UpdateItem(onIndex, toCopy);
        }

        public void UpdateRewards(Person p, IRewardBL rs)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            personsDAO.EditRewards(p, rs.GetList().ToList());
        }

        public void EditInfo(Person p, Person.InfoField fieldToEdit, string newValue)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            personsDAO.EditInfo(p, fieldToEdit, newValue);
        }

        public void Remove(Person p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            personsDAO.Remove(p);
        }

        public void Remove(int id)
        {
            if (id < 0 || id > personsDAO.GetList().Count())
                throw new ArgumentOutOfRangeException("id");

            personsDAO.Remove(id);
        }
    }
}
