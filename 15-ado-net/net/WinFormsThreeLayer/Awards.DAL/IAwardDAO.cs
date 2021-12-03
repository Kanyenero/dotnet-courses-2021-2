using System;
using System.Collections.Generic;

using Entities;

namespace Awards.DAL
{
    public interface IAwardDAO
    {
        IEnumerable<Award> GetList();
        Award GetListItem(int id);

        int Add(Award item);
        void Remove(Award item);
        void Remove(int idx);

        void SetData(int awardID, string[] data);
    }
}
