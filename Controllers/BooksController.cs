using Biblioteka.Data.Abstract;
using Biblioteka.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Biblioteka.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBooksRepository booksRepository, ILogger<BooksController> logger)
        {
            _booksRepository = booksRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            _logger.LogInformation("Getting all books");
            var books = await _booksRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                _logger.LogInformation($"Getting book with id {id}");
                var book = await _booksRepository.GetBookById(id);
                return Ok(book);
            }
            catch(ArgumentNullException)
            {
                _logger.LogError($"Book with id {id} was not found.");
                return NotFound($"Book with id {id} was not found.");
            }
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            try
            {
                _logger.LogInformation($"Updating book {book.Id}");
                _booksRepository.UpdateBook(book);
                return Ok(book);
            }
            catch (ArgumentNullException)
            {
                _logger.LogError($"Book {book.Id} was not updated.");
                return BadRequest($"Book {book.Id} was not updated.");
            }
        }
    }
}