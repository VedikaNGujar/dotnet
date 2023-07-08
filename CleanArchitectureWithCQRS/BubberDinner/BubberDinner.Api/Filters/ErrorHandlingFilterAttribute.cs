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

            context.Result = new ObjectResult(new { error = Constants.ErrorOccured })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
