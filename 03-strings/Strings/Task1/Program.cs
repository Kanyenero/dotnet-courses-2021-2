using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            userInput = userInput.Trim(new char[] {' ', ',', '.'});

            Console.WriteLine($"Your input: {userInput}");

            string[] spltUserInput = userInput.Split
                (
                    new char[] {' ', ',', '.', '!', '?', 
                                ':', ';', '(', ')', '[', 
                                ']', '{', '}', '\\', '/'}, 
                    StringSplitOptions.RemoveEmptyEntries
                );

            int sumWordLengths = 0;

            foreach (string word in spltUserInput)
            {
                Console.WriteLine(word + "\t\t:\t " + word.Length);

                sumWordLengths += word.Length;
            }

            double avgWordLength = (double)sumWordLengths / (double)spltUserInput.Length;
            Console.WriteLine(avgWordLength);
        }
    }
}
