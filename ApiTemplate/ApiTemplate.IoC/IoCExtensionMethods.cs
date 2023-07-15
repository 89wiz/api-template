using ApiTemplate.Application.Commands.Common;
using ApiTemplate.Application.Commands.Login;
using ApiTemplate.Application.Common;
using ApiTemplate.Application.Requests.Login;
using ApiTemplate.Application.Responses.Login;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.IoC;

public static class IoCExtensionMethods
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped(typeof(IAddHandler<,,>), typeof(AddHandler<,,>));
        services.AddScoped(typeof(IDeleteHandler<>), typeof(DeleteHandler<>));
        services.AddScoped(typeof(IUpdateHandler<,,>), typeof(UpdateHandler<,,>));
        services.AddScoped<ICommandHandler<LoginRequest, LoginResponse>, LoginHandler>();
    }
}