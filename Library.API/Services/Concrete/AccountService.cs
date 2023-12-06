using Biblioteka.Data;
using Library.API.Services.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Library.API.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly LibraryDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(LibraryDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User
            {
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                RoleId = dto.RoleId
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
