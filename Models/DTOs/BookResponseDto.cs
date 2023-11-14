namespace Biblioteka.Models.DTOs
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfPublishing { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public LanguageResponseDto? Language { get; set; }
        public Genre? Genre { get; set; }
        public Publisher? Publisher { get; set; }
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
        public IEnumerable<Review>? Reviews { get; set; } = new List<Review>();
    }
}
