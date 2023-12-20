namespace Library.DTOs
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfPublishing { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public LanguageResponseDto? Language { get; set; }
        public GenreResponseDto? Genre { get; set; }
        public PublisherResponseDto? Publisher { get; set; }
        public IEnumerable<AuthorResponseDto>? Authors { get; set; } = new List<AuthorResponseDto>();
        public IEnumerable<ReviewResponseDto>? Reviews { get; set; } = new List<ReviewResponseDto>();
    }
}
