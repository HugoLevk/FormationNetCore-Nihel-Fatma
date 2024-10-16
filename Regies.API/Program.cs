using Regies.Infrastructure.Extensions;
using Regies.Application.Extensions;
using Regies.Infrastructure.Seeders;
using Serilog.Events;
using Serilog;
using System.Reflection;
using Regies.API.SchemaFilters;
using Regies.API.Middlewares;
using Regies.Domain.Model;
using Microsoft.OpenApi.Models;
using Regies.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();



var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRegiesSeeder>();

await seeder.Seed();


// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<TimeLoggingMiddleware>();

app.UseSerilogRequestLogging();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Regies.API v1"));
}

app.UseHttpsRedirection();

app.MapGroup("api/Identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
