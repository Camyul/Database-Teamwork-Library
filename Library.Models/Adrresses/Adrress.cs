namespace Library.Models.Adrresses
{
    public class Adrress
    {
        public int Id { get; set; }
        public int PostalCode { get; set; }
        public string AdrressLine { get; set; }
        public virtual Town Town { get; set; }
    }
}