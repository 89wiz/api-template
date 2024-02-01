using ApiTemplate.Application.Commands.Common;
using ApiTemplate.Application.Requests.Login;
using ApiTemplate.Application.Responses.Login;
using ApiTemplate.Application.Responses.User;

namespace ApiTemplate.Api.Endpoints;

public static partial class LoginMap
{
    public static void Map(WebApplication app)
    {
        app.MapPost("login",
            async (ICommandHandler<LoginRequest, LoginResponse> handler, LoginRequest request) =>
            {
                var result = await handler.Handle(request);
                return result.Match(
                    success => Results.Ok(success),
                    validationResult => validationResult.AsResult());

            })
            .Produces<UserResponse>(StatusCodes.Status200OK)
            .AllowAnonymous();
    }
}
