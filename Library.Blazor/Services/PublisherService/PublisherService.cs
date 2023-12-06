﻿using Library.DTOs;
using System.Text.Json;

namespace Library.Blazor.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private const string Endpoint = "api/publishers";
        private readonly HttpClient _httpClient;

        public PublisherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<PublisherResponseDto>> GetPublishersAsync()
        {
            var apiUrl = $"{Endpoint}";
            var stream = await _httpClient.GetStreamAsync(apiUrl);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var publishers = await JsonSerializer.DeserializeAsync<IEnumerable<PublisherResponseDto>>(stream, options);
            return publishers!;
        }

        public async Task<PublisherResponseDto> GetPublisherAsync(int id)
        {
            var apiUrl = $"{Endpoint}/{id}";
            var stream = await _httpClient.GetStreamAsync(apiUrl);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var publisher = await JsonSerializer.DeserializeAsync<PublisherResponseDto>(stream, options);
            return publisher!;
        }
    }
}