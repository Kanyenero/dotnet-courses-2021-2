using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using Persons.DAL;
using Awards.DAL;
using Persons.BL;
using Awards.BL;

namespace WinFormsThreeLayer
{
    public enum DataAccessLayerType { Collections , SQL_DB }

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

            string dalType = ConfigurationManager.AppSettings["DAL"];

            if (dalType == "sql")
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                IPersonDAO personsDAO = new PersonDAOSql(connectionString);
                IAwardDAO awardsDAO = new AwardDAOSql(connectionString);

                IPersonBL personsBL = new PersonBLSql(personsDAO);
                IAwardBL awardsBL = new AwardBLSql(awardsDAO);

                //personsBL.Add("Lizzy", "Banks", "2000/05/14");
                //personsBL.Add("Jim", "Morrison", "1997/09/01");
                //personsBL.Add("Karl", "Kimbley", "2003/11/25");

                //awardsBL.Add("Best of the best", ":)");
                //awardsBL.Add("Worst of the worst", ":(");

                //personsBL.AddAward(0, awardsBL.GetListItem(0));
                //personsBL.AddAward(0, awardsBL.GetListItem(1));
                //personsBL.AddAward(1, awardsBL.GetListItem(1));
                //personsBL.AddAward(2, awardsBL.GetListItem(0));

                Application.Run(new MainForm(personsBL, awardsBL));
            }
            else if (dalType == "default")
            {
                IPersonDAO personsDAO = new PersonDAOCollections();
                IAwardDAO awardsDAO = new AwardDAOCollections();

                IPersonBL personsBL = new PersonBLCollections(personsDAO);
                IAwardBL awardsBL = new AwardBLCollections(awardsDAO);

                personsBL.Add("Lizzy", "Banks", "2000/05/14");
                personsBL.Add("Jim", "Morrison", "1997/09/01");
                personsBL.Add("Karl", "Kimbley", "2003/11/25");

                awardsBL.Add("Best of the best", ":)");
                awardsBL.Add("Worst of the worst", ":(");

                personsBL.AddAward(0, awardsBL.GetListItem(0));
                personsBL.AddAward(0, awardsBL.GetListItem(1));
                personsBL.AddAward(1, awardsBL.GetListItem(1));
                personsBL.AddAward(2, awardsBL.GetListItem(0));

                Application.Run(new MainForm(personsBL, awardsBL));
            }
            else
            {
                throw new ArgumentException("Unknown app setting. Use [default] or [sql] instead.");
            }
        }
    }
}
