using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input positive integer non-zero number and see what you got :)");

            int n = CheckConsoleInput();
            BuildFigure(n);
        }

        static void BuildFigure(int levels)
        {
            for (int i = 1; i <= levels; i++)
            {
                string side = new String('*', i);
                Console.WriteLine(side);
            }
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
                        Console.WriteLine("Zero is not allowed");
                        continue;
                    }

                    if (sideSize < 0)
                    {
                        Console.WriteLine("Input number must be greater than zero");
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
