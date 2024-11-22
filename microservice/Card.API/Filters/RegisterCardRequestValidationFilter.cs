using Card.Application.CQRS.Commands;

namespace Card.API.Filters
{
    public class RegisterCardRequestValidationFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly Validators.RegisterCardCommandValidator _createOrderRequestValidator;

        public RegisterCardRequestValidationFilter(
            ILoggerFactory loggerFactory,
            Validators.RegisterCardCommandValidator createOrderRequestValidator)
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