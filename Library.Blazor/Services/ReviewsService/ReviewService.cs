using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.ReviewsService;

public class ReviewService : IReviewService
{
    private const string Endpoint = "api/reviews";
    private readonly HttpClient _httpClient;

    public ReviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ReviewResponseDto> AddReviewAsync(int bookId, ReviewCreateDto reviewCreateDto)
    {
        var apiUrl = $"{Endpoint}/{bookId}";
        var reviewJson = new StringContent(JsonSerializer.Serialize(reviewCreateDto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(apiUrl, reviewJson);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        var addedReview = await JsonSerializer.DeserializeAsync<ReviewResponseDto>(stream, options);
        return addedReview!;
    }
}