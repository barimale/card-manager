using AutoMapper;
using Ordering.Application.Dtos;

namespace Ordering.Application.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card.Domain.AggregatesModel.CardAggregate.Card, CardDto>().ReverseMap();
        }
    }
}
