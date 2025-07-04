using Dr_Majdoline_Aldee.Common.Entities;
using Dr_Majdoline_Aldee.Common.Enums;

namespace Dr_Majdoline_Aldee.Common.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string? CompanyName { get; set; }

        public string ProjectType { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public decimal Budget { get; set; }
        public string Timeline { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;

        public string? AdditionalRequirements { get; set; }

        public bool TermsAccepted { get; set; }

        public string? UserId { get; set; }
    }

}
