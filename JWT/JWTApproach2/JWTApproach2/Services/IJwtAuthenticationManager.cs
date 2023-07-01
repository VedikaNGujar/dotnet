using JWTApproach2.Models;

namespace JWTApproach2.Services
{
    public interface IJwtAuthenticationManager
    {
        public AuthenticationResponse Authenticate(string username, string password);
        public AuthenticationResponse GenerateToken(string username);
        public  Dictionary<string, string> usersRefreshToken { get; }
    }
}
