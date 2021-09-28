using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "\0";
            int N;

            Console.WriteLine("Input positive integer non-zero number and see what you got :)");

            N = CheckConsoleInput(ref userInput);
            BuildFigure(N);
        }

        static void BuildFigure(int levels)
        {
            for (int i = 1; i <= levels; i++)
            {
                string side = new String('*', i);
                Console.WriteLine(side);
            }
        }

        static int CheckConsoleInput(ref string input)
        {
            bool state = false;
            int num = 0;

            while (state == false)
            {
                Console.Write("Your input: ");
                string userInput1 = Console.ReadLine();

                try
                {
                    num = int.Parse(userInput1);

                    if (num == 0)
                    {
                        throw new ZeroException("Zero isn't allowed!");
                    }

                    if (num < 0)
                    {
                        throw new ArgumentOutOfRangeException("Negative numbers isn't allowed!");
                    }

                    state = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception: Use only integer numbers!");
                    state = false;
                }
                catch (ZeroException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    state = false;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    state = false;
                }

                if (state == true)
                {
                    //Console.WriteLine("Number accepted!");
                    break;
                }
            }

            return num;
        }
    }

    class ZeroException : Exception  // My exception type
    {
        public ZeroException(string msg) : base(msg) { }
    }
}
