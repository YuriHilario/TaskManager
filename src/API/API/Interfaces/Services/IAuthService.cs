using API.DTOs.Auth;
using API.Models;

namespace API.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(LoginRequestDto login);
    }
}
