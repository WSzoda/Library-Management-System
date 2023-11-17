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


        public Task<IEnumerable<AuthorResponseDto>> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorResponseDto> GetAuthorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
