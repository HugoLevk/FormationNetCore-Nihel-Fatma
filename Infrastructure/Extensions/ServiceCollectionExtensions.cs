using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regies.Infrastructure.Persistence;

namespace Regies.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = "Server=(localdb)\\mssqllocaldb;Database=RegiesDb;Trusted_Connection=True;";

        services.AddDbContext<RegiesDBContext>(options => options.UseSqlServer(connectionString));
    }
}
