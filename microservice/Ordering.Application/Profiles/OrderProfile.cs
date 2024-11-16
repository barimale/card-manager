﻿using AutoMapper;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // WIP
            //CreateMap<Card, OrderDto>().ReverseMap()
            //        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.BillingAddress))
            //        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //        .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.Payment.PaymentMethod));


            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
