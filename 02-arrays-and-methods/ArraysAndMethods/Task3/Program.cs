using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            GenerateArray(ref array);
            PrintArray(ref array);

            Console.WriteLine("~~~~~");

            int sum = GetSumOfNonNegativeElements(array);
            Console.WriteLine(sum);
        }

        static int GetSumOfNonNegativeElements(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0) 
                {
                    sum += array[i]; 
                }
            }

            return sum;
        }

        static void GenerateArray(ref int[] array)
        {
            Random rnd = new Random();

            for (int i = 0; i <= array.Length; i++)
            {
                array[i] = rnd.Next(-100, 100);
            }
        }

        static void PrintArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
