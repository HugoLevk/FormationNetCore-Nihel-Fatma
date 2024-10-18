using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Regies.API.Middlewares;

public class SwaggerResponseStatusCodeFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if(operation.Responses.ContainsKey("404"))
        {
            operation.Responses["404"].Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/json"] = new OpenApiMediaType
                {
                    Example = new OpenApiString("{ \"message\": \"?????????? with id XXxxxxxxxxxxxxxxXX doesn't exist.\" }")
                }
            };
        }
    }
}
