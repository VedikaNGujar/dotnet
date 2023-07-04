using JWTApproach4.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JWTApproach4.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public JwtTokenGenerator(IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name,user.Username)
            };

            claims.AddRange(user.Roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(1));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public RefreshToken CreateRefreshToken(ref UserLogin user)
        {
            var refreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(63)),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(7)
            };
            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpired = refreshToken.Expires;
            return refreshToken;
        }


        public void SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };

            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        }
    }
}
