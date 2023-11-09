using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; } = new Country();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}