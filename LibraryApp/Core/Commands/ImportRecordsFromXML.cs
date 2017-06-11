using ImportBooksFromXML;
using ImportBooksFromXML.Contracts;
using Library.Models.BooksManagement;
using LibraryApp.Core.Contracts;
using LibraryApp.Data;
using System.Linq;
using System.Xml;

namespace LibraryApp.Core.Commands
{
    public class ImportRecordsFromXML : ICommand
    {
        private IDbService xmlService;

        public string Execute(LibraryDbContext database, string path)
        {
            var reader = XmlReader.Create(@path);
            var bookService = new StaxXmlBooksService(reader);

            var booksToList = bookService.GetAll().ToList();


            foreach (var book in booksToList)
            {
                database.Books.Add(book as Book);
                database.Authors.Add((book as Book).Author);
                foreach (var genre in (book as Book).Genres)
                {
                    database.Genres.Add(genre);
                }
            }
            database.SaveChanges();

            return "Successfully imported from XML!";
        }
    }
}
