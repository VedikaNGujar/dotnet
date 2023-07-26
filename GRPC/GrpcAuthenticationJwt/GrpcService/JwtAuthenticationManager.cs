using Google.Protobuf.WellKnownTypes;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GrpcService
{
    public static class JwtAuthenticationManager
    {
        public const string JWT_TOKEN_KEY = "CodingDroplets1233CodingDroplets1233CodingDroplets1233@1234";
        private const int JWT_TOKEN_VALIDITY = 30;

        public static AuthenticationResponse? Authenticate(AuthenticationRequest request)
        {
            string userRole = string.Empty;
            try
            {
                if (request.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase)
                    && request.Password.Equals("password", StringComparison.OrdinalIgnoreCase))
                {
                    userRole = "Admin";
                }
                else if (request.UserName.Equals("user", StringComparison.OrdinalIgnoreCase)
                   && request.Password.Equals("password", StringComparison.OrdinalIgnoreCase))
                {
                    userRole = "User";
                }
                else if (request.UserName != "admin" || request.Password != "password")
                {
                    return null;
                }

                var tokenKey = Encoding.ASCII.GetBytes(JWT_TOKEN_KEY);
                var tokenExpirationDate = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY);
                var securityTokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new List<Claim>
                    {
                       new Claim(ClaimTypes.Name, request.UserName),
                       new Claim(ClaimTypes.Role, userRole)
                    }),
                    Expires = tokenExpirationDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                };

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                return new AuthenticationResponse
                {
                    JwtToken = jwtSecurityTokenHandler.WriteToken(securityToken),
                    ExpiresIn = (int)tokenExpirationDate.Subtract(DateTime.Now).TotalMilliseconds
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
