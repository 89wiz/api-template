using ApiTemplate.Application.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;
using OneOf;

namespace ApiTemplate.Application.Commands.Common;

public class AddHandler<TRequest, TResponse, TEntity> : IAddHandler<TRequest, TResponse, TEntity>
    where TRequest : class
    where TEntity : class
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

    public async Task<OneOf<TResponse, ValidationResult>> Handle(TRequest request)
    {
        await _unitOfWork.BeginTransaction();

        var entity = _mapper.Map<TEntity>(request);
        await _unitOfWork.DbSet<TEntity>().AddAsync(entity);

        if (!_validationResult.IsValid)
        {
            await _unitOfWork.Rollback();
            return _validationResult;
        }
        await _unitOfWork.Commit();
        return _mapper.Map<TResponse>(entity);
    }
}
