using AutoMapper;
using PCPartsShop.Application.Commands.CPUCommands.CreateCPU;
using PCPartsShop.Dtos;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Profiles
{
    public class CPUProfile : Profile
    {
        public CPUProfile()
        {
            CreateMap<CPU, GetCPUDto>()
                .ForMember(c => c.Frequency, opt => opt.MapFrom(c1 => c1.Freq))
                .ForMember(c => c.Technology, opt => opt.MapFrom(c1 => c1.Tech))
                .ForMember(c => c.MemoryFrequency, opt => opt.MapFrom(c1 => c1.MFreq))
                .ForMember(c => c.ThermalDesignPower, opt => opt.MapFrom(c1 => c1.TDP))
                .ForMember(c => c.NumberOfCores, opt => opt.MapFrom(c1 => c1.Cores));

            CreateMap<CreateCPUDto, CreateCPUCommand>()
                .ForMember(c => c.Freq, opt => opt.MapFrom(c1 => c1.Frequency))
                .ForMember(c => c.Tech, opt => opt.MapFrom(c1 => c1.Technology))
                .ForMember(c => c.MFreq, opt => opt.MapFrom(c1 => c1.MemoryFrequency))
                .ForMember(c => c.TDP, opt => opt.MapFrom(c1 => c1.ThermalDesignPower))
                .ForMember(c => c.Cores, opt => opt.MapFrom(c1 => c1.NumberOfCores));
        }
    }
}
