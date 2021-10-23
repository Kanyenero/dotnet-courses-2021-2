using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray <int> arr1 = new DynamicArray<int>(3);
            //DynamicArray <int> arr2 = new DynamicArray<int>(3);

            int[] arr3 = new int[4] { 11, 22, 33, 44 };

            for (uint idx = 0; idx < arr1.Length; idx++)
                arr1[idx] = (int)idx;

            arr1.Print();

            arr1.Add(40);
            arr1.Add(-20);
            arr1.Print();

            arr1.AddRange(arr3);
            arr1.Print();

            arr1.Remove(0);
            arr1.Remove(44);
            arr1.Print();

            arr1.Insert(10000, 3);
            arr1.Print();

            arr1.Remove(777);
            arr1.Print();
        }
    }
}
