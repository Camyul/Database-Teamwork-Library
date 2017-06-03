namespace Library.Models.BookOrders
{
    using BooksManagement;
    using System.Collections.Generic;
    using UsersManagement;

    public class BooksOrder
    {
        public int Id { get; set; }
        public virtual ICollection<Book> BooksBorrowed { get; set; }
        public virtual User User { get; set; }
    }
}
