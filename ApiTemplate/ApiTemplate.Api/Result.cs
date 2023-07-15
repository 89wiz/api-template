using ApiTemplate.Domain.Validation;
using static ApiTemplate.Domain.Validation.ValidationResult;

public static class ValidationResultExtensions
{
    internal static IResult AsResult(this ValidationResult validationResult)
    {
        if (validationResult.IsValid) return Results.Ok();
        return validationResult.ErrorCode switch
        {
            ValidationErrorCode.InvalidEntity => Results.UnprocessableEntity(validationResult),
            ValidationErrorCode.Conflict => Results.Conflict(validationResult),
            ValidationErrorCode.NotAllowed => Results.Unauthorized(),
            ValidationErrorCode.NotFound => Results.NotFound(validationResult),
            _ => Results.BadRequest(validationResult)
        };
    }
}