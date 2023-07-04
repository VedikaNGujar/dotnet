using JWTApproach4.Models;

namespace JWTApproach4.Services
{
    public interface IJwtTokenGenerator
    {
        RefreshToken CreateRefreshToken(ref UserLogin user);
        public string CreateToken(User user);
        void SetRefreshToken(RefreshToken refreshToken);
    }
}
