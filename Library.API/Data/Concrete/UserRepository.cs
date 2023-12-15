using Library.API.Data.Abstract;
using Library.Blazor.Services.UsersService;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete;

public class UserRepository : IUsersRepository
{
    private readonly LibraryDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(LibraryDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
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

    public async Task EditUserPassword(int userId, PasswordEditDto dto)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if(user == null) throw new Exception("User not found");
            if(dto.Password != dto.ConfirmPassword) throw new Exception("Passwords do not match");
            
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}