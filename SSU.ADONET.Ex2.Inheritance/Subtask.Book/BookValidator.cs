using FluentValidation;
using FluentValidation.Results;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Book
{
    class BookValidator : AbstractValidator<Book>
    {
        private const int publishingHouseMinLength = 1;
        private const int publishingHouseMaxLength = 255;

        public BookValidator()
        {
            var msg = "Incorrect \"{PropertyName}\": {PropertyValue}. ";
            var titleFormat = "Must have length between 1 and 255.";
            var writingDateFormat = "Must be less than \"PublicationDate\".";

            RuleFor(b => b.Title)
                .Length(1, 255).WithMessage(msg + titleFormat);

            RuleFor(b => b.PagesCount)
                .GreaterThan(0).WithMessage(msg);

            RuleFor(b => b.PublishingHouse)
                .Length(publishingHouseMinLength, publishingHouseMaxLength)
                .WithMessage(msg + titleFormat);

            RuleFor(b => b.PublicationDate)
                .NotNull().WithMessage(msg);

            RuleFor(b => b)
                .NotNull().WithMessage(msg)
                .Must(BeCorrectWritingDate)
                .WithMessage(msg + writingDateFormat);

            RuleFor(b => b.Author)
                .NotNull()
                .SetValidator(new AuthorValidator())
                .WithMessage(msg);
        }

        bool BeCorrectWritingDate(Book book)
        {
            return book.WritingDate <= book.PublicationDate;
        }
    }
}
