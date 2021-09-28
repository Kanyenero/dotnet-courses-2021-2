using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[4,3,2];

            GenerateArray(ref array);
            Print3DArray(array);

            Console.WriteLine("~~~~~");

            ReplacePositiveElementsWithZero(ref array);
            Print3DArray(array);
        }

        static void ReplacePositiveElementsWithZero(ref int[,,] array)
        {
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    for (int k = array.GetLowerBound(2); k <= array.GetUpperBound(2); k++)
                    {
                        if(array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        static void GenerateArray(ref int[,,] array)
        {
            Random rnd = new Random();

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    for (int k = array.GetLowerBound(2); k <= array.GetUpperBound(2); k++)
                    {
                        array[i,j,k] = rnd.Next(-100, 100);
                    }
                }
            }
        }

        static void Print3DArray(int[,,] array)
        {
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for(int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    for(int k = array.GetLowerBound(2); k <= array.GetUpperBound(2); k++)
                    {
                        Console.WriteLine(array[i,j,k]);
                    }
                }
            }
        }
    }
}
