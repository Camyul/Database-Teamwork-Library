using LibraryApp.Data;

namespace LibraryApp.Contract
{
    public interface IDatabaseLibrary
    {
        LibraryDbContext GetInstance();
    }
}
