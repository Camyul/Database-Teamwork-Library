using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.BooksManagement
{
    public class Author : IDbEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
