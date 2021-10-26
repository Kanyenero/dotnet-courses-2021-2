using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Interfaces
{
	public class IEnumerableDemo
	{
		public static void DemoMain(string[] args)
		{
			ArithmeticalProgression progression = new ArithmeticalProgression(2, 2);
			Console.WriteLine("Progression:");

			MyClass s = new MyClass();

			foreach (var element in s)
			{
				Console.WriteLine(element);
			}

			List<int> l = new List<int>();
			Dictionary<string, string> d = new Dictionary<string, string>();
			foreach (var item in d)
			{

			}
		}
	}

	public class MyClass : IEnumerable<int>
	{
		int[] arr = new int[] { 4, 5, 6, 7 };

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0; i < arr.Length; i++)
			{
				yield return arr[i];

				if (i == 5)
					yield break;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}



	// переделать на IEnumerable
	public class ArithmeticalProgression
	{
		double start, step;
		int currentIndex;

		public ArithmeticalProgression(double start, double step)
		{
			this.start = start;
			this.step = step;
			this.currentIndex = 1;
		}

		public double GetCurrent()
		{
			return start + step * currentIndex;
		}

		public bool MoveNext()
		{
			if (currentIndex == 10)
				return false;

			currentIndex++;
			return true;
		}

		public void Reset()
		{
			currentIndex = 1;
		}


	}

}

