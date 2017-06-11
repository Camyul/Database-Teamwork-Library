using LibraryApp.Data;

namespace LibraryApp.Contract
{
    public interface IDatabaseLibrary
    {
        object Books { get; set; }

        LibraryDbContext GetInstance();
    }
}
