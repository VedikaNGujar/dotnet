using BubberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Authentication.Queries
{
    public record LoginQuery(
        string Email,
        string Password
        ) : IRequest<ErrorOr<AuthenticationResult>>;
}
