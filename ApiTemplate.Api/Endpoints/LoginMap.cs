using ApiTemplate.Application.User.Common;
using ApiTemplate.Application.User.Login;
using MediatR;

namespace ApiTemplate.Api.Endpoints;

public static partial class LoginMap
{
    public static void Map(WebApplication app)
    {
        app.MapPost("login",
            (IMediator mediator, LoginRequest request)
                => mediator.Send(request).AsResult())
            .ProduceResults<UserResponse>()
            .AllowAnonymous();
    }
}