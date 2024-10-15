
using System.Diagnostics;

namespace Regies.API.Middlewares;

public class TimeLoggingMiddleware(ILogger<TimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        logger.LogInformation("TimeLoggingMiddleware.InvokeAsync - Before next");
        logger.LogInformation("Request : {Req}|{Path} started at {Datetime}", context.Request.Method, context.Request.Path, DateTime.Now);

        var watch = new Stopwatch();
        watch.Start();

        await next(context);

        watch.Stop();
        //Log request Execution time
        logger.LogInformation("Request : {Req}|{Path} completed in {Time}ms", context.Request.Method, context.Request.Path, watch.ElapsedMilliseconds);
    }
}
