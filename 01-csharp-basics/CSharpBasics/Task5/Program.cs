using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxNum = 1000;
            int sum = 0;

            for(int i = 0; i < maxNum; i++)
            {
                int mod3 = i % 3; 
                int mod5 = i % 5;

                if (mod3 == 0 || mod5 == 0) 
                { 
                    sum += i; 
                }
            }

            Console.WriteLine(sum);
        }
    }
}
