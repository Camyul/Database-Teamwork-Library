using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using System.Data.Entity;
using ImportBooksFromXML;
using Library.Models.BooksManagement;
using LibraryApp.Migrations;
using ImportBooksFromXML.Contracts;

namespace LibraryApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                                    new MigrateDatabaseToLatestVersion
                                    <LibraryDbContext, Configuration>());
            var db = new LibraryDbContext();

            ////Read cars form books.xml
            IBookService bookService = new StaxXmlBooksService("../../../XmlImportFiles/books.xml");

            var booksToList = bookService.GetAll().ToList();


            foreach (var book in booksToList)
            {
                db.Books.Add(book);
                db.Authors.Add(book.Author);
                foreach (var genre in book.Genres)
                {
                    db.Genres.Add(genre);
                }
            }

                db.SaveChanges();
            
        }
    }
}
