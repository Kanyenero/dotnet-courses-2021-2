using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public static class MathFunctions
    {
        public static long Factorial(int number)
        {
            long n = 1;
            long result = 1;
            for (int i = 0; i < number; i++)
            {
                result *= n;
                n++;
            }

            return result;
        }

        public static double Power(double x, double y)
        {
            double result = x;
            for (int i = 0; i < y; i++)
                result *= x;

            return result;
        }

    }
}
