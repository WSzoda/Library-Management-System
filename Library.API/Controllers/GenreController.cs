using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreController> _logger;

        public GenreController(IGenreRepository genreRepository, IMapper mapper, ILogger<GenreController> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetGenres()
        {
            _logger.LogInformation("Getting all genres");
            var genres = await _genreRepository.GetAllGenres();
            var genresDto = _mapper.Map<List<GenreResponseDto>>(genres);
            return Ok(genresDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGenre(int id)
        {
            try
            {
                _logger.LogInformation($"Getting genre with id: {id}");
                var genre = _genreRepository.GetGenreById(id);
                return Ok(genre);
            }
            catch (ArgumentNullException)
            {
                _logger.LogWarning($"Genre with id: {id} not found");
                return NotFound($"Genre with id: {id} not found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(GenreToCreateDto genre)
        {
            try
            {
                _logger.LogInformation($"Adding genre: {genre.Name}");
                var genreEntity = _mapper.Map<Genre>(genre);
                await _genreRepository.AddGenre(genreEntity);
                var genreDto = _mapper.Map<GenreResponseDto>(genreEntity);
                return CreatedAtAction(nameof(GetGenre), new { id = genreEntity.Id }, genreDto);
            }
            catch (Exception)
            {
                _logger.LogError($"Error happened when adding genre: {genre}");
                return BadRequest("Something went wrong");
            }
        }
    }
}
