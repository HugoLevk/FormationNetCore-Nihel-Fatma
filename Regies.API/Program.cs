using Regies.Infrastructure.Extensions;
using Regies.Application.Extensions;
using Regies.Infrastructure.Seeders;
using Serilog.Events;
using Serilog;
using System.Reflection;
using Regies.API.SchemaFilters;
using Regies.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Regies.API",
        Version = "v1",
        Description = "API pour la gestion des régies.",
        Contact = new()
        {
            Name = "Regies",
            Email = "hugo.leveque@web-atrio.com",
        },
        
    });

    c.SchemaFilter<EnumSchemaFilter>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);

    var applicationXmlFile = $"../../../../Application/bin/Debug/net8.0/Regies.Application.xml";
    var applicationXmlPath = Path.Combine(AppContext.BaseDirectory, applicationXmlFile);

    c.IncludeXmlComments(applicationXmlPath);

    var domainXmlFile = $"../../../../Domain/bin/Debug/net8.0/Regies.Domain.xml";
    var domainXmlPath = Path.Combine(AppContext.BaseDirectory, domainXmlFile);

    c.IncludeXmlComments(domainXmlPath);

});

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(x => { x.SuppressMapClientErrors = true; }); 

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRegiesSeeder>();

await seeder.Seed();


// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Regies.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
