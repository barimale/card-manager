using BuildingBlocks.Application.CQRS;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Integration;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.CommandHandlers;
public class CreateOrderHandler(IOrderRepository orderRepository, IIdGeneratorAdapter generator)
    : ICommandHandler<RegisterCardCommand, RegisterCardResult>
{
    private const int ID_LENGTH = 32;

    public async Task<RegisterCardResult> Handle(RegisterCardCommand command, CancellationToken cancellationToken)
    {
        command.Id = generator.Generate(ID_LENGTH);
        // WIP
        var result = orderRepository.Add(null);
        await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return new RegisterCardResult(result.Id);
    }
}
