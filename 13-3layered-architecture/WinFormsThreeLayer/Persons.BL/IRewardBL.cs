using System;
using System.Collections.Generic;

using Entities;

namespace PersonsAndRewards.BL
{
    public interface IRewardBL
    {
        IEnumerable<Reward> InitList();
        IEnumerable<Reward> GetList();
        void SetList(IEnumerable<Reward> list);

        Reward GetListItem(int id);

        void Add(string title, string description);
        void Add(Reward r);

        void Update(int onIndex, Reward toCopy);

        void EditInfo(Reward r, Reward.InfoField fieldToEdit, string newValue);

        void Remove(Reward r);
        void Remove(int id);
    }
}
