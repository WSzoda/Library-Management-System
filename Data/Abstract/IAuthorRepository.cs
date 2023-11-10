using Biblioteka.Models;

namespace Biblioteka.Data.Abstract
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();   
        Task<Author> GetAuthorById(int id);
        Task AddAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
    }
}