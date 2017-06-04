namespace Library.Models.UsersManagement
{
    using Adrresses;
    using Library.Models.BookOrders;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public virtual Adrress Adrress { get; set; }
        public virtual ICollection<BooksOrder> Orders { get; set; }
    }
}
