using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;

using Entities;

namespace Awards.DAL.SQL
{
    public class AwardDAOSql : IAwardDAOSql
    {
        private SqlCeConnection connection;
        private string connectionString;

        public AwardDAOSql(string connectionString)
        {
            this.connectionString = connectionString;
            InitConnection();
        }

        public void InitConnection()
        {
            connection = new SqlCeConnection(connectionString);
            connection.Open();
            connection.StateChange += ConnectionStateChange;
        }
        private void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Broken)
            {
                InitConnection();
            }
        }

        public void Add(Award item)
        {
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardAdd";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@title", item.Title);
                command.Parameters.AddWithValue("@description", item.Description);

                connection.Open();

                // Вернуть ID
                var result = command.ExecuteScalar();
                var personID = (int)result;
                item.ID = personID;

                connection.Close();
            }
        }
        public void Remove(int id)
        {
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardRemove";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", id);

                command.ExecuteNonQuery();
            }
        }

        public void SetTitle(int id, string newValue)
        {
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardSetTitle";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", id);
                command.Parameters.AddWithValue("@new_title", newValue);

                command.ExecuteNonQuery();
            }
        }
        public void SetDescription(int id, string newValue)
        {
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardSetDescription";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", id);
                command.Parameters.AddWithValue("@new_descr", newValue);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Award> GetList()
        {
            var awards = new List<Award>();
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardGetAll";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                connection.Open();

                SqlCeDataReader reader = command.ExecuteReader();
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
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardGetByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardID", id);

                connection.Open();

                SqlCeDataReader reader = command.ExecuteReader();
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

        public int GetAwardIDByTitle(string title)
        {
            using (SqlCeCommand command = new SqlCeCommand())
            {
                command.CommandText = "AwardGetIDByName";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@title", title);

                connection.Open();

                // Вернуть ID
                var result = command.ExecuteScalar();
                var id = (int)result;

                connection.Close();

                return id;
            }
        }

        public void Dispose()
        {
            if (connection != null) connection.Dispose();
        }
    }
}
