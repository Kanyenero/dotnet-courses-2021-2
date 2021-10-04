using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Round circle = new Round(10, -7, 4);
                circle.ShowInfo();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
        }
    }

    public class Round
    {
        private int radius, x, y;
        private double circumference, area;

        public Round(int radius, int x, int y)
        {
            if(radius < 0)
            {
                throw new ArgumentOutOfRangeException("Radius can not be less than zero", nameof(radius));
            }
            else
            {
                this.radius = radius;
                this.circumference = 2 * Math.PI * this.radius;
                this.area = 2 * Math.PI * Math.Pow(this.radius, 2);
            }

            this.x = x;
            this.y = y;
        }

        public int Radius
        {
            get { return this.radius; }
        }

        public int X
        {
            get { return this.x; }
        }

        public int Y
        {
            get { return this.y; }
        }

        public double Circumference
        {
            get { return this.circumference; }
        }

        public double Area
        {
            get { return this.area; }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Circle [rad: {0}, orgn: [{1}, {2}] ] [cf: {3}, area: {4}]", radius, x, y, circumference, area);
        }
    }
}
