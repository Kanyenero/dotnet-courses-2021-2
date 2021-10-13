using System;
using System.Threading;

namespace DemoApplication
{
	static class PropertiesDemo
	{
		public static void DemoMain(string[] args)
		{
			CallDateTime start = new CallDateTime(
				DateTime.Now.Year, DateTime.Now.Month,
				DateTime.Now.Day, DateTime.Now.Hour,
				DateTime.Now.Minute, DateTime.Now.Second);

			// ...... идёт звонок ......

			CallDateTime finish = new CallDateTime(
				DateTime.Now.Year, DateTime.Now.Month,
				DateTime.Now.Day, DateTime.Now.Hour,
				DateTime.Now.Minute, DateTime.Now.Second);


			Thread.Sleep(3000);

		}
	}

	internal class CallDateTime
	{
		public CallDateTime(int year, int month, int day, int hour, int minute, int second)
		{
		}
	}
}
