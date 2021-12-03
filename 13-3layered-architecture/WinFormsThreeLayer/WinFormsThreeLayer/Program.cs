using System;
using System.Windows.Forms;

using System.Linq;

using PersonsAndRewards.BL;
using Persons.DAL;
using Rewards.DAL;

namespace WinFormsThreeLayer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IPersonDAO personsDAO = new PersonDAO();
            IRewardDAO rewardsDAO = new RewardDAO();

            IPersonBL persons = new PersonBL(personsDAO);
            IRewardBL rewards = new RewardBL(rewardsDAO);

            // Добавить в коллекции парочку объектов
            persons.InitList();
            rewards.InitList();

            // Добавить всем персонам все награды для теста
            persons.GetList().ToList()[0].Rewards = rewards.GetList().ToList();
            persons.GetList().ToList()[1].Rewards = rewards.GetList().ToList();
            persons.GetList().ToList()[2].Rewards = rewards.GetList().ToList();
            persons.GetList().ToList()[3].Rewards = rewards.GetList().ToList();
            persons.GetList().ToList()[4].Rewards = rewards.GetList().ToList();


            Application.Run(new MainForm(persons, rewards));
        }
    }
}
