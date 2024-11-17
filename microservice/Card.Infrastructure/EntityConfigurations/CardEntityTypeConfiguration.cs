namespace Card.Infrastructure.EntityConfigurations;

class CardEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.CardAggregate.Card>
{
    public void Configure(EntityTypeBuilder<Domain.AggregatesModel.CardAggregate.Card> orderConfiguration)
    {
        orderConfiguration.ToTable("cards");

        orderConfiguration.Property(o => o.Id);
        orderConfiguration
            .HasIndex(card => new
            {
                card.SerialNumber
            })
            .IsUnique();
        orderConfiguration
        .HasIndex(card => new
        {
            card.AccountNumber
        })
        .IsUnique();
        orderConfiguration
        .HasIndex(card => new
        {
            card.Id
        })
        .IsUnique();
    }
}
