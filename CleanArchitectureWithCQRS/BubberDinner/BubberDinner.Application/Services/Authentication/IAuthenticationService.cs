using BubberDinner.Application.Common.Errors;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);
    }
}
