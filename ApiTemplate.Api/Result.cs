using ApiTemplate.Domain.Validation;
using OneOf;
using System.Net;
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

    internal static IResult AsResult<T>(this OneOf<T, ValidationResult> result)
    {
        return result.Match(
            success => Results.Ok(success),
            validationResult => validationResult.AsResult());
    }

    internal static async Task<IResult> AsResult<T>(this Task<OneOf<T, ValidationResult>> task)
    {
        return (await task).AsResult();
    }

    internal static RouteHandlerBuilder ProduceResults<T>(this RouteHandlerBuilder builder, params HttpStatusCode[] codes)
    {
        builder.Produces<T>((int)HttpStatusCode.OK);

        foreach(var code in codes)
        {
            builder.Produces<ValidationResult>((int)code);
        }

        return builder;
    }
}