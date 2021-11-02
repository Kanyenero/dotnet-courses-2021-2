using System;
using System.Globalization;
using System.Threading;

namespace Task_3
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
            strs[9] = "Me";

            Function fnc = new Function(CompareStrings);
            Thread new_thrd = SortAsync(strs, fnc);

            // Заморозить главный поток, пока
            // побочный поток не завершится
            while (new_thrd.IsAlive) { Thread.Sleep(1); }

            foreach (string str in strs)
                Console.WriteLine(str);
        }

        // Наш делегат
        public delegate int Function(string s1, string s2);

        // Метод сравнения строк
        public static int CompareStrings(string s1, string s2)
        {
            if (s1.Equals(null) || s2.Equals(null)) throw new ArgumentNullException();

            if (s1.Length < s2.Length) return -1;
            if (s1.Length > s2.Length) return 1;
            if (s1.Length == s2.Length)
                return string.Compare(s1, 0, s2, 0, s1.Length, new CultureInfo("en-US"), CompareOptions.IgnoreCase);

            return -1;
        }

        // Метод сортировки строк
        public static void Sort(string[] strings, Function cmpr)
        {
            string temp;

            for (int i = 0; i < strings.Length - 1; i++)
                for (int j = 0; j < strings.Length - i - 1; j++)
                    if (cmpr(strings[j], strings[j + 1]) > 0)
                    {
                        temp = strings[j];
                        strings[j] = strings[j + 1];
                        strings[j + 1] = temp;
                    }
        }

        public static Thread SortAsync(string[] strings, Function cmpr)
        {
            Thread thrd = new Thread(() => Sort(strings, cmpr));
            thrd.Start();

            return thrd;
        }

    }
}

// Output

//Me
//Cab
//Cat
//Array
//Shaft
//Sheet
//Cabine
//Police
//Grammar
//Temporary
