using Library.Models;
using Library.Models.BooksManagement;
using System.Collections.Generic;

namespace ImportBooksFromXML.Contracts
{
    public interface IDbService
    {
        IEnumerable<IDbEntity> GetAll();
    }
}