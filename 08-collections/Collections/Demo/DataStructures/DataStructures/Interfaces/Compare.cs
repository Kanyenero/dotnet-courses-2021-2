using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	class Employee /*: IComparable<Employee>*/
	{
		public int Salary { get; set; }
		public string Name { get; set; }

		/*public int CompareTo(Employee other)
		{
			if (Salary == other.Salary)
			{
				return Name.CompareTo(other.Name);
			}

			return other.Salary.CompareTo(this.Salary);
		}

		public override string ToString()
		{
			return Salary+ "," + Name;
		}*/
	}

	public static class Compare
	{
		static void Test()
		{
			List<Employee> list = new List<Employee>();
			list.Add(new Employee() { Name = "Steve", Salary = 10000 });
			list.Add(new Employee() { Name = "Janet", Salary = 10000 });
			list.Add(new Employee() { Name = "Andrew", Salary = 10000 });
			list.Add(new Employee() { Name = "Bill", Salary = 500000 });
			list.Add(new Employee() { Name = "Lucy", Salary = 8000 });

			// Uses IComparable.CompareTo()
			list.Sort();

			// Uses Employee.ToString
			foreach (var element in list)
			{
				Console.WriteLine(element);
			}
		}
	}
}
