namespace Biblioteka.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfPublishing { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int LanguageId { get; set; }
        public Language Language { get; set; } = new Language();
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = new Genre();
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = new Publisher();
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public IEnumerable<Rental> Rentals { get; set; } = new List<Rental>();
    }
}