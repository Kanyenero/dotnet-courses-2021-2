using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
			ISeries progression = new ArithmeticalProgression(2, 2);
			Console.WriteLine("Progression:");
			PrintSeries(progression, 10);

			IIndexable list = new List(new double[] { 5, 8, 6, 3, 1 });
			Console.WriteLine("List:");
			PrintIndexable(list, 5);
		}

        public static void PrintSeries(ISeries series, int seriesElementsNum)
        {
            for (int i = 0; i < seriesElementsNum; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

        public static void PrintIndexable(IIndexable indexable, int seriesElementsNum)
        {
            for (int i = 0; i < seriesElementsNum; i++)
            {
                Console.WriteLine(indexable[i]);
            }
        }
    }


	public class ArithmeticalProgression : IIndexableSeries
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
			if(currentIndex < )
            {
				currentIndex++;
				return true;
			}
            else
            {
				return false;
			}
		}

		public void Reset()
		{
			currentIndex = 1;
		}

        public double this[int index]
        {
            get
            {
                return start + step * index;
            }
        }
    }

	public class List : IIndexableSeries
    {
		private double[] series;
		private int currentIndex;

		public List(double[] series)
		{
			this.series = series;
			currentIndex = 0;
		}

		public double GetCurrent()
		{
			return series[currentIndex];
		}

		public bool MoveNext()
		{ 
			if (currentIndex < series.Length - 1)
            {
				currentIndex++;
				return true;
			}
            else
            {
				currentIndex = 0;
				return false;
            }
		}

		public void Reset()
		{
			currentIndex = 0;
		}

        public double this[int index]
        {
            get { return series[index]; }
        }
    }
}
