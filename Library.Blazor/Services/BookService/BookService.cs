﻿using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.BookService
{
    public class BookService : IBooksService
    {
        private const string Endpoint = "api/books";
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksAsync()
        {
            const string apiUrl = $"{Endpoint}";
            var stream = await _httpClient.GetStreamAsync(apiUrl);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var books = await JsonSerializer.DeserializeAsync<IEnumerable<BookResponseDto>>(stream, options);
            return books!;
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksAsync(List<int>? genreIds)
        {
            var queryString = string.Empty;
            if (genreIds is not null)
            {
                queryString += string.Join("&", genreIds.Select(id => $"genreIds={id}"));
            }
            var apiUrl = $"{Endpoint}?{queryString}";
            var stream = await _httpClient.GetStreamAsync(apiUrl);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var books = await JsonSerializer.DeserializeAsync<IEnumerable<BookResponseDto>>(stream, options);
            return books!;
        }

        public async Task<BookResponseDto> GetBookAsync(int id)
        {
            var stream = await _httpClient.GetStreamAsync($"{Endpoint}/{id}");
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var book = await JsonSerializer.DeserializeAsync<BookResponseDto>(stream, options);
            return book!;
        }
    }
}