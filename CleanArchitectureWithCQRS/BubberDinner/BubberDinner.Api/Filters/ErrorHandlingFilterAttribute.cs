using BubberDinner.Api.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BubberDinner.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails()
            {
                Title = Constants.ErrorOccured,
                Detail = exception.Message,
                Status = (int)HttpStatusCode.InternalServerError,
            };


            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
