using LibraryApp.Contract;
using LibraryApp.Core.Commands;
using LibraryApp.Core.Providers;
using LibraryApp.Data;
using LibraryApp.Migrations;
using Ninject;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace LibraryApp
{
    class StartUp
    {
        private const string DefaultFileName = "BooksReport.pdf";
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(
                                    new MigrateDatabaseToLatestVersion
                                    <LibraryDbContext, Configuration>());

            IKernel kernel = new StandardKernel(new LibraryModule());
            var db = kernel.Get<IDatabaseLibrary>();
            LibraryDbContext database = db.GetInstance();
            ILogger logger = kernel.Get<ILogger>("Console Logger");
            logger.Log("Enter \"help\" to see list of valid commands");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (input == "help")
                {
                    Console.WriteLine("List of valid commands:\n importrecordsfromjson <path to file>\n importrecordsfromxml <path to file> \n generatepdfreport");
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
                        case "GeneratePdfReport":
                            string path=GetPdfPath();
                            var generatePdfReportCommand = new GeneratePdfReport();
                            generatePdfReportCommand.Execute(database, path);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }

            }
        }

        private static string GetPdfPath()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.CheckFileExists = false;

            dialog.FileName = DefaultFileName;
            dialog.AddExtension = true;
            dialog.DefaultExt = "pdf";
            dialog.InitialDirectory = "//";
            string location = null;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                location = System.IO.Path.GetFullPath(dialog.FileName);
            }
            return location;
        }
    }
}
