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

        public async Task<BookResponseDto> GetBookAsync(int id)
        {
            var stream = await _httpClient.GetStreamAsync($"api/books/{id}");
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true};
            var book = await JsonSerializer.DeserializeAsync<BookResponseDto>(stream, options);
            return book!;
        }
    }
}
