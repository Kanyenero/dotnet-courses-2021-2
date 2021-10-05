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
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
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

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i,j,k] = rnd.Next(-100, 100);
                    }
                }
            }
        }

        static void Print3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    for(int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.WriteLine(array[i,j,k]);
                    }
                }
            }
        }
    }
}
