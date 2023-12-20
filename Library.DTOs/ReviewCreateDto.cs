namespace Library.DTOs;

public class ReviewCreateDto
{
    public string Description { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int BookId { get; set; }
}