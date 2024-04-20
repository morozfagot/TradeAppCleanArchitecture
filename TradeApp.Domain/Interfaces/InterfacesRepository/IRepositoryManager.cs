namespace TradeApp.Domain.Interfaces.InterfacesRepository
{
    public interface IRepositoryManager
    {
        IClientRepository ClientRepository { get; }
        IPortfolioRepository PortfolioRepository { get; }
        IStockRepository StockRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}