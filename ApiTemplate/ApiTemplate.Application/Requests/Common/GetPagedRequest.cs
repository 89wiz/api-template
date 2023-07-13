using System.Security.Claims;

namespace ApiTemplate.Application.Requests.Common;

public class GetPagedRequest
{
    public int Skip { get; set; }
    public int Take { get; set; }
    public string OrderBy { get; set; }
    public bool Descending { get; set; } = false;
    public int UsuarioId { get; set; }
    public int EmpresaId { get; set; }

    public GetPagedRequest(int skip, int take, string orderBy, bool descending)
    {
        Skip = skip;
        Take = take;
        OrderBy = orderBy;
        Descending = descending;
    }

    public GetPagedRequest(ClaimsPrincipal user, int skip, int take, string orderBy, bool descending) : this(skip, take, orderBy, descending)
    {
        var identity = user.Identity as ClaimsIdentity;
        var usuarioId = identity.FindFirst(ClaimTypes.NameIdentifier);
        var empresaId = identity.FindFirst("IdEmpresa");
        UsuarioId = !string.IsNullOrEmpty(usuarioId?.Value) ? int.Parse(usuarioId.Value) : 0;
        EmpresaId = !string.IsNullOrEmpty(empresaId?.Value) ? int.Parse(empresaId.Value) : 0;
    }
}
