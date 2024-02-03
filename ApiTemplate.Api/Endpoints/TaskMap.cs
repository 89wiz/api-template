using ApiTemplate.Application.Task.Add;
using ApiTemplate.Application.Task.Common;
using ApiTemplate.Application.Task.Done;
using MediatR;
using System.Security.Claims;

namespace ApiTemplate.Api.Endpoints;

public static partial class TaskMap
{
    public static void Map(WebApplication app)
    {
        app.MapPost("user/task",
            (IMediator mediator, TaskAddRequest request, ClaimsPrincipal user)
                => mediator.Send(request.WithUser(user)).AsResult())
            .ProduceResults<TaskResponse>()
            .WithTags("User", "Task");

        app.MapPut("user/task/{id}",
            (IMediator mediator, Guid id, ClaimsPrincipal user)
                => mediator.Send(new TaskDoneRequest().WithId(id).WithUser(user)).AsResult())
            .ProduceResults<TaskResponse>()
            .WithTags("User", "Task");
    }
}
