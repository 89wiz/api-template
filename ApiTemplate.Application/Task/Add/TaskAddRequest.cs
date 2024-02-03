using ApiTemplate.Application.Common;
using ApiTemplate.Application.Common.Requests;
using ApiTemplate.Application.Task.Common;
using System.Security.Claims;

namespace ApiTemplate.Application.Task.Add;

public class TaskAddRequest : ICommand<TaskResponse>
{
    public Guid UserId { get; set; }
    public string Description { get; set; }

    public TaskAddRequest WithUser(ClaimsPrincipal user)
    {
        UserId = user.GetId();
        return this;
    }
}
