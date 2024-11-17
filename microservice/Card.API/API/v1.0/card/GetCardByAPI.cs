using AutoMapper;
using Card.Application.CQRS.Queries;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;

namespace Cards.API.Endpoints;

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
            var mapped = mapper.Map<GetCardBySerialNumberQuery>(serialNumber);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetCardBySerialNumber")
        .Produces<GetCardResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Card by serial number.")
        .WithDescription("Provide serial number to obtain the card details.");

        app.MapGet("api/v1/cards/account-number/{accountNumber}", async (
            string accountNumber,
            ISender sender,
            IMapper mapper,
            ILogger<GetCardByAPI> logger) =>
        {
            var mapped = mapper.Map<GetCardByAccountNumberQuery>(accountNumber);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetCardByAccountNumber")
        .Produces<GetCardResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Card by account number.")
        .WithDescription("Provide account number to obtain the card details.");

        app.MapGet("api/v1/cards/identifier/{id}", async (
            string id,
            ISender sender,
            IMapper mapper,
            ILogger<GetCardByAPI> logger) =>
        {
            var mapped = mapper.Map<GetCardByIdentifierQuery>(id);
            var response = await sender.Send(mapped);

            if (response is null)
                return Results.NotFound();

            return Results.Ok(response);
        })
        .WithName("GetCardByID")
        .Produces<GetCardResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Get Card by identifier.")
        .WithDescription("Provide identifier to obtain the card details.");
    }
}
