using AnyOfTypes;
using ApiTemplate.Domain.Interfaces;
using ApiTemplate.Domain.Interfaces.Service.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Application.Commands.Common;

public class AddHandler<TRequest, TResponse, TEntity> : IAddHandler<TRequest, TResponse, TEntity>
    where TRequest : class
    where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IService<TEntity> _service;
    private readonly ValidationResult _validationResult;

    public AddHandler(IUnitOfWork unitOfWork, IMapper mapper, IService<TEntity> service)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _service = service;
        _validationResult = new ValidationResult();
    }

    public async Task<AnyOf<TResponse, ValidationResult>> Handle(TRequest request)
    {
        await _unitOfWork.BeginTransaction();

        var entity = _mapper.Map<TEntity>(request);
        _validationResult.Add(await _service.Add(entity));

        if (!_validationResult.IsValid)
        {
            await _unitOfWork.Rollback();
            return _validationResult;
        }
        await _unitOfWork.Commit();
        return _mapper.Map<TResponse>(entity);
    }
}
