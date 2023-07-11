using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries;
using BubberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {

            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
               authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
               errors => Problem(errors));

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            //var query = new LoginQuery(request.Email, request.Password);
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
