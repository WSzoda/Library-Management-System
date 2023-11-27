using AutoMapper;
using Library.API.Data.Abstract;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/publishers")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly ILogger<PublisherController> _logger;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository publisherRepository, ILogger<PublisherController> logger, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherResponseDto>>> GetAllPublishers()
        {
            _logger.LogInformation("Getting all publishers");
            try
            {
                var publishers = await _publisherRepository.GetAllPublishers();
                var publishersDto = _mapper.Map<IEnumerable<PublisherResponseDto>>(publishers);
                return Ok(publishersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error happened when getting all publishers");
                return BadRequest();
            }   
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PublisherResponseDto>> GetPublisherById(int id)
        {
            _logger.LogInformation($"Getting publisher with id: {id}");
            try
            {
                var publisher = await _publisherRepository.GetPublisherById(id);
                var publisherDto = _mapper.Map<PublisherResponseDto>(publisher);
                return Ok(publisherDto);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"Publisher with id: {id} not found");
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, $"Id cannot be less than 1");
                return BadRequest();
            }   
        }
    }
}
