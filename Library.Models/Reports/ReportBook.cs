using Library.Models.BooksManagement;
using System.Collections.Generic;

namespace Library.ExportToPdf.Models
{
    public class ReportBook
    {
        public string Author { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}
