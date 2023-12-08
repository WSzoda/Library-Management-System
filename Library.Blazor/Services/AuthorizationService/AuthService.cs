using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Library.DTOs;

namespace Library.Blazor.Services.AuthorizationService;

public class AuthService : IAuthService
{
    private const string Endpoint = "api/account";
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public async Task<HttpResponseMessage> Login(LoginDto dto)
    {
        var userJson = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{Endpoint}/login", userJson);


        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            await _localStorage.SetItemAsStringAsync("token", token);
        }
        return response;
    }

    public async Task<HttpResponseMessage> Register(RegisterUserDto dto)
    {
        var userJson = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{Endpoint}/register", userJson);

        return response;
    }
    
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
    }
}