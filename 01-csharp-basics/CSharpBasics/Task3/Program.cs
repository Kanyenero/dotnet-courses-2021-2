using System;

namespace Task3
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
            for (int i = 0; i < levels; i++)
            {
                string side = new string('*', i);
                Console.WriteLine(side.PadLeft(levels - 1) + "*" + side);
            }
        }

        static int CheckConsoleInput()
        {
            bool correctInput = false;
            int num = 0;

            while (!correctInput)
            {
                Console.Write("Your input: ");
                string userInput = Console.ReadLine();

                try
                {
                    num = int.Parse(userInput);

                    if (num == 0)
                    {
                        Console.WriteLine($"Zero ...");
                        continue;
                    }

                    if (num < 0)
                    {
                        Console.WriteLine($"less zero ...");
                        continue;
                    }

                    correctInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception: Use only integer numbers!");
                    correctInput = false;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    correctInput = false;
                }
            }

            Console.WriteLine("Number accepted!");

            return num;
        }
    }
}

