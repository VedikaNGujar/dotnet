﻿using BubberDinner.Application.Common;
using System.Net;
using System.Text.Json;

namespace BubberDinner.Api.Middlewear
{
    public class ErrorHandlingMiddlewear
    {

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddlewear(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = Constants.ErrorOccured });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
