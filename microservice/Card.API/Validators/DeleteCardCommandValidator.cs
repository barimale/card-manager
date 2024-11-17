using FluentValidation;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Validators
{
    public class DeleteCardCommandValidator : AbstractValidator<RegisterCardRequest>
    {
        public DeleteCardCommandValidator()
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
