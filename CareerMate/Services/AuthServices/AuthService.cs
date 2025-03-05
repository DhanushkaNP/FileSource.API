using FileSource.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FileSource.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateNewJsonWebToken(string id, string email, IList<string> userRoles)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email, ClaimValueTypes.String),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
            };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTAuthenticatom:Secret"]));

            var tokenObject = new JwtSecurityToken(
                issuer: _configuration["JWTAuthenticatom:ValidIssuer"],
                audience: _configuration["JWTAuthenticatom:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }
    }
}
