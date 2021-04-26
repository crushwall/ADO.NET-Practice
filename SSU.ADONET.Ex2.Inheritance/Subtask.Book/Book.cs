using System;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Book
{
    public class Book
    {
        public string Title { get; set; }

        public int PagesCount { get; set; }

        public string PublishingHouse { get; set; }

        public DateTime PublicationDate { get; set; }

        public DateTime WritingDate { get; set; }

        public Author Author { get; set; }
    }
}
