using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public IEnumerable<AuthorBook>? AuthorBooks { get; set; } = new List<AuthorBook>();
    }
}