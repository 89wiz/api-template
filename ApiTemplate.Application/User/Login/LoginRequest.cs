using ApiTemplate.Application.Common;

namespace ApiTemplate.Application.User.Login;

public class LoginRequest : ICommand<LoginResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
