using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Regies.API.SchemaFilters;
/// <summary>
/// Filtre de schéma pour les énumérations.
/// </summary>
public class EnumSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Applique le filtre de schéma pour les énumérations. Affiche le Nombre et le string associé à chaque valeur de l'énumération.
    /// </summary>
    /// <param name="schema">Le schéma OpenAPI.</param>
    /// <param name="context">Le contexte du filtre de schéma.</param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            schema.Enum.Clear();
            Enum.GetNames(context.Type)
                .ToList()
                .ForEach(name => schema.Enum.Add(new OpenApiString($"{Convert.ToInt64(Enum.Parse(context.Type, name))} - {name}")));
        }
    }
}
