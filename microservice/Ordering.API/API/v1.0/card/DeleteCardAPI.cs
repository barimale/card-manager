﻿using AutoMapper;
using Carter;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Ordering.API.Filters;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Endpoints;

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

            var response = mapper.Map<DeleteCardResponse>(result);

            return Results.Accepted($"/orders/{response.Id}", response);
        })
        .WithName("DeleteCard")
        .Produces<RegisterCardResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
        //.AddEndpointFilter<CreateOrderRequestValidationFilter>() WIP
        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders)
        .WithSummary("Create Order summary")
        .WithDescription("Create Order description");
    }
}