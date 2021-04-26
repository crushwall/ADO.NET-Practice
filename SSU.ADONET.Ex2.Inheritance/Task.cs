using FluentValidation.Results;
using SSU.ADONET.Ex2.Inheritance.Subtask.Book;
using SSU.ADONET.Ex2.Inheritance.Subtask.Man;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SSU.ADONET.Ex2.Inheritance
{
    public static class Task
    {
        private const string dateTimeFormat = "d M yyyy";
        public static void Start()
        {
            const string pathToMen = "../../input/inheritance/men.json";
            const string pathToStudents = "../../input/inheritance/students.json";
            const string pathToAuthors = "../../input/inheritance/authors.json";
            const string pathToBooks = "../../input/inheritance/books.json";

            #region Task1

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Task #1.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Men:");
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteAndValidateMen(GetEntitiesFromFile<Man>(pathToMen));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Students:");
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteAndValidateStudents(GetEntitiesFromFile<Student>(pathToStudents));

            Console.Write("Would you like to enter new man? y/n: ");
            string ans = Console.ReadLine().ToLower();
            if (ans.Contains("y"))
            {
                var man = GetManFromConsole();

                WriteAndValidateMan(man);
            }

            Console.Write("Would you like to enter new student? y/n: ");
            ans = Console.ReadLine().ToLower();
            if (ans.Contains("y"))
            {
                var student = GetStudentFromConsole();

                WriteAndValidateStudent(student);
            }

            #endregion

            #region Task2

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Task #2.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Authors:");
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteAndValidateAuthors(GetEntitiesFromFile<Author>(pathToAuthors));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Books:");
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteAndValidateBooks(GetEntitiesFromFile<Book>(pathToBooks));

            Console.Write("Would you like to enter new author? y/n: ");
            ans = Console.ReadLine().ToLower();
            if (ans.Contains("y"))
            {
                var author = GetAuthorFromConsole();

                WriteAndValidateAuthor(author);
            }

            Console.Write("Would you like to enter new book? y/n: ");
            ans = Console.ReadLine().ToLower();
            if (ans.Contains("y"))
            {
                var book = GetBookFromConsole();

                WriteAndValidateBook(book);
            }

            #endregion
        }

        private static IEnumerable<T> GetEntitiesFromFile<T>(string path)
        {
            var text = File.ReadAllText(path);
            var entities = JsonSerializer.Deserialize<List<T>>(text);

            return entities;
        }

        #region ManMethods
        private static Man GetManFromConsole()
        {

            Console.Write("Enter Name: ");
            string firstName = Console.ReadLine();

            Console.Write($"Enter Birthday (format: {dateTimeFormat}): ");
            DateTime birthday = new DateTime();
            bool correct = false;
            while (!correct)
            {
                correct = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat,
                    null, System.Globalization.DateTimeStyles.None,
                    out birthday);
            }

            Console.Write("Enter Weight (kg): ");
            double weight = 0;
            correct = false;
            while (!correct)
            {
                correct = double.TryParse(Console.ReadLine(), out weight);
            }

            Console.Write("Enter Height (cm): ");
            double height = 0;
            correct = false;
            while (!correct)
            {
                correct = double.TryParse(Console.ReadLine(), out height);
            }

            Man man = new Man
            {
                FirstName = firstName,
                Birthday = birthday,
                Weight = weight,
                Height = height
            };

            return man;
        }

        private static void WriteMan(Man man, int number)
        {
            Console.WriteLine($"{number}{"Name",11}: {man.FirstName}");
            Console.WriteLine($"\tBirthday: {man.Birthday.ToShortDateString()}");
            Console.WriteLine($"\tWeight: {man.Weight}");
            Console.WriteLine($"\tHeight: {man.Height}");
            Console.WriteLine();
        }

        private static void ValidateMan(Man man)
        {
            var validator = new ManValidator();

            var results = validator.Validate(man);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Man are successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed. Errors:");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                foreach (ValidationFailure failure in results.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }

        private static void WriteAndValidateMan(Man men)
        {
            WriteAndValidateMen(new List<Man> { men });
        }

        private static void WriteAndValidateMen(IEnumerable<Man> men)
        {
            int manIndex = 1;
            foreach (var man in men)
            {
                WriteMan(man, manIndex);
                ValidateMan(man);
                manIndex++;
            }
        }

        #endregion

        #region StudentMethods

        private static Student GetStudentFromConsole()
        {
            Console.Write("Enter Name: ");
            string firstName = Console.ReadLine();

            Console.Write($"Enter Birthday (format: {dateTimeFormat}): ");
            DateTime birthday = new DateTime();
            bool correct = false;
            while (!correct)
            {
                correct = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat,
                    null, System.Globalization.DateTimeStyles.None,
                    out birthday);
            }

            Console.Write("Enter Weight (kg): ");
            double weight = 0;
            correct = false;
            while (!correct)
            {
                correct = double.TryParse(Console.ReadLine(), out weight);
            }

            Console.Write("Enter Height (cm): ");
            double height = 0;
            correct = false;
            while (!correct)
            {
                correct = double.TryParse(Console.ReadLine(), out height);
            }

            Console.Write($"Enter Start training date (format: {dateTimeFormat}): ");
            DateTime startTrainingDate = new DateTime();
            correct = false;
            while (!correct)
            {
                correct = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat,
                    null, System.Globalization.DateTimeStyles.None,
                    out startTrainingDate);
            }

            Console.Write("Enter Course: ");
            int courseNumber = 0;
            correct = false;
            while (!correct)
            {
                correct = int.TryParse(Console.ReadLine(), out courseNumber);
            }

            Console.Write("Enter Group: ");
            int groupNumber = 0;
            correct = false;
            while (!correct)
            {
                correct = int.TryParse(Console.ReadLine(), out groupNumber);
            }

            var student = new Student
            {
                FirstName = firstName,
                Birthday = birthday,
                Weight = weight,
                Height = height,
                StartTrainingDate = startTrainingDate,
                CourseNumber = courseNumber,
                GroupNumber = groupNumber
            };

            return student;
        }

        private static void WriteStudent(Student student, int number)
        {
            Console.WriteLine($"{number}{"Name",11}: {student.FirstName}");
            Console.WriteLine($"\tBirthday: {student.Birthday.ToShortDateString()}");
            Console.WriteLine($"\tWeight: {student.Weight}");
            Console.WriteLine($"\tHeight: {student.Height}");
            Console.WriteLine($"\tStart traning: {student.StartTrainingDate.ToShortDateString()}");
            Console.WriteLine($"\tCourse numer: {student.CourseNumber}");
            Console.WriteLine($"\tGroup number: {student.GroupNumber}");
            Console.WriteLine();
        }

        private static void ValidateStudent(Student student)
        {
            var validator = new StudentValidator();

            var results = validator.Validate(student);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student are successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed. Errors:");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                foreach (ValidationFailure failure in results.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }

        private static void WriteAndValidateStudent(Student student)
        {
            WriteAndValidateStudents(new List<Student> { student });
        }

        private static void WriteAndValidateStudents(IEnumerable<Student> students)
        {
            int i = 1;
            foreach (var student in students)
            {
                WriteStudent(student, i);
                ValidateStudent(student);
                i++;
            }
        }

        #endregion

        #region AuthorMethods
        private static Author GetAuthorFromConsole()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write($"Enter Birthday (format: {dateTimeFormat}): ");
            DateTime birthday = new DateTime();
            bool correct = false;
            while (!correct)
            {
                correct = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat,
                    null, System.Globalization.DateTimeStyles.None,
                    out birthday);
            }

            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday
            };

            return author;
        }

        private static void WriteAuthor(Author author, int number)
        {
            Console.WriteLine($"{number}{"First name",11}: {author.FirstName}");
            Console.WriteLine($"\tLast name: {author.FirstName}");
            Console.WriteLine($"\tBirthday: {author.Birthday.ToShortDateString()}");
            Console.WriteLine();
        }

        private static void ValidateAuthor(Author author)
        {
            var validator = new AuthorValidator();

            var results = validator.Validate(author);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author are successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed. Errors:");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                foreach (ValidationFailure failure in results.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }

        private static void WriteAndValidateAuthor(Author author)
        {
            WriteAndValidateAuthors(new List<Author> { author });
        }

        private static void WriteAndValidateAuthors(IEnumerable<Author> authors)
        {
            int i = 1;

            foreach (var author in authors)
            {
                WriteAuthor(author, i);
                ValidateAuthor(author);
                i++;
            }
        }

        #endregion

        #region BookMethods

        private static Book GetBookFromConsole()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Pages count: ");
            int pagesCount = 0;
            bool correct = false;
            while (!correct)
            {
                correct = int.TryParse(Console.ReadLine(), out pagesCount);
            }

            Console.Write("Enter Publishing house: ");
            string publishingHouse = Console.ReadLine();

            Console.Write($"Enter Publication date (format: {dateTimeFormat}): ");
            DateTime publicationDate = new DateTime();
            correct = false;
            while (!correct)
            {
                correct = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat,
                    null, System.Globalization.DateTimeStyles.None,
                    out publicationDate);
            }

            Console.Write($"Enter Writing date (format: {dateTimeFormat}): ");
            DateTime writingDate = new DateTime();
            correct = false;
            while (!correct)
            {
                correct = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat,
                    null, System.Globalization.DateTimeStyles.None,
                    out writingDate);
            }

            Author author = GetAuthorFromConsole();

            var book = new Book
            {
                Author = author,
                Title = title,
                PagesCount = pagesCount,
                PublishingHouse = publishingHouse,
                PublicationDate = publicationDate,
                WritingDate = writingDate
            };

            return book;
        }

        private static void WriteBook(Book book, int number)
        {
            Console.WriteLine($"{number}{"Title",11}: {book.Title}");
            Console.WriteLine($"\tPages count: {book.PagesCount}");
            Console.WriteLine($"\tPublishing house: {book.PublishingHouse}");
            Console.WriteLine($"\tPublication date: {book.PublicationDate.ToShortDateString()}");
            Console.WriteLine($"\tWriting date: {book.WritingDate.ToShortDateString()}");
            Console.WriteLine($"\tAuthor first name: {book.Author.FirstName}");
            Console.WriteLine($"\tAuthor last name: {book.Author.LastName}");
            Console.WriteLine($"\tBirthday: {book.Author.Birthday.ToShortDateString()}");
            Console.WriteLine();
        }

        private static void ValidateBook(Book book)
        {
            var validator = new BookValidator();

            var results = validator.Validate(book);

            if (results.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book are successfully validated.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed. Errors:");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                foreach (ValidationFailure failure in results.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }

        private static void WriteAndValidateBook(Book book)
        {
            WriteAndValidateBooks(new List<Book> { book });
        }

        private static void WriteAndValidateBooks(IEnumerable<Book> books)
        {
            int i = 1;
            foreach (var book in books)
            {
                WriteBook(book, i);
                ValidateBook(book);
                i++;
            }
        }

        #endregion
    }
}
