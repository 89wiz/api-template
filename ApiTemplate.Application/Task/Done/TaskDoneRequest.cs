using ApiTemplate.Application.Common;
using ApiTemplate.Application.Common.Requests;
using ApiTemplate.Application.Task.Common;
using System.Security.Claims;

namespace ApiTemplate.Application.Task.Done;

public class TaskDoneRequest : ICommand<TaskResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public TaskDoneRequest WithId(Guid id)
    {
        Id = id;
        return this;
    }

    public TaskDoneRequest WithUser(ClaimsPrincipal user)
    {
        UserId = user.GetId();
        return this;
    }

}
