using System;
using System.Drawing;

namespace WUW01
{
	public struct RectangleR
	{
		private const int Digits = 4;
		private double _x;
		private double _y;
		private double _width;
		private double _height;
		public static readonly RectangleR Empty = new RectangleR();

		public RectangleR(double x, double y, double width, double height)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
		}

		// copy constructor
		public RectangleR(RectangleR r)
		{
			_x = r.X;
			_y = r.Y;
			_width = r.Width;
			_height = r.Height;
		}

		public double X
		{
			get
			{
				return Math.Round(_x, Digits);
			}
			set
			{
				_x = value;
			}
		}

		public double Y
		{
			get
			{
				return Math.Round(_y, Digits);
			}
			set
			{
				_y = value;
			}
		}

		public double Width
		{
			get
			{
				return Math.Round(_width, Digits);
			}
			set
			{
				_width = value;
			}
		}

		public double Height
		{
			get
			{
				return Math.Round(_height, Digits);
			}
			set
			{
				_height = value;
			}
		}

		public PointR TopLeft
		{
			get
			{
				return new PointR(X, Y);
			}
		}

		public PointR BottomRight
		{
			get
			{
				return new PointR(X + Width, Y + Height);
			}
		}

		public PointR Center
		{
			get
			{
				return new PointR(X + Width / 2d, Y + Height / 2d);
			}
		}

		public double MaxSide
		{
			get
			{
				return Math.Max(_width, _height);
			}
		}

		public double MinSide
		{
			get
			{
				return Math.Min(_width, _height);
			}
		}

		public double Diagonal
		{
			get
			{
				return Utils.Distance(TopLeft, BottomRight);
			}
		}

		public static explicit operator RectangleF(RectangleR r)
		{
			return new RectangleF((float) r.X, (float) r.Y, (float) r.Width, (float) r.Height);
		}

		public override bool Equals(object obj)
		{
			if (obj is RectangleR)
			{
				RectangleR r = (RectangleR) obj;
				return (X == r.X && Y == r.Y && Width == r.Width && Height == r.Height);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((RectangleF) this).GetHashCode();
		}


	}
}
