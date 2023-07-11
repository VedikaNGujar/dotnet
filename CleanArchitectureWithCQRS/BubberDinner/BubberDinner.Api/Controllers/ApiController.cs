﻿using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BubberDinner.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {

            if (errors.Count is 0) return Problem();

            if (errors.All(x => x.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            var firstError = errors.First();
            return Problem(errors);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            errors.ForEach(x => modelStateDictionary.AddModelError(x.Code, x.Description));

            return ValidationProblem(modelStateDictionary);
        }
    }
}
