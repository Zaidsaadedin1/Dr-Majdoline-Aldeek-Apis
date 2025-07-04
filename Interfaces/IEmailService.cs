using Dr_Majdoline_Aldee.Common.Enums;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResponseStatus> SendEmailToUserAsync(string toEmail, string subject, string body);
    }
}
