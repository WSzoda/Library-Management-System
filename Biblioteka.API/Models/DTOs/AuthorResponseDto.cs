using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models.DTOs
{
    public class AuthorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}
