using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string userInput = Console.ReadLine();

            string timePattern = @"([0-1][0-9]|2[0-3]):[0-5][0-9]";
            Regex rgxTime = new Regex(timePattern);

            MatchCollection matches = rgxTime.Matches(userInput);
            Console.WriteLine($"Время в тексте присутствует {matches.Count} раз.");
        }
    }
}
