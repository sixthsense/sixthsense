using System;
using System.Collections;
using System.Diagnostics;

namespace WUW01
{
	public class Utils
    {
        #region Constants

        private static readonly Random _rand = new Random();

        #endregion

        #region Lengths and Rects

        public static RectangleR FindBox(ArrayList points)
		{
			double minX = double.MaxValue;
			double maxX = double.MinValue;
			double minY = double.MaxValue;
			double maxY = double.MinValue;
		
			foreach (PointR p in points)
			{
				if (p.X < minX)
					minX = p.X;
				if (p.X > maxX)
					maxX = p.X;
			
				if (p.Y < minY)
					minY = p.Y;
				if (p.Y > maxY)
					maxY = p.Y;
			}
		
			return new RectangleR(minX, minY, maxX - minX, maxY - minY);
		}

		public static double Distance(PointR p1, PointR p2)
		{
			double dx = p2.X - p1.X;
			double dy = p2.Y - p1.Y;
			return Math.Sqrt(dx * dx + dy * dy);
        }

        // compute the centroid of the points given
        public static PointR Centroid(ArrayList points)
        {
            double xsum = 0.0;
            double ysum = 0.0;

            foreach (PointR p in points)
            {
                xsum += p.X;
                ysum += p.Y;
            }
            return new PointR(xsum / points.Count, ysum / points.Count);
        }

        public static double PathLength(ArrayList points)
        {
            double length = 0;
            for (int i = 1; i < points.Count; i++)
            {
                length += Distance((PointR) points[i - 1], (PointR) points[i]);
            }
            return length;
        }

        #endregion

        #region Angles and Rotations

        // determines the angle, in degrees, between two points. the angle is defined 
        // by the circle centered on the start point with a radius to the end point, 
        // where 0 degrees is straight right from start (+x-axis) and 90 degrees is
        // straight down (+y-axis).
        public static double AngleInDegrees(PointR start, PointR end, bool positiveOnly)
        {
            double radians = AngleInRadians(start, end, positiveOnly);
            return Rad2Deg(radians);
        }

        // determines the angle, in radians, between two points. the angle is defined 
        // by the circle centered on the start point with a radius to the end point, 
        // where 0 radians is straight right from start (+x-axis) and PI/2 radians is
        // straight down (+y-axis).
		public static double AngleInRadians(PointR start, PointR end, bool positiveOnly)
		{
            double radians = 0.0;
            if (start.X != end.X)
            {
                radians = Math.Atan2(end.Y - start.Y, end.X - start.X);
            }
            else // pure vertical movement
            {
                if (end.Y < start.Y)
                    radians = -Math.PI / 2.0; // -90 degrees is straight up
                else if (end.Y > start.Y)
                    radians = Math.PI / 2.0; // 90 degrees is straight down
            }
            if (positiveOnly && radians < 0.0)
            {
                radians += Math.PI * 2.0;
            }
            return radians;
		}

        public static double Rad2Deg(double rad)
		{
			return (rad * 180d / Math.PI);
		}

		public static double Deg2Rad(double deg)
		{
			return (deg * Math.PI / 180d);
        }

        // rotate the points by the given degrees about their centroid
        public static ArrayList RotateByDegrees(ArrayList points, double degrees)
        {
            double radians = Deg2Rad(degrees);
            return RotateByRadians(points, radians);
        }

        // rotate the points by the given radians about their centroid
        public static ArrayList RotateByRadians(ArrayList points, double radians)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            PointR c = Centroid(points);

            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);

