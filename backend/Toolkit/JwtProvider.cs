using backend.Abstractions;
using backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend.Toolkit
{
    public class JwtProvider : IJwtProvider
    {

        public string Sign(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            var signinCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Config.SECRET_KEY_BYTES),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signinCredentials,
                expires: DateTime.UtcNow.AddHours(Config.SESSION_EXPIRES_HOURS));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue.ToString();
        }
    }
}
