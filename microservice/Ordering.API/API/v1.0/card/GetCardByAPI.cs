using AutoMapper;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.Filters;
using Ordering.Application.CQRS.Queries;

namespace Ordering.API.Endpoints;

public class GetCardByAPI : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/cards/serial-number/{serialNumber}", async (
            string serialNumber,
            ISender sender,
            IMapper mapper,
            ILogger<GetCardByAPI> logger) =>
        {
            var mapped = mapper.Map<GetOrdersQuery>(serialNumber);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetCardBySerialNumber")
        .Produces<GetOrdersResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        //.AddEndpointFilter<GetOrdersRequestValidationFilter>()// WIP
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Card by serial number.")
        .WithDescription("Provide serial number to obtain the card details.");

        app.MapGet("api/v1/cards/account-number/{accountNumber}", async (
            string accountNumber,
            ISender sender,
            IMapper mapper,
            ILogger<GetCardByAPI> logger) =>
        {
            var mapped = mapper.Map<GetOrdersQuery>(accountNumber);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetCardByAccountNumber")
        .Produces<GetOrdersResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        //.AddEndpointFilter<GetOrdersRequestValidationFilter>() // WIP
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Orders summary")
        .WithDescription("Get Orders description");

        app.MapGet("api/v1/cards/identifier/{id}", async (
            string id,
            ISender sender,
            IMapper mapper,
            ILogger<GetCardByAPI> logger) =>
        {
            var mapped = mapper.Map<GetOrdersQuery>(id);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetCardByID")
        .Produces<GetOrdersResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        //.AddEndpointFilter<GetOrdersRequestValidationFilter>()// WIP
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Orders summary")
        .WithDescription("Get Orders description");
    }
}
