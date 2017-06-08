using ImportBooksFromXML;
using ImportBooksFromXML.Contracts;
using Library.ExportToPdf.Contracts;
using LibraryApp.Contract;
using LibraryApp.Data;
using LibraryApp.Migrations;
using Ninject;
using System.Data.Entity;
using System.Linq;

namespace LibraryApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                                    new MigrateDatabaseToLatestVersion
                                    <LibraryDbContext, Configuration>());

            IKernel kernel = new StandardKernel(new LibraryModule());
            var db = kernel.Get<IDatabaseLibrary>();
            LibraryDbContext database = db.GetInstance();

            ////Read cars form books.xml
            IBookService bookService = new StaxXmlBooksService("../../../XmlImportFiles/books.xml");

            var booksToList = bookService.GetAll().ToList();


            foreach (var book in booksToList)
            {
                database.Books.Add(book);
                database.Authors.Add(book.Author);
                foreach (var genre in book.Genres)
                {
                    database.Genres.Add(genre);
                }
            }


            //var myJsonDocument = JsonConvert.DeserializeObject<JsonBookList>(File.ReadAllText(@"../../../JsonImportFiles/books.json"));
            //foreach (var book in myJsonDocument.Books)
            //{
            //    db.Books.Add(book);
            //    /*db.Authors.Add(book.Author);
            //    foreach (var genre in book.Genres)
            //    {
            //        db.Genres.Add(genre);
            //    }*/
            //}

            database.SaveChanges();

            ILogger logger = kernel.Get<ILogger>("Console Logger");
            logger.Log("Generating pdf reports...");

            //Generating Pdf fle reports
            var generatePdfReports = kernel.Get<IPdfGenerator>();
            generatePdfReports.Generate(database);
        }

    }
}
