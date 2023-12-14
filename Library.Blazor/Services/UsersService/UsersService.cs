using System.Text;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.UsersService;

public class UsersService : IUsersService
{
    private const string Endpoint = "api/users";
    private readonly HttpClient _httpClient;

    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
    {
        try
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var users = await JsonSerializer.DeserializeAsync<IEnumerable<UserResponseDto>>(stream, options);
            return users!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UserResponseDto> GetUserAsync(int id)
    {
        try
        {
            var stream = await _httpClient.GetStreamAsync($"{Endpoint}/{id}");
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var user = await JsonSerializer.DeserializeAsync<UserResponseDto>(stream, options);
            return user!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UserResponseDto> EditUser(UserResponseDto user)
    {
        try
        {
            var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PatchAsync($"{Endpoint}/{user.Id}", userJson);
            response.EnsureSuccessStatusCode();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}