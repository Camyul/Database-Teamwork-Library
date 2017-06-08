using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Adrresses
{
    public class Town
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public virtual ICollection<Adrress> Adrresses { get; set; }
    }
}