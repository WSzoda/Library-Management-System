using Library.DTOs;

namespace Library.Blazor.Services.UsersService;

public interface IUsersService
{
    Task<IEnumerable<UserResponseDto>> GetUsersAsync();
    Task<UserResponseDto> GetUserAsync(int id);
    Task<UserResponseDto> GetCurrentUserAsync();
    Task<UserResponseDto> EditUser(UserResponseDto user);
}
