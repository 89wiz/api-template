namespace ApiTemplate.Application.Requests.Common;

public class GetByIdRequest
{
    public Guid Id { get; init; }

    public GetByIdRequest() { }
    public GetByIdRequest(Guid id)
    {
        Id = id;
    }
}
