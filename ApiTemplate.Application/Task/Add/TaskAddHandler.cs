using ApiTemplate.Application.Common;
using ApiTemplate.Application.Task.Common;
using ApiTemplate.Domain.Entities.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;
using OneOf;

namespace ApiTemplate.Application.Task.Add;

public class TaskAddHandler : ICommandHandler<TaskAddRequest, TaskResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ValidationResult _validationResult;

    public TaskAddHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validationResult = new();
    }

    public async Task<OneOf<TaskResponse, ValidationResult>> Handle(TaskAddRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransaction(cancellationToken);

        var entity = _mapper.Map<Domain.Entities.Task>(request);
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.UtcNow;
        await _unitOfWork.DbSet<Domain.Entities.Task>().AddAsync(entity, cancellationToken);

        if (!_validationResult.IsValid)
        {
            await _unitOfWork.Rollback(cancellationToken);
            return _validationResult;
        }
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<TaskResponse>(entity);
    }
}
