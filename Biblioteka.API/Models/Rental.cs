namespace Biblioteka.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string RentalDate { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
    }
}