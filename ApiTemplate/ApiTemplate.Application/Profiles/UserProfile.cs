using ApiTemplate.Application.Requests.User;
using ApiTemplate.Application.Responses.User;
using ApiTemplate.Domain.Entities;
using AutoMapper;

namespace ApiTemplate.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserAddRequest, User>();
        CreateMap<UserUpdateRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
