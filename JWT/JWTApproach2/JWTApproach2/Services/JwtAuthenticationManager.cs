using JWTApproach2.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTApproach2.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private IConfiguration configuration;
        private IRefreshTokenGenerator refreshTokenGenerator;

        public JwtAuthenticationManager(
            IConfiguration configuration,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            this.configuration = configuration;
            this.refreshTokenGenerator = refreshTokenGenerator;
        }

        private readonly Dictionary<string, string> users = new()
        {
            {"Vedika","Vedika@123" },
            {"Nidhi","Nidhi@123" }
        };

        public Dictionary<string, string> usersRefreshToken { get; set; } = new Dictionary<string, string>();


        public AuthenticationResponse Authenticate(string username, string password)
        {
            if (!users.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }
            return GenerateToken(username);
        }

        public AuthenticationResponse GenerateToken(string username)
        {

            var tokenKey = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var securityKey = new SymmetricSecurityKey(tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                {
                    new Claim(type: ClaimTypes.Name,value : username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = refreshTokenGenerator.GenerateToken();
            //if (!usersRefreshToken.ContainsKey(username))
            //{
            //    usersRefreshToken.Add(username, refreshToken);
            //}
            //else
            //{
                usersRefreshToken[username] = refreshToken;
            //}
            return new AuthenticationResponse
            {
                JwtToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken
            };
        }
    }
}
