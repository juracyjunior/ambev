using Ambev.DeveloperEvaluation.AppService.Command;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.AppService.Validator
{
    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator() 
        {
            RuleFor(i => i).NotNull().WithMessage("Item cannot be null.");
            
            RuleFor(i => i.IdProduct).NotEmpty().WithMessage("Product ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Product ID cannot be empty.");

            RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20).WithMessage("Quantity must be less or equal to 20.");
            
            RuleFor(i => i.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        }
    }
}
