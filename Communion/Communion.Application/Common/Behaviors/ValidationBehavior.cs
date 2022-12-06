using Communion.Application.Authentication.Commands.SignUp;
using Communion.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace Communion.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse> // TRequest will be a request that returns a TResponse
            where TResponse : IErrorOr // TResponse will be an implementation of the IError signature
{
    // Dependency Injection
    private readonly IValidator<TRequest>? _validator;
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    // Methods:

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // calls the validator that is implemented with the type (SignUpCommand), refer to file 'SignUpCommandValidator.cs'.
        if (_validator is null)
            return await next();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
            return await next();

        var errors = validationResult.Errors
        .ConvertAll(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage));

        return (dynamic)errors;
    }
}