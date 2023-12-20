using Library.API.Data.Abstract;
using Library.Blazor.Services.ReviewsService;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Data.Concrete;

public class ReviewRepository : IReviewRepository
{
    private readonly LibraryDbContext _context;

    public ReviewRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task AddReview(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }
}