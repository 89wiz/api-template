using ApiTemplate.Domain.Entities.Common;

namespace ApiTemplate.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }

    public virtual ICollection<Task> Tasks { get; set;}
}