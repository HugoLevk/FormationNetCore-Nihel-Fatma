﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Domain.Repositories;
using Regies.Infrastructure.Persistence;
using Regies.Infrastructure.Repositories;
using Regies.Infrastructure.Seeders;

namespace Regies.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RegiesDB");
        services.AddDbContext<RegiesDBContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IRegieRepository, RegieRepository>();

        services.AddScoped<IRegiesSeeder, RegiesSeeder>();
    }
}
