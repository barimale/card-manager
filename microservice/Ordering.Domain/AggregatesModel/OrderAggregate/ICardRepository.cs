using BuildingBlocks.Domain.SeedWork;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public interface ICardRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Card Add(Card order);
        Task<List<Card>> GetAllAsync(int pageIndex, int pageSize);
        Task<Card> GetByAccountNumberAsync(string id);
        Task<Card> GetByIdAsync(string id);
        Task<Card> GetBySerialNumberAsync(string id);
    }
}