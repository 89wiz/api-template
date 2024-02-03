using ApiTemplate.Application.Common;
using ApiTemplate.Application.User.Common;

namespace ApiTemplate.Application.User.Add;

public class UserAddRequest : ICommand<UserResponse>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
