using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.BooksManagement
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Genre ParentGenres { get; set; }
    }
}