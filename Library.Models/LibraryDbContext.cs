namespace LibraryApp
{
    using Library.Models;
    using Library.Models.BooksManagement;
    using System.Data.Entity;

    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext():base("LibraryConnection")
        {

        }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Genre> Genres { get; set; }
    }
}
