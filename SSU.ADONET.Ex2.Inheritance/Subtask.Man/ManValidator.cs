using FluentValidation;
using System;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Man
{
    public class ManValidator : AbstractValidator<Man>
    {
        private const int maxAge = 100;
        private const int firstNameMinLength = 1;
        private const int firstNameMaxLength = 255;
        private const int weightMinLength = 2;
        private const int weightMaxLength = 200;
        private const int heightMinLength = 40;
        private const int heightMaxLength = 300;

        public ManValidator()
        {
            DateTime minDate = new DateTime(DateTime.Now.Year - maxAge, 1, 1);

            var msg = "Incorrect \"{PropertyName}\": {PropertyValue}. ";
            var firstNameFormat = "Must have length between 1 and 255.";
            var birthdayFormat = $"Must be graten than {minDate.ToShortDateString()}.";
            var weightFormat = "Must be between 2 and 200 kg.";
            var heightFormat = "Must be between 40 and 300 cm.";

            RuleFor(s => s.FirstName)
                .Length(firstNameMinLength, firstNameMaxLength)
                .WithMessage(msg + firstNameFormat);

            RuleFor(m => m.Birthday)
                .Must(BeCorrectBirthday)
                .WithMessage(msg + birthdayFormat);

            RuleFor(s => s.Weight)
                .InclusiveBetween(weightMinLength, weightMaxLength)
                .WithMessage(msg + weightFormat);

            RuleFor(s => s.Height)
                .InclusiveBetween(heightMinLength, heightMaxLength)
                .WithMessage(msg + heightFormat);
        }

        private bool BeCorrectBirthday(DateTime birthday)
        {
            var now = DateTime.Now;

            var minBirthday = now.AddYears(-maxAge);
            return minBirthday <= birthday && birthday <= now;
        }
    }
}
