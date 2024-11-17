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
            CreateMap<RegisterCardCommand, RegisterCardRequest>()
                .ReverseMap();

            CreateMap<RegisterCardCommand, Card>()
                .ReverseMap();

            CreateMap<RegisterCardResult, RegisterCardResponse>();
        }
    }
}
