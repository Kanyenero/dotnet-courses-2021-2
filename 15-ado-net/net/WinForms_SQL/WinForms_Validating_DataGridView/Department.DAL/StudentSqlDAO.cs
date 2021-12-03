using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlServerCe;

namespace Department.DAL
{
	public class StudentSqlDAO : IStudentDAO, IDisposable
	{
		private SqlCeConnection _connection;

		public StudentSqlDAO()
		{
			InitConnection();
		}

		private void InitConnection()
		{
			_connection = new SqlCeConnection(DatabaseConfig.GetConnectionString());
			_connection.Open();
			_connection.StateChange += ConnectionStateChange;
		}

		void ConnectionStateChange(object sender, StateChangeEventArgs e)
		{
			if (e.CurrentState == ConnectionState.Broken)
			{
				InitConnection();
			}
		}

		public void Add(Student student)
		{
			using (SqlCeCommand command = _connection.CreateCommand())
			{
				command.CommandText = String.Format("INSERT INTO Students(FullName, PassNumber, Year) VALUES(@fullName, @passNumber, @year)");

				// параметры добавлять только так. не строкой!
				command.Parameters.Add(new SqlCeParameter("@fullName", SqlDbType.NVarChar));
				command.Parameters.Add(new SqlCeParameter("@passNumber", SqlDbType.Int));
				command.Parameters.Add(new SqlCeParameter("@year", SqlDbType.Int));

				// обязательно вызывать при добавлении параметров
				command.Prepare();

				command.Parameters[0].Value = student.FullName;
				command.Parameters[1].Value = student.PassNumber;
				command.Parameters[2].Value = student.Year;

				// выполняем
				var result = command.ExecuteNonQuery();
			}
		}

		public IEnumerable<Student> GetList()
		{
			using (SqlCeCommand command = new SqlCeCommand("SELECT Id, FullName, Year, PassNumber FROM Students", _connection))
			{
				SqlCeDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					int id = (int)reader["id"]; 
					string fullName = (string)reader["FullName"];
					int year = (int)reader["Year"];
					int passNumber = (int)reader["PassNumber"];

					yield return new Student()
						{
							FullName = fullName,
							Year = year,
							PassNumber = passNumber
						};
				}
			}
		}

		public void Dispose()
		{
			if (_connection != null)
				_connection.Dispose();
		}
	}
}