            double cx = c.X;
            double cy = c.Y;

            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];

                double dx = p.X - cx;
                double dy = p.Y - cy;

                PointR q = PointR.Empty;
                q.X = dx * cos - dy * sin + cx;
                q.Y = dx * sin + dy * cos + cy;
                
                newPoints.Add(q);
            }
            return newPoints;
        }

        // Rotate a point 'p' around a point 'c' by the given radians.
        // Rotation (around the origin) amounts to a 2x2 matrix of the form:
        //
        //		[ cos A		-sin A	] [ p.x ]
        //		[ sin A		cos A	] [ p.y ]
        //
        // Note that the C# Math coordinate system has +x-axis stright right and
        // +y-axis straight down. Rotation is clockwise such that from +x-axis to
        // +y-axis is +90 degrees, from +x-axis to -x-axis is +180 degrees, and 
        // from +x-axis to -y-axis is -90 degrees.
        public static PointR RotatePoint(PointR p, PointR c, double radians)
        {
            PointR q = PointR.Empty;
            q.X = (p.X - c.X) * Math.Cos(radians) - (p.Y - c.Y) * Math.Sin(radians) + c.X;
            q.Y = (p.X - c.X) * Math.Sin(radians) + (p.Y - c.Y) * Math.Cos(radians) + c.Y;
            return q;
        }

        #endregion

        #region Translations

        // translates the points so that the upper-left corner of their bounding box lies at 'toPt'
        public static ArrayList TranslateBBoxTo(ArrayList points, PointR toPt)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            RectangleR r = Utils.FindBox(points);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                p.X += (toPt.X - r.X);
                p.Y += (toPt.Y - r.Y);
                newPoints.Add(p);
            }
            return newPoints;
        }

        // translates the points so that their centroid lies at 'toPt'
        public static ArrayList TranslateCentroidTo(ArrayList points, PointR toPt)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            PointR centroid = Centroid(points);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                p.X += (toPt.X - centroid.X);
                p.Y += (toPt.Y - centroid.Y);
                newPoints.Add(p);
            }
            return newPoints;
        }

        // translates the points by the given delta amounts
        public static ArrayList TranslateBy(ArrayList points, SizeR sz)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                p.X += sz.Width;
                p.Y += sz.Height;
                newPoints.Add(p);
            }
            return newPoints;
        }

        #endregion

        #region Scaling

        // scales the points so that they form the size given. does not restore the 
        // origin of the box.
        public static ArrayList ScaleTo(ArrayList points, SizeR sz)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            RectangleR r = FindBox(points);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                if (r.Width != 0d)
                    p.X *= (sz.Width / r.Width);
                if (r.Height != 0d)
                    p.Y *= (sz.Height / r.Height);
                newPoints.Add(p);
            }
            return newPoints;
        }

        // scales by the percentages contained in the 'sz' parameter. values of 1.0 would result in the
        // identity scale (that is, no change).
        public static ArrayList ScaleBy(ArrayList points, SizeR sz)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            RectangleR r = FindBox(points);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                p.X *= sz.Width;
                p.Y *= sz.Height;
                newPoints.Add(p);
            }
            return newPoints;
        }

        // scales the points so that the length of their longer side
        // matches the length of the longer side of the given box.
        // thus, both dimensions are warped proportionally, rather than
        // independently, like in the function ScaleTo.
        public static ArrayList ScaleToMax(ArrayList points, RectangleR box)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            RectangleR r = FindBox(points);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                p.X *= (box.MaxSide / r.MaxSide);
                p.Y *= (box.MaxSide / r.MaxSide);
                newPoints.Add(p);
            }
            return newPoints;
        }

        // scales the points so that the length of their shorter side
        // matches the length of the shorter side of the given box.
        // thus, both dimensions are warped proportionally, rather than
        // independently, like in the function ScaleTo.
        public static ArrayList ScaleToMin(ArrayList points, RectangleR box)
        {
            ArrayList newPoints = new ArrayList(points.Count);
            RectangleR r = FindBox(points);
            for (int i = 0; i < points.Count; i++)
            {
                PointR p = (PointR) points[i];
                p.X *= (box.MinSide / r.MinSide);
                p.Y *= (box.MinSide / r.MinSide);
                newPoints.Add(p);
            }
            return newPoints;
        }

        #endregion

        #region Path Sampling and Distance

        public static ArrayList Resample(ArrayList points, int n)
        {
            double I = PathLength(points) / (n - 1); // interval length
            double D = 0.0;
            ArrayList srcPts = new ArrayList(points);
            ArrayList dstPts = new ArrayList(n);
            dstPts.Add(srcPts[0]);
            for (int i = 1; i < srcPts.Count; i++)
            {
                PointR pt1 = (PointR) srcPts[i - 1];
                PointR pt2 = (PointR) srcPts[i];

                double d = Distance(pt1, pt2);
                if ((D + d) >= I)
                {
                    double qx = pt1.X + ((I - D) / d) * (pt2.X - pt1.X);
                    double qy = pt1.Y + ((I - D) / d) * (pt2.Y - pt1.Y);
                    PointR q = new PointR(qx, qy);
                    dstPts.Add(q); // append new point 'q'
                    srcPts.Insert(i, q); // insert 'q' at position i in points s.t. 'q' will be the next i
                    D = 0.0;
                }
                else
                {
                    D += d;
                }
            }
            // somtimes we fall a rounding-error short of adding the last point, so add it if so
            if (dstPts.Count == n - 1)
            {
                dstPts.Add(srcPts[srcPts.Count - 1]);
            }

            return dstPts;
        }

        // computes the 'distance' between two point paths by summing their corresponding point distances.
        // assumes that each path has been resampled to the same number of points at the same distance apart.
        public static double PathDistance(ArrayList path1, ArrayList path2)
        {            
            double distance = 0;
            for (int i = 0; i < path1.Count; i++)
            {
                distance += Distance((PointR) path1[i], (PointR) path2[i]);
            }
            return distance / path1.Count;
        }

        #endregion

        #region Random Numbers

        /// <summary>
        /// Gets a random number between low and high, inclusive.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int Random(int low, int high)
        {
            return _rand.Next(low, high + 1);
        }

        /// <summary>
        /// Gets multiple random numbers between low and high, inclusive. The
        /// numbers are guaranteed to be distinct.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[] Random(int low, int high, int num)
        {
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = _rand.Next(low, high + 1);
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        i--; // redo i
                        break;
                    }
                }
            }
            return array;
        }

        #endregion
    }
}
