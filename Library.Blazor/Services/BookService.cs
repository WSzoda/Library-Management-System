using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services
{
    public class BookService : IBooksService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksAsync()
        {
            var stream = await _httpClient.GetStreamAsync("api/books");
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true};
            var books = await JsonSerializer.DeserializeAsync<IEnumerable<BookResponseDto>>(stream, options);
            return books!;
        }

        public Task<BookResponseDto> GetBookAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
