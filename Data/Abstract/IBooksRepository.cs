using Biblioteka.Models;

namespace Biblioteka.Data.Abstract
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}