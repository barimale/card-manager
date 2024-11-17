﻿using BuildingBlocks.API.Middlewares.GlobalExceptions.Handler;
using BuildingBlocks.API.Utilities.Healthcheck;
using Carter;
using Consul;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using NLog;
using NLog.Extensions.Logging;
using Ordering.API.Filters;
using Ordering.API.MappingProfiles;
using Ordering.API.SwaggerFilters;
using Ordering.API.Utilities;
using Ordering.API.Validators;
using HealthStatus = Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus;

namespace Ordering.API;

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
            .AddCheck<StarWarsRemoteHealthCheck>(
                "Star wars remote endpoint health Check", 
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "Feedback", "External" })
            .AddCheck<MemoryHealthCheck>(
            $"Feedback Service Memory Check", 
            failureStatus: HealthStatus.Unhealthy, 
            tags: new[] { "Feedback", "Service" });

        services.AddScoped<RegisterCardRequestValidationFilter>();
        services.AddScoped<RegisterCardCommandValidator>();

        services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
        {
            consulConfig.Address = new Uri(configuration.GetSection("consul").Get<string>());
        }));

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
            options.OperationFilter<AddCustomHeaderParameter>();
        });

        //services.AddMigration<CardContext>();

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