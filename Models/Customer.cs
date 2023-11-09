using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public IEnumerable<Rental> Rentals { get; set; } = new List<Rental>();
    }
}