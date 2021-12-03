using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entities;

namespace Awards.DAL
{
    public class AwardDAOSql : IAwardDAO
    {
        public string ConnectionString { get; set; }


        public AwardDAOSql(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }


        public IEnumerable<Award> GetList()
        {
            var awards = new List<Award>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "AwardGetAll";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Award item = new Award();

                        item.ID = reader.GetInt32(0);
                        item.Title = reader.GetString(1);
                        item.Description = reader.GetString(2);

                        awards.Add(item);
                    }
                }

                connection.Close();
            }

            return awards;
        }
        public Award GetListItem(int id)
        {
            Award item = new Award();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "AwardGetByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item.ID = reader.GetInt32(0);
                        item.Title = reader.GetString(1);
                        item.Description = reader.GetString(2);
                    }
                }

                connection.Close();
            }

            return item;
        }

        public int Add(Award item)
        {
            int id = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "AwardAdd";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@title", item.Title);
                command.Parameters.AddWithValue("@description", item.Description);

                connection.Open();
                object returnedValue = command.ExecuteScalar();
                connection.Close();

                if (returnedValue != null)
                {
                    id = (int)returnedValue;
                    item.ID = id;
                }
            }

            return id;
        }
        public void Remove(Award item)
        {
            Remove(item.ID);
        }
        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "AwardRemove";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void SetData(int awardID, string[] data)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "AwardSetData";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", awardID);
                command.Parameters.AddWithValue("@new_title", data[0]);
                command.Parameters.AddWithValue("@new_descr", data[1]);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
