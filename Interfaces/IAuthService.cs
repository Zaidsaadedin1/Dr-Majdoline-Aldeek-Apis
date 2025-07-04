using Dr_Majdoline_Aldee.Common.Dtos.AuthDtos;
using Dr_Majdoline_Aldee.Common.Dtos;
using Dr_Majdoline_Aldee.Common.Dtos.Shared;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IAuthService
    {
        Task<GenericResponse<RegisterUserDto>> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<GenericResponse<string>> LoginUserAsync(LoginUserDto loginUserDto);
        Task<bool> IsUsersPhoneOrEmailTakenAsync(string identifier);
        Task<GenericResponse<bool>> UserPasswordResetAsync(ResetPasswordDto resetPasswordDto);
    }
}
