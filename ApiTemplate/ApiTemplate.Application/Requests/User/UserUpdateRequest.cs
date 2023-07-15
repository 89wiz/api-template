using ApiTemplate.Application.Requests.Common;

namespace ApiTemplate.Application.Requests.User;

public class UserUpdateRequest : IUpdateRequest
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
