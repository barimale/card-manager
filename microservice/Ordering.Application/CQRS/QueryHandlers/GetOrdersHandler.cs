using AutoMapper;
using BuildingBlocks.API.Pagination;
using BuildingBlocks.Application.CQRS;
using Microsoft.Extensions.Logging;
using Ordering.Application.CQRS.Queries;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Application.CQRS.QueryHandlers;
public class GetOrdersHandler(ICardRepository orderRepository, IMapper mapper, ILogger<GetOrdersHandler> logger)
    : IQueryHandler<GetOrdersQuery, GetCardResult>
     
{
    public async Task<GetCardResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var orders = await orderRepository.GetAllAsync(pageIndex, pageSize);
        var mapped = mapper.Map<List<CardDto>>(orders);

        return new GetCardResult(
            new PaginatedResult<CardDto>(
                pageIndex,
                pageSize,
                orders.Count,
                mapped));
    }
}
