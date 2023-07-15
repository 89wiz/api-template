using ApiTemplate.Application.Requests.Common;

namespace ApiTemplate.Application.Responses.Common;

public class PagedResponse<T> where T : class
{
    public IQueryable<T> Data { get; set; }
    public int Rows { get; set; }

    public PagedResponse(IQueryable<T> data, GetPagedRequest request)
    {
        Rows = data.Count();
        Data = data
            .Skip(request.Skip)
            .Take(request.Take);
    }
}
