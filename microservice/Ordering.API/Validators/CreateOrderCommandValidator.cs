using FluentValidation;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Validators
{
    public class RegisterCardRequestValidator : AbstractValidator<RegisterCardRequest>
    {
        public RegisterCardRequestValidator()
        {
            RuleFor(exp => exp.SerialNumber)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);
        }
    }
}
