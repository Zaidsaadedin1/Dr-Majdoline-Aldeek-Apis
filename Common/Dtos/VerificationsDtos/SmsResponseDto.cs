using Dr_Majdoline_Aldee.Common.Enums;

namespace Dr_Majdoline_Aldee.Common.Dtos.VerificationsDtos
{
    public class SmsResponseDto
    {
        public SmsResponseStatus Status { get; set; }
        public string OtpCode { get; set; } = null!;
    }
}
