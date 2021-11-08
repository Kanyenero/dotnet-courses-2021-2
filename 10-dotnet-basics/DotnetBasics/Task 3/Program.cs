using System;

namespace Task_3
{
    class Program 
    {
        static void Main(string[] args)
        {
            int[] numbers = { -5, 0, 10, -7, 1, 16, -4 };
            int[] answer = RemoveNegativesFromArray(numbers);

            foreach(int item in answer)
            {
                Console.WriteLine(item);
            }
        }

        static int[] RemoveNegativesFromArray(int[] arr)
        {
            return Array.FindAll(arr, x => x >= 0);
        }
    }
}
