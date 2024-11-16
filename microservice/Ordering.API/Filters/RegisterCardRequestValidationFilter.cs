﻿using Ordering.API.Model.order;
using Ordering.API.Validators;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Filters
{
    public class RegisterCardRequestValidationFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly RegisterCardRequestValidator _createOrderRequestValidator;

        public RegisterCardRequestValidationFilter(
            ILoggerFactory loggerFactory,
            RegisterCardRequestValidator createOrderRequestValidator)
        {
            _logger = loggerFactory.CreateLogger<RegisterCardRequestValidationFilter>();
            _createOrderRequestValidator = createOrderRequestValidator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext,
            EndpointFilterDelegate next)
        {
            var command = efiContext.GetArgument<RegisterCardRequest>(0);
            var validationResult = await _createOrderRequestValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(validationResult.ToString());

                return Results.Problem(
                    validationResult
                    .Errors
                    .Select(p => p.ErrorMessage.ToString())
                    .First());

            }

            return await next(efiContext);
        }
    }
}