using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBackend.Application.Data;
using SimpleBackend.Domain.Users;
using SimpleBackend.Infrasturcture.Database;
using SimpleBackend.Infrasturcture.Users;
using SimpleBackend.Presentation.Endpoints;

namespace SimpleBackend.Infrasturcture;

public static class SimpleBackendModule
{
    public static IServiceCollection AddModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastracture(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastracture(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>((sp, options) =>
            options
                .UseSqlServer(
                    configuration.GetConnectionString("Database"),
                    sqlServerOptions => sqlServerOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Users)));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
    }
}
