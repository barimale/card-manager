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
