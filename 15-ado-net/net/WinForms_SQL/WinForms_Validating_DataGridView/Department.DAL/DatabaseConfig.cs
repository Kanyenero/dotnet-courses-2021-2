using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace Department.DAL
{
	public static class DatabaseConfig
	{
		public static string GetConnectionString()
		{
			string databaseName = ConfigurationManager.AppSettings["DatabaseName"];

			SqlCeConnectionStringBuilder builder = new SqlCeConnectionStringBuilder();
			builder.DataSource = databaseName;

			return builder.ToString();
		}
	}
}
