using ApiTemplate.Application.User.Add;
using ApiTemplate.Application.User.Common;
using ApiTemplate.Application.User.Update;
using AutoMapper;

namespace ApiTemplate.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserAddRequest, Domain.Entities.User>()
            .ForMember(x => x.Password, opt => opt.MapFrom(x => BCrypt.Net.BCrypt.HashPassword(x.Password)));
        CreateMap<UserUpdateRequest, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, UserResponse>();
    }
}
