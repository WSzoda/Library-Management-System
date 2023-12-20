using Library.Domain;

namespace Library.API.Data.Abstract;

public interface IReviewRepository
{
    Task AddReview(Review review);
}