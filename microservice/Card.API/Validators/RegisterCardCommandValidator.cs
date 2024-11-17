using FluentValidation;
using Ordering.Application.CQRS.Commands;

namespace Card.API.Validators
{
    public class RegisterCardCommandValidator : AbstractValidator<RegisterCardRequest>
    {
        public RegisterCardCommandValidator()
        {
            RuleFor(exp => exp.SerialNumber)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);

            RuleFor(exp => exp.AccountNumber)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);

            RuleFor(exp => exp.PIN)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
        }
    }
}
