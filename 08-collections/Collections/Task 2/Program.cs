using System;
using System.Collections.Generic;

namespace Task_2
{
    class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>(5);

            for (int i = 0; i < list.Capacity; i++)
                list.Add(new Person());

            DynamicArray<Person> arr = new DynamicArray<Person>(list);

            Console.WriteLine(arr.ToString());

            foreach (Person p in arr)
            {
                Console.WriteLine(p);
            }
        }
    }
}

// Output

//Array[length: 5][capacity: 8]
//Array[idx: 0][val: Task_2.Person]
//Array[idx: 1][val: Task_2.Person]
//Array[idx: 2][val: Task_2.Person]
//Array[idx: 3][val: Task_2.Person]
//Array[idx: 4][val: Task_2.Person]
//Array[idx: 5][val: ]
//Array[idx: 6][val: ]
//Array[idx: 7][val: ]

//Task_2.Person
//Task_2.Person
//Task_2.Person
//Task_2.Person
//Task_2.Person