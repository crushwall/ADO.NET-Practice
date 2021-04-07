using System;

namespace SSU.ADONET.Ex1.Cube
{
    public class Cube
    {
        public double SideLength { get; }

        public Point[] Points { get; set; }

        public double Volume
        {
            get => SideLength * SideLength * SideLength;
        }

        public double Square
        {
            get => SideLength * SideLength;
        }

        public Cube()
        {
            Points = new Point[8];
        }

        public Cube(Point[] points)
        {
            Points = new Point[8];
            SideLength = points[0].Distance(points[1]);

            for (int i = 0; i < 8; i++)
            {
                Points[i] = points[i];
            }
        }

        public override string ToString()
        {
            string s = String.Empty;

            if (Points != null && Points.Length != 0)
            {
                foreach (Point p in Points)
                {
                    s += $"{p.X} {p.Y} {p.Z}{Environment.NewLine}";
                }
            }

            return s;
        }
    }
}
