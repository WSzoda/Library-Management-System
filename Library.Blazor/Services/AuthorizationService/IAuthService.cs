using Library.DTOs;

namespace Library.Blazor.Services.AuthorizationService;

public interface IAuthService
{
    public Task<HttpResponseMessage> Login(LoginDto dto);
}