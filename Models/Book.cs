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
        public Language? Language { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public IEnumerable<Author>? Authors { get; set; }
        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<Rental>? Rentals { get; set; }
    }
}