using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication
{
	public class Polymorphism
	{
		public static void DemoMain(string[] args)
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

			for (int i = 0; i < fig.Length; i++)
			{
				double area;

				if (fig[i] is Rectangle)
				{
					area = ((Rectangle)fig[i]).GetArea();
				}
				else if (fig[i] is Ring)
				{
					area = ((Ring)fig[i]).GetArea();
				}
				else if (fig[i] is Round)
				{
					area = ((Round)fig[i]).GetArea();
				}
				else
				{
					// WTF?
					area = 0;
				}

				Console.WriteLine(area);
			}

		}

		class Figure { }

		class Rectangle : Figure
		{
			protected double width, height;

			public Rectangle(double width, double height)
			{
				this.width = width;
				this.height = height;
			}

			public double GetArea()
			{
				return width*height;
			}

			public void Draw()
			{
				Console.WriteLine("Это прямоугольник со сторонами {0} и {1}", width, height);
			}
		}

		class Round : Figure
		{
			protected double radius;

			public Round(double r)
			{
				radius = r;
			}

			public double GetArea()
			{
				return Math.PI*radius*radius;
			}

			public void Draw()
			{
				Console.WriteLine("Это окружность с радиусом {0}", radius);
			}
		}

		class Ring : Round
		{
			protected double innerR;

			public Ring(double r, double ir) : base(r)
			{
				innerR = ir;
			}

			public double GetArea()
			{
				return base.GetArea() - Math.PI * innerR * innerR;
			}

			public void Draw()
			{
				Console.WriteLine("Это окружность с внешним радиусом {0} и внутренним {1}", radius, innerR);
			}
		}
	}
}
