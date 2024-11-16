using AutoMapper;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Card, CardDto>().ReverseMap();
        }
    }
}
