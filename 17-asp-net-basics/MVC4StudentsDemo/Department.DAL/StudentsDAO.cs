using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Department.DAL
{
	public class StudentDAO : IStudentDAO
	{
		private List<Student> students = new List<Student>();

		public void Add(Student student)
		{
			if (student == null)
				throw new ArgumentException("student");

			students.Add(student);
		}

		public IEnumerable<Student> GetList()
		{
			return students;
		}
	}

	public class StudentDAOdb : IStudentDAO
	{
		public void Add(Student student)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Student> GetList()
		{
			throw new NotImplementedException();
		}
	}
}
