using Library.Models.BooksManagement;
using Library.Models.UsersManagement;
using System.Data.Entity;

namespace LibraryApp.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryConnection")
        {
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnGenreModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnGenreModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(genre => genre.Name)
                .IsRequired()
                .HasMaxLength(60);
        }
    }

}
