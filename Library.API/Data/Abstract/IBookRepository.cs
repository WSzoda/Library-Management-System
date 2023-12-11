using Library.Domain;

namespace Library.API.Data.Abstract
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks(List<int>? genreIdsFilter = null, List<int>? languageIds = null);
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}