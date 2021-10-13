using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();

            figures.Add(new Line(5, 6));
            figures.Add(new Circle(-3, 1));
            figures.Add(new Rectangle(0, 16));
            figures.Add(new Round(5, 8));
            figures.Add(new Ring(-7, -10));

            foreach (Figure figure in figures)
            {
                figure.Draw();
            }
        }
    }


    public abstract class Figure
    {
        public abstract int X { get; set; }
        public abstract int Y { get; set; }

        public abstract void Draw();
    }


    public class Line : Figure
    {
        int _x;
        int _y;

        public Line(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override void Draw()
        {
            Console.WriteLine("Here's the {0} drawing [pos: {1}, {2}]", nameof(Line), X, Y);
            Console.WriteLine();
            Console.WriteLine("\t...");
        }
    }

    public class Circle : Figure
    {
        int _x;
        int _y;

        public Circle(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override void Draw()
        {
            Console.WriteLine("Here's the {0} drawing [pos: {1}, {2}]", nameof(Circle), X, Y);
            Console.WriteLine();
            Console.WriteLine("\t...");
        }
    }

    public class Rectangle : Figure
    {
        int _x;
        int _y;

        public Rectangle(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override void Draw()
        {
            Console.WriteLine("Here's the {0} drawing [pos: {1}, {2}]", nameof(Rectangle), X, Y);
            Console.WriteLine();
            Console.WriteLine("\t...");
        }
    }

    public class Round : Figure
    {
        int _x;
        int _y;

        public Round(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override void Draw()
        {
            Console.WriteLine("Here's the {0} drawing [pos: {1}, {2}]", nameof(Round), X, Y);
            Console.WriteLine();
            Console.WriteLine("\t...");
        }
    }

    public class Ring : Round
    {
        int _x;
        int _y;

        public Ring(int x, int y) : base(x, y)
        {
            _x = x;
            _y = y;
        }

        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override void Draw()
        {
            Console.WriteLine("Here's the {0} drawing [pos: {1}, {2}]", nameof(Ring), X, Y);
            Console.WriteLine();
            Console.WriteLine("\t...");
        }
    }
}

