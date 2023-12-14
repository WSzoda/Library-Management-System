using System.Security.Claims;
using AutoMapper;
using Library.API.Data.Abstract;
using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUsersRepository usersRepository, ILogger<UsersController> logger, IMapper mapper, IRoleRepository roleRepository)
    {
        _usersRepository = usersRepository;
        _logger = logger;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers()
    {
        _logger.LogInformation("Getting all users");
        var users = await _usersRepository.GetAllUsers();
        var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(users);
        return Ok(usersDto);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
    {
        try
        {
            _logger.LogInformation($"Getting user with id: {id}");
            var user = await _usersRepository.GetUserById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult<UserResponseDto>> EditUser(int id, UserResponseDto user)
    {
        var editedUser = await _usersRepository.EditUser(id, user);
        var userDto = _mapper.Map<UserResponseDto>(editedUser);
        
        return Ok(userDto);
    }
    
    [HttpGet]
    [Route("current")]
    public async Task<ActionResult<UserResponseDto>> GetCurrentUser()
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId is null) throw new Exception("User not found");
        
        var user = await _usersRepository.GetUserById(int.Parse(userId));
        var userDto = _mapper.Map<UserResponseDto>(user);
        return Ok(userDto);
    }
}