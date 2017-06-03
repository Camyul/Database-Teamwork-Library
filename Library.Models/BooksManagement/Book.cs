using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BooksManagement
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
