using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<Rental>? Rentals { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}