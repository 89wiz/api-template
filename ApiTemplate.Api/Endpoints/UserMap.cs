using ApiTemplate.Application.Requests.Common;
using ApiTemplate.Application.User.Add;
using ApiTemplate.Application.User.Common;
using ApiTemplate.Application.User.Update;
using MediatR;

namespace ApiTemplate.Api.Endpoints;

public static partial class UserMap
{
    public static void Map(WebApplication app)
    {
        app.MapGet("user/{id}",
            (IMediator mediator, Guid id)
                => mediator.Send(new GetByIdRequest<UserResponse>(id)))
            .ProduceResults<UserResponse>();

        app.MapPost("user",
            (IMediator mediator, UserAddRequest request)
                => mediator.Send(request).AsResult())
            .ProduceResults<UserResponse>()
            .AllowAnonymous();

        app.MapPut("user",
            (IMediator mediator, UserUpdateRequest request)
                => mediator.Send(request).AsResult())
            .ProduceResults<UserResponse>();
    }
}