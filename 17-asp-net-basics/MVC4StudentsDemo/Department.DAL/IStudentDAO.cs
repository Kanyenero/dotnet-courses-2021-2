using System;
namespace Department.DAL
{
	public interface IStudentDAO
	{
		void Add(Entities.Student student);
		System.Collections.Generic.IEnumerable<Entities.Student> GetList();
	}
}
