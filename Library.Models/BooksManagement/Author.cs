using Newtonsoft.Json;
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
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
