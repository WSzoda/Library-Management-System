using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteka.Models.DTOs
{
    public class PublisherResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
    }
}
