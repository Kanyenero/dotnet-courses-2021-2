using System;

namespace NetBasicsDemo
{
	public class ComparisonDemo
	{
		public static void Demo(string[] args)
		{
			TwoDPoint point1 = new TwoDPoint(1,10);
			TwoDPoint point2 = new TwoDPoint(1,10);

			object object1 = (object)point1;
			object object2 = (object)point2;

			Console.WriteLine(point1.Equals(point2));
			Console.WriteLine(point1 == point2);

			Console.WriteLine(object1.Equals(object2));
			Console.WriteLine(object1 == object2); // false !!!! почему?

			// в чем разница определений методов Equals и == ?
		}
	}

	class TwoDPoint : Object
	{
		public readonly int x, y;

		public TwoDPoint(int x, int y)  //constructor
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Point return false.
			TwoDPoint p = obj as TwoDPoint;
			if ((Object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public bool Equals(TwoDPoint p)
		{
			// If parameter is null return false:
			if ((object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public static bool operator ==(TwoDPoint a, TwoDPoint b)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(TwoDPoint a, TwoDPoint b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return string.Format("x:{0} y:{1}", x, y);
		}
	}
}
