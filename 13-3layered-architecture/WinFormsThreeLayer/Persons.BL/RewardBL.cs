using System;
using System.Collections.Generic;
using System.Linq;

using Entities;
using Rewards.DAL;

namespace PersonsAndRewards.BL
{
    public class RewardBL : IRewardBL
    {
        private readonly IRewardDAO rewardsDAO;

        public RewardBL(IRewardDAO rewardsDAO)
        {
            this.rewardsDAO = rewardsDAO;
        }

        public IEnumerable<Reward> InitList()
        {
            Add("Nobel Prize", "Very high science award");
            Add("Medal of Honor", "Very high wartime award");
            Add("Darwin Award", "The most famous world anti-award");

            return GetList();
        }

        public IEnumerable<Reward> GetList()
        {
            return rewardsDAO.GetList();
        }

        public Reward GetListItem(int id)
        {
            return rewardsDAO.GetListItem(id);
        }

        public void SetList(IEnumerable<Reward> list)
        {
            rewardsDAO.SetList(list);
        }

        public void Add(string title, string description)
        {
            Reward r = new Reward(title, description);

            Add(r);
        }

        public void Add(Reward r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            rewardsDAO.Add(r);
        }

        public void Update(int onIndex, Reward toCopy)
        {
            if (toCopy == null) throw new ArgumentNullException(nameof(toCopy));

            rewardsDAO.UpdateItem(onIndex, toCopy);
        }

        public void EditInfo(Reward r, Reward.InfoField fieldToEdit, string newValue)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            rewardsDAO.EditInfo(r, fieldToEdit, newValue);
        }

        public void Remove(Reward r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            rewardsDAO.Remove(r);
        }

        public void Remove(int id)
        {
            if (id < 0 || id > rewardsDAO.GetList().Count())
                throw new ArgumentOutOfRangeException("id");

            rewardsDAO.Remove(id);
        }
    }
}
