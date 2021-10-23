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

            this.radius = radius;

            this.x = x;
            this.y = y;
        }

        public int Radius
        {
            get { return radius; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public double Circumference
        {
            get 
            {
                circumference = 2 * Math.PI * radius;
                return circumference; 
            }
        }

        public double Area
        {
            get 
            {
                area = Math.PI * Math.Pow(radius, 2);
                return area; 
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Circle [rad: {0}, orgn: [{1}, {2}] ] [cf: {3}, area: {4}]", radius, x, y, circumference, area);
        }
    }
}
