using System;

namespace DemoApplication
{
	public static class StaticDemo
	{
		public static void DemoMain(string[] args)
		{
			StaticDemoClass.PrintContent();
			StaticDemoClass.Content = "I'm new content";
			StaticDemoClass.PrintContent();
		}
	}

	public static class StaticDemoClass
	{
		public static string Content;

		public static void PrintContent()
		{
			Console.WriteLine(Content);
		}

		static StaticDemoClass()
		{
			Content = "I'm static";
		}
	}
}
