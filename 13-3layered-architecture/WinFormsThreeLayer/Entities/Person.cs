using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Person
    {
        public enum InfoField { ID, Name, LastName, Birthdate }

        public Person() 
        {
            Rewards = new List<Reward>();
        }
        public Person(string name, string lastname, DateTime birthdate) : this()
        {
            Name = name;
            LastName = lastname;
            Birthdate = birthdate;
        }
        public Person(string name, string lastname, DateTime birthdate, List<Reward> rs) : this(name, lastname, birthdate)
        {
            Rewards = new List<Reward>(rs);
        }
        public Person(Person person) : this()
        {
            ID = person.ID;
            Name = person.Name;
            LastName = person.LastName;
            Birthdate = person.Birthdate;
            Rewards = person.Rewards;
        }


        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        public int Age 
        {
            get
            {
                TimeSpan ts = DateTime.Now.Subtract(Birthdate);
                DateTime dt = DateTime.MinValue + ts;
                return dt.Year - 1;
            }
        }

        public List<Reward> Rewards { get; set; }

        public string GetRewards() 
        {
            string s = string.Empty;

            if (Rewards != null)
            {
                foreach (Reward r in Rewards)
                {
                    s += r.Title + ", ";
                }
            }

            return s;
        }
        public string[] GetFieldsValues() 
        {
            return new string[] { ID.ToString(), Name, LastName, 
                                  Birthdate.ToString("dd/MM/yyyy"), Age.ToString(), GetRewards() };
        }
        public static string[] GetFieldsNames() 
        {
            return new string[] { nameof(ID), nameof(Name), nameof(LastName), 
                                  nameof(Birthdate), nameof(Age), nameof(Rewards) };
        }
    }
}
