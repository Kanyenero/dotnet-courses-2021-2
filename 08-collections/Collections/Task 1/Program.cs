using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            List<int> list = new List<int>(size);

            Console.WriteLine("List");

            for (int i = 0; i < size; i++)
            {
                list.Add(i + 1);
                Console.WriteLine(list[i]);
            }

            RemoveEachSecondItem(list);
        }

        static void RemoveEachSecondItem<T>(ICollection<T> collection)
        {
            int steps = 0;
            int count = 0;

            while (collection.Count > 1)
            {
                Console.WriteLine("Step {0}", steps + 1);

                foreach (T item in collection.ToList())
                {
                    count++;

                    // Если элемент на четной позиции, удалить его
                    // из коллекции
                    if (count % 2 == 0)
                    {
                        collection.Remove(item);
                        Console.WriteLine("Removed: {0}", item);
                    }
                }

                steps++;
            }

            foreach (T item in collection)
            {
                Console.WriteLine("Answer: {0}", item);
            }
        }
    }
}

// Output

//List
//1
//2
//3
//4
//5
//Step 1
//Removed: 2
//Removed: 4
//Step 2
//Removed: 1
//Removed: 5
//Answer: 3