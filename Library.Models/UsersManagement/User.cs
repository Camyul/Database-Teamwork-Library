using Library.Models.Adrresses;
using Library.Models.BookOrders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.UsersManagement
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public virtual Adrress Adrress { get; set; }

        public virtual ICollection<BooksOrder> Orders { get; set; }
    }
}
