using Library.Domain;
using Library.DTOs;

namespace Library.API.Data.Abstract;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> EditUser(int id, UserResponseDto user);
}