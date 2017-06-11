using ImportBooksFromXML;
using ImportBooksFromXML.Contracts;
using Library.ExportToPdf.Contracts;
using Library.Models;
using Library.Models.BooksManagement;
using LibraryApp.Contract;
using LibraryApp.Core.Commands;
using LibraryApp.Core.Providers;
using LibraryApp.Data;
using LibraryApp.Migrations;
using Ninject;
using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;

namespace LibraryApp
{
    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(
                                    new MigrateDatabaseToLatestVersion
                                    <LibraryDbContext, Configuration>());

            IKernel kernel = new StandardKernel(new LibraryModule());
            var db = kernel.Get<IDatabaseLibrary>();
            LibraryDbContext database = db.GetInstance();

            while(true)
            {
                var input = Console.ReadLine();
                var commandParser = new CommandParser();
                var command = commandParser.Parse(input);
                if(command == null)
                {
                    break;
                }

                switch (command.GetType().Name)
                {
                    case "ImportRecordsFromJSON":
                        string path = input.Split(' ')[1].ToLower();
                        var cmd = new ImportRecordsFromJSON();
                        var res = cmd.Execute(database, path);
                        Console.WriteLine(res);
                        break;
                    case "ImportRecordsFromXML":
                        Console.WriteLine("Case 2");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
          }

            ////Read cars form books.xml
            /*var reader = XmlReader.Create("../../../XmlImportFiles/books.xml");
            var bookService = new StaxXmlBooksService(reader);

            var booksToList = bookService.GetAll().ToList();


            foreach (var book in booksToList)
            {
                database.Books.Add(book as Book);
                database.Authors.Add((book as Book).Author);
                foreach (var genre in (book as Book).Genres )
                {
                    database.Genres.Add(genre);
                }
            }*/


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

            //database.SaveChanges();

            //ILogger logger = kernel.Get<ILogger>("Console Logger");
            //logger.Log("Generating pdf reports...");

            //Generating Pdf fle reports
            ///var generatePdfReports = kernel.Get<IPdfGenerator>();
            //generatePdfReports.Generate(database);
            

        }

    }
}
