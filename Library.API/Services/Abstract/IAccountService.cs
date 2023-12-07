using Library.DTOs;

namespace Library.API.Services.Abstract
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
        public string GenerateJwt(LoginDto dto);
    }
}
