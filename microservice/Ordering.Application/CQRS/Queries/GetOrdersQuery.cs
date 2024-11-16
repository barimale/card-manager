using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.Queries;

public class GetOrdersQuery
    : IQuery<GetCardResult>
{
    public GetOrdersQuery()
    {
        PaginationRequest = new PaginationRequest();
    }

    public GetOrdersQuery(PaginationRequest paginationRequest)
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