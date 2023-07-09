﻿using BubberDinner.Application.Common;
using BubberDinner.Application.Common.Errors;
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Result<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName,
                                                          request.LastName,
                                                          request.Email,
                                                          request.Password);
            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }
            else
            {
                var firstError = registerResult.Errors.First();
                if (firstError is DuplicateEmailError)
                {
                    return Problem(statusCode: StatusCodes.Status409Conflict, title: Constants.DuplicateEmailExists);
                }
            }
            return Problem();

        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                                authResult.User.Id,
                                authResult.User.FirstName,
                                authResult.User.LastName,
                                authResult.User.Email,
                                authResult.Token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email,
                                                         request.Password);
            var response = new AuthenticationResponse(
               authResult.User.Id,
               authResult.User.FirstName,
               authResult.User.LastName,
               authResult.User.Email,
               authResult.Token);

            return Ok(response);
        }
    }
}
