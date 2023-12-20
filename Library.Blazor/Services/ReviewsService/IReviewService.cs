using Library.DTOs;

namespace Library.Blazor.Services.ReviewsService;

public interface IReviewService
{
    Task<ReviewResponseDto> AddReviewAsync(int bookId, ReviewCreateDto reviewCreateDto);
}