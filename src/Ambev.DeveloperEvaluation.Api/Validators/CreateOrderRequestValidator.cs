using Ambev.DeveloperEvaluation.Api.Controllers.Request;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator() 
        {
            RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale date is required.");
            
            RuleFor(x => x.IdCustomer).NotEmpty().WithMessage("Customer ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Customer ID cannot be empty.");

            RuleFor(x => x.IdBranch).NotEmpty().WithMessage("Branch ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Branch ID cannot be empty.");

            RuleFor(x => x.Items).NotEmpty().WithMessage("Items are required.")
                .Must(items => items.Count > 0).WithMessage("At least one item is required.")
                .ForEach(item => item.SetValidator(new CreateOrderItemRequestValidator()));
        }
    }
}
