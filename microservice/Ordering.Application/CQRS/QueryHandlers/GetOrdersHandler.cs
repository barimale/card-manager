using AutoMapper;
using BuildingBlocks.Application.CQRS;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Application.CQRS.QueryHandlers;
public class GetOrdersHandler(ICardRepository orderRepository, IMapper mapper, ILogger<GetOrdersHandler> logger)
    : IQueryHandler<GetCardBySerialNumberQuery, GetCardResult>
     
{
    public async Task<GetCardResult> Handle(GetCardBySerialNumberQuery query, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetBySerialNumberAsync(query.Id);
        var mapped = mapper.Map<CardDto>(orders);

        return new GetCardResult(mapped);
    }
}
