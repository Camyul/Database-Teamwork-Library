using Library.Models.BooksManagement;
using System.Collections.Generic;

namespace ImportBooksFromXML.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
    }
}