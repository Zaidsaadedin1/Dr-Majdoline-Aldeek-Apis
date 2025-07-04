using Dr_Majdoline_Aldee.Common.Dtos.Shared;
using Dr_Majdoline_Aldee.Common.Dtos.VerificationsDtos;
using Dr_Majdoline_Aldee.Common.Enums;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IOtpService
    {
        Task<GenericResponse<bool>> SendOtpAsync(string emailOrPhone);
        Task<VerificationResult> VerifyUserOtpAsync(VerifyOtpDto verifyOtpDto);
    }
}
