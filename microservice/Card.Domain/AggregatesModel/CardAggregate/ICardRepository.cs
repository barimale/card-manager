using BuildingBlocks.Domain.SeedWork;

namespace Card.Domain.AggregatesModel.CardAggregate
{
    public interface ICardRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Card Add(Card card);
        Task<string> Delete(string id);
        Task<Card> GetByAccountNumberAsync(string id);
        Task<Card> GetByIdAsync(string id);
        Task<Card> GetBySerialNumberAsync(string id);
    }
}