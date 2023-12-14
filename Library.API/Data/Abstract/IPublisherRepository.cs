using Library.Domain;

namespace Library.API.Data.Abstract
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
        Task DeletePublisher(int id);
    }
}
