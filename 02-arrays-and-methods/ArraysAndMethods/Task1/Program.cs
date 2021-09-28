using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] generatedArray = new int[6];
            int[] sortedArray = new int[6];

            int minArrayValue;
            int maxArrayValue;

            generatedArray = GenerateArray();
            PrintArray(generatedArray);

            Console.WriteLine("~~~~~");

            sortedArray = SortAndGetMinAndMaxValues(generatedArray, out minArrayValue, out maxArrayValue);
            PrintArray(sortedArray);
        }

        static int[] GenerateArray()
        {
            int[] array = new int[6];
            Random rnd = new Random();

            for(int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                array[i] = rnd.Next(-100, 100);
            }

            return array;
        }

        static int[] SortAndGetMinAndMaxValues(int[] arrayToSort, out int minValue, out int maxValue)
        {
            // sorting
            int temp = 0;

            for(int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for(int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if(arrayToSort[j] > arrayToSort[j + 1])
                    {
                        temp = arrayToSort[j];
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
