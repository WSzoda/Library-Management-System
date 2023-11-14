using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}