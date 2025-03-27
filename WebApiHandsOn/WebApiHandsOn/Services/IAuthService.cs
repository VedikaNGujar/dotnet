using WebApiHandsOn.Entities;
using WebApiHandsOn.Models;

namespace WebApiHandsOn.Services
{
    public interface IAuthService
    {

        Task<User?> RegisterAsync(UserDto user);
        Task<TokenResponseDto?> LoginAsync(UserDto user);

        Task<TokenResponseDto?> ValidateRefreshToken(Guid userId, string refreshToken);
    }
}
