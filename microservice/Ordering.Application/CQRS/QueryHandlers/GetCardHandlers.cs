using AutoMapper;
using BuildingBlocks.Application.CQRS;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Application.CQRS.QueryHandlers;
public class GetCardHandlers(ICardRepository orderRepository, IMapper mapper, ILogger<GetOrdersHandler> logger)
    : IQueryHandler<GetCardBySerialNumberQuery, GetCardResult>,
      IQueryHandler<GetCardByIdentifierQuery, GetCardResult>,
      IQueryHandler<GetCardByAccountNumberQuery, GetCardResult>

     
{
    public async Task<GetCardResult> Handle(GetCardBySerialNumberQuery query, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetBySerialNumberAsync(query.Id);
        var mapped = mapper.Map<CardDto>(orders);

        return new GetCardResult(mapped);
    }

    public async Task<GetCardResult> Handle(GetCardByAccountNumberQuery query, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetByAccountNumberAsync(query.Id);
        var mapped = mapper.Map<CardDto>(orders);

        return new GetCardResult(mapped);
    }

    public async Task<GetCardResult> Handle(GetCardByIdentifierQuery query, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetByIdAsync(query.Id);
        var mapped = mapper.Map<CardDto>(orders);

        return new GetCardResult(mapped);
    }
}
