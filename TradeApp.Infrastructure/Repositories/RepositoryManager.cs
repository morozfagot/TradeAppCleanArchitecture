using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Infrastructure.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IClientRepository> _lazyClientRepository;
        private readonly Lazy<IPortfolioRepository> _lazyPortfolioRepository;
        private readonly Lazy<IStockRepository> _lazyStockRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(TradingDbContext dbContext)
        {
            _lazyClientRepository = new Lazy<IClientRepository>(() => new ClientRepository(dbContext));
            _lazyPortfolioRepository = new Lazy<IPortfolioRepository>(() => new PortfolioRepository(dbContext));
            _lazyStockRepository = new Lazy<IStockRepository>(() => new StockRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IClientRepository ClientRepository { get {  return _lazyClientRepository.Value; } }
        public IPortfolioRepository PortfolioRepository { get { return _lazyPortfolioRepository.Value; } }
        public IStockRepository StockRepository { get { return _lazyStockRepository.Value; } }
        public IUnitOfWork UnitOfWork { get { return _lazyUnitOfWork.Value; } }
    }
}
