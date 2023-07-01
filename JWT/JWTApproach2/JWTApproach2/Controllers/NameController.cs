using JWTApproach2.Models;
using JWTApproach2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTApproach2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NameController : ControllerBase
    {
        private IJwtAuthenticationManager _jwtAuthenticationManager;
        private ITokenRefresher _tokenRefresher;

        public NameController(
            IJwtAuthenticationManager jwtAuthenticationManager,
            ITokenRefresher tokenRefresher)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _tokenRefresher = tokenRefresher;
        }

        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Maharastra", "Gujurat" };
        }

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NameController>
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCred.UserName, userCred.Password);
            if (token is not null)
                return Ok(new { token = token.JwtToken, refreshToken = token.RefreshToken });
            else
                return Unauthorized();
        }

        // POST api/<NameController>
        [HttpPost("refreshToken")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromBody] RefreshCred refreshCred)
        {
            var token = _tokenRefresher.Refresh(refreshCred);
            if (token is not null)
                return Ok(new { token = token.JwtToken, refreshToken = token.RefreshToken });
            else
                return Unauthorized();
        }


    }
}
