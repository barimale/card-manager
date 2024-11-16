using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;

namespace Ordering.UnitTests;

public class AddressDemoData
{
    public Address Build()
    {
        return new Address("street", "city", "state", "country", "zipcode");
    }
}

public class OrderDemoData
{
    private readonly Card order;

    public OrderDemoData(Address address)
    {
        order = new Card(
            "userId",
            "fakeName",
            address,
            cardTypeId: 5,
            cardNumber: "12",
            cardSecurityNumber: "123",
            cardHolderName: "name",
            cardExpiration: DateTime.UtcNow);
    }

    public OrderDemoData AddOne(
        int productId,
        string productName,
        decimal unitPrice,
        decimal discount,
        string pictureUrl,
        int units = 1)
    {
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
        return this;
    }

    public Card Build()
    {
        return order;
    }
}
