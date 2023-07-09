using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            var firstError = errors.First();
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
