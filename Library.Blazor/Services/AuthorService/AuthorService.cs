using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private const string Endpoint = "api/authors";
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<AuthorResponseDto>> GetAuthorsAsync()
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var authors = await JsonSerializer.DeserializeAsync<IEnumerable<AuthorResponseDto>>(stream, options);
            return authors!;
        }

        public async Task<AuthorResponseDto> GetAuthorByIdAsync(int id)
        {
            var apiUrl = $"{Endpoint}/{id}";
            var stream = await _httpClient.GetStreamAsync(apiUrl);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var author = await JsonSerializer.DeserializeAsync<AuthorResponseDto>(stream, options);
            return author!;
        }
    }
}
