using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.Queries;

public class GetCardBySerialNumberQuery
    : IQuery<GetCardResult>
{
    public GetCardBySerialNumberQuery(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}

public class GetCardByIDentifierQuery
    : IQuery<GetCardResult>
{
    public GetCardByIDentifierQuery()
    {
        PaginationRequest = new PaginationRequest();
    }

    public GetCardByIDentifierQuery(PaginationRequest paginationRequest)
    {
        PaginationRequest = paginationRequest;
    }

    public PaginationRequest PaginationRequest { get; set; }
}

public class GetCardByAccountNumberQuery
    : IQuery<GetCardResult>
{
    public GetCardByAccountNumberQuery()
    {
        PaginationRequest = new PaginationRequest();
    }

    public GetCardByAccountNumberQuery(PaginationRequest paginationRequest)
    {
        PaginationRequest = paginationRequest;
    }

    public PaginationRequest PaginationRequest { get; set; }
}
public class GetCardResult
{
    public GetCardResult()
    {
        //intentionally left blank
    }
    public GetCardResult(CardDto orders)
    {
        this.Card = orders;
    }
    
    public CardDto Card { get; set; }
}