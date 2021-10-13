using System;

namespace DemoApplication
{
	public static class ProtectedDemo
	{
		public static void DemoMain(string[] args)
		{
			var a = new A();
			var b = new B();
			var c = new C();
		}
	}

	class A
	{
		private int X;
		protected int Y;
		public int Z;

		public void DoSomething()
		{
			Console.WriteLine(X);
			Console.WriteLine(Y);
			Console.WriteLine(Z);
		}
	}

	class B : A
	{
		public void DoSomething()
		{
			//Console.WriteLine(X);
			Console.WriteLine(Y);
			Console.WriteLine(Z);
		}
	}

	class C : B
	{
		public void DoSomething()
		{
			//Console.WriteLine(X);
			Console.WriteLine(Y);
			Console.WriteLine(Z);
		}
	}

}
