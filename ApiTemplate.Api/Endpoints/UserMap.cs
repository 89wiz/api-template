using ApiTemplate.Application.Commands.Common;
using ApiTemplate.Application.Requests.User;
using ApiTemplate.Application.Responses.User;
using ApiTemplate.Domain.Entities;

namespace ApiTemplate.Api.Endpoints;

public static partial class UserMap
{
    public static void Map(WebApplication app)
    {
        app.MapPost("user",
            async (IAddHandler<UserAddRequest, UserResponse, User> handler, UserAddRequest request) =>
            {
                var result = await handler.Handle(request);
                return result.Match(
                    success => Results.Ok(success),
                    validationResult => validationResult.AsResult());

            })
            .Produces<UserResponse>(StatusCodes.Status200OK)
            .AllowAnonymous();

        app.MapPut("user",
            async (IUpdateHandler<UserUpdateRequest, UserResponse, User> handler, UserUpdateRequest request) =>
            {
                var result = await handler.Handle(request);
                return result.Match(
                    success => Results.Ok(success),
                    validationResult => validationResult.AsResult());

            })
            .Produces<UserResponse>(StatusCodes.Status200OK);
    }
}
