using ApiTemplate.Application.Requests.Common;

namespace ApiTemplate.Application.Requests.Task;

public class TaskDoneRequest : IUpdateRequest
{
    public Guid Id { get; set; }
}
