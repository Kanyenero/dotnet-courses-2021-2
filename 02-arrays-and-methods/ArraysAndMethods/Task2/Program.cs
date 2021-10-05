using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[4,3,2];

            GenerateArray(array);
            Print3DArray(array);

            Console.WriteLine("~~~~~");

            ReplacePositiveElementsWithZero(ref array);
            Print3DArray(array);
        }

        static void ReplacePositiveElementsWithZero(ref int[,,] array)
        {
            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j <= array.Length; j++)
                {
                    for (int k = 0; k <= array.Length; k++)
                    {
                        if(array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        static void GenerateArray(int[,,] array)
        {
            Random rnd = new Random();

            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j <= array.Length; j++)
                {
                    for (int k = 0; k <= array.Length; k++)
                    {
                        array[i,j,k] = rnd.Next(-100, 100);
                    }
                }
            }
        }

        static void Print3DArray(int[,,] array)
        {
            for (int i = 0; i <= array.Length; i++)
            {
                for(int j = 0; j <= array.Length; j++)
                {
                    for(int k = 0; k <= array.Length; k++)
                    {
                        Console.WriteLine(array[i,j,k]);
                    }
                }
            }
        }
    }
}
