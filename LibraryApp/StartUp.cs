﻿using ImportBooksFromXML;
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
                if(input == "end")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if(input == "help")
                {
                    Console.WriteLine("List of valid commands:\n importrecordsfromjson <path to file>\n importrecordsfromxml <path to file>");
                }
                else
                {
                    var commandParser = new CommandParser();
                    var command = commandParser.Parse(input);
                    if (command == null)
                    {
                        Console.WriteLine("You have inserted a wrong command. Type help for a list of valid commands.");
                        break;
                    }

                    switch (command.GetType().Name)
                    {
                        case "ImportRecordsFromJSON":
                            string JSONpath = input.Split(' ')[1].ToLower();
                            var JSONcmd = new ImportRecordsFromJSON();
                            var JSONres = JSONcmd.Execute(database, JSONpath);
                            Console.WriteLine(JSONres);
                            break;
                        case "ImportRecordsFromXML":
                            string XMLpath = input.Split(' ')[1].ToLower();
                            var XMLcmd = new ImportRecordsFromXML();
                            var XMLres = XMLcmd.Execute(database, XMLpath);
                            Console.WriteLine(XMLres);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
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

            //ILogger logger = kernel.Get<ILogger>("Console Logger");
            //logger.Log("Generating pdf reports...");

            //Generating Pdf fle reports
            ///var generatePdfReports = kernel.Get<IPdfGenerator>();
            //generatePdfReports.Generate(database);
            

        }

    }
}
