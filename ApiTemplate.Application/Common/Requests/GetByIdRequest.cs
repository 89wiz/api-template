using MediatR;

namespace ApiTemplate.Application.Requests.Common;

public class GetByIdRequest<TResponse> : IRequest<TResponse>
{
    public Guid Id { get; init; }

    public GetByIdRequest() { }
    public GetByIdRequest(Guid id)
    {
        Id = id;
    }
}
