using LibraryApp.Data;

namespace LibraryApp.Core.Contracts
{
    public interface ICommand
    {
        string Execute(LibraryDbContext database, string arguments);
    }
}
