using Microsoft.EntityFrameworkCore;
using SimpleBackend.Infrasturcture.Database;

namespace SimpleBackend.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<UsersDbContext>(scope);
    }

    internal static IApplicationBuilder UseLogContextTraceLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<LogContextTraceLoggingMiddleware>();

        return app;
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
