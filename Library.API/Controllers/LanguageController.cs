using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguageController : ControllerBase
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;


        public LanguageController(ILogger<LanguageController> logger, ILanguageRepository languageRepository, IMapper mapper)
        {
            _logger = logger;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageResponseDto>>> GetLanguages()
        {
            _logger.LogInformation("Getting all languages");
            var languages = await _languageRepository.GetAllLanguages();
            var languagesDto = _mapper.Map<List<LanguageResponseDto>>(languages);
            return Ok(languagesDto);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddLanguage(LanguageCreateDto language)
        {
            _logger.LogInformation("Adding a new language");
            var languageEntity = _mapper.Map<Language>(language);
            await _languageRepository.AddLanguage(languageEntity);
            var languageDto = _mapper.Map<LanguageResponseDto>(languageEntity);
            return CreatedAtAction(nameof(GetLanguages), new { id = languageEntity.Id }, languageDto);
        }
        
        [HttpPatch("{id}")]
        public async Task<ActionResult> EditLanguage(int id, LanguageResponseDto language)
        {
            try
            {
                _logger.LogInformation($"Editing language with id {id}");
                var languageEntity = _mapper.Map<Language>(language);
                await _languageRepository.UpdateLanguage(languageEntity);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                _logger.LogError($"Language with id {id} was not found.");
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLanguage(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting language with id {id}");
                await _languageRepository.DeleteLanguage(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                _logger.LogError($"Language with id {id} was not found.");
                return NotFound();
            }
        }
    }
}
