using System;
using System.Collections.Generic;
using System.Text;

using Entities;

namespace Persons.DAL
{
    public interface IPersonDAO
    {
        void Add(Entities.Person p);
        void UpdateItem(int id, Entities.Person p);
        void EditInfo(Entities.Person p, Entities.Person.InfoField fieldToEdit, string newValue);
        void EditRewards(Person p, List<Reward> rs);
        void Remove(Entities.Person p);
        void Remove(int id);

        System.Collections.Generic.IEnumerable<Entities.Person> GetList();
        Entities.Person GetListItem(int idx);

        void SortPersonsByIDAscOrder();
        void SortPersonsByIDDescOrder();

        void SortPersonsByNameAscOrder();
        void SortPersonsByNameDescOrder();

        void SortPersonsByLastNameAscOrder();
        void SortPersonsByLastNameDescOrder();

        void SortPersonsByBirthdateAscOrder();
        void SortPersonsByBirthdateDescOrder();

        void SortPersonsByAgeAscOrder();
        void SortPersonsByAgeDescOrder();
    }
}
