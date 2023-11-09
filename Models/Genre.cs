using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Book>? Books { get; set; }
    }
}