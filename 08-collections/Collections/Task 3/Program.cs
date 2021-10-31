using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "After after school, Kamal took the girls to the old house. " +
                "It was very old and very dirty too. There was rubbish everywhere. " +
                "The windows were broken and the walls were damp. It was scary. " +
                "Amy didn’t like it. There were paintings of zombies and skeletons on the walls. " +
                "“We’re going to take photos for the school art competition,” said Kamal. " +
                "Amy didn’t like it but she didn’t say anything. “Where’s Grant?” asked Tara. " +
                "“Er, he’s buying more paint.” Kamal looked away quickly. " +
                "Tara thought he looked suspicious. “It’s getting dark, can we go now?” said Amy. " +
                "She didn’t like zombies.";

            Dictionary<string, int> dictionary = CountWords(text);

            Console.WriteLine("Here is some text in English:\n");
            Console.WriteLine(text);
            Console.WriteLine();

            Console.WriteLine("Here is a result dictionary:\n");

            foreach (KeyValuePair<string, int> kvp in dictionary)
                Console.WriteLine("[word]\t {0}\t [key]\t {1}", kvp.Value, kvp.Key);
        }

        static Dictionary<string, int> CountWords(string str)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Regex rgx = new Regex(@"\b\w+\b");

            MatchCollection matches = rgx.Matches(str);

            foreach (Match item in matches)
            {
                string word = item.ToString().ToLower();

                if (dict.ContainsKey(word))
                {
                    dict[word]++; // increment
                    continue;
                }

                dict.Add(word, 1);
            }

            return dict;
        }
    }
}


// Output

//Here is some text in English:

//After after school, Kamal took the girls to the old house.
//It was very old and very dirty too. There was rubbish everywhere.
//The windows were broken and the walls were damp. It was scary. Amy didn't like it.
//There were paintings of zombies and skeletons on the walls.
//"We're going to take photos for the school art competition," said Kamal.
//Amy didn't like it but she didn't say anything. "Where's Grant?" asked Tara.
//"Er, he's buying more paint." Kamal looked away quickly. Tara thought he looked suspicious.
//"It's getting dark, can we go now?" said Amy.
//She didn't like zombies.

//Here is a result dictionary:

//[word]   2[key]   after
//[word]   2[key]   school
//[word]   3[key]   kamal
//[word]   1[key]   took
//[word]   6[key]   the
//[word]   1[key]   girls
//[word]   2[key]   to
//[word]   2[key]   old
//[word]   1[key]   house
//[word]   5[key]   it
//[word]   3[key]   was
//[word]   2[key]   very
//[word]   3[key]   and
//[word]   1[key]   dirty
//[word]   1[key]   too
//[word]   2[key]   there
//[word]   1[key]   rubbish
//[word]   1[key]   everywhere
//[word]   1[key]   windows
//[word]   3[key]   were
//[word]   1[key]   broken
//[word]   2[key]   walls
//[word]   1[key]   damp
//[word]   1[key]   scary
//[word]   3[key]   amy
//[word]   4[key]   didn
//[word]   4[key]   t
//[word]   3[key]   like
//[word]   1[key]   paintings
//[word]   1[key]   of
//[word]   2[key]   zombies
//[word]   1[key]   skeletons
//[word]   1[key]   on
//[word]   2[key]   we
//[word]   1[key]   re
//[word]   1[key]   going
//[word]   1[key]   take
//[word]   1[key]   photos
//[word]   1[key]   for
//[word]   1[key]   art
//[word]   1[key]   competition
//[word]   2[key]   said
//[word]   1[key]   but
//[word]   2[key]   she
//[word]   1[key]   say
//[word]   1[key]   anything
//[word]   1[key]   where
//[word]   3[key]   s
//[word]   1[key]   grant
//[word]   1[key]   asked
//[word]   2[key]   tara
//[word]   1[key]   er
//[word]   2[key]   he
//[word]   1[key]   buying
//[word]   1[key]   more
//[word]   1[key]   paint
//[word]   2[key]   looked
//[word]   1[key]   away
//[word]   1[key]   quickly
//[word]   1[key]   thought
//[word]   1[key]   suspicious
//[word]   1[key]   getting
//[word]   1[key]   dark
//[word]   1[key]   can
//[word]   1[key]   go
//[word]   1[key]   now