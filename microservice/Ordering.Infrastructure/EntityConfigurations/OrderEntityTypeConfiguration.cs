using Ordering.Domain.AggregatesModel.BuyerAggregate;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Infrastructure.EntityConfigurations;

class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> orderConfiguration)
    {
        orderConfiguration.ToTable("cards");

        orderConfiguration.Property(o => o.Id);
    }
}
