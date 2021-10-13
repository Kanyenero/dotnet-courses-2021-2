using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISeries gp = new GeometricProgression(8, 2);
            PrintSeries(gp, 20);
        }

        public static void PrintSeries(ISeries series, int seriesElementsNum)
        {
            for (int i = 0; i < seriesElementsNum; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }
    }

    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
    }


    public class GeometricProgression : ISeries
    {
		double start, step;
		int currentIndex;

		public GeometricProgression(double start, double step)
		{
			this.start = start;
			this.step = step;
			currentIndex = 0;
		}

		public double GetCurrent()
		{
            return start * Math.Pow(step, currentIndex);
		}

		public bool MoveNext()
		{
			currentIndex++;
			return true;
		}
    }

}
