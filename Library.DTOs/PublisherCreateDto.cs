using System.ComponentModel.DataAnnotations;

namespace Library.DTOs;

public class PublisherCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public int YearOfCreation { get; set; }
    public int CountryId { get; set; }
}