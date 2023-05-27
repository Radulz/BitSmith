using AutoMapper;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;

namespace PCPartsShop.WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
