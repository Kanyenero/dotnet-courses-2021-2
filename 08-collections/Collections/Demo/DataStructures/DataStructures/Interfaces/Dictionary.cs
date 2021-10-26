using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	public static class DictionaryDemo
	{
		public static void Foreach()
		{
			// Example Dictionary again.
			Dictionary<string, int> d = new Dictionary<string, int>()
				{
						{"cat", 2},
						{"dog", 1},
						{"llama", 0},
						{"iguana", -1}
				};

			// Loop over pairs with foreach.
			foreach (KeyValuePair<string, int> pair in d)
			{
				Console.WriteLine("{0}, {1}",
				pair.Key,
				pair.Value);
			}

			// Use var keyword to enumerate dictionary.
			foreach (var pair in d)
			{
				Console.WriteLine("{0}, {1}",
				pair.Key,
				pair.Value);
			}
		}

		public static void ContainsKey()
		{
			Dictionary<string, int> dictionary = 
				new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

			dictionary.Add("apple", 1);
			dictionary.Add("windows", 5);

			// See whether Dictionary contains this string.
			if (dictionary.ContainsKey("Apple"))
			{
				int value = dictionary["apple"];
				Console.WriteLine(value);
			}

			// See whether it contains this string.
			if (!dictionary.ContainsKey("acorn"))
			{
				Console.WriteLine(false);
			}
		}

		public static void TryGetValue()
		{
			Dictionary<string, string> values = new Dictionary<string, string>();

			values.Add("cat", "feline");
			values.Add("dog", "canine");
			// Use TryGetValue.
			string test;

			if (values.TryGetValue("cat", out test)) // Returns true.
			{
				Console.WriteLine(test); // This is the value at cat.
			}

			if (values.TryGetValue("bird", out test)) // Returns false.
			{
				Console.WriteLine(false); // Not reached.
			}
		}
	}
}
