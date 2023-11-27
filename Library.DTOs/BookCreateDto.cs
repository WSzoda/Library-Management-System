using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Library.DTOs
{
    public class BookCreateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfPublishing { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public int LanguageId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public IEnumerable<int> AuthorsIds { get; set; } = new List<int>();
    }
}