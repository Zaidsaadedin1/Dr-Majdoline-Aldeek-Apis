using Dr_Majdoline_Aldee.Common.Dtos.Shared;
using Dr_Majdoline_Aldee.Common.Dtos.UserDto;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IUserService
    {
        Task<GenericResponse<GetUserDto>> GetUserByEmailOrPhoneAsync(string emailOrPhone);
        Task<GenericResponse<GetUserDto>> GetUserByIdAsync(string userId);
        Task<GenericResponse<IEnumerable<GetUserDto>>> GetAllUsersAsync();
        Task<GenericResponse<bool>> UpdateUserAsync(string userId, UpdateUserDto userDto);
        Task<GenericResponse<bool>> DeleteUserAsync(string userId);
    }
}
