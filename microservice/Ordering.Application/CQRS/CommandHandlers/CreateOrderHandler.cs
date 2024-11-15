using BuildingBlocks.Application.CQRS;
using Microsoft.Extensions.Options;
using Ordering.Application.CQRS.Commands;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.CommandHandlers;
public class CreateOrderHandler(IOrderRepository orderRepository)
    : ICommandHandler<RegisterCardCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(RegisterCardCommand command, CancellationToken cancellationToken)
    {
        var result = orderRepository.Add(null);
        await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return new CreateOrderResult(result.Id);
    }
}
