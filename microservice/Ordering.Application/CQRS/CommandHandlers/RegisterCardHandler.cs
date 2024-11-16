using BuildingBlocks.Application.CQRS;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Integration;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.CQRS.CommandHandlers;
public class RegisterCardHandler(ICardRepository cardRepository, IIdGeneratorAdapter generator)
    : ICommandHandler<RegisterCardCommand, RegisterCardResult>
{
    private const int ID_LENGTH = 32;

    public async Task<RegisterCardResult> Handle(RegisterCardCommand command, CancellationToken cancellationToken)
    {
        command.Id = generator.Generate(ID_LENGTH);
        var card = new Card()
        {
            RegisteringTime = DateTime.UtcNow,
            PIN = command.PIN,
            SerialNumber = command.SerialNumber,
            AccountNumber = command.AccountNumber,
            Id = command.Id,
        };
        
        var result = cardRepository.Add(card);
        await cardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return new RegisterCardResult(result.Id);
    }
}
