using Serilog;
using SimpleBackend.Api.Extensions;
using SimpleBackend.Api.Middleware;
using SimpleBackend.Application;
using SimpleBackend.Infrasturcture;
using SimpleBackend.Presentation.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddApplication([SimpleBackend.Application.AssemblyReference.Assembly]);

builder.Services.AddModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseLogContextTraceLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.MapEndpoints();

await app.RunAsync();
