using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Domain.Events.OrderEvents;

public class OrderCancelledDomainEvent : INotification
{
    public Card Order { get; }

    public OrderCancelledDomainEvent(Card order)
    {
        Order = order;
    }
}

