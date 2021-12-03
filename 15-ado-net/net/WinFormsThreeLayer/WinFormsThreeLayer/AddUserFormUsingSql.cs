using System;
using System.Windows.Forms;
using System.Linq;

using Persons.BL;
using Awards.BL;

namespace WinFormsThreeLayer
{
    /*  
     *      В данном файле описана некоторая логика формы 
     *      хранении данных на сервере SQL
     */
    public partial class AddPersonForm : Form
    {
        //private PersonBLSql personsSqlService;
        //private AwardBLSql awardsSqlService;
        //private int personID;

        //public int PersonID
        //{
        //    get { return personID; }
        //}

        //public AddUserForm(FormTask task, int personID, PersonBLSql personsSqlService, AwardBLSql awardsSqlService) : this()
        //{
        //    daltype = DALType.SQL;

        //    this.personsSqlService = personsSqlService;
        //    this.awardsSqlService = awardsSqlService;

        //    string[] personData = { };
        //    string[] awardsTitles = { };

        //    if (task == FormTask.Add)
        //    {
        //        this.personID = personsSqlService.Add(string.Empty, string.Empty, string.Empty);
        //    }
        //    if (task == FormTask.Edit)
        //    {
        //        this.personID = personID;

        //        personData = personsSqlService.GetListItem(personID).GetData();
        //        awardsTitles = awardsSqlService.GetList()?.Select(r => r.Title).ToArray();
        //    }

        //    InitializeUI(task, personData, awardsTitles);
        //}
    }
}
