using System.ComponentModel.DataAnnotations;

namespace Library.DTOs;

public class CountryCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}