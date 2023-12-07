using System.Text;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.AuthorizationService;

public class AuthService : IAuthService
{
    private const string Endpoint = "api/account";
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> Login(LoginDto dto)
    {
        var userJson = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var resonse = await _httpClient.PostAsync($"{Endpoint}/login", userJson);

        return resonse;

    }
}