using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
        public IEnumerable<Publisher> Publishers { get; set; } = new List<Publisher>();
    }
}