using Microsoft.OpenApi.Models;
using Regies.API.Middlewares;
using Regies.API.SchemaFilters;
using Serilog;
using System.Reflection;

namespace Regies.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
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

            c.AddSecurityDefinition("bearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
            },
            []
        }
    });

        });

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<TimeLoggingMiddleware>();

        builder.Services.AddControllers().ConfigureApiBehaviorOptions(x => { x.SuppressMapClientErrors = true; });
    }
}
