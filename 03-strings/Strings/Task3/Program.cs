using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo en  = new CultureInfo("en");
            CultureInfo ru  = new CultureInfo("ru");
            CultureInfo inv = new CultureInfo("");

            ShowCultureDifferences(ref ru, ref en);
            ShowCultureDifferences(ref en, ref inv);
            ShowCultureDifferences(ref ru, ref inv);
        }

        public static void ShowCultureDifferences(ref CultureInfo ci1, ref CultureInfo ci2)
        {
            string infoRow = String.Format("{0,2} vs {1,2}: {2, 4} | {3, 4} | {4, 4} " +
                                           "| {5, 4} | {6, 20} | {7, 20} | {8, 10} | {9, 10}",
                ci1, 
                ci2,
                ci1.NumberFormat.NumberDecimalSeparator,
                ci2.NumberFormat.NumberDecimalSeparator,
                ci1.NumberFormat.NumberDecimalSeparator,
                ci2.NumberFormat.NumberDecimalSeparator,
                ci1.DateTimeFormat.LongDatePattern,
                ci2.DateTimeFormat.LongDatePattern,
                ci1.DateTimeFormat.LongTimePattern,
                ci2.DateTimeFormat.LongTimePattern);

            Console.WriteLine(infoRow);
        }
    }
}
