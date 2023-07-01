using JWTApproach2.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTApproach2.Services
{
    public class TokenRefresher : ITokenRefresher
    {
        private IConfiguration _configuration;
        private IJwtAuthenticationManager _jwtAuthenticationManager;
        public TokenRefresher(IConfiguration configuration, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _configuration = configuration;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }


        public AuthenticationResponse Refresh(RefreshCred refreshCred)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(refreshCred.JwtToken, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;
            if (jwtToken is null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                throw new SecurityTokenException("Invalid Token Passed!");
            }

            var userName = principal.Identity.Name;
            if (refreshCred.RefreshToken != _jwtAuthenticationManager.usersRefreshToken[userName])
            {
                throw new SecurityTokenException("Invalid RefreshToken!");
            }

            return _jwtAuthenticationManager.GenerateToken(userName);
        }

    }
}
