using AutoMapper;
using Library.API.Data.Abstract;
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
    }
}
