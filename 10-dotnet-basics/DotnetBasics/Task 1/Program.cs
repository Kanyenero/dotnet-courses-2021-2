using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {

            long m = MathLibrary.MathFunctions.Factorial(5);
            double n = MathLibrary.MathFunctions.Power(5, 3);

            Console.WriteLine("Factorial 5: {0} \nPower(5,5): {1}", m, n);
        }
    }
}
