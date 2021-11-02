using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Ivanov", "Ivan", "Ivanovich", new DateTime(1985, 6, 15), new DateTime(2007, 5, 8), "Middle .NET Developer");
            Employee emp2 = new Employee("Ivanov", "Ivan", "Ivanovich", new DateTime(1985, 6, 15), new DateTime(2007, 5, 8), "Middle .NET Developer");

            if (emp1.Equals(emp2))
                Console.WriteLine("This is equal employees");
            else
                Console.WriteLine("This is unequal employees");
        }
    }
}

// Output

//This is equal employees
