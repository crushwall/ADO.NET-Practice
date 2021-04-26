using FluentValidation;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Book
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        private const int nameMinLength = 1;
        private const int nameMaxLength = 255;

        public AuthorValidator()
        {
            var msg = "Incorrect \"{PropertyName}\": {PropertyValue}. ";
            var firstNameFormat = "Must have length between 1 and 255.";

            RuleFor(a => a.FirstName)
                .Length(nameMinLength, nameMaxLength).WithMessage(msg + firstNameFormat);

            RuleFor(a => a.LastName)
                .Length(nameMinLength, nameMaxLength).WithMessage(msg + firstNameFormat);
        }
    }
}
