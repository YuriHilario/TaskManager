using API.DTOs.Auth;
using API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var token = await _authService.AuthenticateAsync(login);
            if (token == null)
                return Unauthorized("Credenciais inválidas.");

            return Ok(new { token });
        }
    }
}
