using BuildingBlocks.Application.CQRS;

namespace Ordering.Application.CQRS.Commands
{
    public class RegisterCardCommand : ICommand<CreateOrderResult>
    {
        public RegisterCardCommand()
        {
            //intentionally left blank
        }

        public string AccountNumber { get; set; }
        public string PIN { get; set; }
        public string SerialNumber { get; set; }
    }
}
