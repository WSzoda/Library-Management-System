using Library.DTOs;

namespace Library.Blazor.Services.PublisherService
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherResponseDto>> GetPublishersAsync();
        Task<PublisherResponseDto> GetPublisherAsync(int id);
        Task<PublisherResponseDto> AddPublisherAsync(PublisherCreateDto publisher);
    }
}
