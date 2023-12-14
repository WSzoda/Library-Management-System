using Library.DTOs;

namespace Library.Blazor.Services.UsersService;

public interface IUsersService
{
    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    Task<UserResponseDto> GetUserAsync(int id);
    Task<UserResponseDto> EditUser(UserResponseDto user);
}
