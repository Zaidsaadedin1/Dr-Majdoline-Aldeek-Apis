using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.AuthDtos;
using Dr_Majdoline_Aldee.Common.Entities;

namespace Dr_Majdoline_Aldee.Common.Mappers
{
    public class AuthProfile : Profile
    {

        public AuthProfile()
        {
            CreateMap<LoginUserDto, User>();

            CreateMap<RegisterUserDto, User>();

        }
    }

}

