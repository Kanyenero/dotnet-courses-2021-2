using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input positive integer non-zero number and see what you got :)");

            int num = CheckConsoleInput();
            BuildFigure(num);
        }

        static void BuildFigure(int figNum)
        {
            for(int i = 1; i <= figNum; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    string side = new String('*', j);
                    Console.WriteLine(side.PadLeft(figNum-1) + "*" + side);
                }
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

            return num;
        }
    }
}
