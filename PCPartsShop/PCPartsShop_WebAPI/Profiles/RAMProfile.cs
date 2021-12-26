using AutoMapper;
using PCPartsShop.Application.Commands.RAMCommands.CreateRAM;
using PCPartsShop.Dtos;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Profiles
{
    public class RAMProfile : Profile
    {
        public RAMProfile()
        {
            CreateMap<RAM, GetRAMDto>()
                .ForMember(r => r.Frequency, opt => opt.MapFrom(r1 => r1.Freq));

            CreateMap<CreateRAMDto, CreateRAMCommand>()
                .ForMember(r => r.Freq, opt => opt.MapFrom(r1 => r1.Frequency));
        }
    }
}
