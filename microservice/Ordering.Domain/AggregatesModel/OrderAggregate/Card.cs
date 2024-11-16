using BuildingBlocks.Domain.SeedWork;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using Ordering.Domain.Events.OrderEvents;
using Ordering.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.AggregatesModel.OrderAggregate;

public class Card
    : Entity, IAggregateRoot
{
    public DateTime RegisteringTime { get; set; }
    public string AccountNumber { get; set; }
    public string PIN { get; set; }
    public string SerialNumber { get; set; }
    public string Id { get; set; }
}
