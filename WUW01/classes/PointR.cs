using System;
using System.Drawing;

namespace WUW01
{
	public struct PointR
	{
        public static readonly PointR Empty;
        //private double _x;
        //private double _y;
        //private int _t;


        public double X, Y;
        public int T;

		public PointR(double x, double y) : this(x, y, 0)
		{
		}

        public PointR(double x, double y, int t)
        {
            //_x = x;
            //_y = y;
            //_t = t;
            X = x;
            Y = y;
            T = t;
        }

		// copy constructor
		public PointR(PointR p)
		{
            //_x = p.X;
            //_y = p.Y;
            //_t = p.T;
            X = p.X;
            Y = p.Y;
            T = p.T;
        }

        //public double X
        //{
        //    get
        //    {
        //        return _x;
        //    }
        //    set
        //    {
        //        _x = value;
        //    }
        //}

        //public double Y
        //{
        //    get
        //    {
        //        return _y;
        //    }
        //    set
        //    {
        //        _y = value;
        //    }
        //}

        //public int T
        //{
        //    get
        //    {
        //        return _t;
        //    }
        //    set
        //    {
        //        _t = value;
        //    }
        //}

		public static explicit operator PointF(PointR p)
		{
			return new PointF((float) p.X, (float) p.Y);
		}

		public static bool operator==(PointR p1, PointR p2)
		{
			return (p1.X == p2.X && p1.Y == p2.Y);
		}

		public static bool operator!=(PointR p1, PointR p2)
		{
			return (p1.X != p2.X || p1.Y != p2.Y);
		}

		public override bool Equals(object obj)
		{
			if (obj is PointR)
			{
				PointR p = (PointR) obj;
				return (X == p.X && Y == p.Y);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((PointF) this).GetHashCode();
		}
	}
}
