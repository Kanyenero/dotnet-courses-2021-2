using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program calculates all nature nums divisible by 3 and 5 (up to 1000)");

            int maxNum = 1000;
            int sum = 0;
            int mod3 = 0;
            int mod5 = 0;

            for(int i = 0; i < maxNum; i++)
            {
                mod3 = i % 3; mod5 = i % 5;

                if (mod3 == 0) { sum += i; }
                else if (mod5 == 0) { sum += i; }
                else {  }
            }

            Console.WriteLine(sum);
        }
    }
}
