using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Domain.Repositories;
using Regies.Infrastructure.Persistence;
using Regies.Infrastructure.Repositories;
using Regies.Infrastructure.Seeders;
using Regies.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Regies.Infrastructure.Authorization;

namespace Regies.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RegiesDB");
        services.AddDbContext<RegiesDBContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<RegiesUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<RegiesDBContext>();

        services.AddScoped<IRegieRepository, RegieRepository>();
        services.AddScoped<IBienImmoRepository, BienImmoRepository>();

        services.AddScoped<IRegiesSeeder, RegiesSeeder>();
    }
}
