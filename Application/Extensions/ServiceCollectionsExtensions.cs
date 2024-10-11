using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Application.Regies;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegieService, RegieService>();

        services.AddAutoMapper(typeof(RegieProfile), typeof(BienImmobiliersProfile));
    }
}
