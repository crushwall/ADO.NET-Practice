using FluentValidation;
using System;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Man
{
    class StudentValidator : AbstractValidator<Student>
    {
        private const int maxAge = 100;
        private const int firstNameMinLength = 1;
        private const int firstNameMaxLength = 255;
        private const int weightMinLength = 2;
        private const int weightMaxLength = 200;
        private const int heightMinLength = 40;
        private const int heightMaxLength = 300;
        private const int minCourseNumber = 1;
        private const int maxCourseNumber = 6;
        private const int minStudentAge = 15;
        public StudentValidator()
        {
            DateTime minDate = new DateTime(DateTime.Now.Year - maxAge, 1, 1);

            var msg = "Incorrect \"{PropertyName}\": {PropertyValue}. ";
            var firstNameFormat = "Must have length between 1 and 255.";
            var birthdayFormat = $"Must be graten than {minDate.ToShortDateString()}.";
            var weightFormat = "Must be between 2 and 200 kg.";
            var heightFormat = "Must be between 40 and 300 cm.";
            var courseNumberFormat = "Must be between 1 and 6.";

            RuleFor(s => s.FirstName)
                .Length(firstNameMinLength, firstNameMaxLength)
                .WithMessage(msg + firstNameFormat);

            RuleFor(m => m.Birthday)
                .Must(BeCorrectBirthday).WithMessage(msg + birthdayFormat);

            RuleFor(s => s.Weight)
                .InclusiveBetween(weightMinLength, weightMaxLength)
                .WithMessage(msg + weightFormat);

            RuleFor(s => s.Height)
                .InclusiveBetween(heightMinLength, heightMaxLength)
                .WithMessage(msg + heightFormat);

            RuleFor(s => s.CourseNumber)
                .InclusiveBetween(minCourseNumber, maxCourseNumber)
                .WithMessage(msg + courseNumberFormat);

            RuleFor(s => s)
                .Must(BeCorrectStartTrainingDate).WithMessage("{PropertyValue}");
        }

        private bool BeCorrectBirthday(DateTime birthday)
        {
            //int result = DateTime.Compare(DateTime.Now.AddYears(-maxAge), birthday);
            //result += DateTime.Compare(DateTime.Now, birthday);
            //return -1 <= result && result <= 1;

            var now = DateTime.Now;

            var minBirthday = now.AddYears(-maxAge);
            return minBirthday <= birthday && birthday <= now;
        }

        private bool BeCorrectStartTrainingDate(Student student)
        {
            var startTrainingAge = student.StartTrainingDate.Add(-new TimeSpan(student.Birthday.Ticks));

            return startTrainingAge.Year >= minStudentAge;
        }
    }
}
