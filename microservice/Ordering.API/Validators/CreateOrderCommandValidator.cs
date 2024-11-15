﻿using FluentValidation;
using Ordering.API.Model.order;

namespace Ordering.API.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(exp => exp.Description)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);
        }
    }
}
