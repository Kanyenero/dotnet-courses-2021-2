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

                user.Lastname = "Smirnov";
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
            if (!IsStrValid(lastname))
            {
                return;
            }
            if(!IsStrValid(name))
            {
                return;
            }
            if(!IsStrValid(patronymic))
            {
                return;
            }
            else
            {
                this.birthday = birthday;
                this.name = name;
                this.lastname = lastname;
                this.patronymic = patronymic;
            }
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if(IsStrValid(value))
                {
                    this.name = value;
                }
            }
        }

        public string Lastname
        {
            get { return this.lastname; }
            set
            {
                if (IsStrValid(value))
                {
                    this.lastname = value;
                }
            }
        }

        public string Patronymic
        {
            get { return this.patronymic; }
            set
            {
                if (IsStrValid(value))
                {
                    this.patronymic = value;
                }
            }
        }

        public DateTime Birthday
        {
            get { return this.birthday; }
            set 
            {
                this.birthday = value;
            }
        }


        private bool IsStrValid(string str)
        {
            if(str == null)
            {
                str = "";
                Console.WriteLine("Warning! You are passing a null value to the variable {0}", nameof(str));
                return true;
            }

            //if (StrHasDigitsOrPunctuation(str))
            //{
            //    throw new ArgumentException(String.Format("Field [{0}] contains digits or punctuation!", str), "str");
            //}

            return true;
        }

        private bool StrHasDigitsOrPunctuation(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c) || char.IsPunctuation(c))
                    return true;
            }

            return false;
        }

        public string UserInfo()
        {
            return lastname + " " + name + " " + patronymic + " (" + birthday.ToString() + ")";
        }
    }
}
