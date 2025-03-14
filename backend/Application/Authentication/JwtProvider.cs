using backend.Domain.Abstractions;
using backend.Domain.Models;
using backend.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend.Application.Authentication
{
    public class JwtProvider : IJwtProvider
    {

        public string Sign(User user)
        {
            Claim[] claims = new Claim[] { new Claim("userId", user.Id.ToString()) };

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

        public Guid Decode(string token)
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            if (jwt == null)
                return Guid.Empty;

            var userIdClaim = jwt.Claims.FirstOrDefault(c => c.Type == "userId");

            if (userIdClaim == null)
                return Guid.Empty;

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
