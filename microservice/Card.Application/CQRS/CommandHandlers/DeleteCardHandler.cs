using BuildingBlocks.Application.CQRS;
using Card.Domain.AggregatesModel.CardAggregate;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Integration;

namespace Ordering.Application.CQRS.CommandHandlers;
public class DeleteCardHandler(ICardRepository cardRepository, IIdGeneratorAdapter generator)
    : ICommandHandler<DeleteCardCommand, DeleteCardResult>
{
    public async Task<DeleteCardResult> Handle(DeleteCardCommand command, CancellationToken cancellationToken)
    {
        var result = await cardRepository.Delete(command.Id);
        await cardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return new DeleteCardResult(result);
    }
}
