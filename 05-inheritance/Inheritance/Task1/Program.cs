using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // test User
            User usr1 = new User("Ivanov", "Ivan", "Ivanovich", new DateTime(1985, 6, 15));
            Console.WriteLine(usr1.ShowUserInfo());

            User usr2 = new User("Sobolev", "Ilya", "Petrovich", new DateTime(1996, 1, 3));
            Console.WriteLine(usr2.ShowUserInfo());

            Console.WriteLine();

            // test Employee
            Employee emp1 = new Employee("Ivanov", "Ivan", "Ivanovich", new DateTime(1985, 6, 15), new DateTime(2007, 5, 8), "Middle .NET Developer");
            Console.WriteLine(emp1.ShowEmployeeInfo());
            Console.WriteLine(emp1.ShowUserInfo());

            Employee emp2 = new Employee("Sobolev", "Ilya", "Petrovich", new DateTime(1996, 1, 3), new DateTime(2007, 5, 8), "Middle .NET Developer");
            Console.WriteLine(emp2.ShowEmployeeInfo());
            Console.WriteLine(emp2.ShowUserInfo());

            Console.WriteLine();

            // test uncorrect states
            Employee emp3 = new Employee(null, "Vladimir", "", new DateTime(1964, 2, 4), new DateTime(2007, 5, 8), "");
            Console.WriteLine(emp3.ShowEmployeeInfo());

            Employee emp4 = new Employee(null, "Vladimir", "", new DateTime(1973, 2, 4), new DateTime(1972, 5, 8), "");
            Console.WriteLine(emp4.ShowEmployeeInfo());
        }
    }


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


    public class Employee : User
    {
        private static int _employeeID;
        private readonly DateTime _enrollmentDate;
        private readonly int[] _experience = new int[3];
        private readonly string _title;

        // У класса User нет конструктора по умолчанию, а есть только конструктор с параметрами,
        // по этому нужно обязательно вызывать конструктор User'a в конструкторе Employee!
        public Employee(string lastname, string name, string patronymic, DateTime dateOfBirth, DateTime enrollmentDate, string title)
            : base(lastname, name, patronymic, dateOfBirth)
        {
            _employeeID++;

            _title = ProcessNullOrEmptyStr(title);

            if (DateTime.Compare(enrollmentDate, dateOfBirth) < 0 || DateTime.Compare(enrollmentDate, LocalDate) > 0)
            {
                throw new ArgumentOutOfRangeException("Enrollment date/time can not be earlier than the date/time of birth" +
                    " and can not be later than the current local date/time", nameof(enrollmentDate));
            }
            else
            {
                _enrollmentDate = enrollmentDate;
            }

            CalculateDatesDifference(LocalDate, EnrollmentDate, out int[] datesDifference);
            Array.Copy(datesDifference, _experience, datesDifference.Length);
        }

        public DateTime EnrollmentDate
        {
            get { return _enrollmentDate; }
        }

        public int[] Experience
        {
            get { return _experience; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string ShowEmployeeInfo()
        {
            return string.Format("Class [{0, 8}]: [id: {1}] {2} {3} {4} (age: [{5} years, {6} months, {7} days], DoB: {8:d}) " +
                "(work experience: [{9} years, {10} months, {11} days] (from {12:d}) as '{13}')",
                nameof(Employee), _employeeID, LastName, Name, Patronymic, Age[0], Age[1], Age[2], DateOfBirth,
                Experience[0], Experience[1], Experience[2], EnrollmentDate, Title);
        }
    }
}
