using System.Security.Cryptography;

namespace JWTApproach2.Services
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public string GenerateToken()
        {
            var randomNumber = new byte[32];
            using (var randomnumberGenerator = RandomNumberGenerator.Create())
            {
                randomnumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

        }
    }
}
