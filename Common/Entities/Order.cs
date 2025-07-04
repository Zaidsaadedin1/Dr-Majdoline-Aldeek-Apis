
namespace Dr_Majdoline_Aldee.Common.Entities
{
    public class Order
    {
        public int Id { get; set; }

        // Contact Information
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? CompanyName { get; set; }

        // Project Requirements
        public string ProjectType { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public decimal Budget { get; set; }
        public string Timeline { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public string? AdditionalRequirements { get; set; }
        public bool TermsAccepted { get; set; }

        // Relationship to User
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
