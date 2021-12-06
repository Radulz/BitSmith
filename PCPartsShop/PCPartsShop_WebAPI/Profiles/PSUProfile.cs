using AutoMapper;
using PCPartsShop.Application.Commands.PSUCommands.CreatePSU;
using PCPartsShop.Dtos;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Profiles
{
    public class PSUProfile : Profile
    {
        public PSUProfile()
        {
            CreateMap<PSU, GetPSUDto>()
                .ForMember(p => p.PowerUnitId, opt => opt.MapFrom(p1 => p1.ComponentId))
                .ForMember(p => p.Modularity, opt => opt.MapFrom(p1 => p1.Type));

            CreateMap<CreatePSUDto, CreatePSUCommand>()
                .ForMember(p => p.Type, opt => opt.MapFrom(p1 => p1.Modularity));
        }
    }
}
