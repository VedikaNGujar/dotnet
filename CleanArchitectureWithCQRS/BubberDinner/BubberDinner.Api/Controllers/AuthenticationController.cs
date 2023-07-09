using BubberDinner.Application.Services.Authentication;
using BubberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(request.FirstName,
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
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(request.Email,
                                                         request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }
    }
}
