using BubberDinner.Application.Services.Authentication.Commands;
using BubberDinner.Application.Services.Authentication.Common;
using BubberDinner.Application.Services.Authentication.Queries;
using BubberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(
            IAuthenticationCommandService authenticationService,
            IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(request.FirstName,
                                                          request.LastName,
                                                          request.Email,
                                                          request.Password);

            return authResult.Match(
               authResult => Ok(MapAuthResult(authResult)),
               errors => Problem(errors));

        }

        private AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
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
            ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(request.Email,
                                                         request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }
    }
}
