using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // test Round
            Round rnd = new Round(10, 1, 1);
            Console.WriteLine(rnd.ShowRoundInfo());

            Console.WriteLine();

            // test Ring
            Ring rng1 = new Ring(10, 5, 1, 1);
            Console.WriteLine(rng1.ShowRingInfo());

            Ring rng2 = new Ring(10, 20, 1, 1);
            Console.WriteLine(rng2.ShowRingInfo());
        }
    }


    public class Round
    {
        private int _centerX;
        private int _centerY;
        private int _radius;
        private double _circumference;
        private double _area;

        public Round(int radius, int centerX, int centerY)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius can not be less than or equal to zero", nameof(radius));
            }
            else
            {
                _radius = radius;
                _circumference = 2 * Math.PI * _radius;
                _area = Math.PI * Math.Pow(_radius, 2);
            }

            _centerX = centerX;
            _centerY = centerY;
        }

        public int Radius
        {
            get { return _radius; }
        }

        public int CenterX
        {
            get { return _centerX; }
        }

        public int CenterY
        {
            get { return _centerX; }
        }

        public double Circumference
        {
            get { return _circumference; }
        }

        public double Area
        {
            get { return _area; }
        }

        public string ShowRoundInfo()
        {
            return String.Format("Class [{0, 8}]: [rad: {1}, orgn: [{2}, {3}] ] [cf: {4:.###}, area: {5:.###}]", 
                nameof(Round), _radius, _centerX, _centerY, _circumference, _area);
        }
    }


    public class Ring : Round
    {
        private int _innerRadius;
        private double _circumference;
        private double _area;

        public Ring(int outterRadius, int innerRadius, int centerX, int centerY) 
            : base(outterRadius, centerX, centerY)
        {
            if(innerRadius > outterRadius || innerRadius <= 0)
            {
                throw new ArgumentOutOfRangeException("Inner round radius can not be greater than outter radius and less than or equal to zero", 
                    nameof(innerRadius));
            }

            _innerRadius = innerRadius;  
        }

        public double InnerRadius
        {
            get { return _innerRadius; }
        }

        public new double Circumference
        {
            get 
            {
                _circumference = 2 * Math.PI * (Radius + _innerRadius);
                return _circumference; 
            }
        }

        public new double Area
        {
            get 
            {
                _area = Math.PI * (Math.Pow(Radius, 2) - Math.Pow(_innerRadius, 2));
                return _area; 
            }
        }

        public string ShowRingInfo()
        {
            return String.Format("Class [{0, 8}]: [rad: [outter {1}, inner {2}], orgn: [{3}, {4}] ] [cf [outter + inner]: {5:.###}, area: {6:.###}]",
                nameof(Ring), Radius, InnerRadius, CenterX, CenterY, Circumference, Area);
        }
    }
}
