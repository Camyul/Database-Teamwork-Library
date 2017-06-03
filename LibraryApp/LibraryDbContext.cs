namespace LibraryApp
{
    using Library.Models;
    using System.Data.Entity;

    class LibraryDbContext:DbContext
    {
        public LibraryDbContext():base("LibraryConnection")
        {

        }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Genre> Genres { get; set; }
    }
}
