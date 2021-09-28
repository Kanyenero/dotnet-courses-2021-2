using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3,3];
            GenerateArray(ref array);
            PrintArray(ref array);

            Console.WriteLine("~~~~~");

            int sum = GetSumOfElementsOnEvenPositions(array);
            Console.WriteLine(sum);
        }

        static int GetSumOfElementsOnEvenPositions(int[,] array)
        {
            int sum = 0;

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    if((i + j) % 2 == 0)
                    {
                        sum += array[i,j];
                    }
                }
            }

            return sum;
        }

        static void GenerateArray(ref int[,] array)
        {
            Random rnd = new Random();

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for(int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    array[i,j] = rnd.Next(-100, 100);
                }
            }
        }

        static void PrintArray(ref int[,] array)
        {
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    Console.WriteLine(array[i,j]);
                }
            }
        }
    }
}
