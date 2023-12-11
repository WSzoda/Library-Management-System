using System.ComponentModel.DataAnnotations;

namespace Library.DTOs;

public class AuthorCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Surname { get; set; } = string.Empty;
    public int CountryId { get; set; }
}