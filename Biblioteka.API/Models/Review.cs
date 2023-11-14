namespace Biblioteka.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}