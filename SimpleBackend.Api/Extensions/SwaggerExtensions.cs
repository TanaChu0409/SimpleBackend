namespace SimpleBackend.Api.Extensions;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "SimpleBackend API",
                Version = "v1",
                Description = "SimpleBackend API",
            });

            options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
        });

        return services;
    }
}