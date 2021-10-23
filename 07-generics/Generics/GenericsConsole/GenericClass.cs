using System;

namespace GenericsConsole
{
	static class GenericDemo
	{
		public static void DemoMain(string[] args)
		{
			ISeries<int> listInt = new List<int>(new int[] { 5, 8, 6, 3, 1 });
			PrintSeries(listInt);

			ISeries<double> listDouble = new List<double>(new double[] { 5.89, 8.74, 6.48, 3.67, 1.45 }); // нужно чтобы заработало
			PrintSeries(listDouble);

			ISeries<int> progressionInt = new CharSeries("Some string");
			PrintSeries(progressionInt);
		}

		static void PrintSeries<T>(ISeries<T> series)
		{
			series.Reset();

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(series.GetCurrent());
				series.MoveNext();
			}
		}

		interface ISeries<T>
		{
			T GetCurrent();
			bool MoveNext();
			void Reset();
		}

		class CharSeries : ISeries<int>
		{
			private readonly string initialString;
			int index;

			public CharSeries(string initialString)
			{
				this.initialString = initialString;
				index = 0;
			}

			public int GetCurrent()
			{
				return initialString[index];
			}

			public bool MoveNext()
			{
				index++;
				return true;
			}

			public void Reset()
			{
				index = 1;
			}
		}

		class List<T> : ISeries<T>
		{
			private T[] series;
			private int index;

			public List(T[] series)
			{
				this.series = series;
				index = 0;
			}

			public T GetCurrent()
			{
				return series[index];
			}

			public bool MoveNext()
			{
				index = index < series.Length - 1 ? index + 1 : 0;
				return true;
			}

			public void Reset()
			{
				index = 0;
			}
		}
	}
}
