using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        public string LanguageName { get; set; } = string.Empty;
        public IEnumerable<Book>? Books { get; set; }
    }
}