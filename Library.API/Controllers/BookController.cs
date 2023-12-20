using AutoMapper;
using Library.API.Data.Abstract;
using Library.API.Services.Abstract;
using Library.Blazor.Services.RentService;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _booksRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BookController(IBookRepository booksRepository, ILogger<BookController> logger, IMapper mapper, IAuthorBookRepository authorBookRepository, IFileService fileService, IRentalRepository rentalRepository)
        {
            _booksRepository = booksRepository;
            _logger = logger;
            _mapper = mapper;
            _authorBookRepository = authorBookRepository;
            _fileService = fileService;
            _rentalRepository = rentalRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BookResponseDto>> GetBooks([FromQuery] List<int> genreIds, [FromQuery] List<int> languageIds)
        {
            _logger.LogInformation("Getting all books");
            var books = await _booksRepository.GetAllBooks(genreIds, languageIds);
            var booksDto = _mapper.Map<List<BookResponseDto>>(books);
            foreach (var book in booksDto)
            {
                book.Authors = _mapper.Map<List<AuthorResponseDto>>(books.Where(b => b.Id == book.Id).SelectMany(b => b.BookAuthors!).Select(ba => ba.Author).ToList());
                var rents = _rentalRepository.GetRents(book.Id);
                book.IsAvailable = rents.Result.All(r => r.Returned);
            }
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                _logger.LogInformation($"Getting book with id {id}");
                var book = await _booksRepository.GetBookById(id);
                var bookDto = _mapper.Map<BookResponseDto>(book);
                bookDto.Authors = _mapper.Map<List<AuthorResponseDto>>(book.BookAuthors!.Select(ba => ba.Author).ToList());
                bookDto.Reviews = _mapper.Map<List<ReviewResponseDto>>(book.Reviews!.ToList());
                return Ok(bookDto);
            }
            catch (ArgumentNullException)
            {
                _logger.LogError($"Book with id {id} was not found.");
                return NotFound($"Book with id {id} was not found.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book? book)
        {
            if (book is null)
            {
                _logger.LogError("Book was null.");
                return BadRequest("Book was null.");
            }
            if (id != book.Id)
            {
                _logger.LogError("Mismatching Ids.");
                return BadRequest("Mismatching Ids.");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Book was invalid.");
                return BadRequest("Book was invalid.");
            }

            var bookExists = _booksRepository.GetBookById(book.Id);
            if (bookExists is null)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting book {id}");
                await _booksRepository.DeleteBook(id);
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogError($"Book {id} was not deleted.");
                return NotFound($"Book {id} was not deleted.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(BookCreateDto book)
        {
            if (book is null)
            {
                _logger.LogError("Book was null.");
                return BadRequest("Book was null.");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Book was invalid.");
                return BadRequest("Book was invalid.");
            }

            try
            {
                _logger.LogInformation("Creating book");
                Book bookCreated = _mapper.Map<Book>(book);
                var image = await _fileService.SaveImage(book.Image, book.ImageName);
                bookCreated.ImageName = image.Item2;
                if (image.Item1 == 0)
                {
                    return BadRequest("Image was not saved.");
                }
                await _booksRepository.AddBook(bookCreated);
                List<AuthorBook> authorBooks = new();
                if (bookCreated.BookAuthors is not null)
                {
                    foreach (var authorId in book.AuthorsIds)
                    {
                        authorBooks.Add(new AuthorBook { AuthorId = authorId, BookId = bookCreated.Id });
                    }
                }
                await _authorBookRepository.AddAuthorBooks(authorBooks);
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