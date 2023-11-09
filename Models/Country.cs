using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Author>? Authors { get; set; }
        public IEnumerable<Publisher>? Publishers { get; set; }
    }
}