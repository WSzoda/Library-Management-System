namespace Biblioteka.Models.DTOs
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
