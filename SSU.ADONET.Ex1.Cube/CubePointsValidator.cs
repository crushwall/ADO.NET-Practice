using FluentValidation;

namespace SSU.ADONET.Ex1.Cube
{
    public class CubePointsValidator : AbstractValidator<Point[]>
    {
        public CubePointsValidator()
        {
            RuleFor(p => p)
                .Must(BeRightNumberOfPoints)
                .WithMessage("The cube is uniquely defined by four or eight points.");
        }

        private bool BeRightNumberOfPoints(Point[] points)
        {
            return (points.Length == 4 || points.Length == 8) ? true : false;
        }
    }
}
