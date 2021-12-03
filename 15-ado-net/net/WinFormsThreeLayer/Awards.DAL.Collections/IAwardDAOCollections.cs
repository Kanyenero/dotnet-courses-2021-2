using System;
using System.Collections.Generic;

using Entities;

namespace Awards.DAL.Collections
{
    public interface IAwardDAOCollections
    {
        void Add(Award item);
        void Copy(int idx, Award itemToCopy);
        void Remove(Award item);
        void Remove(int idx);

        void SetTitle(Award item, string newValue);
        void SetDescription(Award item, string newValue);

        IEnumerable<Award> GetList();
        Award GetListItem(int idx);

        string[] GetTitles();

        void SortAwardsByIDAscOrder();
        void SortAwardsByIDDescOrder();

        void SortAwardsByTitleAscOrder();
        void SortAwardsByTitleDescOrder();

        void SortAwardsByDescriptionAscOrder();
        void SortAwardsByDescriptionDescOrder();
    }
}
