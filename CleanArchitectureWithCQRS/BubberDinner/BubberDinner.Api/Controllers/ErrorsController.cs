using BubberDinner.Api.Helper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BubberDinner.Api.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext?.Features?.Get<IExceptionHandlerFeature>()?.Error;
            //return Problem();//this will return by default 500
            return Problem(title: exception?.Message);
        }
    }
}
