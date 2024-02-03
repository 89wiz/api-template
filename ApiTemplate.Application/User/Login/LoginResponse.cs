namespace ApiTemplate.Application.User.Login;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}
