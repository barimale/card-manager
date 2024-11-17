using AutoMapper;
using Card.API.Filters;
using Card.Application.CQRS.Commands;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.Application.CQRS.Commands;

namespace Cards.API.Endpoints;

public class RegisterCardAPI : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/cards", async (
            RegisterCardRequest commandRequest,
            ISender sender,
            IMapper mapper,
            ILogger<RegisterCardAPI> logger) =>
        {
            var command = mapper.Map<RegisterCardCommand>(commandRequest);
            var result = await sender.Send(command);

            return Results.Created($"/api/v1/cards/{result.Id}", result);
        })
        .WithName("RegisterCard")
        .Produces<RegisterCardResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .AddEndpointFilter<RegisterCardRequestValidationFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Register card.")
        .WithDescription("Register card.");
    }
}
