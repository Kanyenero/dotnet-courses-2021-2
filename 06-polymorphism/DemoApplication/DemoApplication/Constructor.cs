namespace DemoApplication
{
	public static class ConstructorDemo
	{
		private static void DemoMain(string[] args)
		{
			// лишаемся возможности просто создать объект
			//CircleWithConstructor c1 = new CircleWithConstructor();
			CircleWithConstructor c2 = new CircleWithConstructor(10.5);
		}
	}

	public class CircleWithConstructor
	{
		public double x;
		public double y;
		private double r;

		/*public CircleWithConstructor()
		{
			x = y = 0;
			r = 1;
		}*/

		public CircleWithConstructor(double r)
		{
			x = y = 0;
			this.r = r;
		}
	}
}
