using ApiTemplate.Application.Requests.Common;
using ApiTemplate.Application.Responses.Common;
using ApiTemplate.Domain.Validation;
using OneOf;

namespace ApiTemplate.Application.Commands.Common;

public interface ICommandHandler<TRequest, TResponse> where TRequest : class
{
    Task<OneOf<TResponse, ValidationResult>> Handle(TRequest request);
}

public interface ICommandHandler<TRequest> where TRequest : class
{
    Task<ValidationResult> Handle(TRequest request);
}

public interface IAddHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest : class { }
public interface IDeleteHandler<TEntity> : ICommandHandler<GetByIdRequest, DeleteResponse<GetByIdRequest>> { }
public interface IUpdateHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse> where TRequest : class, IUpdateRequest { }