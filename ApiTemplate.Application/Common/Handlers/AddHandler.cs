using ApiTemplate.Application.Common;
using ApiTemplate.Domain.Entities.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;
using OneOf;

namespace ApiTemplate.Application._Common.Handlers;

public abstract class AddHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    where TResponse : class, new()
    where TEntity : class, IEntity, new()
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ValidationResult _validationResult;

    public AddHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validationResult = new ValidationResult();
    }

    public virtual async Task<OneOf<TResponse, ValidationResult>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransaction(cancellationToken);

        var entity = _mapper.Map<TEntity>(request);
        entity.Id = Guid.NewGuid();
        await _unitOfWork.DbSet<TEntity>().AddAsync(entity, cancellationToken);

        if (!_validationResult.IsValid)
        {
            await _unitOfWork.Rollback(cancellationToken);
            return _validationResult;
        }
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<TResponse>(entity);
    }
}
