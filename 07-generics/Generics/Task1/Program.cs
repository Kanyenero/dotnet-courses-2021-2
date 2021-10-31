using System;

namespace Task1
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
            Person Alex = new Person();
            Person Den = new Person();
            Person Nick = new Person();

            Person[] persons = { Alex, Den, Nick };

            DynamicArray<Person> arr1 = new DynamicArray<Person>(persons);
            Console.WriteLine(arr1.ToString());


            Console.WriteLine("Add");
            Person Matt = new Person();
            Person Lizzy = new Person();
            arr1.Add(Matt);
            arr1.Add(Lizzy);
            Console.WriteLine(arr1.ToString());


            Console.WriteLine("AddRange");
            Person Mary = new Person();
            Person Kyle = new Person();
            Person[] new_persons = { Mary, Kyle };
            arr1.AddRange(new_persons);
            Console.WriteLine(arr1.ToString());


            Console.WriteLine("Remove existing");
            if(arr1.Remove(Mary))
                Console.WriteLine(arr1.ToString());
            else
            {
                Console.WriteLine("No member {0} in {1}", nameof(Mary), nameof(persons));
                Console.WriteLine(arr1.ToString());
            }


            Console.WriteLine("Remove not existing");
            Person Jack = new Person();
            if (arr1.Remove(Jack))
                Console.WriteLine(arr1.ToString());
            else
                Console.WriteLine("No member {0} in {1}", nameof(Jack), nameof(persons));


            Console.WriteLine("\nInsert");
            Person Timmy = new Person();
            arr1.Insert(Timmy, 0);
            Console.WriteLine(arr1.ToString());

            Console.WriteLine("\nInsert Error");
            Person Megan = new Person();
            arr1.Insert(Megan, 29);
            Console.WriteLine(arr1.ToString());
        }
    }
}

// Output

//Array[length: 3][capacity: 3]
//Array[idx: 0][val: Task1.Person]
//Array[idx: 1][val: Task1.Person]
//Array[idx: 2][val: Task1.Person]

//Add
//Array[length: 5] [capacity: 8]
//Array[idx: 0][val: Task1.Person]
//Array[idx: 1][val: Task1.Person]
//Array[idx: 2][val: Task1.Person]
//Array[idx: 3][val: Task1.Person]
//Array[idx: 4][val: Task1.Person]
//Array[idx: 5][val: ]
//Array[idx: 6][val: ]
//Array[idx: 7][val: ]

//AddRange
//Array[length: 7] [capacity: 8]
//Array[idx: 0][val: Task1.Person]
//Array[idx: 1][val: Task1.Person]
//Array[idx: 2][val: Task1.Person]
//Array[idx: 3][val: Task1.Person]
//Array[idx: 4][val: Task1.Person]
//Array[idx: 5][val: Task1.Person]
//Array[idx: 6][val: Task1.Person]
//Array[idx: 7][val: ]

//Remove existing
//Array [length: 6] [capacity: 8]
//Array[idx: 0][val: Task1.Person]
//Array[idx: 1][val: Task1.Person]
//Array[idx: 2][val: Task1.Person]
//Array[idx: 3][val: Task1.Person]
//Array[idx: 4][val: Task1.Person]
//Array[idx: 5][val: Task1.Person]
//Array[idx: 6][val: ]
//Array[idx: 7][val: ]

//Remove not existing
//No member Jack in persons

//Insert
//Array [length: 7] [capacity: 8]
//Array[idx: 0][val: Task1.Person]
//Array[idx: 1][val: Task1.Person]
//Array[idx: 2][val: Task1.Person]
//Array[idx: 3][val: Task1.Person]
//Array[idx: 4][val: Task1.Person]
//Array[idx: 5][val: Task1.Person]
//Array[idx: 6][val: Task1.Person]
//Array[idx: 7][val: ]


//Insert Error
//Unhandled exception. System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values. (Parameter 'Array out of bounds')
//   at Task1.DynamicArray`1.Insert(TCollectionElement element, Int32 idx) in D:\EPAM\EPAM\GitHub\dotnet-courses-2021-2\07-generics\Generics\Task1\DynamicArray.cs:line 118
//   at Task1.Program.Main(String[] args) in D:\EPAM\EPAM\GitHub\dotnet-courses-2021-2\07-generics\Generics\Task1\Program.cs:line 72