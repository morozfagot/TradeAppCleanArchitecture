using TradeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Infrastructure.Repositories
{
    internal sealed class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(TradingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .ToListAsync(cancellationToken);
            
            return result;
        }

        public async Task<Client> GetClientByIdAsync(int id, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(id))
                .SingleAsync(cancellationToken);

            return result;
        }
        
        public async Task<Client> GetClientWithPortfolioByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(id))
                .Include(c => c.Portfolio)
                .ThenInclude(p => p.PortfolioStocks)
                .ThenInclude(ps => ps.Stock)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Client> GetClientByConditionAsync(Expression<Func<Client, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(expression))
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Client> GetClientWithPortfolioByConditionAsync(Expression<Func<Client, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(expression))
                .Include(c => c.Portfolio)
                .ThenInclude(p => p.PortfolioStocks)
                .ThenInclude(ps => ps.Stock)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateClient(Client input)
        {
            Create(input);
        }
        
        public void UpdateClient(Client input)
        {
            Update(input);
        }

        public void DeleteClient(Client input)
        {
            Delete(input);
        }
    }
}