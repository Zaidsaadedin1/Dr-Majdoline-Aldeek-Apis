using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using FluentValidation;

namespace Dr_Majdoline_Aldee.Infrastructure.Validators
{
    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company Name is required.");
            RuleFor(x => x.ProjectType).NotEmpty().WithMessage("Project Type is required.");
            RuleFor(x => x.ServiceType).NotEmpty().WithMessage("Service Type is required.");
            RuleFor(x => x.Budget).GreaterThan(0).WithMessage("Budget must be greater than 0.");
            RuleFor(x => x.Timeline).NotEmpty().WithMessage("Timeline is required.");
            RuleFor(x => x.ProjectDescription).NotEmpty().WithMessage("Project Description is required.");
        }
    }
}
