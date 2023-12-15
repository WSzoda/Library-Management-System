using Library.DTOs;

namespace Library.Blazor.Services.RentService;

public interface IRentService
{
    Task RentBook(BookResponseDto bookToRent);
    Task ReturnBook(BookResponseDto bookToReturn);
    Task<IEnumerable<RentResponseDto>> GetRentsAsync();
}