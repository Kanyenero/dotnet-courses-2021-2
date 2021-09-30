using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string userInput = Console.ReadLine();

            string basicNumPattern = @"^\-?\d*\.?\d*$";
            string scienNumPattern = @"^-?[\d.]+(?:e-?\d+)$";
            Regex rgxBasicNum = new Regex(basicNumPattern);
            Regex rgxScienNum = new Regex(scienNumPattern);

            if (rgxBasicNum.IsMatch(userInput))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else if (rgxScienNum.IsMatch(userInput))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
            }
        }
    }
}
