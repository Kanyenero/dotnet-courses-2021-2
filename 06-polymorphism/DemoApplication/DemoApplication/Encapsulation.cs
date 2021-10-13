using System;

namespace DemoApplication
{
	public static class EncapsulationDemo
	{
		static void DemoMain(string[] args)
		{
			CircleD c = new CircleD();
			c.x = 5;
			c.y = 6;
			//c.r = 7;   // Ошибка
			c.R = 7;   // Вызов метода set
			Console.WriteLine(c.GetLength());
		}
	}

	public class CircleD
	{
		public double x;
		public double y;
		private double r;

		public double R
		{
			get
			{
				return r;
			}
			set
			{
				if (value >= 0)
					r = value;
			}
		}

		public double GetLength()
		{
			return 2 * Math.PI * r;
		}
	}

}
