namespace Library.Models.Adrresses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Adrress> Adrresses { get; set; }
    }
}