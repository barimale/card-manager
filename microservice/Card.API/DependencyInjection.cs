using BuildingBlocks.API.Middlewares.GlobalExceptions.Handler;
using BuildingBlocks.API.Utilities.Healthcheck;
using Card.API.Extensions;
using Card.API.Filters;
using Card.API.MappingProfiles;
using Card.API.Validators;
using Card.Infrastructure;
using Carter;
using Consul;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using NLog;
using NLog.Extensions.Logging;
using HealthStatus = Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus;

namespace Card.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddAutoMapper(typeof(ApiProfile));
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddHealthChecks()
            .AddSqlServer(
                configuration["ConnectionStrings:Database"],
                healthQuery: "select 1",
                name: "SQL server health check",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "Feedback", "Database" })
            .AddCheck<MemoryHealthCheck>(
            $"Feedback Service Memory Check",
            failureStatus: HealthStatus.Unhealthy,
            tags: new[] { "Feedback", "Service" });

        services.AddScoped<RegisterCardRequestValidationFilter>();
        services.AddScoped<RegisterCardCommandValidator>();

        LogManager.Configuration = new NLogLoggingConfiguration(
                    configuration.GetSection("NLog"));

        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.ResponsePropertiesAndHeaders;
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.DocumentFilter<HealthChecksDocumentFilter>();
            options.EnableAnnotations();
        });

        services.AddMigration<CardContext>();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseExceptionHandler(options => { });
        app.UseHealthChecks(HeartbeatUtility.Path,
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        return app;
    }
}
