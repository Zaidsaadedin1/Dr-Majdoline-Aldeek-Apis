using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using FluentValidation;

namespace Dr_Majdoline_Aldee.Infrastructure.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company Name is required.");
            RuleFor(x => x.ProjectType).NotEmpty().WithMessage("Project Type is required.");
            RuleFor(x => x.ServiceType).NotEmpty().WithMessage("Service Type is required.");
            RuleFor(x => x.Budget).GreaterThan(0).WithMessage("Budget must be greater than 0.");
            RuleFor(x => x.Timeline).NotEmpty().WithMessage("Timeline is required.");
            RuleFor(x => x.ProjectDescription).NotEmpty().WithMessage("Project Description is required.");
            RuleFor(x => x.TermsAccepted).Equal(true).WithMessage("You must accept the terms.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
        }
    }
}
