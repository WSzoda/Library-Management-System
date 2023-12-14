using System.Collections;
using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/countries")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<CountryController> _logger;
    private readonly ICountryRepository _countryRepository;

    public CountryController(IMapper mapper, ILogger<CountryController> logger, ICountryRepository countryRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _countryRepository = countryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryResponseDto>>> GetCountries()
    {
        _logger.LogInformation("Getting all countries");
        var countries = await _countryRepository.GetAllCountries();
        var countriesDto = _mapper.Map<List<CountryResponseDto>>(countries);
        return Ok(countriesDto);
    }
    
    
    [HttpGet("{id}"), ActionName("GetCountry")]
    public async Task<ActionResult<CountryResponseDto>> GetCountry(int id)
    {
        try
        {
            _logger.LogInformation($"Getting country with id: {id}");
            var country = await _countryRepository.GetCountryById(id);
            var countryDto = _mapper.Map<CountryResponseDto>(country);
            return Ok(countryDto);
        }
        catch (ArgumentNullException)
        {
            _logger.LogWarning($"Country with id: {id} not found");
            return NotFound($"Country with id: {id} not found");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CountryResponseDto>> CreateCountry([FromBody] CountryCreateDto country)
    {
        _logger.LogInformation($"Adding a new country: {country.Name}");
        var countryEntity = _mapper.Map<Country>(country);
        var countryExists = await _countryRepository.GetAllCountries(country.Name);
        if (countryExists.Any())
        {
            _logger.LogWarning($"Country with name: {country.Name} already exists");
            return Conflict($"Country with name: {country.Name} already exists");
        }
        await _countryRepository.AddCountry(countryEntity);
        var countryDto = _mapper.Map<CountryResponseDto>(countryEntity);
        return CreatedAtAction(nameof(GetCountries), new { id = countryEntity.Id }, countryDto);
    }
    
    [HttpPatch("{id}")]
    public async Task<ActionResult<CountryResponseDto>> EditCountry(int id, [FromBody] CountryResponseDto country)
    {
        try
        {
            _logger.LogInformation($"Editing country with id: {id}");
            var countryEntity = _mapper.Map<Country>(country);
            var countryResponse = await _countryRepository.EditCountry(id, countryEntity);
            return Ok(_mapper.Map<CountryResponseDto>(countryResponse));
        }
        catch (ArgumentNullException)
        {
            _logger.LogWarning($"Country with id: {id} not found");
            return NotFound($"Country with id: {id} not found");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCountry(int id)
    {
        try
        {
            _logger.LogInformation($"Deleting country with id: {id}");
            await _countryRepository.DeleteCountry(id);
            return NoContent();
        }
        catch (ArgumentNullException)
        {
            _logger.LogWarning($"Country with id: {id} not found");
            return NotFound($"Country with id: {id} not found");
        }
    }
    
}