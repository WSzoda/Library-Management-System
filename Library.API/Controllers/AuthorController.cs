using AutoMapper;
using Biblioteka.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<AuthorController> _logger;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorController> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAuthors()
        {
            _logger.LogInformation("Getting all authors");
            var authors = await _authorRepository.GetAllAuthors();
            var authorsDto = _mapper.Map<List<AuthorResponseDto>>(authors);
            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> GetAuthorById(int id)
        {
            try
            {
                _logger.LogInformation($"Getting author with id {id}");
                var author = await _authorRepository.GetAuthorById(id);
                var authorDto = _mapper.Map<AuthorResponseDto>(author);
                return Ok(authorDto);
            }
            catch (ArgumentNullException)
            {
                _logger.LogError($"Author with id {id} was not found.");
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthor(Author author)
        {
            try
            {
                _logger.LogInformation("Adding author");
                await _authorRepository.AddAuthor(author);
                return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                _logger.LogError("Mismatching Ids.");
                return BadRequest("Mismatching Ids.");
            }

            try
            {
                await _authorRepository.UpdateAuthor(author);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            try
            {
                await _authorRepository.DeleteAuthor(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
