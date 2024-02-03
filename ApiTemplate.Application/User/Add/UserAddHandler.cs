using ApiTemplate.Application._Common.Handlers;
using ApiTemplate.Application.Common;
using ApiTemplate.Application.User.Common;
using AutoMapper;

namespace ApiTemplate.Application.User.Add;

public class UserAddHandler : AddHandler<UserAddRequest, UserResponse, Domain.Entities.User>, ICommandHandler<UserAddRequest, UserResponse>
{
    public UserAddHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
