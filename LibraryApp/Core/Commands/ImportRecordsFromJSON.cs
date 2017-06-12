using Library.Models.BooksManagement;
using LibraryApp.Core.Contracts;
using LibraryApp.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LibraryApp.Core.Commands
{
    public class ImportRecordsFromJSON : ICommand
    {
        [JsonProperty("bookList")]
        public List<Book> Books { get; set; }

        public string Execute(LibraryDbContext database, string path)
        {
            var myJsonDocument = JsonConvert.DeserializeObject<ImportRecordsFromJSON>(File.ReadAllText(@path));

            foreach (var book in myJsonDocument.Books)
            {
                database.Books.Add(book);
            }
            database.SaveChanges();
            return "Successfully imported from JSON!";
        }
    }
}
