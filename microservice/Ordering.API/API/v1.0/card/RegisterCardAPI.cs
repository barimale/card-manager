using AutoMapper;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.Filters;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Endpoints;

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

            var response = mapper.Map<CreateOrderResponse>(result);

            return Results.Created($"/cards/{response.Id}", response);
        })
        .WithName("RegisterCard")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .AddEndpointFilter<RegisterCardRequestValidationFilter>()
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders).WithSummary("Get Orders")
        .WithSummary("Register card summary")
        .WithDescription("Register card description");
    }
}