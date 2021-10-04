using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle trngl = new Triangle(2,3,4);
                trngl.ShowInfo();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
        }
    }

    public class Triangle
    {
        private int a, b, c;

        public Triangle(int a, int b, int c)
        {
            // feasibility conditions
            if(a > b + c || b > a + c || c > a + b)
            {
                throw new ArgumentOutOfRangeException("Triangle with sides like that can not really exist");
            }

            if(a == 0 || b == 0 || c == 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides can not equals zero");
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int A
        {
            get { return a; }
        }

        public int B
        {
            get { return b; }
        }

        public int C
        {
            get { return c; }
        }

        public int GetPerimeter()
        {
            return a + b + c;
        }

        public double GetArea()
        {
            double halfPrmt = (a + b + c) / 2.0;
            return Math.Sqrt(halfPrmt * (halfPrmt - a) * (halfPrmt - b) * (halfPrmt - c));
        }


        public void ShowInfo()
        {
            Console.WriteLine("Triangle [ [sides: {0}, {1}, {2}] [prmt: {3}, sqr: {4}] ]", a, b, c, GetPerimeter(), GetArea());
        }
    }
}
