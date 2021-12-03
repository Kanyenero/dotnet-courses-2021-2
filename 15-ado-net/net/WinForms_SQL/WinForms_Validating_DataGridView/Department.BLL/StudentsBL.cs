using Department.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Department.BLL
{
	public class StudentsBL
	{
		private readonly IStudentDAO studentsDAO;

		public StudentsBL()
		{
			//studentsDAO = new StudentDAO();
			studentsDAO = new StudentSqlDAO();
		}

		public IEnumerable<Student> InitList()
		{
			Add(new Student() {
				FullName = "Иванов И.И.", Year = 2010, PassNumber = 90000 });
			Add(new Student() {
				FullName = "Петров И.И.", Year = 2011, PassNumber = 90001 });
			Add(new Student() {
				FullName = "Никитин И.И.", Year = 2012, PassNumber = 90002 });

			return GetList();
		}

		public IEnumerable<Student> SortStudentsByFullNameAsc()
		{
			return (from s in GetList()
						orderby s.FullName ascending
						select s);
		}

		public IEnumerable<Student> SortStudentsByFullNameDesc()
		{
			return (from s in GetList()
						orderby s.FullName descending
						select s).ToList();
		}

		public void Add(string fullName, int year, int passNumber)
		{
			Student student = new Student
			{ 
				FullName = fullName,
				Year = year,
				PassNumber = passNumber
			};

			this.Add(student);
		}

		public void Add(Student student)
		{
			if (student == null)
				throw new ArgumentException("student");

			studentsDAO.Add(student);
		}

		public IEnumerable<Student> GetList()
		{
			return studentsDAO.GetList().ToList();
		}
	}
}
