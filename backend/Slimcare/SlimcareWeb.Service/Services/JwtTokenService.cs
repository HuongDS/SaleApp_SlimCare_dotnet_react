using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.AppsettingsConfigurations;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettingOptions;

        public JwtTokenService(IOptions<JwtSettings> jwtSettingOptions)
        {
            _jwtSettingOptions = jwtSettingOptions.Value;
        }

        public string ComputeHash(string token, string salt)
        {
            using var h = new HMACSHA256(Convert.FromBase64String(salt));
            return Convert.ToBase64String(h.ComputeHash(Encoding.UTF8.GetBytes(token)));
        }

        public string GenerateAccessToken(User user)
        {
            var secretKey = _jwtSettingOptions.SecretKey;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _jwtSettingOptions.Issuer,
                audience: _jwtSettingOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettingOptions.ExpirationInMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public (string plain, RefreshToken entity) GenerateRefreshToken(int userId, TimeSpan lifetime)
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            var plain = Convert.ToBase64String(bytes);
            var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
            var hash = ComputeHash(plain, salt);

            return (plain, new RefreshToken
            {
                UserId = userId,
                TokenSalt = salt,
                TokenHash = hash,
                RevokeAt = DateTime.MinValue,
                ExpiresAt = DateTime.UtcNow.Add(lifetime)
            });
        }

        public bool VerifyRefreshToken(string plain, string salt, string hash)
        {
            return ComputeHash(plain, salt) == hash;
        }
    }
}
