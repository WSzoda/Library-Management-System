using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/publishers")]
    [Authorize]
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletePublisher(int id)
        {
            _logger.LogInformation($"Deleting publisher with id: {id}");
            try
            {
                await _publisherRepository.DeletePublisher(id);
                return NoContent();
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

        [HttpPost]
        public async Task<ActionResult<PublisherResponseDto>> CreatePublisher(PublisherCreateDto publisherCreateDto)
        {
            _logger.LogInformation("Creating a new publisher");

            try
            {
                var publisher = _mapper.Map<Publisher>(publisherCreateDto);
                await _publisherRepository.AddPublisher(publisher);
                var publisherResponseDto = _mapper.Map<PublisherResponseDto>(publisher);
                return CreatedAtAction(nameof(GetPublisherById), new { id = publisherResponseDto.Id }, publisherResponseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new publisher");
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PublisherResponseDto>> UpdatePublisher(int id, PublisherResponseDto? dto)
        {
            try
            {
                _logger.LogInformation($"Editing country with id: {id}");
                var publisherEntity = _mapper.Map<Publisher>(dto);
                await _publisherRepository.EditPublisher(publisherEntity.Id, publisherEntity);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                _logger.LogWarning($"Country with id: {id} not found");
                return NotFound($"Country with id: {id} not found");
            }
        }
    }
}
