using System;
using System.Collections.Generic;
using System.Text;

namespace WinForms
{
    public class Person
    {
        private string name;
        private string lastname;
        private DateTime birthdate;
        private List<Reward> rewards;

        public Person() 
        {
            rewards = new List<Reward>();
        }
        public Person(List<Reward> rs)
        {
            rewards = rs;
        }
        public Person(string name, string lastname, string birthdate)
        {
            this.name = name;
            this.lastname = lastname;
            this.birthdate = DateTime.ParseExact(birthdate, "dd/MM/yyyy", null);
            rewards = new List<Reward>();
        }

        public int ID { get; set; }
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
        public string LastName 
        { 
            get { return lastname; } 
            set { lastname = value; } 
        }
        public string Birthdate 
        { 
            get { return birthdate.ToString("dd/MM/yyyy"); }
            set { birthdate = DateTime.Parse(value); }
        }
        public int Age 
        { 
            get 
            {
                TimeSpan ts = DateTime.Now.Subtract(birthdate);
                DateTime dt = DateTime.MinValue + ts;
                return dt.Year - 1; 
            } 
        }

        public List<Reward> Rewards
        {
            get { return rewards; }
        }
        public string RewardsString
        {
            get 
            {
                string s = string.Empty;
                for (int i = 0; i < rewards.Count; i++)
                {
                    if (i == rewards.Count - 1)
                    {
                        s += rewards[i].Title;
                        break;
                    }

                    s += rewards[i].Title + ", ";
                }

                return s;
            }
        }
        
        public void AddReward(List<Reward> rs)
        {
            foreach (Reward r in rs)
            {
                if (!rewards.Contains(r))
                {
                    rewards.Add(r);
                }
            }
        }
        public void AddReward(Reward r)
        {
            if (!rewards.Contains(r))
            {
                rewards.Add(r);
            }
        }
        public void ResetRewards()
        {
            rewards.Clear();
        }
        public void RemoveReward(Reward r)
        {
            if (rewards.Contains(r))
            {
                rewards.Remove(r);
            }
        }
        public void RemoveReward(string rewardTitle)
        {
            foreach (Reward r in rewards)
            {
                if (r.Title == rewardTitle)
                {
                    rewards.Remove(r);
                    break;
                }
            }
        }
    }
}
