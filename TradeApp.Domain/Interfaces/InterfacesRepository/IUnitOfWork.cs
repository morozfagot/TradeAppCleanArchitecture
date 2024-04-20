namespace TradeApp.Domain.Interfaces.InterfacesRepository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
