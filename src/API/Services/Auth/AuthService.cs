using API.DTOs.Auth;
using API.Interfaces.Repositories;
using API.Interfaces.Services;
using API.Models;
using API.Settings;
using API.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string?> AuthenticateAsync(LoginRequestDto login)
        {
            // Normaliza email e senha para evitar erros de espaços e case
            string email = login.Email.Trim().ToLower();
            string passwordHash = PasswordHasher.ComputeSha256Hash(login.Password.Trim());

            // Busca usuário pelo email e senha hash
            var user = await _userRepository.GetByEmailAndPasswordAsync(email, passwordHash);

            if (user == null)
                return null;

            // Cria claims para o token JWT
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
        new Claim(ClaimTypes.Email, user.email)
    };

            // Configura chave secreta e credenciais de assinatura do token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token JWT
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            // Retorna o token serializado
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
