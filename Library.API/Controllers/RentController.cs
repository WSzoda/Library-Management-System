using System.Security.Claims;
using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/rents")]
public class RentController : ControllerBase
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<RentController> _logger;

    public RentController(IRentalRepository rentalRepository, IMapper mapper, ILogger<RentController> logger)
    {
        _rentalRepository = rentalRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentResponseDto>>> GetRents()
    {
        try
        {
            IEnumerable<Rental> rents;
            if(!HttpContext.User.IsInRole("Admin,Worker"))
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(userId is null) throw new Exception("User not found");
                rents = await _rentalRepository.GetRents(int.Parse(userId));
            }
            else
            {
                rents = await _rentalRepository.GetRents(null);
            }
            _logger.LogInformation("Getting all rents");
            var rentsDto = _mapper.Map<IEnumerable<RentResponseDto>>(rents);
            return Ok(rentsDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<RentResponseDto>> GetRent(int id)
    {
        try
        {
            _logger.LogInformation($"Getting rent with id: {id}");
            var rent = await _rentalRepository.GetRent(id);
            var rentDto = _mapper.Map<RentResponseDto>(rent);
            return Ok(rentDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("rent")]
    public async Task<ActionResult<RentResponseDto>> CreateRent(RentCreateDto rent)
    {
        try
        {
            _logger.LogInformation("Checking if book is free to rent");
            var rentsForBook = await _rentalRepository.GetRents(rent.BookId);
            if(rentsForBook.Any(r => !r.Returned)) throw new Exception("Book is not available");
            _logger.LogInformation("Creating new rent");
            var newRent = await _rentalRepository.CreateRent(rent);
            var newRentDto = _mapper.Map<RentResponseDto>(newRent);
            return Ok(newRentDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("return")]
    public async Task<ActionResult<RentResponseDto>> ReturnRent(RentResponseDto rent)
    {
        try
        {
            _logger.LogInformation($"Returning rent with id: {rent.Id}");
            var returnedRent = await _rentalRepository.UpdateRent(rent);
            var returnedRentDto = _mapper.Map<RentResponseDto>(returnedRent);
            return Ok(returnedRentDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}