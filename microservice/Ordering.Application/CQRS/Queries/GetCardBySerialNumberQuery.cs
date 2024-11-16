using BuildingBlocks.Application.CQRS;

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
