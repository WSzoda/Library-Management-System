using AutoMapper;
using Biblioteka.Data.Abstract;
using Biblioteka.Models;
using Biblioteka.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Biblioteka.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _booksRepository;
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;

        public BookController(IBookRepository booksRepository, ILogger<BookController> logger, IMapper mapper, IAuthorBookRepository authorBookRepository)
        {
            _booksRepository = booksRepository;
            _logger = logger;
            _mapper = mapper;
            _authorBookRepository = authorBookRepository;
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

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            if(book is null)
            {
                _logger.LogError("Book was null.");
                return BadRequest("Book was null.");
            }
            if(!ModelState.IsValid)
            {
                _logger.LogError("Book was invalid.");
                return BadRequest("Book was invalid.");
            }

            var bookExists = _booksRepository.GetBookById(book.Id);
            if(bookExists is null)
            {
                _logger.LogError($"Book {book.Id} was not found.");
                return NotFound($"Book {book.Id} was not found.");
            }

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

        [HttpPost]
        public IActionResult CreateBook(BookCreateDto book)
        {
            if(book is null)
            {
                _logger.LogError("Book was null.");
                return BadRequest("Book was null.");
            }
            if(!ModelState.IsValid)
            {
                _logger.LogError("Book was invalid.");
                return BadRequest("Book was invalid.");
            }

            try
            {
                _logger.LogInformation("Creating book");
                Book bookCreated = _mapper.Map<Book>(book);
                _booksRepository.AddBook(bookCreated);
                List<AuthorBook> authorBooks = new();
                if(bookCreated.BookAuthors is not null)
                {
                    foreach (var authorId in book.AuthorsIds)
                    {
                        authorBooks.Add(new AuthorBook { AuthorId = authorId, BookId = bookCreated.Id });
                    }
                }
                _authorBookRepository.AddAuthorBooks(authorBooks);
                _logger.LogInformation(bookCreated.Id.ToString());
                return Ok(bookCreated);
            }
            catch (ArgumentNullException)
            {
                _logger.LogError("Book was not created.");
                return BadRequest("Book was not created.");
            }
        }


    }
}