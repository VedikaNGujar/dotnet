using JWTApproach3.Models;
using JWTApproach3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTApproach3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NameController : ControllerBase
    {
        private ICustomAuthenticationManager customAuthenticationManager;

        public NameController(
            ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
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
            var token = customAuthenticationManager.Authenticate(userCred.UserName, userCred.Password);
            if (token is not null)
                return Ok(new { token = token });
            else
                return Unauthorized();
        }


    }
}
