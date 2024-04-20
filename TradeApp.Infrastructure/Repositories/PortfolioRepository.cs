using TradeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Infrastructure.Repositories
{
    internal sealed class PortfolioRepository : RepositoryBase<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(TradingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Portfolio>> GetAllPortfoliosAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .Include(p => p.PortfolioStocks)
                .ThenInclude(ps => ps.Stock)
                .OrderBy(p => p.Id)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int id, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(id))
                .Include(p => p.PortfolioStocks)
                .ThenInclude(ps => ps.Stock)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Portfolio> GetPortfolioByConditionAsync(Expression<Func<Portfolio, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(expression))
                .Include(p => p.PortfolioStocks)
                .ThenInclude(ps => ps.Stock)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreatePortfolio(Portfolio input)
        {
            Create(input);
        }

        public void UpdatePortfolio(Portfolio input)
        {
            Update(input);
        }

        public void DeletePortfolio(Portfolio input)
        {
            Delete(input);
        }
    }
}