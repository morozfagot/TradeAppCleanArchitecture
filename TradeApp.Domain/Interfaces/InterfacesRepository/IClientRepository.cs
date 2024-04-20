using System.Linq.Expressions;
using TradeApp.Domain.Entities;

namespace TradeApp.Domain.Interfaces.InterfacesRepository
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken = default);
        Task<Client> GetClientByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Client> GetClientWithPortfolioByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Client> GetClientByConditionAsync(Expression<Func<Client, bool>> expression,
            CancellationToken cancellationToken = default);
        Task<Client> GetClientWithPortfolioByConditionAsync(Expression<Func<Client, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}