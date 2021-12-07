using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;  

namespace Entities
{


	public class Student
	{
		private static int idCounter = 0;

		[StringLength(50), Required]
		public string FullName { get; set; }

		[Range(2000, 2100)]
		public int Year { get; set; }

		[Required]
		public int PassNumber { get; set; }

		private int _id = -1;
		public int Id
		{
			get
			{
				return _id != -1 ? _id : (_id = idCounter++);
			}
		}
	}
}
