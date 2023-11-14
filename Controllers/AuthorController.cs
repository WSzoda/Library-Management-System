using Biblioteka.Data.Abstract;
using Biblioteka.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            try
            {
                var author = await _authorRepository.GetAuthorById(id);
                return Ok(author);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] Author author)
        {
            try
            {
                await _authorRepository.AddAuthor(author);
                return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
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
