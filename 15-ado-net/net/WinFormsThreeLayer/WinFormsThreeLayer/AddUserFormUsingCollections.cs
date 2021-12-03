using System;
using System.Windows.Forms;
using System.Linq;

using Entities;
using Awards.BL;

namespace WinFormsThreeLayer
{
    /* 
     *      В данном файле описана некоторая логика формы 
     *      при обработке и хранении данных в памяти приложения
     */
    public partial class AddPersonForm : Form
    {
        //private Person person;
        //private AwardBLCollection allAvailableAwards;

        //// Возвращает результирующее значение формы
        //public Person Person 
        //{
        //    get { return person; } 
        //}

        //public AddUserForm(FormTask task, Person person, AwardBLCollection allAvailableAwards) : this()
        //{
        //    daltype = DALType.Collections;

        //    InitializeVariables(person, allAvailableAwards);
        //    InitializeUI(task, person.GetData(), allAvailableAwards.GetTitles());
        //}

        //private void InitializeVariables(Person p, AwardBLCollection rs)
        //{
        //    if (p == null)
        //        person = new Person();
        //    else
        //        person = new Person(p);

        //    if (rs == null)
        //        throw new ArgumentNullException("Input value of type 'Award' must not be null");
        //    else
        //        allAvailableAwards = new AwardBLCollection(rs);
        //}
    }
}
