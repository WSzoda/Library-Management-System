﻿using System.Text;
using System.Text.Json;
using Library.Blazor.Services.UsersService;
using Library.DTOs;

namespace Library.Blazor.Services.RentService;

public class RentService : IRentService
{
    private readonly HttpClient _httpClient;
    private readonly IUsersService _usersService;
    private const string Endpoint = "api/rents";
    
    
    public RentService(HttpClient httpClient, IUsersService usersService)
    {
        _httpClient = httpClient;
        _usersService = usersService;
    }
    
    public async Task<IEnumerable<RentResponseDto> > GetRentsAsync()
    {
        try
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var rents = await JsonSerializer.DeserializeAsync<IEnumerable<RentResponseDto>>(stream, options);
            return rents!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<IEnumerable<RentResponseDto> > GetAllRentsAsync()
    {
        try
        {
            var stream = await _httpClient.GetStreamAsync($"{Endpoint}/all");
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var rents = await JsonSerializer.DeserializeAsync<IEnumerable<RentResponseDto>>(stream, options);
            return rents!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task RentBook(BookResponseDto bookToRent)
    {
        try
        {
            var newRent = new RentCreateDto
            {
                BookId = bookToRent.Id,
                UserId = (await _usersService.GetCurrentUserAsync()).Id,
            };
            
            var bookJson = new StringContent(JsonSerializer.Serialize(newRent), Encoding.UTF8, "application/json");
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