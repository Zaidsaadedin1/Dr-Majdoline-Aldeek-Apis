using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.UserDto;
using Dr_Majdoline_Aldee.Common.Entities;

namespace Dr_Majdoline_Aldee.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, GetUserDto>();
              
        }
    }
}
