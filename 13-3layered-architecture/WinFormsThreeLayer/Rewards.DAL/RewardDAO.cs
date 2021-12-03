using System;
using System.Collections.Generic;
using System.Linq;

using Entities;

namespace Rewards.DAL
{
    public class RewardDAO : IRewardDAO
    {
        private List<Reward> rewards = new List<Reward>();

        public void Add(Reward r)
        {
            if (r == null) { throw new ArgumentNullException("Reward was null"); }

            r.ID = rewards.Count;
            rewards.Add(r);
        }

        public void UpdateItem(int idx, Entities.Reward r)
        {
            rewards[idx].Title = r.Title;
            rewards[idx].Description = r.Description;
        }

        public void EditInfo(Reward r, Reward.InfoField fieldToEdit, string newValue)
        {
            CheckInput(r);

            int idx = rewards.FindIndex(reward => reward.ID == r.ID);

            if (fieldToEdit == Reward.InfoField.Title)
            {
                rewards[idx].Title = newValue;
            }

            if (fieldToEdit == Reward.InfoField.Description)
            {
                rewards[idx].Description = newValue;
            }
        }

        public void Remove(Reward r)
        {
            CheckInput(r);

            int idx = rewards.FindIndex(reward => reward.ID == r.ID);

            Remove(idx);
        }

        public void Remove(int idx)
        {
            foreach (Reward reward in rewards)
            {
                if (reward.ID > rewards[idx].ID)
                {
                    reward.ID--;
                }
            }

            rewards.Remove(rewards[idx]);
        }

        public IEnumerable<Reward> GetList()
        {
            return rewards;
        }

        public Reward GetListItem(int idx)
        {
            if (idx < 0 || idx > rewards.Count) throw new ArgumentOutOfRangeException("idx");

            return rewards[idx];
        }

        public void SetList(IEnumerable<Reward> list)
        {
            if (list == null) throw new ArgumentNullException("list");

            rewards = new List<Reward>(list);
        }

        public void CheckInput(Reward r)
        {
            if (r == null)
            {
                throw new ArgumentNullException("Reward was null");
            }
            else if (!rewards.Contains(r))
            {
                throw new ArgumentException($"Reward '{nameof(r)}' doesn't exist");
            }
        }
    }
}
