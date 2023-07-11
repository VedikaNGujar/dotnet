using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace BubberDinner.Application.Common.Behaviors
{
    public class ValidateBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidateBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator!;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                var result = await next();
                return result;
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                var result = await next();
                return result;
            }
            var errors = validationResult.Errors
                .ConvertAll(x => Error.Validation(x.PropertyName, x.ErrorMessage));
            return (dynamic)errors;
        }

    }
}
