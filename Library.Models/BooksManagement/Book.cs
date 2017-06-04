using Library.Models.BookOrders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BooksManagement
{
    public class Book
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual BooksOrder Order { get; set; }
    }
}
