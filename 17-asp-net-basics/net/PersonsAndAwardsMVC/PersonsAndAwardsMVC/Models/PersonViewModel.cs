using System;
using System.Collections.Generic;

using Entities;

namespace PersonsAndAwardsMVC.Models
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            Awards = new List<Award>();
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
        public List<Award> Awards { get; set; }

        public string GetAwards()
        {
            string s = string.Empty;
            for (int i = 0; i < Awards.Count; i++)
            {
                if (i == Awards.Count - 1)
                {
                    s += Awards[i].Title;
                    break;
                }
                s += Awards[i].Title + ", ";
            }
            return s;
        }

        public Person ToPerson()
        {
            return new Person
            {
                ID = ID,
                Name = Name,
                LastName = LastName,
                Birthdate = Birthdate,
                Awards = Awards
            };
        }

        public static PersonViewModel GetViewModel(Person item)
        {
            return new PersonViewModel
            {
                ID = item.ID,
                Name = item.Name,
                LastName = item.LastName,
                Birthdate = item.Birthdate,
                Awards = item.Awards
            };
        }
    }
}
