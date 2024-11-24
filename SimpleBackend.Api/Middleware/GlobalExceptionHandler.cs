using Microsoft.AspNetCore.Diagnostics;

namespace SimpleBackend.Api.Middleware;

internal sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IProblemDetailsService problemDetailsService)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An unhandled exception has occurred.");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await problemDetailsService.WriteAsync(new()
        {
            HttpContext = httpContext,
            Exception = exception,
        });

        return true;
    }
}