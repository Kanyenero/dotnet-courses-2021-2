using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entities;

namespace Persons.DAL
{
    public class PersonDAOSql : IPersonDAO
	{
		private string connectionString;


		public PersonDAOSql(string connectionString)
		{
			this.connectionString = connectionString;
		}


		public IEnumerable<Person> GetList()
		{
			List<Person> persons = new List<Person>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonGetAll";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var p = new Person();

						p.ID = reader.GetInt32(0);
						p.Name = reader.GetString(1);
						p.LastName = reader.GetString(2);
						p.Birthdate = reader.GetDateTime(3);

						persons.Add(p);
					}
				}

				connection.Close();
			}

			GetAwards(persons);
			return persons;
		}
		public Person GetListItem(int id)
        {
			Person item = new Person();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonGetByID";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", id);

				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						item.ID = reader.GetInt32(0);
						item.Name = reader.GetString(1);
						item.LastName = reader.GetString(2);
						item.Birthdate = reader.GetDateTime(3);
					}
				}

				connection.Close();
			}

			GetAwards(item);
			return item;
		}

		public int Add(Person item)
        {
			int id = -1;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();
				
				command.CommandText = "PersonAdd";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@name", item.Name);
				command.Parameters.AddWithValue("@lastname", item.LastName);
				command.Parameters.AddWithValue("@birthdate", item.Birthdate);
				
				connection.Open();
				object returnedValue = command.ExecuteScalar();
				connection.Close();

				if (returnedValue != null)
                {
					id = (int)returnedValue;
					item.ID = id;
                }

                foreach (Award award in item.Awards)
				{
					AddAward(item, award);
				}
			}

			return id;
		}
		public void Remove(Person item)
		{
			Remove(item.ID);
		}
		public void Remove(int id)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonRemove";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", id);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void SetData(int personID, string[] data)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonSetData";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", personID);
				command.Parameters.AddWithValue("@new_name", data[0]);
				command.Parameters.AddWithValue("@new_lastname", data[1]);
				command.Parameters.AddWithValue("@new_birthdate", DateTime.ParseExact(data[2], "yyyy/MM/dd", null));

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void AddAward(Person person, Award award)
		{
			AddAward(person.ID, award);
		}
		public void AddAward(int personID, Award award)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonSetAward";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", personID);
				command.Parameters.AddWithValue("@awardID", award.ID);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void RemoveAward(Person person, Award award)
		{
			RemoveAward(person.ID, award.ID);
		}
		public void RemoveAward(int personID, int awardID)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonRemoveAward";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", personID);
				command.Parameters.AddWithValue("@awardID", awardID);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void GetAwards(List<Person> list)
        {
			foreach (var item in list)
			{
				GetAwards(item);
			}
		}
		public void GetAwards(Person item)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
            {
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonGetAwards";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", item.ID);

				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var award = new Award();

						award.ID = reader.GetInt32(0);
						award.Title = reader.GetString(1);
						award.Description = reader.GetString(2);

						item.Awards.Add(award);
					}
				}

				connection.Close();
			}
		}

		public void ResetAwards(int personID)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand();

				command.CommandText = "PersonResetAwards";
				command.CommandType = CommandType.StoredProcedure;
				command.Connection = connection;

				command.Parameters.AddWithValue("@personID", personID);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}
	}
}
