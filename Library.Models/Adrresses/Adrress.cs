using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Adrresses
{
    public class Adrress
    {
        public int Id { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string AdrressLine { get; set; }

        public virtual Town Town { get; set; }
    }
}