using ApiTemplate.Domain.Entities.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;
using OneOf;

namespace ApiTemplate.Application.Common;

public abstract class UpdateHandler<TRequest, TResponse, TEntity> : ICommandHandler<TRequest, TResponse>
    where TRequest : IUpdateCommand<TResponse>
    where TResponse : class, new()
    where TEntity : class, IEntity, new()
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ValidationResult _validationResult;

    public UpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validationResult = new ValidationResult();
    }

    public async Task<OneOf<TResponse, ValidationResult>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransaction();
        var dbSet = _unitOfWork.DbSet<TEntity>();
        var entity = await dbSet.FindAsync(request.Id);

        if (entity == null)
            return _validationResult.Add("Not Found", ValidationResult.ValidationErrorCode.NotFound);

        _mapper.Map(request, entity);
        dbSet.Update(entity);

        if (_validationResult.IsValid) await _unitOfWork.Commit();

        return _mapper.Map<TResponse>(entity);
    }
}
