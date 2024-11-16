using BuildingBlocks.Domain.SeedWork;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Infrastructure.Repositories
{
    public interface ICardRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Card Add(Card order);
        Task<string> Delete(string id);
        Task<List<Card>> GetAllAsync(int pageIndex, int pageSize);
        Task<Card> GetByAccountNumberAsync(string id);
        Task<Card> GetByIdAsync(string id);
        Task<Card> GetBySerialNumberAsync(string id);
    }
}