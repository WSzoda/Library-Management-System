using Library.API.Data.Abstract;
using Library.Blazor.Services.UsersService;
using Library.Domain;
using Library.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete;

public class UserRepository : IUsersRepository
{
    private readonly LibraryDbContext _context;

    public UserRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _context.Users.Include(u => u.Role).ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(int id)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user!;
        } catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<User> EditUser(int id, UserResponseDto user)
    {
        try
        {
            var userToEdit = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(userToEdit == null) throw new Exception("User not found");
            if(userToEdit.Id != user.Id) throw new Exception("Id's do not match");

            userToEdit.Name = user.Name;
            userToEdit.Surname = user.Surname;
            userToEdit.Email = user.Email;
            
            _context.Users.Update(userToEdit);
            await _context.SaveChangesAsync();
            return userToEdit;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}