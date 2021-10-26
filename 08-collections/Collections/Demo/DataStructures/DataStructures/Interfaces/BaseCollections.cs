using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	class BaseCollections
	{
		public static void Demo(string[] args)
		{
			// (1) Массивы
			int[] vector = new int[3] { 1, 2, 3 };

			// IEnumerable = "перечисляемый"
			foreach (int v in vector)
			{
				Console.WriteLine(v);
			}

			// более удобный "массив"
			List<string> strings = new List<string>(5);
			strings.Add("ABC");
			strings.Add("DEF");
			strings.Add("1");
			strings.Add("1");
			strings.Add("1");
			strings.Add("1"); // #6

			strings.RemoveAt(0);
			strings.Insert(0, "ZZZ");

			int capacity = strings.Capacity;	// = 10
			int count = strings.Count;			// = 6

			// IEnumerable 
			foreach (string s in strings)
			{
				Console.WriteLine(s);
			}

			// связанный список
			LinkedList<string> linkedList = new LinkedList<string>();

			LinkedListNode<string> element = linkedList.AddFirst("Hello");

			linkedList.AddAfter(element, "world");
			linkedList.AddLast("!");

			// IEnumerable 
			foreach (string s in linkedList)
			{
				Console.WriteLine(s);
			}

			// FIFO - first in first out
			Queue<string> queue = new Queue<string>();
			queue.Enqueue("ABC");
			string abc = queue.Dequeue();

			// LIFO - Last in First Out
			Stack<string> stack = new Stack<string>();
			stack.Push("1");
			string pop = stack.Pop();

			Console.ReadKey();
		}
	}
}
