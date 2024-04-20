using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Infrastructure.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TradingDbContext _dbContext;
        public UnitOfWork(TradingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                int result = await _dbContext.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
