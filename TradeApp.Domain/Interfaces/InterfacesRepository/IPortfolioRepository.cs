using System.Linq.Expressions;
using TradeApp.Domain.Entities;

namespace TradeApp.Domain.Interfaces.InterfacesRepository
{
    public interface IPortfolioRepository : IRepositoryBase<Portfolio>
    {
        Task<IEnumerable<Portfolio>> GetAllPortfoliosAsync(CancellationToken cancellationToken = default);
        Task<Portfolio> GetPortfolioByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Portfolio> GetPortfolioByConditionAsync(Expression<Func<Portfolio, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreatePortfolio(Portfolio portfolio);
        void UpdatePortfolio(Portfolio portfolio);
        void DeletePortfolio(Portfolio portfolio);
    }
}