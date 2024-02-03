using ApiTemplate.Application.Task.Add;
using ApiTemplate.Application.Task.Common;
using AutoMapper;

namespace ApiTemplate.Application.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskAddRequest, Domain.Entities.Task>();
        CreateMap<Domain.Entities.Task, TaskResponse>();
    }
}
