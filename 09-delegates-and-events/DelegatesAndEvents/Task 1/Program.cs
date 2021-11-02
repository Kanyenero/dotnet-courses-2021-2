using System;
using System.Globalization;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[10];

            strs[0] = "Grammar";
            strs[1] = "Police";
            strs[2] = "Shaft";
            strs[3] = "Sheet";
            strs[4] = "Temporary";
            strs[5] = "Cat";
            strs[6] = "Cab";
            strs[7] = "Cabine";
            strs[8] = "Array";
            strs[9] = "900";

            Function fnc = new Function(CompareStrings);
            Sort(strs, fnc);

            string s = strs[0];
        }

        // Наш делегат
        public delegate int Function(string s1, string s2);

        // Метод сравнения строк
        public static int CompareStrings(string s1, string s2)
        {
            if (s1.Equals(null) || s2.Equals(null)) throw new ArgumentNullException();

            if (s1.Length < s2.Length) return -1;
            if (s1.Length > s2.Length) return  1;
            if (s1.Length == s2.Length)
                return string.Compare(s1, 0, s2, 0, s1.Length, new CultureInfo("en-US"), CompareOptions.IgnoreCase);

            return -1;
        }

        // Метод сортировки строк
        public static void Sort(string[] strings, Function cmpr)
        {
            string temp;

            for (int i = 0; i < strings.Length - 1; i++)
                for(int j = 0; j < strings.Length - i - 1; j++)
                    if(cmpr(strings[j], strings[j + 1]) > 0)
                    {
                        temp = strings[j];
                        strings[j] = strings[j + 1];
                        strings[j + 1] = temp;
                    }
        }
    }
}
