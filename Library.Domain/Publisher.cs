using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Domain
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        [JsonIgnore]
        public IEnumerable<Book>? Books { get; set; }
    }
}