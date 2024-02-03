namespace ApiTemplate.Application.Task.Common;

public class TaskResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DoneAt { get; set; }
}
