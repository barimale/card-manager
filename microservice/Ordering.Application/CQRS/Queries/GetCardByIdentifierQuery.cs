using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;

namespace Ordering.Application.CQRS.Queries;

public class GetCardByIdentifierQuery
    : IQuery<GetCardResult>
{
    public GetCardByIdentifierQuery(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}
