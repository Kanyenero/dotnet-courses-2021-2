using System;

namespace Task_2
{
    public class User
    {
        private static int _userID;
        private readonly string _name = string.Empty;
        private readonly string _lastname = string.Empty;
        private readonly string _patronymic = string.Empty;
        private readonly DateTime _localDate = DateTime.Now;
        private readonly DateTime _dateOfBirth;
        private readonly int[] _age = new int[3];

        public User(string lastname, string name, string patronymic, DateTime dateOfBirth)
        {
            _userID++;

            _lastname = ProcessNullOrEmptyStr(lastname);
            _name = ProcessNullOrEmptyStr(name);
            _patronymic = ProcessNullOrEmptyStr(patronymic);

            if (DateTime.Compare(dateOfBirth, _localDate) > 0)
            {
                throw new ArgumentOutOfRangeException("Date/time of birth can not be later than the current local date/time", nameof(dateOfBirth));
            }
            else
            {
                _dateOfBirth = dateOfBirth;
            }

            CalculateDatesDifference(LocalDate, DateOfBirth, out int[] datesDifference);
            Array.Copy(datesDifference, _age, datesDifference.Length);
        }

        public int UserID
        {
            get { return _userID; }
        }

        public string LastName
        {
            get { return _lastname; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Patronymic
        {
            get { return _patronymic; }
        }

        public DateTime LocalDate
        {
            get { return _localDate; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
        }

        public int[] Age
        {
            get { return _age; }
        }


        public string ProcessNullOrEmptyStr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "[none]";
            }

            return str;
        }

        public void CalculateDatesDifference(DateTime dateMinuend, DateTime dateSubtrahend, out int[] datesDifference)
        {
            TimeSpan difference = dateMinuend.Subtract(dateSubtrahend);
            DateTime dateResult = DateTime.MinValue + difference; // 01.01.0001 00:00:00 + mm.dd.yyyy hh:mm:ss

            datesDifference = new int[3];
            datesDifference[0] = dateResult.Year - 1;
            datesDifference[1] = dateResult.Month - 1;
            datesDifference[2] = dateResult.Day - 1;
        }

        public string ShowUserInfo()
        {
            return string.Format("Class [{0, 8}]: [id: {1}] {2} {3} {4} (age: [{5} years, {6} months, {7} days], DoB: {8:d})",
                nameof(User), UserID, LastName, Name, Patronymic, Age[0], Age[1], Age[2], DateOfBirth);
        }
    }
}
