using AutoMapper;
using PCPartsShop.Domain.Models;
using PCPartsShop.WebAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, GetOrderDto>().ForMember(p => p.ShippingStatus, opt => opt.MapFrom(p1 => p1.IsShipped));
        }
    }
}
