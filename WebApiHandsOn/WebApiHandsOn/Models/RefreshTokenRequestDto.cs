namespace WebApiHandsOn.Models
{
    public class RefreshTokenRequestDto
    {
        public required Guid userId { get; set; }
        public required string refreshToken { get; set; }

    }
}
