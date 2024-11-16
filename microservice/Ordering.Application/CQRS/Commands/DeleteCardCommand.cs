using BuildingBlocks.Application.CQRS;
using FluentValidation;

namespace Ordering.Application.CQRS.Commands;

public class DeleteCardCommand : ICommand<DeleteCardResult>
{
    public DeleteCardCommand()
    {
        // intentionally left blank
    }
    public string Id {  get; set; }
}


public class DeleteCardResult
{
    public DeleteCardResult()
    {
        // intentionally left blank
    }

    public DeleteCardResult(string id)
    {
        this.Id = id;
    }

    public string Id { get; set; }
}

public class DeleteCardCommandValidator : AbstractValidator<DeleteCardCommand>
{
    public DeleteCardCommandValidator()
    {
        // WIP
        //RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        //RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        //RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}