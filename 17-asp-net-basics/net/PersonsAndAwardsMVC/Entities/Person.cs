using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Person
    {
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

        public Person()
        {
            Awards = new List<Award>();
        }
        public Person(string name, string lastname, DateTime birthdate) : this()
        {
            Name = name;
            LastName = lastname;
            Birthdate = birthdate;
        }
        public Person(string name, string lastname, DateTime birthdate, List<Award> rs) : this(name, lastname, birthdate)
        {
            Awards = new List<Award>(rs);
        }
        public Person(Person person) : this()
        {
            ID = person.ID;
            Name = person.Name;
            LastName = person.LastName;
            Birthdate = person.Birthdate;
            Awards = person.Awards;
        }


        public void UpdateAward(int awardID, Award newData)
        {
            int idx = Awards.FindIndex(0, Awards.Count, thisItem => thisItem.ID == awardID);

            Awards[idx].Title = newData.Title;
            Awards[idx].Description = newData.Description;
        }
        public string[] GetAwards() 
        {
            return (Awards?.Select(r => r.Title) ?? new List<string>()).ToArray();
        }
        public string[] GetData() 
        {
            return new string[] { Name, LastName, Birthdate.ToString("yyyy/MM/dd"), 
                                  Age.ToString(), string.Join(",", GetAwards()) };
        }
    }
}
