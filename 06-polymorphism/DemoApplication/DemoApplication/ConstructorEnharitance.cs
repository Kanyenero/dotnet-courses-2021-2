using System;

namespace DemoApplication
{
	public static class ConstructorEnharitanceDemo
	{
		public static void DemoMain(string[] args)
		{
			Circle c = new Ring();
			c.r = 5;
			//c.InnerR = 4; // ошибка!

			((Ring)c).InnerR = 4;
		}
	}

	class Ring : Circle
	{
		public int InnerR;

		public Ring()
		{
		}

		public Ring(int r, int ir) : base(r)
		{
			InnerR = ir;
		}

		public override double GetLength()
		{
			return base.GetLength() + 2 * Math.PI * InnerR;
		}

		public override string ToString()
		{
			return "Кольцо с внутренним радиусом " + InnerR;
		}
	}

	class Circle
	{
		public int x, y, r;

		public Circle()
		{
			x = y = r = 0;
		}

		public Circle(int r) : this()
		{
			this.r = r;
		}

		public virtual double GetLength()
		{
			return 2 * Math.PI * r;
		}

		public override string ToString()
		{
			return "Окружность с радиусом " + r;
		}
	}
}
