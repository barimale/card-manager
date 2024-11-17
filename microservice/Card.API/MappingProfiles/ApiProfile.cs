using AutoMapper;
using Card.Application.CQRS.Commands;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Card.API.MappingProfiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<RegisterCardCommand, RegisterCardRequest>()
                .ReverseMap();

            CreateMap<RegisterCardCommand, Domain.AggregatesModel.CardAggregate.Card>()
                .ReverseMap();

            CreateMap<RegisterCardResult, RegisterCardResponse>();
        }
    }
}
