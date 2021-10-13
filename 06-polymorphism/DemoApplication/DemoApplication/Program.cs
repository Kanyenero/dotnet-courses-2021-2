using System;

namespace DemoApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			Figure[] fig = new Figure[10];

			Random randomGenerator = new Random();
			for (int i = 0; i < fig.Length; i++)
			{
				switch (randomGenerator.Next(3))
				{
					case 0:
						fig[i] = new Rectangle(10, 10);
						break;
					case 1:
						fig[i] = new Round(10);
						break;
					case 2:
						fig[i] = new Ring(10, 5);
						break;
				}
			}

			foreach (Figure figure in fig)
			{
				figure.Draw();
				Console.WriteLine(figure.GetArea());
				Console.WriteLine(figure.IsValid());
			}


		}

		abstract class Figure
		{
			public bool IsValid()
			{
				var area = GetArea();
				return area > 100;
			}

			public abstract double GetArea();
			public abstract void Draw();
		} 

		class Rectangle : Figure
		{
			protected double width, height;

			public Rectangle(double width, double height)
			{
				this.width = width;
				this.height = height;
			}

			public override double GetArea()
			{
				return width * height;
			}

			public override void Draw()
			{
				Console.WriteLine(this.ToString());
			}

			public override string ToString()
			{
				return string.Format("Это прямоугольник со сторонами {0} и {1}", width, height);
			}
		}

		class Round : Figure
		{
			protected double radius;

			public Round(double r)
			{
				radius = r;
			}

			public override double GetArea()
			{
				return Math.PI * radius * radius;
			}

			public override void Draw()
			{
				Console.WriteLine("Это окружность с радиусом {0}", radius);
			}
		}

		class Ring : Round
		{
			protected double innerR;

			public Ring(double r, double ir)
				: base(r)
			{
				innerR = ir;
			}

			public override double GetArea()
			{
				return base.GetArea() - Math.PI * innerR * innerR;
			}

			public override void Draw()
			{
				Console.WriteLine("Это окружность с внешним радиусом {0} и внутренним {1}", radius, innerR);
			}
		}
	}
}
