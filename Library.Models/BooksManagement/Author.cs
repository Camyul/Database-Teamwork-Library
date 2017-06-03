using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BooksManagement
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
