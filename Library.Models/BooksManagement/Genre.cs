using Newtonsoft.Json;
using System.Collections.Generic;

namespace Library.Models.BooksManagement
{
    public class Genre : IDbEntity
    {
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Genre ParentGenres { get; set; }
    }
}