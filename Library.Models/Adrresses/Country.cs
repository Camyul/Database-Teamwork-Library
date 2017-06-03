using System.Collections.Generic;

namespace Library.Models.Adrresses
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Town>Towns { get; set; }
    }
}
