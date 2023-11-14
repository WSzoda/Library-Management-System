using Biblioteka.Models;

namespace Biblioteka.Data.Abstract
{
    public interface IAuthorBookRepository
    {
        Task AddAuthorBook(AuthorBook authorBook);
        Task AddAuthorBooks(IEnumerable<AuthorBook> authorBooks);
        Task DeleteAuthorBook(int authorId, int bookId);
        Task<IEnumerable<AuthorBook>> GetAuthorBooksForBookId(int bookId);
        Task<IEnumerable<AuthorBook>> GetAuthorBooksForAuthorId(int authorId);
        Task<IEnumerable<AuthorBook>> GetAuthorBooks();
    }
}
