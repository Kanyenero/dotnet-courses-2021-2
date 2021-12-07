using System;
using System.Collections.Generic;

namespace TestMvc2.Models
{
	public class User
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime Birthdate { get; set; }

		public int Age
		{
			get
			{
				//
				return DateTime.Now.Year - Birthdate.Year;
			}
		}

		public List<Reward> Rewards { get; set; }
	}
}