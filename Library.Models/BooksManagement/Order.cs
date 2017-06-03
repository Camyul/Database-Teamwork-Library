namespace Library.Models.BooksManagement
{
    using Library.Models.UsersManagement;
    public class Order
    {

        public int Id { get; set; }
        public virtual User User { get; set; }
    }
}