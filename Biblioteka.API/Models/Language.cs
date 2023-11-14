using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteka.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        public string LanguageName { get; set; } = string.Empty;
        public IEnumerable<Book>? Books { get; set; }
    }
}