using TradeApp.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TradeApp.Infrastructure
{
    public static class TradeInitializer
    {
        public async static Task<WebApplication> SeedAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<TradingDbContext>();

                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    var lukoil = new Stock
                    {
                        Id = 1,
                        Name = "Lukoil",
                        Price = 6000
                    };

                    var yandex = new Stock
                    {
                        Id = 2,
                        Name = "Yandex",
                        Price = 3000
                    };

                    var evgeny = new Client
                    {
                        Id = 1,
                        FirstName = "Евгений",
                        LastName = "Морозов",
                        Password = "1234",
                    };

                    var vladimir = new Client
                    {
                        Id = 2,
                        FirstName = "Владимир",
                        LastName = "Сапронов",
                        Password = "1234",
                    };

                    var portfolio1 = new Portfolio
                    {
                        Id = 1,
                        Cash = 15000,
                        ClientId = evgeny.Id
                    };

                    var portfolio2 = new Portfolio
                    {
                        Id = 2,
                        Cash = 20000,
                        ClientId = vladimir.Id
                    };

                    var stock1 = new PortfolioStock
                    {
                        Id = 1,
                        Count = 5,
                        PortfolioId = portfolio1.Id,
                        StockId = lukoil.Id,
                        TotalPrice = 30000
                    };

                    var stock2 = new PortfolioStock
                    {
                        Id = 2,
                        Count = 8,
                        PortfolioId = portfolio2.Id,
                        StockId = lukoil.Id,
                        TotalPrice = 72000
                    };

                    var stock3 = new PortfolioStock
                    {
                        Id = 3,
                        Count = 12,
                        PortfolioId = portfolio2.Id,
                        StockId = yandex.Id,
                        TotalPrice = 24000
                    };

                    await context.Portfolios.AddRangeAsync(portfolio1, portfolio2);
                    await context.Clients.AddRangeAsync(evgeny, vladimir);
                    await context.Stocks.AddRangeAsync(lukoil, yandex);
                    await context.PortfoliosStocks.AddRangeAsync(stock1, stock2, stock3);

                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                }
                return app;
            }
        }
    }
}