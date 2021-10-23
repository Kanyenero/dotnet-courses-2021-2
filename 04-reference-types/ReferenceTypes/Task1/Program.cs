using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(1999, 7, 12);

            try
            {
                User user = new User(dateTime, "Ivanov", "Ivan", "Ivanovich");
                Console.WriteLine(user.UserInfo());
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine($"Error: {exc}");
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine($"Error: {exc}");
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine($"Error: {exc}");
            }
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
            StrToValidState(lastname);
            StrToValidState(name);
            StrToValidState(patronymic);

            

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


        private void StrToValidState(string str)
        {
            if(str == null)
            {
                str = String.Empty;
                Console.WriteLine("Warning! You are passing a null value to the variable [{0}]", nameof(str));
            }
        }

        public string UserInfo()
        {
            return lastname + " " + name + " " + patronymic + " " + age + " years" + " (" + birthday.ToString() + ")";
        }
    }
}
