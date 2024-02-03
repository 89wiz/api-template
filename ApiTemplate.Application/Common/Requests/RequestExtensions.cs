using System.Security.Claims;

namespace ApiTemplate.Application.Common.Requests;

public static class RequestExtensions
{
    public static Guid GetId(this ClaimsPrincipal user)
    {
        var player = (user.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Sid);
        return !string.IsNullOrEmpty(player?.Value) ? Guid.Parse(player.Value) : new();
    }
}
