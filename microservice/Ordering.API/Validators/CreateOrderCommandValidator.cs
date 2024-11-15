using FluentValidation;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<RegisterCardRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(exp => exp.SerialNumber)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);
        }
    }
}
