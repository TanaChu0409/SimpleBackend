using Microsoft.Extensions.Configuration;

namespace SimpleBackend.Infrasturcture.Configuration;

public static class ConfigurtionExtensions
{
    public static string GetConnectionStringOrThrow(this IConfiguration configuration, string name)
    {
        return configuration.GetConnectionString(name) ??
            throw new InvalidOperationException($"The connection string {name} was not found");
    }
}
