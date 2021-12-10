using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities;

namespace PersonsAndAwardsMVC.Models
{
    public class PersonAndAwardsViewModel
    {
        public Person person { get; set; }
        public IEnumerable<Award> allAvailableAwards { get; set; }

        public PersonAndAwardsViewModel()
        {
            person = new Person();
            allAvailableAwards = new List<Award>();
        }
        public PersonAndAwardsViewModel(IEnumerable<Award> allAvailableAwards)
        {
            person = new Person();
            this.allAvailableAwards = allAvailableAwards;
        }
        public PersonAndAwardsViewModel(Person person, IEnumerable<Award> allAvailableAwards) : this(allAvailableAwards)
        {
            this.person = person;
        }
    }
}
