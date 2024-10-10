using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Application.Regies;

namespace Regies.Application.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegieService, RegieService>();
    }
}
