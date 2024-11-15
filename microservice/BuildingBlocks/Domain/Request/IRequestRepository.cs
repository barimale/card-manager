using BuildingBlocks.Domain.SeedWork;

namespace BuildingBlocks.Domain.Request;

//This is just the RepositoryContracts or Interface defined at the Domain Layer
//as requisite for the Buyer Aggregate

public interface IRequestRepository : IRepository<Request>
{
    Request Add(Request buyer);
}

