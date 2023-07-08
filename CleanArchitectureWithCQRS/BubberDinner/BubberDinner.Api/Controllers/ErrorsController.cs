using BubberDinner.Application.Common;
using BubberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext?.Features?.Get<IExceptionHandlerFeature>()?.Error;

            //var (statusCode, message) = exception switch
            //{
            //    DuplicateEmailException => (StatusCodes.Status409Conflict, Constants.DuplicateEmailExists),
            //    _ => (StatusCodes.Status500InternalServerError, Constants.ErrorOccured)
            //};

            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, Constants.ErrorOccured)
            };

            //return Problem();//this will return by default 500
            return Problem(title: message, statusCode: statusCode);
        }
    }
}
