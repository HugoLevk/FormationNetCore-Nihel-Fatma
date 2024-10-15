
using Microsoft.Data.SqlClient;
using Regies.Domain.Exceptions;

namespace Regies.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException nfEx)
        {
            logger.LogError(nfEx, "Not Found Exception : {Message}", nfEx.Message);
            context.Response.StatusCode = 404;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(nfEx.Message);
        }
        catch (SqlException ex)
        {
            logger.LogError(ex, "Sql Error : {Message} ", ex.Message);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync("Something went wrong in DB.");
        }
        catch(Exception ex)
        {
            logger.LogError(ex,"{Message}", ex.Message);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync("Something went wrong.");
        }
    }
}
