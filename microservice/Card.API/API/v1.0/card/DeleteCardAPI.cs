using AutoMapper;
using Card.Application.CQRS.Commands;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;

namespace Cards.API.Endpoints;

public class DeleteCardAPI : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/v1/cards/delete/{id}", async (
            string id,
            ISender sender,
            IMapper mapper,
            ILogger<DeleteCardAPI> logger) =>
        {
            var command = new DeleteCardCommand()
            {
                Id = id
            };

            var result = await sender.Send(command);

            return Results.Accepted(value: result);
        })
        .WithName("DeleteCard")
        .Produces<RegisterCardResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Delete card summary")
        .WithDescription("Delete card description");
    }
}