using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.LanguageService
{
    public class LanguageService : ILanguageService
    {
        private const string Endpoint = "api/languages";
        private readonly HttpClient _httpClient;

        public LanguageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LanguageResponseDto>> GetLanguagesAsync()
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var languages = await JsonSerializer.DeserializeAsync<IEnumerable<LanguageResponseDto>>(stream, options);
            return languages!;
        }
        
        public async Task<LanguageResponseDto> AddLanguageAsync(LanguageCreateDto language)
        {
            var languageJson = new StringContent(JsonSerializer.Serialize(language), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(Endpoint, languageJson);
            response.EnsureSuccessStatusCode();
            
            var stream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var createdLanguage = await JsonSerializer.DeserializeAsync<LanguageResponseDto>(stream, options);
            return createdLanguage!;
        }
    }
}
