using Library.DTOs;

namespace Library.Blazor.Services.AuthorizationService;

public interface IAuthService
{
    public Task<HttpResponseMessage> Login(LoginDto dto);
    public Task<HttpResponseMessage> Register(RegisterUserDto dto);
    public Task Logout();
}