using ApiTemplate.Domain.Validation;
using FluentValidation;
using MediatR;
using OneOf;

namespace ApiTemplate.Application.Common.Validator;

public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, OneOf<TResponse, ValidationResult>>
    where TRequest : IRequest<OneOf<TResponse, ValidationResult>>
{
    private readonly IValidator<TRequest> _validator;

    public ValidatorPipelineBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<OneOf<TResponse, ValidationResult>> Handle(TRequest request, RequestHandlerDelegate<OneOf<TResponse, ValidationResult>> next, CancellationToken cancellationToken)
    {
        var validationResult = new ValidationResult().AddFluentResult(_validator.Validate(request));

        if (!validationResult.IsValid)
            return validationResult;

        return await next();
    }
}
