using ApiTemplate.Application.Common;
using ApiTemplate.Application.Common.Validator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.IoC;

public static class IoCExtensionMethods
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));

        services.AddScoped(typeof(IValidator<>), typeof(DummyValidator<>));
    }
}