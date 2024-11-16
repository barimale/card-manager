using BuildingBlocks.Application.CQRS;
using FluentValidation;

namespace Ordering.Application.CQRS.Commands;

public class RegisterCardCommand : ICommand<RegisterCardResult>
{
    public RegisterCardCommand()
    {
        // intentionally left blank
    }

    public string AccountNumber { get; set; }
    public string PIN { get; set; }
    public string SerialNumber { get; set; }
    public string Id {  get; set; }
}


public class RegisterCardResult
{
    public RegisterCardResult()
    {
        // intentionally left blank
    }

    public RegisterCardResult(string id)
    {
        this.Id = id;
    }

    public string Id { get; set; }
}

//public class RegisterCardCommandValidator : AbstractValidator<RegisterCardCommand>
//{
//    public RegisterCardCommandValidator()
//    {
//        // WIP
//        //RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
//        //RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
//        //RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
//    }
//}