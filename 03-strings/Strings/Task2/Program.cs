using System;
using System.Text;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input 1'st string: ");
            string userInput1 = Console.ReadLine();

            Console.Write("Input 2'nd string: ");
            string userInput2 = Console.ReadLine();

            string targets = RemoveDuplicates(userInput2);

            var sb = new StringBuilder(userInput1);

            foreach (char c in targets)
            {
                if (userInput1.Contains(c))
                {
                    sb.Replace(c.ToString(), $"{c}{c}");
                }
            }

            string finalStr = sb.ToString();
            Console.WriteLine(finalStr);
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}
