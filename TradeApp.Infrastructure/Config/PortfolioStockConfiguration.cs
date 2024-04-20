using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeApp.Domain.Entities;

namespace TradeApp.Infrastructure.Config
{
    public class PortfolioStockConfiguration : IEntityTypeConfiguration<PortfolioStock>
    {
        public void Configure(EntityTypeBuilder<PortfolioStock> builder)
        {
            builder.HasKey(ps => ps.Id);
            builder.HasOne(ps => ps.Portfolio).WithMany(p => p.PortfolioStocks).HasForeignKey(ps => ps.PortfolioId);
            builder.HasOne(ps => ps.Stock).WithMany(s => s.PortfoliosStock).HasForeignKey(ps => ps.StockId);
        }
    }
}