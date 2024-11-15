//using AutoMapper;
//using Carter;
//using MediatR;
//using Microsoft.AspNetCore.HttpLogging;
//using Ordering.API.Filters;
//using Ordering.API.Model.order;
//using Ordering.Application.CQRS.Commands;

//namespace Ordering.API.Endpoints;

//public class DeleteCardAPI : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapDelete("api/v1/orders", async (
//            [AsParameters] string request,
//            ISender sender,
//            IMapper mapper,
//            ILogger<DeleteCardAPI> logger) =>
//        {
//            var command = mapper.Map<CreateOrderCommand>(request);
//            var result = await sender.Send(command);

//            var response = mapper.Map<CreateOrderResponse>(result);

//            return Results.Created($"/orders/{response.Id}", response);
//        })
//        .WithName("CreateOrder")
//        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
//        .ProducesProblem(StatusCodes.Status400BadRequest)
//        .WithHttpLogging(HttpLoggingFields.RequestPropertiesAndHeaders)
//        .AddEndpointFilter<CreateOrderRequestValidationFilter>()
//        .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders).WithSummary("Get Orders")
//        .WithSummary("Create Order summary")
//        .WithDescription("Create Order description");
//    }
//}