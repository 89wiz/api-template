using ApiTemplate.Application.Common;
using ApiTemplate.Application.User.Common;
using AutoMapper;

namespace ApiTemplate.Application.User.Update;

public class UserUpdateHandler : UpdateHandler<UserUpdateRequest, UserResponse, Domain.Entities.User>
{
    public UserUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
