using LibraryApp.Contract;
using LibraryApp.Data;

namespace Library.ExportToPdf.Contracts
{
    public interface IPdfGenerator
    {
        void Generate(LibraryDbContext dbContext, string fileLocation);
    }
}
