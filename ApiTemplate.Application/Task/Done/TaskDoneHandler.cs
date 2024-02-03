using ApiTemplate.Application.Common;
using ApiTemplate.Application.Task.Common;
using ApiTemplate.Domain.Entities.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OneOf;
using System.Linq.Dynamic.Core;

namespace ApiTemplate.Application.Task.Done;

public class TaskDoneHandler : ICommandHandler<TaskDoneRequest, TaskResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ValidationResult _validationResult;

    public TaskDoneHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validationResult = new ValidationResult();
    }

    public async Task<OneOf<TaskResponse, ValidationResult>> Handle(TaskDoneRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransaction();
        var dbSet = _unitOfWork.DbSet<Domain.Entities.Task>();
        var entity = await dbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity is null)
            return _validationResult.Add("Not Found", ValidationResult.ValidationErrorCode.NotFound);

        if (!entity.UserId.Equals(request.UserId))
            return _validationResult.Add("Conflict", ValidationResult.ValidationErrorCode.Conflict);

        entity.DoneAt = DateTime.UtcNow;
        dbSet.Update(entity);

        if (_validationResult.IsValid) await _unitOfWork.Commit();

        return _mapper.Map<TaskResponse>(entity);
    }
}
