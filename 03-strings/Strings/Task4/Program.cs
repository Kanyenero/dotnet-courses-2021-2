using System;
using System.Text;
using System.Diagnostics;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;

            stopWatch.Start();
            for (int i = 0; i < N; i++) { str += "*";  }
            stopWatch.Stop();

            TimeSpan tsString = stopWatch.Elapsed;

            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < N; i++) { sb.Append("*"); }
            stopWatch.Stop();

            TimeSpan tsStringBuilder = stopWatch.Elapsed;

            Console.WriteLine($"String: {tsString.TotalMilliseconds}");
            Console.WriteLine($"StringBuilder: {tsStringBuilder.TotalMilliseconds}");
        }
    }
}
