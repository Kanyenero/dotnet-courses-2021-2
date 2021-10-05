using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates rectangle square");
            Console.WriteLine("=================");

            int side1 = CheckConsoleInput();
            int side2 = CheckConsoleInput(); 

            int square = side1 * side2;
            Console.WriteLine("=================");
            Console.WriteLine(square);
        }

        static int CheckConsoleInput()
        {
            bool correctInput = false;
            int sideSize = 0;

            while (!correctInput)
            {
                Console.Write("Input rectangle side size: ");
                string userInput = Console.ReadLine();

                try
                {
                    sideSize = int.Parse(userInput);

                    if (sideSize == 0)
                    {
                        Console.WriteLine($"Zero is not allowed");
                        continue;
                    }

                    if (sideSize < 0)
                    {
                        Console.WriteLine($"Input number must be greater than zero");
                        continue;
                    }

                    correctInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception. Use only integer numbers!");
                    correctInput = false;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    correctInput = false;
                }
            }

            return sideSize;
        }
    }
}
