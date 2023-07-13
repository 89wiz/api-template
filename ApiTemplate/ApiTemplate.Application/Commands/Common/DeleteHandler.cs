using ApiTemplate.Domain.Interfaces;
using ApiTemplate.Domain.Interfaces.Repositories.Common;
using ApiTemplate.Domain.Interfaces.Service.Common;
using ApiTemplate.Domain.Validation;

namespace ApiTemplate.Application.Commands.Common;

public class DeleteHandler<TEntity> : IDeleteHandler<TEntity>
    where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IService<TEntity> _service;
    private readonly IReadRepository<TEntity> _repository;
    private readonly ValidationResult _validationResult;

    public DeleteHandler(IUnitOfWork unitOfWork, IService<TEntity> service, IReadRepository<TEntity> repository)
    {
        _unitOfWork = unitOfWork;
        _service = service;
        _repository = repository;
        _validationResult = new ValidationResult();
    }

    public async Task<(DeleteResponse<GetByIdRequest>, ValidationResult)> Handle(GetByIdRequest request)
    {
        await _unitOfWork.BeginTransaction();
        var entity = await _repository.Get(request.Id);

        if (entity == null)
            return  (new DeleteResponse<GetByIdRequest> { Id = request.Id, Value = request },
                _validationResult.Add("Not Found", ValidationResult.ValidationErrorCode.NotFound));

        _validationResult.Add(await _service.Delete(entity));
        if (_validationResult.IsValid) await _unitOfWork.Commit();

        return (new DeleteResponse<GetByIdRequest> { Id = request.Id, Value = request }, _validationResult);
    }
}
