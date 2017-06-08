using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Adrresses
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        public ICollection<Town>Towns { get; set; }
    }
}
