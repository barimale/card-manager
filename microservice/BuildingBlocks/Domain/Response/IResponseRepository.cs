using BuildingBlocks.Domain.SeedWork;

namespace BuildingBlocks.Domain.Response;

//This is just the RepositoryContracts or Interface defined at the Domain Layer
//as requisite for the Buyer Aggregate

public interface IResponseRepository : IRepository<Response>
{
    Response Add(Response buyer);
}

