using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput1 = "\0";
            string userInput2 = "\0";
            int side1 = 0; 
            int side2 = 0;
            int square = 0;

            Console.WriteLine("This program calculates rectangle square");
            Console.WriteLine("=================");

            side1 = CheckConsoleInput(ref userInput1);
            side2 = CheckConsoleInput(ref userInput2); 

            square = side1 * side2;
            Console.WriteLine("=================");
            Console.WriteLine(square);
        }

        static int CheckConsoleInput(ref string input)
        {
            bool state = false;
            int sideSize = 0;

            while (state == false)
            {
                Console.Write("Input rectangle side size: ");
                string userInput1 = Console.ReadLine();

                try
                {
                    sideSize = int.Parse(userInput1);

                    if (sideSize == 0)
                    {
                        throw new ZeroException("Rectangle side size 0 isn't allowed!");
                    }

                    if(sideSize < 0)
                    {
                        throw new ArgumentOutOfRangeException("Negative rectangle side size isn't allowed!");
                    }

                    state = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception. Use only integer numbers!");
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
                    Console.WriteLine("Number accepted!");
                    break;
                }
            }

            return sideSize;
        }
    }

    class ZeroException : Exception  // My exception type
    {
        public ZeroException(string msg) : base (msg) { }
    }
}
