namespace Library.Domain
{
    public class Rental
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string RentalDate { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
        public bool Returned { get; set; }
    }
}