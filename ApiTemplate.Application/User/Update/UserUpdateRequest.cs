using ApiTemplate.Application.Common;
using ApiTemplate.Application.User.Common;

namespace ApiTemplate.Application.User.Update;

public class UserUpdateRequest : IUpdateCommand<UserResponse>
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
