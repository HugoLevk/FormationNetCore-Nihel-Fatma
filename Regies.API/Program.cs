using Regies.Infrastructure.Extensions;
using Regies.Application.Extensions;
using Regies.Infrastructure.Seeders;
using Serilog.Events;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


    builder.Host.UseSerilog((context, configuration) => {
        configuration
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
            .WriteTo.Console(
                outputTemplate : "[{Timestamp:dd-MM HH:mm:ss}] {Level:u3} | {SourceContext} | {NewLine}{Message:lJ}{NewLine}{Exception}"
            );
    });


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRegiesSeeder>();

await seeder.Seed();


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
