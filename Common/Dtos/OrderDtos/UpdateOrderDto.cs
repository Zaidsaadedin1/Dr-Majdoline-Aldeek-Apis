namespace Dr_Majdoline_Aldee.Common.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public string? CompanyName { get; set; }
        public string ProjectType { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public decimal Budget { get; set; }
        public string Timeline { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public string? AdditionalRequirements { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
}
