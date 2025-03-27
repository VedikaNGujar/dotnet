using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiHandsOn.Data;
using WebApiHandsOn.Entities;
using WebApiHandsOn.Models;

namespace WebApiHandsOn.Services
{
    public class AuthService(WebApiHandsOnDbContext context, IConfiguration configuration)
        : IAuthService
    {

        public async Task<TokenResponseDto?> LoginAsync(UserDto userDto)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(userDto.UserName.ToLower()));

            if (user == null)
            {
                return null;
            }
            else
            {
                if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password)
                    == PasswordVerificationResult.Failed)
                {
                    return null;
                }

                return await GenerateRefreshAndAccessToken(user);
            }
        }

        public async Task<TokenResponseDto?> ValidateRefreshToken(Guid userId, string refreshToken)
        {
            var user = await context.Users.FindAsync(userId);
            if (user == null
                || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null;
            }
            return await GenerateRefreshAndAccessToken(user);
        }

        private async Task<TokenResponseDto> GenerateRefreshAndAccessToken(User user)
        {
            return new()
            {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user)
            };
        }

        private string CreateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }

        public async Task<User?> RegisterAsync(UserDto userDto)
        {

            if (context.Users.Any(u => u.UserName.ToLower().Equals(userDto.UserName.ToLower())))
            {
                return null;
            }

            User user = new();
            var passwordHash = new PasswordHasher<User>().HashPassword(user, userDto.Password);

            user.UserName = userDto.UserName;
            user.PasswordHash = passwordHash;
            user.Role = userDto.Role;

            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        private async Task<string> GenerateAndSaveRefreshTokenAsync(User user)
        {
            user.RefreshToken = GenerateRefreshToken(user);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await context.SaveChangesAsync();
            return user.RefreshToken;
        }

        private string GenerateRefreshToken(User user)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }


    }
}
