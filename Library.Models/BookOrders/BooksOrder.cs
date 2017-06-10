using Library.Models.BooksManagement;
using Library.Models.UsersManagement;
using System.Collections.Generic;

namespace Library.Models.BookOrders
{
    public class BooksOrder: IDbEntity
    {
        public int Id { get; set; }

        public virtual ICollection<Book> BooksBorrowed { get; set; }

        public virtual User User { get; set; }
    }
}
