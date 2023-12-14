using System.Text;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.RentService;

public class RentService : IRentService
{
    private readonly HttpClient _httpClient;
    private const string Endpoint = "api/rents";
    public async Task RentBook(BookResponseDto bookToRent)
    {
        try
        {
            var bookJson = new StringContent(JsonSerializer.Serialize(bookToRent), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{Endpoint}/rent", bookJson);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ReturnBook(BookResponseDto bookToReturn)
    {
        try
        {
            var bookJson = new StringContent(JsonSerializer.Serialize(bookToReturn), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{Endpoint}/return", bookJson);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}