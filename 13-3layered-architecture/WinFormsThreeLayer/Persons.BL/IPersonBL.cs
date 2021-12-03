using System;
using System.Collections.Generic;

using Entities;

namespace PersonsAndRewards.BL
{
    public interface IPersonBL
    {
        IEnumerable<Person> InitList();
        IEnumerable<Person> GetList();
        void SetList(IEnumerable<Person> list);

        Person GetListItem(int idx);

        void Add(string name, string lastname, string birthdate);
        void Add(Person p);

        void Update(int onIndex, Person toCopy);
        void UpdateRewards(Person p, IRewardBL rs);

        void EditInfo(Person p, Person.InfoField fieldToEdit, string newValue);

        void Remove(Person p);
        void Remove(int id);
    }
}
