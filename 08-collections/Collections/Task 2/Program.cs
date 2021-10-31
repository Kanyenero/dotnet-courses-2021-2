using System;
using System.Collections.Generic;


namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(10);
            for (int i = 0; i < 10; i++)
                list.Add(i);

            DynamicArray<int> arr = new DynamicArray<int>(list);

            foreach (int item in arr)
                Console.WriteLine(item);
        }
    }
}
