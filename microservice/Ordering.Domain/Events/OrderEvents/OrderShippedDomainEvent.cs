using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Domain.Events.OrderEvents;

public class OrderShippedDomainEvent : INotification
{
    public Card Order { get; }

    public OrderShippedDomainEvent(Card order)
    {
        Order = order;
    }
}
