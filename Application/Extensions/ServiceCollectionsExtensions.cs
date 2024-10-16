using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Application.Regies;
using Regies.Application.Regies.DTOs;
using Regies.Application.User;

namespace Regies.Application.Extensions;

/// <summary>
/// Provides extension methods for configuring application services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the necessary application services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        System.Reflection.Assembly assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddAutoMapper(assembly);

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();

        services.AddScoped<IUserContext, UserContext>();
    }
}
