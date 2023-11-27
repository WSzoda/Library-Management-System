using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}