using ApiTemplate.Domain.Validation;
using static ApiTemplate.Domain.Validation.ValidationResult;

namespace ApiTemplate.Application.Extensions;

internal static class ValidationResultExtensions
{
    internal static void AddFluentResult(this ValidationResult validationResult, FluentValidation.Results.ValidationResult fluentValidationResult)
    {
        if (validationResult.IsValid) return;

        validationResult.ErrorCode = ValidationErrorCode.InvalidEntity;
        validationResult.Errors.AddRange(fluentValidationResult.Errors.Select(e => new ValidationError($"{e.PropertyName}: {e.ErrorMessage}")));
    }
}
