using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/authorbooks")]
    public class AuthorBookController : ControllerBase
    {
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly ILogger<AuthorBookController> _logger;
        private readonly IMapper _mapper;

        public AuthorBookController(IAuthorBookRepository authorBookRepository, IMapper mapper, ILogger<AuthorBookController> logger)
        {
            _authorBookRepository = authorBookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorBooks()
        {
            var authorBooks = await _authorBookRepository.GetAuthorBooks();
            return Ok(authorBooks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthorBook([FromBody] AuthorBookDto authorBook)
        {
            _logger.LogInformation($"Creating new AuthorBook for AuthorId: {authorBook.AuthorId}, BookId: {authorBook.BookId}");
            try
            {
                var authorBookNew = _mapper.Map<AuthorBook>(authorBook);
                await _authorBookRepository.AddAuthorBook(authorBookNew);
                return Ok(authorBookNew);
            }
            catch(Exception)
            {
                _logger.LogError($"Error happened when creating AuthorBook for AuthorId: {authorBook.AuthorId}, BookId: {authorBook.BookId}");
                return BadRequest("Something went wrong");
            }
        }
    }
}
