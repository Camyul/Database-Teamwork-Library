﻿using System.Collections.Generic;

namespace Library.Models.BooksManagement
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual Genre ParentGenres { get; set; }
    }
}