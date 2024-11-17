using AutoMapper;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.MappingProfiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<RegisterCardCommand, RegisterCardRequest>()
                .ReverseMap();

            CreateMap<RegisterCardCommand, Card.Domain.AggregatesModel.CardAggregate.Card>()
                .ReverseMap();

            CreateMap<RegisterCardResult, RegisterCardResponse>();
        }
    }
}
