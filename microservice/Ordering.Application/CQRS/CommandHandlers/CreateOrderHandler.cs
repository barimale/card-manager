using BuildingBlocks.Application.CQRS;
using BuildingBlocks.Application.Services.RabbitMq;
using Microsoft.Extensions.Options;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Services.BackgroundServices;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.CommandHandlers;
public class CreateOrderHandler(IOrderRepository orderRepository, IOptions<OrderingBackgroundSettings> _settings)
    : ICommandHandler<RegisterCardRequest, CreateOrderResult>
{
    private PublishToChannelService publishToChannelService;

    public async Task<CreateOrderResult> Handle(RegisterCardRequest command, CancellationToken cancellationToken)
    {
        var result = orderRepository.Add(order);
        await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return new CreateOrderResult(result.Id);
    }
}
