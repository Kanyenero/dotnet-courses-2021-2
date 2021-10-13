using System;

namespace DemoApplication
{
	public class Overload
	{
		public static void DemoMain(string[] args)
		{
			Console.WriteLine(Sum(1, 2));
			Console.WriteLine(Sum(1, 2, 3));

			//Console.WriteLine(); // 19 перегрузок

			// перекрытие методов
			Ring r = new Ring(5, 3);
			Circle c = new Circle(99);
			//double totalR = r.GetLength();
			//double outerR = ((Circle)r).GetLength();


			Console.WriteLine((Circle) r);
			Console.WriteLine(c);

			Console.ReadLine();

			// прегрузка методов
			// override в ConstructorEnharitanceDemo и тоже самое
		}

		public static int Sum(int x, int y)
		{
			return x + y;
		}

		public static int Sum(int x, int y, int z)
		{
			return x + y + z;
		}
	}
}
