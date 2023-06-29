using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTApproach1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [Route("GetData")]
        public string GetData()
        {
            return "Hello I am Authorised";
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetData1")]
        public string GetData1()
        {
            return "Hello I am Anonymous";
        }
    }
}
