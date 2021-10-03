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
            if (!validString(lastname))
            {
                return;
            }
            if(!validString(name))
            {
                return;
            }
            if(!validString(patronymic))
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
                if(validString(value))
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
                if (validString(value))
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
                if (validString(value))
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


        private bool validString(string str)
        {
            if(str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if(str == "")
            {
                throw new ArgumentException("This field can not be empty!");
            }

            if(str.Length > 40)
            {
                throw new ArgumentOutOfRangeException(String.Format("Field [{0}] is too long!", str), "str");
            }

            if(strHasDigitsOrPunctuation(str))
            {
                throw new ArgumentException(String.Format("Field [{0}] contains digits or punctuation!", str), "str");
            }

            return true;
        }

        private bool strHasDigitsOrPunctuation(string str)
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
