using FluentValidation;

namespace Shapes
{
    public class CubeValidator : AbstractValidator<Cube>
    {
        public CubeValidator()
        {
            RuleFor(c => c.Points)
                .Must(BeRightNumberOfPoints).WithMessage("The cube is uniquely defined by four or eight points.")
                .Must(BePointsRightDistance).WithMessage($"Invalid points are set. The resulting shape is not a cube.");
        }

        private bool BeRightNumberOfPoints(Point[] points)
        {
            return (points.Length == 4 || points.Length == 8) ? true : false;
        }

        private bool IsRightDistance(Point p1, Point p2, double sideLenght)
        {
            if ((p1.X == p2.X && (p1.Y == p2.Y || p1.Z == p2.Z) ||
                p1.Y == p2.Y && p1.Z == p2.Z) &&
                p1.Distance(p2) != sideLenght)
            {
                return false;
            }

            return true;
        }

        private bool BePointsRightDistance(Point[] points)
        {
            double sideLenght = points[0].Distance(points[1]);

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (!IsRightDistance(points[i], points[i + 1], sideLenght))
                {
                    return false;
                }

                if ((points.Length == 8 || points.Length ==4) && !IsRightDistance(points[3], points[7], sideLenght))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
