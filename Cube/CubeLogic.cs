using System.Collections.Generic;
using CubeExceptions;

namespace Shapes
{
    public class CubeLogic
    {
        public void CreateCubeFromPoints(Point[] points)
        {
            Validate(points);

            Point[] cubePoints = new Point[8];

            if (points.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    cubePoints[i] = points[i];
                }

                cubePoints[4] = new Point(points[2].X, points[3].Y, points[1].Z);
                cubePoints[5] = new Point(points[1].X, points[3].Y, points[1].Z);
                cubePoints[6] = new Point(points[2].X, points[3].Y, points[2].Z);
                cubePoints[7] = new Point(points[3].X, points[0].Y, points[1].Z);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    cubePoints[i] = points[i];
                }
            }

            return new Cube(cubePoints);
        }

        public void CreateCubeFrompoints(Point p1, Point p2, Point p3, Point p4)
        {
            CreateCubeFromPoints(new Point[] { p1, p2, p3, p4 });
        }

        public void CreateCubeFrompoints(Point p1, Point p2, Point p3, Point p4, Point p5, Point p6, Point p7, Point p8)
        {
            CreateCubeFromPoints(new Point[] { p1, p2, p3, p4, p5, p6, p7, p8 });
        }

        public void CreateCubeFromOnepointsList(List<Point> list)
        {
            CreateCubeFromPoints(list.ToArray());
        }

        public void CreateCubeFromOnePointAndsideLength(Point p, double sideLength, bool abscissa = true, bool ordinate = true, bool applicata = true)
        {
            Point[] points = new Point[8];

            points[0] = p;
            points[1] = new Point(p.X, p.Y, applicata ? p.Z + sideLength : p.Z - sideLength);
            points[2] = new Point(abscissa ? p.X + sideLength : p.X - sideLength, p.Y, p.Z);
            points[3] = new Point(p.X, ordinate ? p.Y + sideLength : p.Y - sideLength, p.Z);

            points[4] = new Point(abscissa ? p.X + sideLength : p.X - sideLength,
                ordinate ? p.Y + sideLength : p.Y - sideLength,
                applicata ? p.Z + sideLength : p.Z - sideLength);
            points[5] = new Point(p.X, ordinate ? p.Y + sideLength : p.Y - sideLength,
                applicata ? p.Z + sideLength : p.Z - sideLength);
            points[6] = new Point(abscissa ? p.X + sideLength : p.X - sideLength,
                ordinate ? p.Y + sideLength : p.Y - sideLength, p.Z);
            points[7] = new Point(abscissa ? p.X + sideLength : p.X - sideLength, p.Y,
                applicata ? p.Z + sideLength : p.Z - sideLength);

            CreateCubeFromPoints(points);
        }


        public Cube GetCube()
        {
            return _cube;
        }

        private bool IsRightDistanceBetweenPoints(Point p1, Point p2, double sideLenght)
        {
            var isWrong = ((p1.X == p2.X && (p1.Y == p2.Y || p1.Z == p2.Z) ||
                p1.Y == p2.Y && p1.Z == p2.Z) &&
                p1.Distance(p2) != sideLenght);
            
            return !isWrong;
        }

        private double GetSideLength(Point[] points)
        {

        }

        private bool IsRightPoints(Point[] points)
        {
            double sideLenght = GetSideLength(points);

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (!IsRightDistanceBetweenPoints(points[i], points[i + 1], sideLenght))
                {
                    return false;
                }

                if (points.Length == 8 && !IsRightDistanceBetweenPoints(points[3], points[7], sideLenght))
                {
                    return false;
                }
            }

            return true;
        }

        private void Validate(Point[] points)
        {            
            if (!IsRightPoints(points))
            {
                throw new InvalidNumberOfPointsException("Invalid points are set. The resulting shape is not a cube.");
            }
        }
    }
}
