namespace Library.DTOs;

public class RentResponseDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public string RentalDate { get; set; } = string.Empty;
    public string ReturnDate { get; set; } = string.Empty;
}