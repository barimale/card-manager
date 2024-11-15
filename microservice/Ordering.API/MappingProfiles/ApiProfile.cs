using AutoMapper;
using BuildingBlocks.API.Pagination;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.CQRS.Queries;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.MappingProfiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            // WIP
            CreateMap<CreateOrderCommand, RegisterCardRequest>()
                .ForMember(p => p.PIN, pp => pp.MapFrom(src => src.PIN))
                .ReverseMap()
                .ForMember(p => p.PIN, pp => pp.MapFrom(src => src.PIN));

            CreateMap<PaginationRequest, GetOrdersQuery>()
                .ForPath(p => p.PaginationRequest.PageIndex, pp => pp.MapFrom(src => src.PageIndex))
                .ForPath(p => p.PaginationRequest.PageSize, pp => pp.MapFrom(src => src.PageSize))
                .ReverseMap();

            CreateMap<CreateOrderCommand, Order>()
                .ReverseMap();

            CreateMap<CreateOrderResult, CreateOrderResponse>();
        }
    }
}
