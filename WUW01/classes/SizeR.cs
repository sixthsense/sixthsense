using System;
using System.Drawing;

namespace WUW01
{
	public struct SizeR
	{
		public static readonly SizeR Empty;
        	private double _cx;
		private double _cy;

		public SizeR(double cx, double cy)
		{
			_cx = cx;
			_cy = cy;
		}

		// copy constructor
		public SizeR(SizeR sz)
		{
			_cx = sz.Width;
			_cy = sz.Height;
		}

		public double Width
		{
			get
			{
                		return _cx;
			}
			set
			{
				_cx = value;
			}
		}

		public double Height
		{
			get
			{
                		return _cy;
			}
			set
			{
				_cy = value;
			}
		}

		public static explicit operator SizeF(SizeR sz)
		{
			return new SizeF((float) sz.Width, (float) sz.Height);
		}

		public static bool operator==(SizeR sz1, SizeR sz2)
		{
			return (sz1.Width == sz2.Width && sz1.Height == sz2.Height);
		}

		public static bool operator!=(SizeR sz1, SizeR sz2)
		{
			return (sz1.Width != sz2.Width || sz1.Height != sz2.Height);
		}

		public override bool Equals(object obj)
		{
			if (obj is SizeR)
			{
				SizeR sz = (SizeR) obj;
				return (Width == sz.Width && Height == sz.Height);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((SizeR) this).GetHashCode();
		}
	}
}
