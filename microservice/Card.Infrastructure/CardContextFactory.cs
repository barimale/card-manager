using Microsoft.EntityFrameworkCore.Design;

namespace Card.Infrastructure
{
    /* For migrations generation only */

    public class CardContextFactory : IDesignTimeDbContextFactory<CardContext>
    {
        public CardContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CardContext>();
            optionsBuilder.UseSqlServer("Data Source=MATEUSZ;Initial Catalog=DataBaseName;TrustServerCertificate=True;Integrated Security=True;");

            return new CardContext(optionsBuilder.Options);
        }
    }
}