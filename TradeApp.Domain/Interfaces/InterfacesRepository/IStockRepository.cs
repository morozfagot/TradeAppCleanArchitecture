using System.Linq.Expressions;
using TradeApp.Domain.Entities;

namespace TradeApp.Domain.Interfaces.InterfacesRepository
{
    public interface IStockRepository : IRepositoryBase<Stock>
    {
        Task<IEnumerable<Stock>> GetAllStocksAsync(CancellationToken cancellationToken = default);
        Task<Stock> GetStockByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Stock> GetStockByConditionAsync(Expression<Func<Stock, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(Stock stock);
    }
}