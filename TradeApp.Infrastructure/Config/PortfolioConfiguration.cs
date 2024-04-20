using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeApp.Domain.Entities;

namespace TradeApp.Infrastructure.Config
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Client).WithOne(c => c.Portfolio).HasForeignKey<Portfolio>(p => p.ClientId);
            builder.HasMany(p => p.PortfolioStocks).WithOne(ps => ps.Portfolio).HasForeignKey(ps => ps.PortfolioId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}