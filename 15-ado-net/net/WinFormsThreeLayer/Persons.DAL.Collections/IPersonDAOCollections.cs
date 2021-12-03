using System;
using System.Collections.Generic;

using Entities;

namespace Persons.DAL.Collections
{
    public interface IPersonDAOCollections
    {
        void Add(Person item);
        void Copy(int idx, Person itemToCopy);
        void Remove(Person item);
        void Remove(int idx);

        void SetName(Person item, string newValue);
        void SetLastName(Person item, string newValue);
        void SetBirthdate(Person item, string newValue);

        void UpdateAwards(Person item, List<Award> newAwardsList);

        IEnumerable<Person> GetList();
        Person GetListItem(int idx);


        // Отправить в PL


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
