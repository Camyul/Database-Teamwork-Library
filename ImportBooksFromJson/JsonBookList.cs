using Library.Models.BooksManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBooksFromJson
{
    public class JsonBookList
    {
        [JsonProperty("bookList")]
        public List<Book> Books { get; set; }

        public static void Main()
        {
        }
    }
}
