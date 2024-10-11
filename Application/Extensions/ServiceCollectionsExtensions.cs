using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Application.Regies;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        System.Reflection.Assembly assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddScoped<IRegieService, RegieService>();

        services.AddAutoMapper(assembly);

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();
    }
}
