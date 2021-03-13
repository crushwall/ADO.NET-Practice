using System;
using CubeExceptions;
using System.Collections.Generic;

namespace Shapes
{
    public class Cube
    {
        private double _sideLength;
        private Point[] _points;

        public double SideLength
        {
            get => _sideLength;
        }
        public Point[] Points
        {
            get => _points;

            set
            {
                _points = new Point[8];
                _sideLength = value[0].Distance(value[1]);

                ValidateEnteredPoints(value);

                if (value.Length == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        _points[i] = value[i];
                    }

                    _points[4] = new Point(_points[2].X, _points[3].Y, _points[1].Z);
                    _points[5] = new Point(_points[1].X, _points[3].Y, _points[1].Z);
                    _points[6] = new Point(_points[2].X, _points[3].Y, _points[2].Z);
                    _points[7] = new Point(_points[3].X, _points[0].Y, _points[1].Z);
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        _points[i] = value[i];
                    }

                }
            }
        }

        public double Volume
        {
            get => _sideLength * _sideLength * _sideLength;
        }

        public double Square
        {
            get => _sideLength * _sideLength;
        }

        public Cube()
        {
            _points = new Point[8];
            _sideLength = 0;
        }

        public Cube(Point[] points)
        {
            _points = new Point[8];
            _sideLength = points[0].Distance(points[1]);

            ValidateEnteredPoints(points);

            if (points.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    _points[i] = points[i];
                }

                _points[4] = new Point(_points[2].X, _points[3].Y, _points[1].Z);
                _points[5] = new Point(_points[1].X, _points[3].Y, _points[1].Z);
                _points[6] = new Point(_points[2].X, _points[3].Y, _points[2].Z);
                _points[7] = new Point(_points[3].X, _points[0].Y, _points[1].Z);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    _points[i] = points[i];
                }

            }
        }

        public Cube(List<Point> list) : this(list.ToArray()) { }

        public Cube(Point p1, Point p2, Point p3, Point p4) : this(new Point[] { p1, p2, p3, p4 }) { }

        public Cube(Point p1, Point p2, Point p3, Point p4, Point p5, Point p6, Point p7, Point p8) :
            this(new Point[] { p1, p2, p3, p4, p5, p6, p7, p8}) { }

        public Cube(double x1, double y1, double z1, double x2, double y2, double z2,
            double x3, double y3, double z3, double x4, double y4, double z4) :
            this(
                new Point[] {new Point(x1, y1, z1),
                new Point(x2, y2, z2),
                new Point(x3, y3, z3),
                new Point(x4, y4, z4)}
                )
        { }

        public Cube(Point p1, double _sideLength, bool abscissa = true, bool ordinate = true, bool applicata = true)
        {
            _points = new Point[8];
            this._sideLength = _sideLength;

            _points[0] = p1;
            _points[1] = new Point(p1.X, p1.Y, applicata ? p1.Z + _sideLength : p1.Z - _sideLength);
            _points[2] = new Point(abscissa? p1.X + _sideLength : p1.X - _sideLength, p1.Y,p1.Z);
            _points[3] = new Point(p1.X, ordinate? p1.Y + _sideLength : p1.Y - _sideLength,p1.Z);

            _points[4] = new Point(abscissa ? p1.X + _sideLength : p1.X - _sideLength,
                ordinate ? p1.Y + _sideLength : p1.Y - _sideLength,
                applicata ? p1.Z + _sideLength : p1.Z - _sideLength);
            _points[5] = new Point(p1.X, ordinate ? p1.Y + _sideLength : p1.Y - _sideLength,
                applicata ? p1.Z + _sideLength : p1.Z - _sideLength);
            _points[6] = new Point(abscissa ? p1.X + _sideLength : p1.X - _sideLength,
                ordinate ? p1.Y + _sideLength : p1.Y - _sideLength, p1.Z);
            _points[7] = new Point(abscissa ? p1.X + _sideLength : p1.X - _sideLength, p1.Y,
                applicata ? p1.Z + _sideLength : p1.Z - _sideLength);
        }


        public override string ToString()
        {
            string s = String.Empty;

            if (_points != null && _points.Length != 0)
            {
                foreach (Point p in _points)
                {
                    s += $"{p.X} {p.Y} {p.Z}\n";
                }
            }

            return s;
        }

        private bool ValidateSameEdge(Point p1, Point p2)
        {
            if ((p1.X == p2.X && (p1.Y == p2.Y || p1.Z == p2.Z) ||
                p1.Y == p2.Y && p1.Z == p2.Z) &&
                p1.Distance(p2) != _sideLength)
            {
                return false;
            }

            return true;
        }

        private void ValidateEnteredPoints(Point[] points)
        {
            if (points.Length != 4 && points.Length != 8)
            {
                throw new InvalidNumberOfPointsException("The cube is uniquely defined by four or eight points.");
            }
            else
            {
                for (int i = 0; i < points.Length - 1; i++)
                {
                    if (!ValidateSameEdge(points[i], points[i + 1]))
                    {
                        throw new WrongSideLengthException(
                                    $"Invalid points are set." +
                                    $"The resulting shape is not a cube." +
                                    $"\nSide Length: {_sideLength}, found: {points[i].Distance(points[i + 1])}"
                                    );
                    }

                    if (points.Length == 8 && !ValidateSameEdge(points[3], points[7]))
                    {
                        throw new WrongSideLengthException(
                                    $"Invalid points are set." +
                                    $"The resulting shape is not a cube." +
                                    $"\nSide Length: {_sideLength}, found: {points[i].Distance(points[i + 1])}"
                                    );
                    }
                }
            }
        }
    }
}
