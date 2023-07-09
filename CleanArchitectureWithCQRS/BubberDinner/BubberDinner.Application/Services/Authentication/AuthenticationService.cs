using BubberDinner.Application.Common.Errors;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // validate if user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("Invalid credentials.");
            }

            // validate password
            if (user.Password != password)
            {
                throw new Exception("Invalid credentials.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password)
        {
            //validate if user doesnot exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return new DuplicateEmailError();
            }
            //create new user and persist to database
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            //create a new token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);

        }
    }
}
