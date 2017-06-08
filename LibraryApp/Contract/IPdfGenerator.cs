using LibraryApp.Data;

namespace Library.ExportToPdf.Contracts
{
    public interface IPdfGenerator
    {
        void Generate(LibraryDbContext dbContext);
    }
}
