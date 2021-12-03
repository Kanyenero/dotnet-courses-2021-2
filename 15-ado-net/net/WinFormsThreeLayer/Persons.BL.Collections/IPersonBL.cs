using System;
using System.Collections.Generic;

using Entities;

namespace Persons.BL
{
    public interface IPersonBL
    {
        IEnumerable<Person> GetList();
        Person GetListItem(int id);

        int Add(string name, string lastname, string birthdate);
        int Add(Person item);
        void Remove(Person item);
        void Remove(int id);

        void SetData(int personID, string[] data);

        void AddAward(Person person, Award award);
        void AddAward(int personID, Award award);

        void RemoveAward(Person person, Award award);
        void RemoveAward(int personID, int awardID);

        void GetAwards(List<Person> persons);
        void GetAwards(Person person);

        void ResetAwards(int personID);
    }
}
