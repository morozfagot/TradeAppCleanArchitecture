using Microsoft.EntityFrameworkCore;
using TradeApp.Domain.Entities;
using TradeApp.Infrastructure.Config;

namespace TradeApp.Infrastructure
{
    public sealed class TradingDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<PortfolioStock> PortfoliosStocks { get; set; }

        public TradingDbContext(DbContextOptions<TradingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioStockConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}