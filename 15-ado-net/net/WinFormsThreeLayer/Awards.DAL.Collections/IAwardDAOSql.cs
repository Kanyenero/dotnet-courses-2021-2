using System;
using System.Collections.Generic;

using Entities;

namespace Awards.DAL.SQL
{
    public interface IAwardDAOSql : IDisposable
    {
        void InitConnection();

        void Add(Award item);
        void Remove(int id);

        void SetTitle(int id, string newValue);
        void SetDescription(int id, string newValue);

        IEnumerable<Award> GetList();
        Award GetListItem(int id);

        int GetAwardIDByTitle(string title);
    }
}
