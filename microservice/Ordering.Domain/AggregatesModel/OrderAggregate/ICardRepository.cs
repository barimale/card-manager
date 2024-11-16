using BuildingBlocks.Domain.SeedWork;

namespace Ordering.Domain.AggregatesModel.OrderAggregate;

//This is just the RepositoryContracts or Interface defined at the Domain Layer
//as requisite for the Order Aggregate

public interface ICardRepository : IRepository<Card>
{
    Card Add(Card order);

    void Update(Card order);

    Task<Card> GetAsync(int orderId);
    Task<List<Card>> GetAllAsync(int pageIndex, int pageSize);
}
