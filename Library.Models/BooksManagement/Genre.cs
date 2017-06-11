using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.BooksManagement
{
    public class Genre : IDbEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [JsonProperty("name")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Genre ParentGenres { get; set; }
    }
}