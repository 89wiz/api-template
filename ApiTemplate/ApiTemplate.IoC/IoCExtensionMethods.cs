using ApiTemplate.Domain.Interfaces;
using ApiTemplate.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.IoC;

public static class IoCExtensionMethods
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}