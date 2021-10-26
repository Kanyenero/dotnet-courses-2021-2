using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	class ListVsSet
	{
		const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		static readonly Random Random = new Random();

		private static string GetRandomString()
		{
			return new string(Enumerable.Repeat(Chars, 8)
				.Select(s => s[Random.Next(Chars.Length)])
				.ToArray());
		}

		private static void RunTest(ICollection<string> collection)
		{
			var sw = Stopwatch.StartNew();

			for (int i = 0; i < 100000; i++)
			{
				collection.Contains("somestring");
			}
			sw.Stop();

			Console.WriteLine("{0} Elapsed: {1} ms", collection.GetType().Name, sw.ElapsedMilliseconds);
		}

		public static void Demo(string[] args)
		{
			var randomStrings = Enumerable.Range(0, 10000).Select(i => GetRandomString());

			var list = new List<string>(randomStrings);
			var set = new HashSet<string>(randomStrings);

			RunTest(list);
			RunTest(set);
		}
	}
}
