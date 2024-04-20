using TradeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Infrastructure.Repositories
{
    internal sealed class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(TradingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .Include(s => s.PortfoliosStock)
                .ThenInclude(ps => ps.Portfolio)
                .OrderBy(p => p.Id)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Stock> GetStockByIdAsync(int id, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(id))
                .Include(s => s.PortfoliosStock)
                .ThenInclude(ps => ps.Portfolio)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Stock> GetStockByConditionAsync(Expression<Func<Stock, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(s => s.Id.Equals(expression))
                .Include(p => p.PortfoliosStock)
                .ThenInclude(ps => ps.Portfolio)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateStock(Stock input)
        {
            Create(input);
        }

        public void UpdateStock(Stock input)
        {
            Update(input);
        }

        public void DeleteStock(Stock input)
        {
            Delete(input);
        }
    }
}