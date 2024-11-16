using Ordering.API.Model.order;
using Ordering.API.Validators;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.Filters
{
    public class DeleteCardRequestValidationFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly Validators.RegisterCardCommandValidator _createOrderRequestValidator;

        public DeleteCardRequestValidationFilter(
            ILoggerFactory loggerFactory,
            Validators.RegisterCardCommandValidator createOrderRequestValidator)
        {
            _logger = loggerFactory.CreateLogger<DeleteCardRequestValidationFilter>();
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