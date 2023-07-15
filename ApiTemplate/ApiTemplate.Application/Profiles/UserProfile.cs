using ApiTemplate.Application.Requests.User;
using ApiTemplate.Application.Responses.User;
using ApiTemplate.Domain.Entities;
using AutoMapper;

namespace ApiTemplate.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserAddRequest, User>()
            .ForMember(x => x.Password, opt => opt.MapFrom(x => BCrypt.Net.BCrypt.HashPassword(x.Password)));
        CreateMap<UserUpdateRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
