using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

using Persons.DAL;
using Persons.BL;
using Awards.DAL;
using Awards.BL;

namespace PersonsAndAwardsMVC
{
    public class MySingletonService : IMySingletonService
    {
        private IConfiguration config;

        private readonly IPersonBL personsService;
        private readonly IAwardBL awardsService;

        public MySingletonService(IConfiguration config)
        {
            this.config = config;

            string dalType = this.config.GetValue<string>("AppSettings:DAL");

            if (dalType == "sql")
            {
                string connectionString = this.config.GetValue<string>("ConnectionStrings:DefaultDBConnection");

                IPersonDAO personDAO = new PersonDAOSql(connectionString);
                personsService = new PersonBLSql(personDAO);

                IAwardDAO awardDAO = new AwardDAOSql(connectionString);
                awardsService = new AwardBLSql(awardDAO);
            }
            else if (dalType == "default")
            {
                IPersonDAO personDAO = new PersonDAOCollections();
                personsService = new PersonBLCollections(personDAO);

                IAwardDAO awardDAO = new AwardDAOCollections();
                awardsService = new AwardBLCollections(awardDAO);

                personsService.Add("Peter", "Griffin", "2000/03/12");
                personsService.Add("Jimmy", "Neutron", "2003/06/22");
                personsService.Add("Patrick", "Star", "1985/10/01");

                awardsService.Add("Best of the best", "");
                awardsService.Add("Worst of the worst", "");
                awardsService.Add("Funniest of the funniest", "");

                personsService.AddAward(0, awardsService.GetListItem(0));
                personsService.AddAward(0, awardsService.GetListItem(1));
                personsService.AddAward(0, awardsService.GetListItem(2));
                personsService.AddAward(1, awardsService.GetListItem(0));
                personsService.AddAward(1, awardsService.GetListItem(2));
            }
            else
            {
                throw new ArgumentException("Unknown app setting. Use [default] or [sql] instead.");
            }
        }

        public IPersonBL PersonBL { get { return personsService; } }
        public IAwardBL AwardBL { get { return awardsService; } }
    }
}
