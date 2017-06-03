namespace Library.Models.UsersManagement
{
    using Adrresses;
    using Library.Models.BookOrders;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual Adrress Adrress { get; set; }
        public virtual ICollection<BooksOrder> Orders { get; set; }
    }
}
