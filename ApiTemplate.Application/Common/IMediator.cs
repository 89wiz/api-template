using ApiTemplate.Application.Responses.Common;
using ApiTemplate.Domain.Validation;
using MediatR;
using OneOf;

namespace ApiTemplate.Application.Common;

public interface ICommand<TResponse> : IRequest<OneOf<TResponse, ValidationResult>> where TResponse : class, new() { }
public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class, new() { }
public interface IUpdateCommand<TResponse> : ICommand<TResponse>
    where TResponse : class, new()
{
    public Guid Id { get; set; }
}
public interface IDeleteCommand : ICommand<DeleteResponse>
{
    public Guid Id { get; set; }
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, OneOf<TResponse, ValidationResult>>
    where TCommand : ICommand<TResponse>
    where TResponse : class, new()
{ }