using ApiTemplate.Domain.Entities.Common;
using ApiTemplate.Domain.Interfaces;
using ApiTemplate.Domain.Interfaces.Repositories.Common;
using ApiTemplate.Domain.Interfaces.Service.Common;
using ApiTemplate.Domain.Validation;
using AutoMapper;

namespace ApiTemplate.Application.Commands.Common
{

    public class UpdateHandler<TRequest, TResponse, TEntity> : IUpdateHandler<TRequest, TResponse, TEntity>
        where TRequest : class, IUpdateRequest
        where TEntity : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IService<TEntity> _service;
        private readonly IReadRepository<TEntity> _repository;
        private readonly ValidationResult _validationResult;

        public UpdateHandler(IUnitOfWork unitOfWork, IMapper mapper, IService<TEntity> service, IReadRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
            _repository = repository;
            _validationResult = new ValidationResult();
        }

        public async Task<(TResponse, ValidationResult)> Handle(TRequest request)
        {
            await _unitOfWork.BeginTransaction();
            var entity = await _repository.Get(request.Id);

            if (entity == null)
                return (_mapper.Map<TResponse>(request), _validationResult.Add("Not Found", ValidationResult.ValidationErrorCode.NotFound));

            entity = _mapper.Map(request, entity);
            _validationResult.Add(await _service.Update(entity));
            if (_validationResult.IsValid) await _unitOfWork.Commit();

            return (_mapper.Map<TResponse>(entity), _validationResult);
        }
    }
}
