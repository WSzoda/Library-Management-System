using Library.Domain;

namespace Library.API.Data.Abstract
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
        Task<Publisher> AddPublisher(Publisher publisher);
        Task EditPublisher(int id, Publisher publisher);
        Task DeletePublisher(int id);
    }
}
