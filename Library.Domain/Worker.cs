using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Worker : User
    {
        public string Role { get; set; } = string.Empty;
    }
}