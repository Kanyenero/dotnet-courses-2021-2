using System;

namespace Task_2
{
    public class Employee : User, IEquatable <Employee>
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

        public bool Equals(Employee emp)
        {
            if (ReferenceEquals(null, emp)) return false;
            if (ReferenceEquals(this, emp)) return true;

            return Name == emp.Name && LastName == emp.LastName && Patronymic == emp.Patronymic &&
                   DateOfBirth == emp.DateOfBirth && EnrollmentDate == emp.EnrollmentDate && Title == emp.Title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var tmp = obj as Employee;

            return base.Equals(tmp);
        }
    }
}
