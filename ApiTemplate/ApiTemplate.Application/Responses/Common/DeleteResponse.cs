namespace ApiTemplate.Application.Responses.Common;

public class DeleteResponse<T>
    where T : class
{
    public int Id { get; set; }
    public T Value { get; set; }
}