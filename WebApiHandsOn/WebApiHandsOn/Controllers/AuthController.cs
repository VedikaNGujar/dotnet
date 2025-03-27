using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiHandsOn.Entities;
using WebApiHandsOn.Models;
using WebApiHandsOn.Services;

namespace WebApiHandsOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new();
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.RegisterAsync(request);
            if (user is null)
            {
                return Ok("Username already exists");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {

            var result = await _authService.LoginAsync(request);
            if (result is null)
            {
                return BadRequest("User or Password is incorrect");
            }
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {

            var result = await _authService.ValidateRefreshToken(request.userId, request.refreshToken);
            if (result is null)
            {
                return Forbid();
            }
            return Ok(result);
        }

        [HttpGet("checkEndpoint")]
        [Authorize]
        public string AuthenticatedEndpointOnly()
        {
            return "Hey you here";
        }

        [HttpGet("checkEndpointForAdmin")]
        [Authorize(Roles = "Admin")]
        public string AuthenticatedAdminEndpointOnly()
        {
            return "Hey you here!! Admin";
        }


    }
}
