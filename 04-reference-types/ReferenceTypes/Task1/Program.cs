using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(1999, 7, 12);
             
            User user = new User(dateTime, "Ivanov", "Ivan", "Ivanovich");
            Console.WriteLine(user.UserInfo());
        }
    }

    public class User
    {
        private DateTime birthday;
        private string name = string.Empty, 
                       lastname = string.Empty, 
                       patronymic = string.Empty;


        public User(DateTime birthday, string lastname, string name, string patronymic)
        {
            CheckStr(lastname);
            CheckStr(name);
            CheckStr(patronymic);

            this.birthday = birthday;
            
            this.name = name;
            this.lastname = lastname;
            this.patronymic = patronymic;
        }

        public string Name
        {
            get { return name; }
        }

        public string LastName
        {
            get { return lastname; }
        }

        public string Patronymic
        {
            get { return patronymic; }
        }

        public int Age
        {
            get 
            {
                DateTime localDate = DateTime.Now;
                var age = localDate.Year - birthday.Year;
                return age; 
            }
        }

        private void CheckStr(string str)
        {
            if(str is null)
                throw new ArgumentNullException("Str is null");

            char[] arr = str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
                if (Char.IsDigit(arr[i]))
                    throw new ArgumentException("Str cannot contain digits");
        }

        public string UserInfo()
        {
            return lastname + " " + name + " " + patronymic + " " + Age + " years" + " (" + birthday.ToString() + ")";
        }
    }
}
