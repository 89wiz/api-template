using ApiTemplate.Application.Common;
using ApiTemplate.Application.Requests.Common;
using ApiTemplate.Application.User.Common;
using AutoMapper;
using MediatR;

namespace ApiTemplate.Application.User.GetById;

public class UserGetByIdHandler : IRequestHandler<GetByIdRequest<UserResponse>, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserGetByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetByIdRequest<UserResponse> request, CancellationToken cancellationToken)
    {
        return _mapper.Map<UserResponse>(await _unitOfWork.DbSet<Domain.Entities.User>().FindAsync(request.Id, cancellationToken));
    }
}