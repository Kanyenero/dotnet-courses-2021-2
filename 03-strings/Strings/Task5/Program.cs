using System;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите HTML текст: ");
            string userInput = Console.ReadLine();

            string pattern = @"<.*?>";
            string replacement = "_";

            string result = Regex.Replace(userInput, pattern, replacement);

            Console.WriteLine($"Результат замены: {result}");
        }
    }
}
