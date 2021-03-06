﻿using ImportBooksFromXML.Contracts;
using System.Collections.Generic;
using System.Xml;
using Library.Models.BooksManagement;
using Library.Models;

namespace ImportBooksFromXML
{
    public class StaxXmlBooksService : IDbService
    {
        private const string BookElementName = "book";

        private const string BookElementTitle = "title";

        private const string BookElementDescription = "description";

        private const string BookElementYear = "year";

        private const string BookElementPrice = "price";

        private const string AuthorElementName = "author";

        private const string GenreElementName = "genre";

        private XmlReader reader;
        public StaxXmlBooksService(XmlReader reader)
        {
            this.reader = reader;
        }

        public string XmlFileLocation { get; set; }

        ////Read XML from file 
        public IEnumerable<IDbEntity> GetAll()
        {
            var books = new List<Book>();

            using (reader)
            {
                Book book = this.ReadNextBook();
                while (book != null)
                {
                    books.Add(book);
                    book = this.ReadNextBook();
                }
            }

            return books;
        }

        private Book ReadNextBook()
        {
            const int BookPropertiesToRead = 6;
            int bookPropertiesRead = 0;
            bool isInBook = false;
            string title = string.Empty;
            string description = string.Empty;
            Author author = new Author();
            Genre genre = new Genre();
            int year = 0;
            double price = 0;

            while (reader.Read() && bookPropertiesRead < BookPropertiesToRead)
            {
                if (isInBook == false && reader.IsStartElement() && reader.Name == BookElementName)
                {
                    isInBook = true;
                    reader.Read();
                }

                if (isInBook && reader.IsStartElement() && reader.Name == BookElementTitle)
                {
                    bookPropertiesRead++;
                    reader.Read();
                    title = reader.Value;
                }

                if (isInBook && reader.IsStartElement() && reader.Name == BookElementDescription)
                {
                    bookPropertiesRead++;
                    reader.Read();
                    description = reader.Value;
                }

                if (isInBook && reader.IsStartElement() && reader.Name == BookElementPrice)
                {
                    bookPropertiesRead++;
                    reader.Read();
                    price = double.Parse(reader.Value);
                }

                if (isInBook && reader.IsStartElement() && reader.Name == BookElementYear)
                {
                    bookPropertiesRead++;
                    reader.Read();
                    year = int.Parse(reader.Value);
                }

                if (isInBook && reader.IsStartElement() && reader.Name == AuthorElementName)
                {
                    bookPropertiesRead++;
                    reader.Read();
                    var fullName = (reader.Value).Split(' ');
                    author.FirstName = fullName[0];
                    author.LastName = fullName[1];
                }

                if (isInBook && reader.IsStartElement() && reader.Name == GenreElementName)
                {
                    bookPropertiesRead++;
                    reader.Read();
                    genre.Name = reader.Value;
                }
            }

            return bookPropertiesRead < BookPropertiesToRead
                ? null
                : new Book(title, description, author, genre, year, price);
        }
    }
}
