using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BooksManagement
{
    public class Author
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
