using BuildingBlocks.Domain.Request;
using BuildingBlocks.Domain.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Repositories;
using System;

namespace Ordering.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<CardContext>(options =>
        {
            options.UseSqlServer(connectionString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            });
        });

        // Add services to the container.
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IResponseRepository, ResponseRepository>();

        return services;
    }
}
