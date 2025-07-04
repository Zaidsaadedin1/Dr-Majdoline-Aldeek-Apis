using Dr_Majdoline_Aldee.Common.Enums;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface ISmsService
    {
        Task<SmsResponseStatus> SendSmsToUserAsync(string phoneNumber, string message, string otp);
    }
}
