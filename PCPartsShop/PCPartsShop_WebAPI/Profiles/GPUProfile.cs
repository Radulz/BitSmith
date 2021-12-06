using AutoMapper;
using PCPartsShop.Application.Commands.GPUCommands.CreateGPU;
using PCPartsShop.Dtos;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Profiles
{
    public class GPUProfile : Profile
    {
        public GPUProfile()
        {
            CreateMap<GPU, GetGPUDto>()
                .ForMember(g => g.GPUId, opt => opt.MapFrom(g1 => g1.ComponentId))
                .ForMember(g => g.Frequency, opt => opt.MapFrom(g1 => g1.Freq))
                .ForMember(g => g.MemoryCapacity, opt => opt.MapFrom(g1 => g1.Memory))
                .ForMember(g => g.Technology, opt => opt.MapFrom(g1 => g1.Tech))
                .ForMember(g => g.PowerConsumption, opt => opt.MapFrom(g1 => g1.PowerC));

            CreateMap<CreateGPUDto, CreateGPUCommand>()
                .ForMember(g => g.Freq, opt => opt.MapFrom(g1 => g1.Frequency))
                .ForMember(g => g.Memory, opt => opt.MapFrom(g1 => g1.MemoryCapacity))
                .ForMember(g => g.Tech, opt => opt.MapFrom(g1 => g1.Technology))
                .ForMember(g => g.PowerC, opt => opt.MapFrom(g1 => g1.PowerConsumption));
        }
    }
}
