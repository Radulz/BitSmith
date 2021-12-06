using AutoMapper;
using PCPartsShop.Application.Commands.MOBOCommands.CreateMOBO;
using PCPartsShop.Dtos;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Profiles
{
    public class MOBOProfile : Profile
    {
        public MOBOProfile()
        {
            CreateMap<MOBO, GetMOBODto>()
                .ForMember(m => m.MotherboardId, opt => opt.MapFrom(m1 => m1.ComponentId))
                .ForMember(m => m.LowestFrequencySupported, opt => opt.MapFrom(m1 => m1.MemoryFreqInf))
                .ForMember(m => m.HighestFrequencySupported, opt => opt.MapFrom(m1 => m1.MemoryFreqSup));

            CreateMap<CreateMOBODto, CreateMOBOCommand>()
                .ForMember(m => m.MemoryFreqInf, opt => opt.MapFrom(m1 => m1.LowestFrequencySupported))
                .ForMember(m => m.MemoryFreqSup, opt => opt.MapFrom(m1 => m1.HighestFrequencySupported));
        }
    }
}
