using System;
using System.Collections.Generic;
using System.Text;

using Entities;

namespace Rewards.DAL
{
    public interface IRewardDAO
    {
        void Add(Entities.Reward r);
        void UpdateItem(int id, Entities.Reward r);
        void EditInfo(Entities.Reward r, Entities.Reward.InfoField fieldToEdit, string newValue);
        void Remove(Entities.Reward r);
        void Remove(int id);

        System.Collections.Generic.IEnumerable<Entities.Reward> GetList();
        Entities.Reward GetListItem(int idx);

        void SortRewardsByIDAscOrder();
        void SortRewardsByIDDescOrder();

        void SortRewardsByTitleAscOrder();
        void SortRewardsByTitleDescOrder();

        void SortRewardsByDescriptionAscOrder();
        void SortRewardsByDescriptionDescOrder();
    }
}
