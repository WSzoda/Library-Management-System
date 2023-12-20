using System.Text;
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

        public async Task<AuthorResponseDto> AddAuthorAsync(AuthorCreateDto author)
        {
            var authorJson = new StringContent(JsonSerializer.Serialize(author), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(Endpoint, authorJson);
            var stream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var newAuthor = await JsonSerializer.DeserializeAsync<AuthorResponseDto>(stream, options);
            return newAuthor!;
        }
        public async Task<AuthorResponseDto> EditAuthorAsync(int id, AuthorResponseDto authorUpdateDto)
        {
            var apiUrl = $"{Endpoint}/{id}";
            var authorJson = new StringContent(JsonSerializer.Serialize(authorUpdateDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiUrl, authorJson);
            var stream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var updatedAuthor = await JsonSerializer.DeserializeAsync<AuthorResponseDto>(stream, options);
            return updatedAuthor!;
        }
        public async Task DeleteAuthorAsync(int id)
        {
            var apiUrl = $"{Endpoint}/{id}";
            await _httpClient.DeleteAsync(apiUrl);
        }
    }
}
