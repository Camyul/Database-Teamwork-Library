using LibraryApp.Contract;

namespace LibraryApp.Data
{
    public class DatabaseLibrary : IDatabaseLibrary
    {
        public object Books { get; set; }
        private static LibraryDbContext database;

        public LibraryDbContext GetInstance()
        {
              database = new LibraryDbContext();

            return database;
        }
    }
}
