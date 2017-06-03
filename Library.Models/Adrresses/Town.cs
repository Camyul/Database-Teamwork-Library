namespace Library.Models.Adrresses
{
    using System.Collections.Generic;

    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Adrress> Adrresses { get; set; }
    }
}