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

        public Book(string title, string description, Author author, Genre genre, int year, double price)
        {
            this.Title = title;
            this.Description = description;
            this.Author = author;
            this.Genres = new List<Genre>();
            this.Genres.Add(genre);
            this.Year = year;
            this.Price = price;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        public virtual Author Author { get; set; }
        
        public virtual ICollection<Genre> Genres { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual BooksOrder Order { get; set; }
    }
}
