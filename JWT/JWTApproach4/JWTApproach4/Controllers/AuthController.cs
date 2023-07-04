using JWTApproach4.Models;
using JWTApproach4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Enconding = System.Text.Encoding;

namespace JWTApproach4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        public static UserLogin userLogin = new UserLogin();
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserService userService;

        public AuthController(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserService userService)
        {
            this._jwtTokenGenerator = jwtTokenGenerator;
            this.userService = userService;
        }


        [HttpGet("getMe"), Authorize]
        public ActionResult<string> GetMe()
        {
            var AllRoles = User.FindAll(ClaimTypes.Role);
            return Ok(new
            {
                Name = User.Identity?.Name,
                Name1 = User.FindFirstValue(ClaimTypes.Name),
                Role = User.FindFirstValue(ClaimTypes.Role),
                AllRoles = AllRoles.Select(x => x.Value).ToList(),
                NameUsingHttpContextAccessor = userService.GetMyName()
            });
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(UserRegisterDTO request)
        {
            CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            user.Username = request.Username;
            user.Roles = request.Roles;
            return Ok(user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLogin>> Login(UserLoginDTO request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found");
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }
            userLogin.Username = user.Username;
            userLogin.PasswordHash = user.PasswordHash;
            userLogin.PasswordSalt = user.PasswordSalt;
            userLogin.Roles = user.Roles;

            var token = _jwtTokenGenerator.CreateToken(user);
            userLogin.JwtToken = token;
            var refreshToken = _jwtTokenGenerator.CreateRefreshToken(ref userLogin);
            _jwtTokenGenerator.SetRefreshToken(refreshToken);

            return Ok(new
            {
                user = userLogin
            });
        }

        [HttpGet("getRefreshToken"), Authorize]
        public async Task<ActionResult<UserLogin>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (refreshToken != userLogin.RefreshToken)
            {
                return Unauthorized("Invalid Refresh Token");
            }
            if (userLogin.TokenExpired < DateTime.Now)
            {
                return Unauthorized("Token expired");
            }

            var token = _jwtTokenGenerator.CreateToken(user);
            userLogin.JwtToken = token;
            var refreshTokenObj = _jwtTokenGenerator.CreateRefreshToken(ref userLogin);
            _jwtTokenGenerator.SetRefreshToken(refreshTokenObj);
            return Ok(new
            {
                user = userLogin
            });
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Enconding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Enconding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


    }
}
