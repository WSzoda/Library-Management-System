using Library.Domain;

namespace Library.API.Data.Abstract
{
    public interface IAuthorBookRepository
    {
        Task AddAuthorBook(AuthorBook authorBook);
        Task AddAuthorBooks(IEnumerable<AuthorBook> authorBooks);
        Task DeleteAuthorBook(int authorId, int bookId);
        Task<IEnumerable<AuthorBook>> GetAuthorBooks();
        Task<IEnumerable<AuthorBook>> GetAuthorBooks(int id, bool getByAuthorId = true);
    }
}
