using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using BubberDinner.Application.Authentication.Common;

namespace BubberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    //this is taking RegisterCommand as input
    //and ErrorOr<AuthenticationResult> as output
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;


        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }


        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //validate if user doesnot exists
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            //create new user and persist to database
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
            _userRepository.Add(user);

            //create a new token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
