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
            arr1.Print();


            Console.WriteLine("Add");
            Person Matt = new Person();
            Person Lizzy = new Person();
            arr1.Add(Matt);
            arr1.Add(Lizzy);
            arr1.Print();


            Console.WriteLine("AddRange");
            Person Mary = new Person();
            Person Kyle = new Person();
            Person[] new_persons = { Mary, Kyle };
            arr1.AddRange(new_persons);
            arr1.Print();


            Console.WriteLine("Remove existing");
            if(arr1.Remove(Mary))
                arr1.Print();
            else
            {
                Console.WriteLine("No member {0} in {1}", nameof(Mary), nameof(persons));
                arr1.Print();
            }


            Console.WriteLine("Remove not existing");
            Person Jack = new Person();
            if (arr1.Remove(Jack))
                arr1.Print();
            else
                Console.WriteLine("No member {0} in {1}", nameof(Jack), nameof(persons));


            Console.WriteLine("\nInsert");
            Person Timmy = new Person();
            arr1.Insert(Timmy, 0);
            arr1.Print();

            Console.WriteLine("\nInsert Error");
            Person Megan = new Person();
            arr1.Insert(Megan, 29);
            arr1.Print();
        }
    }
}
