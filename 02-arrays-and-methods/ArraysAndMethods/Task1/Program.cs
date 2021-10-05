using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] generatedArray = GenerateArray();
            PrintArray(generatedArray);

            Console.WriteLine("~~~~~");

            int[] sortedArray = SortAndGetMinAndMaxValues(generatedArray, out int minArrayValue, out int maxArrayValue);
            PrintArray(sortedArray);
        }

        static int[] GenerateArray()
        {
            int[] array = new int[6];
            Random rnd = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 100);
            }

            return array;
        }

        static int[] SortAndGetMinAndMaxValues(int[] arrayToSort, out int minValue, out int maxValue)
        {
            // sorting
            for(int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for(int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if(arrayToSort[j] > arrayToSort[j + 1])
                    {
                        int temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                    }
                }
            }

            //min and max
            minValue = arrayToSort[0];
            maxValue = arrayToSort[arrayToSort.Length - 1];

            return arrayToSort;
        }

        static void PrintArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
